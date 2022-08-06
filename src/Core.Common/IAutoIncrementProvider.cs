namespace Core.Common
{
    public interface IAutoIncrementProvider
    {
        long GetNextId<TType>();

        long GetNextId(string keyName);
    }
}
