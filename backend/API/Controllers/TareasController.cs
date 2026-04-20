using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskManager.Application.DTO;
using taskManager.Application.Services;

namespace taskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TareasController : ControllerBase
    {
        private readonly TareaService _service;

        public TareasController(TareaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene las tareas filtradas por estado
        /// </summary>
        /// <param name="estado">
        /// Estado de la tarea. Valores posibles:
        /// Pendiente, EnProgreso, Completada
        /// </param>
        /// <returns>Lista de tareas filtradas</returns>
        [HttpGet("estado/{estado}")]       
        public async Task<IActionResult> GetByEstado(string estado)
        {
            var tareas = await _service.GetByEstadoAsync(estado);

            if (!tareas.Any())
                return NotFound(new { message = "No hay tareas con ese estado" });

            return Ok(tareas);
        }

        /// <summary>
        /// Crea una nueva tarea
        /// </summary>
        /// <param name="tarea">Datos de la tarea</param>
        /// <returns>Tarea creada</returns>
        [HttpPost]       
        public async Task<IActionResult> Crear([FromBody] TareaDTO tarea)
        {
            if (tarea == null)
                return BadRequest(new { message = "Datos inválidos" });

            var createdTarea = await _service.CreateTareaAsync(tarea);

            return CreatedAtAction(
                nameof(GetTarea),
                new { id = createdTarea.Id },
                createdTarea
            );
        }

        /// <summary>
        /// Obtiene una tarea por su ID
        /// </summary>
        /// <param name="id">ID de la tarea</param>
        /// <returns>Tarea encontrada</returns>
        [HttpGet("{id}")]      
        public async Task<IActionResult> GetTarea(int id)
        {
            var tarea = await _service.GetTareaByIdAsync(id);

            if (tarea == null)
                return NotFound(new { message = "Tarea no encontrada" });

            return Ok(tarea);
        }
    }
}