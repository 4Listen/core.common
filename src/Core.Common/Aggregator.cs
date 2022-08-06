namespace Core.Common
{
    public class Aggregator
    {
		static readonly AsyncLocal<AggregationIdScope> _asyncLocal = new AsyncLocal<AggregationIdScope>();

		public static string CurrentAggregationId => _asyncLocal.Value?.AggregationId;

		public static IDisposable CreateAggregationContext(string aggregationId)
		{
			_asyncLocal.Value = new AggregationIdScope()
			{
				AggregationId = aggregationId
			};

			return _asyncLocal.Value;
		}
		private class AggregationIdScope : IDisposable
		{
			public string AggregationId { get; set; }

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (disposing)
				{
                    _asyncLocal.Value = null;
				}
			}
		}
	}
}
