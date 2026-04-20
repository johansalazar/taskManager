using Microsoft.AspNetCore.Mvc;
using taskManager.Application.DTO;
using taskManager.Application.Services;
using taskManager.Domain.Entities;

namespace taskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProyectosController : ControllerBase
    {
        private readonly ProyectoService _proyectoService;

        public ProyectosController(ProyectoService proyectoService)
        {
            _proyectoService = proyectoService;
        }

        /// <summary>
        /// Obtiene la lista de todos los proyectos
        /// </summary>
        /// <returns>Lista de proyectos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos()
        {
            var proyectos = await _proyectoService.GetAllProyectosAsync();
            return Ok(proyectos);
        }

        /// <summary>
        /// Obtiene un proyecto por su ID
        /// </summary>
        /// <param name="id">ID del proyecto</param>
        /// <returns>Proyecto encontrado</returns>
        [HttpGet("{id}")]    
        public async Task<ActionResult<Proyecto>> GetProyecto(int id)
        {
            var proyecto = await _proyectoService.GetProyectoByIdAsync(id);

            if (proyecto == null)
                return NotFound(new { message = "Proyecto no encontrado" });

            return Ok(proyecto);
        }

        /// <summary>
        /// Crea un nuevo proyecto
        /// </summary>
        /// <param name="proyecto">Datos del proyecto</param>
        /// <returns>Proyecto creado</returns>
        [HttpPost]        
        public async Task<ActionResult<Proyecto>> CreateProyecto([FromBody] ProyectoDTO proyecto)
        {
            if (proyecto == null)
                return BadRequest(new { message = "Datos inválidos" });

            var createdProyecto = await _proyectoService.CreateProyectoAsync(proyecto);

            return CreatedAtAction(
                nameof(GetProyecto),
                new { id = createdProyecto.Id },
                createdProyecto
            );
        }
    }
}