namespace Core.Common.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
    using Core.Common.Logging;
    using Serilog.Core;
	using Serilog.Events;
    using Serilog.Parsing;
    using Xunit;

	public class AggregatorTests
	{
		[Fact]
		public async Task GeneratePassCorrectlyForTheLog()
		{
			var aggId = Guid.NewGuid().ToString();
			
			Assert.Null(Aggregator.CurrentAggregationId);

			using (var aggIdCtx = Aggregator.CreateAggregationContext(aggId))
			{
				Assert.Equal(aggId, Aggregator.CurrentAggregationId);

				await Task.Run(() =>
				{
					Assert.Equal(aggId, Aggregator.CurrentAggregationId);

					var enricher = new AggregationIdEnricher();
					var logEvent = new LogEvent(
						DateTimeOffset.Now, 
						LogEventLevel.Information,
						null,
						new MessageTemplate(new List<MessageTemplateToken>()),
						new List<LogEventProperty>());
					var logFactory = new PropFactory();
					enricher.Enrich(logEvent, logFactory);

					Assert.Contains(logEvent.Properties, a => a.Key == "AggregationId");
					var prop = logEvent.Properties.First(a => a.Key == "AggregationId");

					Assert.IsType<ScalarValue>(prop.Value);
					Assert.Equal(aggId, (prop.Value as ScalarValue).Value);
				});

				Assert.Equal(aggId, Aggregator.CurrentAggregationId);
			}

			Assert.Null(Aggregator.CurrentAggregationId);
		}

		private class PropFactory : ILogEventPropertyFactory
		{
			public LogEventProperty CreateProperty(string name, object value, bool destructureObjects = false)
			{
				return new LogEventProperty(name, new ScalarValue(value));
			}
		}
	}
}
