using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostgreSqlExample.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PostgreSqlExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppContext _context;
        public HomeController(AppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Students.ToList();
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var model = _context.Students.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {        
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var model = _context.Students.Find(id);
            _context.Students.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
