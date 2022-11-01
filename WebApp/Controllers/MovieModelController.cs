using Microsoft.AspNetCore.Mvc;
using ASP.NET_Web.Data;
using ASP.NET_Web.Models;

namespace ASP.NET_Web.Controllers
{
    public class MovieModelController : Controller
    {
        private readonly ApplicationDBContext _db;

        public MovieModelController(ApplicationDBContext db)
        {
            _db = db;
        }

        //GET 
        public IActionResult Create()
        {
            return View();  
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieModel obj)
        {
            if (ModelState.IsValid && _db.MovieModels != null)
            {
                _db.MovieModels.Add(obj);
                _db.SaveChanges();
                TempData["Created"] = "Created successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET 
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var movie = _db.MovieModels.Find(id);
                
             if (movie == null)
                    return NotFound();
                 else return View(movie);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MovieModel obj)
        {
            if (ModelState.IsValid && _db.MovieModels != null)
            {
                _db.MovieModels.Update(obj);
                _db.SaveChanges();
                TempData["Edited"] = "Edited successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var movie = _db.MovieModels.Find(id);

            if (movie == null)
                return NotFound();
            else return View(movie);
        }   

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
                var obj = _db.MovieModels.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

                _db.MovieModels.Remove(obj);
            _db.SaveChanges();
            TempData["Deleted"] = "Deleted successfully";
            
            return RedirectToAction("Index");
        }
    }
}
