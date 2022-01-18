using Microsoft.EntityFrameworkCore;
using Core.Models.Models;

namespace Data {
    public class RepositoryContext : DbContext{
        public RepositoryContext(DbContextOptions<RepositoryContext> options) 
            : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
    }
}
