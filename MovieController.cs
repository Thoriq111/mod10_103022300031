using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace Modul10_103022300031
{
    [ApiController]
    [Route("api/[controlller]")]
    public class MovieController : ControllerBase
    {
        public static readonly List<Movie> Movie = new List<Movie>
        {
            new Movie("The Shawshank Redemption", "Frank Darabont", ["Tim Robbins", "Morgan Freeman", "Bob Gunton"], "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie("The Godfather", "Francis Ford Coppola", ["Marlon Brando", "Al Pacino", "James Caan"], "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
            new Movie("The Dark Knight", "Christopher Nolan", ["Christian Bale", "Heath Ledger", "Aaron Eckhart "], "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.")
        };
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllmovie() 
        { 
            return Ok (Movie);
        }
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieByIndex(int id) 
        {
            if (id < 0 || id >= Movie.Count) 
            {
                return NotFound(new { message = "Movie tidak ditemukan" });
            }
            return Ok(Movie[id]);
        }
        [HttpPost]
        public ActionResult AddMovie([FromBody] Movie movBaru)
        {
            if (string.IsNullOrWhiteSpace(movBaru.Title) || string.IsNullOrWhiteSpace(movBaru.Director))
            {
                return BadRequest(new { message = "Title dan Director harus diisi" });
            }
            Movie.Add(movBaru);
            return Ok(new { message = "Movie telah ditambahkan", id = Movie.Count - 1});
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie (int id) 
        {
            Movie.RemoveAt(id);
            return Ok(new { Message = "Movie berhasil dihapus" });
        }
       
    }
}
