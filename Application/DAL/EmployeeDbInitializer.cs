using Application.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Application.DAL
{

    public class EmployeeDbInitializer : DropCreateDatabaseAlways<EmployeeDbContext>
    {

        protected override void Seed(EmployeeDbContext context)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Name = "Deividas", Surname = "Popelskis", Salary = 1000.0m },
                new Employee { Name = "Augustinas", Surname = "Radauskas", Salary = 500.5m },
                new Employee { Name = "Karolis", Surname = "Siaurusaitis", Salary = 700.8m },
            };

            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();
        }

    }

}