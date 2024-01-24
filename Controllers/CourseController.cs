using BALLayer;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    public class CourseController : Controller
    {
        BALLayer.BAL bal = new BALLayer.BAL();
        public IActionResult Index()
        {
        
            var list = bal.GetAllCourses();
            //if(list.Count==0)
            //{
            //    ViewBag.msg = "no record";
            //    return View();
            //}


            return View(list);
        }

        
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
           bal.AddCourse(course);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetCourseById(int id)
        {
            Course course = new Course();
            course = bal.GetCourseById(id);
            return View(course);
        }

        [HttpGet]
        public IActionResult UpdateCourse(int id)
        {
            Course course = new Course();
           course =  bal.GetCourseById(id);
            return View(course);

        }

        [HttpPost]
        public IActionResult UpdateCourse(Course course)
        {
            bal.EditCourse(course);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            bal.DeleteCourse(id);
            return RedirectToAction("Index");
        }
    }
}
