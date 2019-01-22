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
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CannotSee = false;
            }
            else {
                ViewBag.CannotSee = true;
            }
            var associates = from assoc in db.AspNetUsers join nur in db.AspNetUserRoles on assoc.Id equals nur.UserId where nur.RoleId == "2" select assoc;
            var users = from us in db.AspNetUsers  join nur in db.AspNetUserRoles on us.Id equals nur.UserId where nur.RoleId=="3" select us;
            var auxAs = from aa in db.AspNetUsers join nur in db.AspNetUserRoles on aa.Id equals nur.UserId where nur.RoleId == "4" select aa;
            var auxBs = from ab in db.AspNetUsers join nur in db.AspNetUserRoles on ab.Id equals nur.UserId where nur.RoleId == "5" select ab;
            var auxCs = from ac in db.AspNetUsers join nur in db.AspNetUserRoles on ac.Id equals nur.UserId where nur.RoleId == "6" select ac;
            var trains = from tn in db.AspNetUsers join nur in db.AspNetUserRoles on tn.Id equals nur.UserId where nur.RoleId == "7" select tn;


            var roles = from ro in db.SalaryByRoles select ro;
            var listAssociates = new List<AspNetUser>();
            var managers = new List<AspNetUser>();
            var listAuxA = new List<AspNetUser>();
            var listAuxB = new List<AspNetUser>();
            var listAuxC = new List<AspNetUser>();
            var listTrainees = new List<AspNetUser>();

            var salary = new List<SalaryByRole>();
            foreach (var associate in associates) {
                listAssociates.Add(associate);
            }
            foreach (var role in roles) {
                salary.Add(role);
            }
            foreach (var user in users) {
                managers.Add(user);
            }
            foreach (var auxa in auxAs)
            {
                listAuxA.Add(auxa);
            }
            foreach (var auxb in auxBs)
            {
                listAuxB.Add(auxb);
            }
            foreach (var auxc in auxCs)
            {
                listAuxC.Add(auxc);
            }
            foreach (var train in trains)
            {
                listAssociates.Add(train);
            }
            ViewBag.AssocL = listAssociates;
            ViewBag.ManagerHlist = managers;
            ViewBag.AuxAL = listAuxA;
            ViewBag.AuxBL = listAuxB;
            ViewBag.AuxCL = listAuxC;
            ViewBag.TraineeL = listTrainees;
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