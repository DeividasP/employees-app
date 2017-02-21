﻿using Application.DAL;
using Application.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace Application.Controllers
{

    public class EmployeesController : Controller
    {

        private readonly EmployeeDbContext dbContext = new EmployeeDbContext();

        public ActionResult Index(FormCollection form, string savedFilter, int? page)
        {
            var employees = from e in dbContext.Employees select e;

            employees = employees.OrderBy(e => e.Name);

            string filter = "";
            string filterType = "";

            if (form.Count > 0)
            {
                filter = form["filter"];
                filterType = form["filter-type"];

                ViewBag.SavedFilter = filter + ":" + filterType;
            }
            else if (!string.IsNullOrEmpty(savedFilter))
            {
                string[] filterArgs = savedFilter.Split(':');

                filter = filterArgs[0];
                filterType = filterArgs[1];

                ViewBag.SavedFilter = savedFilter;
            }

            switch (filterType)
            {
                case "name":
                    employees = employees.Where(e => e.Name.Contains(filter));
                    break;
                case "surname":
                    employees = employees.Where(e => e.Surname.Contains(filter));
                    break;
            }

            return View(employees.ToPagedList(page ?? 1, 5));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add([Bind(Include = "ID, Name, Surname, Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }

}