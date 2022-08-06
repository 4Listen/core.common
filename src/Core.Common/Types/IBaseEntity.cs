namespace Core.Common.Types
{
	public interface IBaseEntity : IBaseKeyEntity<string>
	{
	}

	public interface IBaseKeyEntity<out TKey>
	{
		TKey Id { get; }
	}
}