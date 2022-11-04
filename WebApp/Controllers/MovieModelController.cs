using Microsoft.AspNetCore.Mvc;
using ASP.NET_Web.Data;
using ASP.NET_Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using System.Linq;
using NPOI.SS.Formula.Functions;

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
        public async Task<IActionResult> Create(MovieModel obj)
        {
            if (ModelState.IsValid && _db.MovieModels != null)
            {
                try
                {
                    await _db.MovieModels.AddAsync(obj);
                    MovieDetailsModel detailsModel = new(obj.SalonId, obj.Id, obj.ReleaseDate);
                    await _db.MovieDetailsModels.AddAsync(detailsModel);
                    await _db.SaveChangesAsync();
                    TempData["Created"] = "Created successfully";

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

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

            return movie == null ? NotFound() : View(movie);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieModel obj)
        {
            if (ModelState.IsValid && _db.MovieModels != null)
            {
                try
                {
                    _db.MovieModels.Update(obj);
                    await _db.SaveChangesAsync();
                    TempData["Edited"] = "Edited successfully";

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

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

            return movie == null ? NotFound() : View(movie);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.MovieModels.Find(id);
            if (obj != null)
            {
                try
                {
                    _db.MovieModels.Remove(obj);
                    _db.SaveChanges();
                    TempData["Deleted"] = "Deleted successfully";

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return RedirectToAction("Index");
        }



        //GET
        [HttpGet]
        public IActionResult Filter_XtoY()
        {
            return View();
        }
        //POST
        [HttpPost]
        public IActionResult Filter_XtoY(DateTime releaseDate1, DateTime releaseDate2)
        {
            try
            {
                var result = _db.MovieModels
                             .Where(x => releaseDate1 < x.ReleaseDate && x.ReleaseDate < releaseDate2);
                return result != null ? View(result) : NotFound($"There are no movies between {releaseDate1} and {releaseDate2}");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }



        //GET
        [HttpGet]
        public IActionResult Filter_XSalonsandDate()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Filter_XSalonsandDate(int id)
        {
            List<MovieDetailsModel> allMovieDetails = _db.MovieDetailsModels.ToList();
            List<MovieDetailsModel> checkedMovieDetails = new(allMovieDetails.FindAll(idCheck));

            Dictionary<int, DateTime> result = new Dictionary<int, DateTime>();

            foreach (MovieDetailsModel m in checkedMovieDetails)
            {
                result.Add(m.SalonId, m.ReleaseDate);
            }

            return View(result);

            bool idCheck(MovieDetailsModel obj)
            {
                return obj.MovieId == id /*|| obj.SalonId == id*/;
            }
        }





        //GET
        [HttpGet]
        public IActionResult Filter_XSalon()
        {
            return View();
        }
        //POST
        [HttpPost]
        public async Task<IActionResult> Filter_XSalon(string name)
        {
            try
            {
                var salon = await _db.SalonModels
                    .FindAsync(name);
                if (salon.Movies != null)
                {
                    List<MovieModel> movies = (List<MovieModel>)salon.Movies;
                    if (salon != null && movies != null)
                    {
                        return View(movies);
                    }
                    else
                        return NotFound("Specified salon does not exist or does not consists of any movies");
                }
                return NotFound("Specified salon does not exist or does not consists of any movies");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
