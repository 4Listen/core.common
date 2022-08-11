namespace Core.Common.Types
{
    public interface ISortedFieldsQuery : IQuery
    {
        public List<ISortedQuery> FieldsToOrderBy { get; set; }
    }
}
