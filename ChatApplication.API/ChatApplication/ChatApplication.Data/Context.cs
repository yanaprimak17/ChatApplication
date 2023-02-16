using System.Reflection;
using ChatApplication.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        
        public DbSet<UserEntity> Users { get; set; }
        
        public DbSet<MessageEntity> Messages { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}