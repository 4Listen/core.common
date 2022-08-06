using Core.Common.Types;
using Xunit;

namespace Tcp.Core.Common.Tests
{
    public class CovarianciaTests
    {
        class BaseAuditedEntity : IBaseAuditedEntity
        {
            public AuditData Insert { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public AuditData Alter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public AuditData LastAlter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public string Id => throw new NotImplementedException();
        }

        [Fact]
        public async Task BaseAuditedEntityIsIBaseKeyEntity()
        {
            BaseAuditedEntity baseAuditedEntity = new BaseAuditedEntity();
            Assert.True(baseAuditedEntity is IBaseAuditedEntity);
            Assert.True(baseAuditedEntity is IBaseAuditedEntity<string>);
            Assert.True(baseAuditedEntity is IBaseKeyEntity<string>);
        }
    }
}
