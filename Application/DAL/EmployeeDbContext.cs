using Application.Models;
using System.Data.Entity;

namespace Application.DAL
{

    public class EmployeeDbContext : DbContext
    {

        public EmployeeDbContext() : base("EmployeeDbContext")
        {
        }

        public DbSet<Employee> Employees
        {
            get;
            set;
        }

    }

}