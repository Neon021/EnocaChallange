using ASP.NET_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Web.Data
{
    public class DataAccess
    {
        private ApplicationDBContext _ctx;

        public DataAccess(ApplicationDBContext context)
        {
            _ctx = context;
        }

        public IEnumerable<MovieModel> GetMovies()
        {
            IEnumerable<MovieModel>? movieModels = _ctx.MovieModels;
            if (movieModels != null)
                return movieModels;
            else
                return Enumerable.Empty<MovieModel>();
        }

        public IEnumerable<MovieModel> GetMovie(int id)
        {
            var model = _ctx.MovieModels.FirstOrDefault(x => x.id == id);
            if(model != null)
                yield return model;
        }

        public IResult InsertMovie(MovieModel obj)
        {
            if (_ctx.MovieModels != null)
                _ctx.MovieModels.Add(obj);
            _ctx.SaveChanges();
            return Results.Ok();
        }

        public IResult UpdateMovie(MovieModel obj, int id)
        {
            var model = _ctx.MovieModels.FirstOrDefault(x => x.id == id);

            if (_ctx.MovieModels != null && model != null)
            {
                model.id = obj.id;
                model.Director = obj.Director;
                model.Name = obj.Name;
                model.ReleaseDate = obj.ReleaseDate;
            }
            _ctx.SaveChanges();
            return Results.Ok();
        }

        public IResult DeleteMovie(int id)
        {
            try
            {
                _ctx.Remove(id);
                return Results.Ok();
            }catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

    }
}
