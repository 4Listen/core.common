namespace Core.Common.Types
{
	public interface ISortedQuery : IQuery
	{
		string OrderBy { get; }

		OrderingDirection SortOrder { get; }
	}
}