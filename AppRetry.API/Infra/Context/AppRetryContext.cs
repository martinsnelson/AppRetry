using AppRetry.API.DTO;
using AppRetry.API.Entities;
using AppRetry.API.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AppRetry.API.Infra.Context
{
    public class AppRetryContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public AppRetryContext(DbContextOptions<AppRetryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
        
    }
}