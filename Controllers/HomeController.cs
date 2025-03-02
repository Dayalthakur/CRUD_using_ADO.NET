using System.Diagnostics;
using CRUD_ADO.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ADO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeDataAccessLayer dal;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            dal = new EmployeeDataAccessLayer();
        }

        public IActionResult Index()
        {
            List<Employees> data = dal.GetEmployees();
            return View(data);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult AddUser(Employees emp)
        {
            try
            {
                dal.Add_User(emp);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Employees emp=dal.getEmployeebyID(id);
            return View(emp);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Edit(Employees emp)
        {
            try
            {
                dal.Update_User(emp);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var data = dal.getEmployeebyID(id);
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = dal.getEmployeebyID(id);
            return View(data);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Delete(Employees emp)
        {
            try
            {
                dal.Delete_User(emp.Id);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
