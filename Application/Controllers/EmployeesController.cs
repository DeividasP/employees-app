using Application.DAL;
using System.Linq;
using System.Web.Mvc;

namespace Application.Controllers
{

    public class EmployeesController : Controller
    {

        private readonly EmployeeDbContext dbContext = new EmployeeDbContext();

        public ActionResult Index()
        {
            return View(dbContext.Employees.ToList());
        }

    }

}