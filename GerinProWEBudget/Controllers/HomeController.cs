using GerinProWEBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerinProWEBudget.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GPWEntities db = new GPWEntities();
            var users = from us in db.AspNetUsers  join nur in db.AspNetUserRoles on us.Id equals nur.UserId where nur.RoleId=="3" select us;
            var roles = from ro in db.SalaryByRoles select ro;
            var managers = new List<AspNetUser>();
            var salary = new List<SalaryByRole>();
            foreach (var role in roles) {
                salary.Add(role);
            }
            foreach (var user in users) {
                managers.Add(user);
            }
            ViewBag.ManagerHlist = managers;
            ViewBag.AllSalaries = salary;
            foreach (var rem in salary)
            {
                var roleid = rem.rolid;
                switch (roleid) {
                    case "1":
                        break;
                    case "2":
                        ViewBag.AssociateS = rem.sueldo;
                        break;
                    case "3":
                        ViewBag.ManagerS = rem.sueldo;
                        break;
                    case "4":
                        ViewBag.AuxAS = rem.sueldo;
                        break;
                    case "5":
                        ViewBag.AuxBS = rem.sueldo;
                        break;
                    case "6":
                        ViewBag.AuxCS = rem.sueldo;
                        break;
                    case "7":
                        ViewBag.TraineeS = rem.sueldo;
                        break;
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}