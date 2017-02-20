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
                new Employee { Name = "Deividas", Surname = "Popelskis", Salary = 1000m },
                new Employee { Name = "Augustinas", Surname = "Radauskas", Salary = 900m },
                new Employee { Name = "Karolis", Surname = "Siaurusaitis", Salary = 800m },
                new Employee { Name = "Mantas", Surname = "Pabedinskas", Salary = 700m },
                new Employee { Name = "Giedrius", Surname = "Ramanauskas", Salary = 600m },
                new Employee { Name = "Jonas", Surname = "Tiurkinas", Salary = 500m },
                new Employee { Name = "Mikas", Surname = "Tulojus", Salary = 400m },
                new Employee { Name = "Ernestas", Surname = "Kasparauskas", Salary = 300m },
                new Employee { Name = "Andrius", Surname = "Dremeikis", Salary = 200m },
                new Employee { Name = "Linas", Surname = "Pradauskas", Salary = 100m },
            };

            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();
        }

    }

}