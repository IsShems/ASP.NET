using REST_WEB_API_.Models;
using Microsoft.AspNetCore.Mvc;

namespace REST_WEB_API_.Services.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        List<Movie> AddMovie(Movie movie);
        List<Movie> UpdateMovie(int id, Movie movie);
        List<Movie> DeleteMovie(int id);

    }
}
