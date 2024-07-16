using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenerosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            var entidades = await _context.Generos.ToListAsync();
            var dtos = _mapper.Map<List<GeneroDTO>>(entidades);
            return dtos;
        }
        [HttpGet("{id:int}", Name = "obtenerGenero")]
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            var entidad = await _context.Generos.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (entidad == null)
            {
                return NotFound();
            }
            var dtos = _mapper.Map<GeneroDTO>(entidad);
            return dtos;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var entidad = _mapper.Map<Genero>(generoCreacionDTO);
            _context.Add(entidad);
            await _context.SaveChangesAsync();

            var generoDto = _mapper.Map<GeneroDTO>(entidad);

            return new CreatedAtRouteResult("obtenerGenero", new { id = generoDto.Id }, generoDto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var entidad = _mapper.Map<Genero>(generoCreacionDTO);
            entidad.Id = id;
            _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Generos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Genero() { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}