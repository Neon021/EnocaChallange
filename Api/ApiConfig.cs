using System.Runtime.CompilerServices;

namespace Api
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet(pattern: "/Users", GetBands);
            app.MapGet(pattern: "/Users/{id}", GetBand);
            app.MapGet(pattern: "/Users", InsertBand);
            app.MapGet(pattern: "/Users", UpdateBand);
            app.MapGet(pattern: "/Users", DeleteBand);
        }
    }
}