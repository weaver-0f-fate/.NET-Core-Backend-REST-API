using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
