using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AdvertMVC.Controllers
{
    public class PersonController : Controller
    {
        List<ResponsiblePerson> list = new List<ResponsiblePerson>();
        DataBase DB = new DataBase();
        // GET: Person
        public ActionResult Index()
        {
            list = DB.LoadPersonFromDB();
            return View(list);
        }
        public ActionResult Details(int id)
        {
            list = DB.LoadPersonFromDB();
            ResponsiblePerson person = list[id - 1];
            return View(person);
        }
    }
}