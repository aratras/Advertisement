using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvertMVC.Controllers
{
    public class PersonController : Controller
    {
        DataBase DB = new DataBase();
        List<ResponsiblePerson> List = new List<ResponsiblePerson>();
        // GET: Person
        public ActionResult Index()
        {
            List = DB.GetAllPerson();
            return View(List);
        }
        public ActionResult Details(int ID)
        {
            return View(DB.GetOnePerson(ID));
        }
        public ActionResult Edit(int id)
        {
            return View(DB.GetOnePerson(id));
        }
        [HttpPost]
        public ActionResult Edit(ResponsiblePerson person)
        {
            if (ModelState.IsValid)
            {
                DB.UpdatePerson(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ResponsiblePerson person)
        {
            if (ModelState.IsValid)
            {
                DB.CreatePerson(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }
        public ActionResult Delete(int id)
        {
            return View(DB.GetOnePerson(id));
        }
        [HttpPost]
        public ActionResult Delete(ResponsiblePerson person)
        {
            DB.DeletePerson(person);
            return RedirectToAction("Index");
        }
    }
}