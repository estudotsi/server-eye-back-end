using Microsoft.EntityFrameworkCore;
using server_eye_back_end.Models;
using System.Reflection.Metadata;

namespace server_eye_back_end.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Os> Oss { get; set; }
		public DbSet<Server> Servers { get; set; }
		public DbSet<App> Apps { get; set; }
		public DbSet<DB> DBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Os>()
            .HasMany(o => o.Servers)
            .WithOne(s => s.Os)
            .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
