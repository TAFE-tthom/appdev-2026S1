namespace Demo2;

using Microsoft.EntityFrameworkCore;
using Demo2.Models;

public class ApplicationDbContext : DbContext
{
	private readonly string applicationConnectionString;

	public DbSet<User> User { get; set; }
	public DbSet<UserPost> UserPost { get; set; }
	

	public ApplicationDbContext(string connectionString)
	{
		applicationConnectionString = connectionString;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite(applicationConnectionString);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<UserPost>()
			.HasOne<User>(p => p.User)
			.WithMany(u => u.Posts)
			.HasForeignKey(p => p.UserID)
			.IsRequired();
			
		modelBuilder.Entity<User>()
			.HasMany<UserPost>(u => u.Posts)
			.WithOne(p => p.User)
			.HasForeignKey(p => p.UserID)
			.IsRequired();
	}
}
