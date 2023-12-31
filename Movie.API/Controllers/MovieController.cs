﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.API.Data;
using Movie.API.Models;
using Movie.API.Models.Dto;


namespace Movie.API.Controllers
{
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieDBContext _context;
        private readonly IMapper _mapper;

        public MovieController(MovieDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> addMovie(CreateMovieDto movieDTO)
        {
            var movie = _mapper.Map<Movies>(movieDTO);
             _context.Movies.Add(movie);
            var result = await _context.SaveChangesAsync() >0;
            if (!result) return BadRequest("Could not save changes to Movie!");
            return CreatedAtAction(nameof(addMovie), new { movie.Id }, movieDTO);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteMovie(int id)
        {
            var movie =   await _context.Movies.FirstOrDefaultAsync(m=>m.Id == id);

            if (movie == null) return BadRequest("Movie not found!");

            _context.Movies.Remove(movie);

           var result= await _context.SaveChangesAsync() > 0;

            if (!result) return BadRequest("Could not delete the movie!");

            return Ok("Movie Deleted Successfully!");
        }
    }
}
