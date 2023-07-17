using REST_WEB_API_.Models;
using REST_WEB_API_.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace REST_WEB_API_.Services.Classes
{
    public class MovieService : IMovieService
    {
        static List<Movie> movies = new List<Movie>
        {
             new Movie{Id = 1, Title="Iron man", Rating = 7.9, Profit = 140000000},
             new Movie{Id = 2, Title="Now you see me", Rating = 7.2, Profit = 351700000},
             new Movie{Id = 3, Title="Now you see me 2", Rating = 6.4, Profit = 651000000},
             new Movie{Id = 4, Title="The Matrix", Rating = 8.7, Profit = 171500000},
             new Movie{Id = 5, Title="pride and prejudice", Rating = 7.8, Profit = 121000000},
         };

        [HttpGet]
        public List<Movie> GetAll()
        {
            return movies;
        }
        [HttpGet]
        public Movie GetById([FromHeader] int id)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Id == id)
                {
                    return movies[i];
                }
            }
            throw new Exception("This id doesn't exist");
        }

        [HttpPost]
        public List<Movie> AddMovie([FromBody] Movie movie)
        {
            int counter = 0;
            for (int i = 0; i < movies.Count; i++)
            {
                if (movie.Id != movies[i].Id)
                {
                    counter++;
                }
            }
            if (counter == movies.Count)
            {
                movies.Add(movie);
                return movies;
            }
            throw new Exception("This id is already taken");
        }

        [HttpPut]
        public List<Movie> UpdateMovie([FromHeader] int id, [FromBody] Movie movie)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Id == id)
                {
                    movies.RemoveAt(i);
                    movies.Insert(i, movie);
                }
            }
            return movies;
        }

        [HttpDelete]
        public List<Movie> DeleteMovie([FromHeader] int id)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Id == id)
                {
                    movies.RemoveAt(i);
                    return movies;
                }
            }
            throw new Exception("This id doesn't exist");
        }

    }
}
