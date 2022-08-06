using Newtonsoft.Json;

namespace Core.Common.Types
{
	public class QueryablePagedResult<T> : PagedResultBase
	{
		public Task<IQueryable<T>> Items { get; }

		public bool IsEmpty => Items == null || !Items.Result.Any();
		public bool IsNotEmpty => !IsEmpty;

		protected QueryablePagedResult()
		{
		}

		[JsonConstructor]
		protected QueryablePagedResult(Task<IQueryable<T>> items, int currentPage, int resultsPerPage, int totalPages, long totalResults)
			: base(currentPage, resultsPerPage, totalPages, totalResults)
		{
			Items = items;
		}

		public static QueryablePagedResult<T> Create(Task<IQueryable<T>> items, int currentPage, int resultsPerPage, int totalPages, long totalResults)
			=> new QueryablePagedResult<T>(items, currentPage, resultsPerPage, totalPages, totalResults);

		public static QueryablePagedResult<T> From(PagedResultBase result, Task<IQueryable<T>> items)
			=> new QueryablePagedResult<T>(items, result.CurrentPage, result.ResultsPerPage, result.TotalPages, result.TotalResults);

		public static QueryablePagedResult<T> Empty => new QueryablePagedResult<T>();
	}
}