using Microsoft.EntityFrameworkCore;
using WpfEmployeesOrders.Models;

namespace WpfEmployeesOrders.Data
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Division> Divisions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=shop.db");
        }
    }
}
