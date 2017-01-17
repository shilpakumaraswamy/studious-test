using System.Data;
using System.Linq;
using System.Web.Mvc;
using test.Models;


namespace test.Controllers
{
    public class HomeController : Controller
    {

        private ExcerciseRepository excercise = new ExcerciseRepository();

        public ActionResult Index()
        {
            var excercises = excercise.ExcerciseRep.Get();
            return View(excercises.ToList());
        }
        public ActionResult Create()
        {
            PopulateDepartmentsDropDownList();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add( Excercise exc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    excercise.ExcerciseRep.Insert(exc);
                    excercise.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDepartmentsDropDownList(exc.Id);
            return View(exc);
        }

        private void PopulateDepartmentsDropDownList(object selectedExcercise = null)
        {
            var excQuery = excercise.ExcerciseRep.Get(
                orderBy: q => q.OrderByDescending(d => d.ExcerciseDate));
            ViewBag.DepartmentID = new SelectList(excQuery, "Id", "ExcerciseName", selectedExcercise);
        }
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}