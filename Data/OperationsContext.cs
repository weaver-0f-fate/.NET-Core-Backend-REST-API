using Microsoft.EntityFrameworkCore;
using Models;

namespace Data {
    public class OperationsContext : DbContext{
        public OperationsContext(DbContextOptions<OperationsContext> options) 
            : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
    }
}
