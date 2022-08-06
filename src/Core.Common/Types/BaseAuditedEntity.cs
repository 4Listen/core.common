using Core.Common.Types;

namespace Core.Common.Types
{
	public class BaseAuditedEntity : BaseEntity, IBaseAuditedEntity<string>
	{
		public AuditData Insert { get; set; }
		public AuditData Alter { get; set; }
		public AuditData LastAlter { get; set; }
	}
}