using AutoMapper;
using taskManager.Application.DTO;
using taskManager.Domain.Entities;
using taskManager.Domain.Interfaces;

namespace taskManager.Application.Services
{
    public class TareaService
    {
        private readonly ITareaRepository _tareaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TareaService> _logger;

        public TareaService(ITareaRepository tareaRepository, IMapper mapper, ILogger<TareaService> logger)
        {
            _tareaRepository = tareaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TareaDTO>> GetByEstadoAsync(string estado)
        {            
            var tareas = await _tareaRepository.GetTareasByEstado(estado);
            return _mapper.Map<IEnumerable<TareaDTO>>(tareas);
        }
        public async Task<TareaDTO> GetTareaByIdAsync(int id)
        {
            var tarea = await _tareaRepository.GetTareaById(id);
            return _mapper.Map<TareaDTO>(tarea);
        }
        public async Task<TareaDTO> CreateTareaAsync(TareaDTO tareaCreateDto)
        {
            if (tareaCreateDto == null)
            {
                _logger.LogWarning("Tarea CreateTareaAsync fallo: Datos nulos.");
                return null;
            }
            var tarea = _mapper.Map<Tarea>(tareaCreateDto);
            var createdTarea = await _tareaRepository.CreateTarea(tarea);
            return _mapper.Map<TareaDTO>(createdTarea);
        }
        public async Task<TareaDTO> UpdateTareaAsync(int id, TareaDTO tareaUpdateDto)
        {
            var existingTarea = await _tareaRepository.GetTareaById(id);
            if (existingTarea == null)
            {
                _logger.LogWarning("Tarea con ID {Id} no se encuentra para actualizar.", id);
                return null;
            }
            _mapper.Map(tareaUpdateDto, existingTarea);
            var updatedTarea = await _tareaRepository.UpdateTarea(existingTarea);
            return _mapper.Map<TareaDTO>(updatedTarea);
        }

        public async Task<bool> DeleteTareaAsync(int id)
        {
            var existingTarea = await _tareaRepository.GetTareaById(id);
            if (existingTarea == null)
            {
                _logger.LogWarning("Tarea con ID {Id}  no se encuentra para Eliminar.", id);
                return false;
            }
            await _tareaRepository.DeleteTarea(existingTarea);
            return true;
        }
    }
}
