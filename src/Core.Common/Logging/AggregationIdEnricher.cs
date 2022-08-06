using Serilog.Core;
using Serilog.Events;

namespace Core.Common.Logging
{
	public class AggregationIdEnricher : ILogEventEnricher
	{
		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			if (!string.IsNullOrWhiteSpace(Aggregator.CurrentAggregationId))
			{
				logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("AggregationId", Aggregator.CurrentAggregationId));
			}
		}
	}
}
