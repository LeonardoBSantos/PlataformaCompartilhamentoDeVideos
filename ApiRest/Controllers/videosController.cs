using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRest.Model;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class videosController : ControllerBase
    {
        private readonly videoContext _context;

        public videosController(videoContext context)
        {
            _context = context;
        }

        // GET: api/videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<video>>> GetvideoItems()
        {
            return await _context.videoItems.ToListAsync();
        }

        // GET: api/videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<video>> Getvideo(int id)
        {
            var video = await _context.videoItems.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // GET: api/videos/busca?titulo=O Lobo de WallStreet
        [HttpGet("busca")]
        public async Task<IActionResult> BuscaPorTitulo([FromQuery] string titulo)
        {
            var video = from v in _context.videoItems.Where(v => v.Titulo == titulo)
                              select v;

            if (video == null)
            {
                return NotFound();
            }

            return Ok(video);
        }

        // PUT: api/videos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putvideo(int id, video video)
        {
            if (id != video.Id)
            {
                return BadRequest();
            }

            _context.Entry(video).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!videoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/videos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<video>> Postvideo(video video)
        {
            if(video.Titulo == null)
            {
                return BadRequest();
            }

            _context.videoItems.Add(video);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getvideo", new { id = video.Id }, video);
        }

        // DELETE: api/videos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletevideo(int id)
        {
            var video = await _context.videoItems.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            _context.videoItems.Remove(video);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool videoExists(int id)
        {
            return _context.videoItems.Any(e => e.Id == id);
        }
    }
}
