using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Data {
    public class RepositoryContext : DbContext{
        public RepositoryContext(DbContextOptions<RepositoryContext> options) 
            : base(options) {
        }

        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Operation>().ToTable("Operations");
            modelBuilder.Entity<OperationType>().ToTable("OperationTypes");

            modelBuilder.Entity<OperationType>()
                .HasIndex(operationType => operationType.Name)
                .IsUnique(true);
        }
    }
}
