namespace Core.Common.Types
{
	public interface IBaseAuditedEntity : IBaseAuditedEntity<string>
	{
	}

	public interface IBaseAuditedEntity<out TKey> : IBaseKeyEntity<TKey>
	{
		AuditData Insert { get; set; }

		AuditData Alter { get; set; }

		AuditData LastAlter { get; set; }
	}
}