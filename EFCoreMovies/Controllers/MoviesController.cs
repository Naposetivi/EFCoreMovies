﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Keyless;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet("withCounts")]
        public async Task<ActionResult<IEnumerable<MovieWithCount>>> GetWithCount()
        {
            return await context.Set<MovieWithCount>().ToListAsync();
        }


        [HttpGet("automapper/{id:int}")]
        public async Task<ActionResult<MovieDTO>> GetWithAutoMapper(int id)
        {
            var movieDTO = await context.Movies
               .ProjectTo<MovieDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movieDTO is null)
            {
                return NotFound();
            }


            movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(x => x.Id).ToList();

            return movieDTO;
        }


        [HttpPost]
        public async Task<ActionResult> Post(MovieCreationDTO movieCreationDTO)
        {
            var movie = mapper.Map<Movie>(movieCreationDTO);

            movie.Genres.ForEach(g => context.Entry(g).State = EntityState.Unchanged);
            movie.CinemaHalls.ForEach(ch => context.Entry(ch).State = EntityState.Unchanged);

            if(movie.MovieActor is not null)
            {
                for(int i = 0; i < movie.MovieActor.Count; i++)
                {
                    movie.MovieActor[i].Order = i + 1;
                }
            }

            context.Add(movie);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}