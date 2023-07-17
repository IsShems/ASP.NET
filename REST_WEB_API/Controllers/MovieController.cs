using REST_WEB_API_.Models;
using REST_WEB_API_.Services.Classes;
using REST_WEB_API_.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace REST_WEB_API_.Controllers
{

    [ApiController]
    [Route("moviesApi/[controller]/[action]")]
    public class MovieController : ControllerBase
    {
        private IMovieService movieService;
        public MovieController(IMovieService service)
        {
            this.movieService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(movieService.GetAll());
        }
        [HttpGet]
        public IActionResult GetById([FromHeader] int id)
        {
            try
            {
                return Ok(movieService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            try
            {
                return Ok(movieService.AddMovie(movie));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public IActionResult Put([FromHeader] int id, [FromBody] Movie movie)
        {
            return Ok(movieService.UpdateMovie(id, movie));
        }
        [HttpDelete]
        public IActionResult Delete([FromHeader] int id)
        {
            try
            {
                return Ok(movieService.DeleteMovie(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}