using AutoMapper;
using taskManager.Domain.Entities;

namespace taskManager.Domain.Interfaces
{
    public interface ITareaRepository
    {
        Task<Tarea> CreateTarea(Tarea tarea);
        Task<Tarea> DeleteTarea(Tarea existingTarea);
        Task<Tarea> GetTareaById(int id);
        Task<IEnumerable<Tarea>> GetTareasByEstado(string estado);
        Task<Tarea> UpdateTarea(Tarea Tarea);

    }
}
