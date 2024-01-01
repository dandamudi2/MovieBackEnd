using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Movie.API.Data;
using Movie.API.Models;
using Movie.API.Models.Dto;

namespace Movie.API.Controllers
{
    [Route("api/Platform")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly MovieDBContext _context;
        private readonly IMapper _mapper;

        public PlatformController(MovieDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Platform>>> GetAllPlatform()
        {
            var platforms= await _context.Platform.ToListAsync();
            if (platforms == null) return BadRequest("Failed to fetch Platforms");
            return Ok(platforms);
        }

        [HttpPost]
        public async Task<ActionResult<Platform>> SavePlatform(PlatformDto platformDto)
        {
            platformDto.Id = Guid.NewGuid();
           var platform = _mapper.Map<Platform>(platformDto);
      
            _context.Platform.AddRange(platform);
            var result = await  _context.SaveChangesAsync()>0;
            if (!result) return BadRequest("Platform save failed!");
            return CreatedAtAction(nameof(SavePlatform), new { id = platform.Id }, platformDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlatform(Guid id, PlatformDto platformDto)
        {

            var platform = await _context.Platform.FirstOrDefaultAsync(p => p.Id == id);

            if (platform == null) return NotFound();

            platform.PlatformName = platformDto.PlatformName ?? platformDto.PlatformName;

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok("Platform Updated Successfully!");

            return BadRequest("Problem in saving Platform");
        }
    }
}
