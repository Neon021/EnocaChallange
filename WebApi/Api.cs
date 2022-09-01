
using ASP.NET_Web.Controllers;
using ASP.NET_Web.Data;
using ASP.NET_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet(pattern: "/Movies",GetMovies);
            app.MapGet(pattern: "/Movies{id}",GetMovie);
            app.MapGet(pattern: "/Movie", InsertMovie);
            app.MapGet(pattern: "/Movie", UpdateMovie);
            app.MapGet(pattern: "/Movie", DeleteMovie);
        }

        private static IEnumerable<MovieModel> GetMovies(DataAccess context)
        {
            IEnumerable<MovieModel> movies = context.GetMovies();
            return movies;
        }
        private static IEnumerable<MovieModel> GetMovie(DataAccess context,int id)
        {
            IEnumerable<MovieModel> movies = context.GetMovie(id);
            return movies;
        }

        private static IResult InsertMovie(DataAccess ctx, MovieModel movie)
        {
            return ctx.InsertMovie(movie);
        }

        private static IResult UpdateMovie(DataAccess ctx, MovieModel model, int id)
        {
            return ctx.UpdateMovie(model, id);
        }
        private static IResult DeleteMovie(DataAccess ctx, int id)
        {
            return ctx.DeleteMovie(id);
        }
    }
}
