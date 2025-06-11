using ClientManagerAPIV001.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClientManagerAPIV001.DataAccess
{
    public class SQLDBContext(IConfiguration configuration) : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerNote> CustomerNotes { get; set; }
        public DbSet<CustomerFieldDefinition> CustomerFieldDefinitions { get; set; }
        public DbSet<CustomerFieldValue> CustomerFieldValues { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserCD)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .Property(u => u.RoleID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Role>()
                .HasKey(u => u.RoleID);

            modelBuilder.Entity<Role>()
                .HasIndex(u => u.RoleCD)
                .IsUnique();

            new CustomerConfig().Configure(modelBuilder.Entity<Customer>());
            new CustomerFieldDefinitionConfig().Configure(modelBuilder.Entity<CustomerFieldDefinition>());
            new CustomerNoteConfig().Configure(modelBuilder.Entity<CustomerNote>());
            new CustomerFieldValueConfig().Configure(modelBuilder.Entity<CustomerFieldValue>());

            base.OnModelCreating(modelBuilder); 
        }



    }
}
