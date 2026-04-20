using AutoMapper;
using taskManager.Application.DTO;
using taskManager.Domain.Entities;
using taskManager.Domain.Interfaces;

namespace taskManager.Application.Services
{
    public class ProyectoService
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProyectoService> _logger;

        public ProyectoService(IProyectoRepository proyectoRepository, IMapper mapper, ILogger<ProyectoService> logger)
        {
            _proyectoRepository = proyectoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ProyectoDTO>> GetAllProyectosAsync()
        {
            var proyectos = await _proyectoRepository.GetAllProyectos();
            return _mapper.Map<IEnumerable<ProyectoDTO>>(proyectos);
        }
        public async Task<ProyectoDTO> GetProyectoByIdAsync(int id)
        {
            var proyecto = await _proyectoRepository.GetProyectoById(id);
            return _mapper.Map<ProyectoDTO>(proyecto);
        }
        public async Task<ProyectoDTO> CreateProyectoAsync(ProyectoDTO proyectoCreateDto)
        {
            if (proyectoCreateDto == null)
            {
                _logger.LogWarning("Proyecto CreateProyectoAsync fallo: Datos nulos.");
                return null;
            }
            var proyecto = _mapper.Map<Proyecto>(proyectoCreateDto);
            var createdProyecto = await _proyectoRepository.CreateProyecto(proyecto);
            return _mapper.Map<ProyectoDTO>(createdProyecto);
        }
        public async Task<ProyectoDTO> UpdateProyectoAsync(int id, ProyectoDTO proyectoUpdateDto)
        {
            var existingProyecto = await _proyectoRepository.GetProyectoById(id);
            if (existingProyecto == null)
            {
                _logger.LogWarning("Proyecto con ID {Id} no se encuentra para actualizar.", id);
                return null;
            }
            _mapper.Map(proyectoUpdateDto, existingProyecto);
            var updatedProyecto = await _proyectoRepository.UpdateProyecto(existingProyecto);
            return _mapper.Map<ProyectoDTO>(updatedProyecto);
        }
        public async Task<bool> DeleteProyectoAsync(int id)
        {
            var existingProyecto = await _proyectoRepository.GetProyectoById(id);
            if (existingProyecto == null)
            {
                _logger.LogWarning("Proyecto con ID {Id}  no se encuentra para Eliminar.", id);
                return false;
            }
            await _proyectoRepository.DeleteProyecto(existingProyecto);
            return true;

        }

        public async Task<IEnumerable<ProyectoDTO>> GetProyectosByFechaCreacionAsync(DateTime fechaCreacion)
        {
            var proyectos = await _proyectoRepository.GetProyectosByFechaCreacion(fechaCreacion);
            return _mapper.Map<IEnumerable<ProyectoDTO>>(proyectos);
        }
       

    }
}
