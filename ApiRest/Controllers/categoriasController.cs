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
    public class categoriasController : ControllerBase
    {
        private readonly videoContext _context;

        public categoriasController(videoContext context)
        {
            _context = context;
        }

        // GET: api/categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<categoria>>> GetcategoriaItems()
        {
            return await _context.categoriaItems.ToListAsync();
        }

        // GET: api/categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<categoria>> Getcategoria(int id)
        {
            var categoria = await _context.categoriaItems.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // GET: api/categorias/5/videos
        [HttpGet("{id}/videos")]
        public async Task<IQueryable<video>> GetVideosPorCategoria(int id)
        {
            var videosPorCategoria = _context.videoItems.Where(v =>v.fk_categoriaId == id);

            //if (videosPorCategoria == null)
            //{
            //    return NotFound();
            //}

            return videosPorCategoria;
        }

        [HttpGet("{id}/videos2")]
        public async Task<IActionResult> GetVideosPorCategoria2(int id)
        {
            var videosPorCategoria = from v in _context.videoItems.Where(v => v.fk_categoriaId == id)
                                     select v;

            if (videosPorCategoria == null)
            {
                return NotFound();
            }

            return Ok(videosPorCategoria);
        }

        // PUT: api/categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcategoria(int id, categoria categoria)
        {
            if (id != categoria.categoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<categoria>> Postcategoria(categoria categoria)
        {
            _context.categoriaItems.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcategoria", new { id = categoria.categoriaId }, categoria);
        }

        // DELETE: api/categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecategoria(int id)
        {
            var categoria = await _context.categoriaItems.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.categoriaItems.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool categoriaExists(int id)
        {
            return _context.categoriaItems.Any(e => e.categoriaId == id);
        }
    }
}
