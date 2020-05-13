using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DAL.Base
{
    abstract class BaseDomainMapping<T> : IEntityTypeConfiguration<T>
        where T : BaseModel, new()
    {
        public BaseDomainMapping()
        {
            Init();
        }
        public virtual void Init() { }

        public virtual void Configure(EntityTypeBuilder<T> builder) { }
    }
}
