using taskManager.Domain.Entities;

namespace taskManager.Domain.Interfaces
{
    public interface IProyectoRepository
    {
        Task<Proyecto> CreateProyecto(Proyecto proyecto);
        Task<Proyecto> DeleteProyecto(Proyecto Proyect);
        Task<IEnumerable<Proyecto>> GetAllProyectos();
        Task<Proyecto> GetProyectoById(int id);
        Task<IEnumerable<Proyecto>> GetProyectosByFechaCreacion(DateTime fechaCreacion);
        Task<Proyecto> UpdateProyecto(Proyecto proyecto);
    }
}
