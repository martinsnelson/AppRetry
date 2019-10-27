using AppRetry.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppRetry.API.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Name).HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.Email).HasMaxLength(60).HasColumnType("varchar(60)");
        }
    }
}