using conectados.Models;
using Microsoft.EntityFrameworkCore;

namespace conectados.Data
{
    public class ConectadosDBContext : DbContext
    {
        public ConectadosDBContext(DbContextOptions<ConectadosDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(tb =>
            {
                tb.HasKey(col => col.UserID);
                tb.Property(col => col.UserID)
                    .UseMySqlIdentityColumn()
                    .ValueGeneratedOnAdd();
                tb.Property(col => col.FullName).HasMaxLength(50);
                tb.Property(col => col.Email).HasMaxLength(50);
                tb.Property(col => col.Hashed_Password).HasMaxLength(255);
                tb.ToTable("users");
            });
        }
    }
}
