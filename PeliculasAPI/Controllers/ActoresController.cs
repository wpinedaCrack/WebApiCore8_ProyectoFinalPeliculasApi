using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get()
        {
            var entidades = await _context.Actores.ToListAsync();
            return _mapper.Map<List<ActorDTO>>(entidades);
        }
        [HttpGet("{id:int}", Name = "obtenerActor")]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            var entidad = await _context.Actores.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<ActorDTO>(entidad);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreacionDTO actorCreacionDTO)
        {
            var entidad = _mapper.Map<Actor>(actorCreacionDTO);
            _context.Add(entidad);
            await _context.SaveChangesAsync();

            var actorDto = _mapper.Map<ActorDTO>(entidad);

            return new CreatedAtRouteResult("obtenerActor", new { id = actorDto.Id }, actorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ActorCreacionDTO actorCreacionDTO)
        {
            var entidad = _mapper.Map<Actor>(actorCreacionDTO);
            entidad.Id = id;
            _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Actores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Actor() { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
