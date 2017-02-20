using Application.DAL;
using System.Linq;
using System.Web.Mvc;

namespace Application.Controllers
{

    public class EmployeesController : Controller
    {

        private readonly EmployeeDbContext dbContext = new EmployeeDbContext();

        public ActionResult Index(FormCollection form)
        {
            var employees = from e in dbContext.Employees select e;

            if (form.Count > 0)
            {
                string filter = form["filter"];
                string filterType = form["filter-type"];

                switch (filterType)
                {
                    case "name":
                        employees = employees.Where(e => e.Name.Contains(filter));
                        break;
                    case "surname":
                        employees = employees.Where(e => e.Surname.Contains(filter));
                        break;
                }
            }

            return View(employees.ToList());
        }

    }

}