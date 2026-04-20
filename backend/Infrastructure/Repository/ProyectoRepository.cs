using Microsoft.EntityFrameworkCore;
using taskManager.Domain.Entities;
using taskManager.Domain.Interfaces;
using taskManager.Infrastructure.Data;


namespace taskManager.Infrastructure.Repository
{
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly AppDbContext _context;

        public ProyectoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Proyecto> CreateProyecto(Proyecto proyecto)
        {
            _context.Proyectos.Add(proyecto);
            await _context.SaveChangesAsync();
            return proyecto;
        }

        public async Task<Proyecto> UpdateProyecto(Proyecto Proyecto)
        {
            _context.Proyectos.Update(Proyecto);
            await _context.SaveChangesAsync();
            return Proyecto;
        }

        public async Task<Proyecto> DeleteProyecto(Proyecto Proyecto)
        {
            _context.Proyectos.Remove(Proyecto);
            await _context.SaveChangesAsync();
            return Proyecto;
        }

        public async Task<Proyecto> GetProyectoById(int id)
        {
            return await _context.Proyectos.Include(p => p.Tareas).Where(p => p.Id == id).FirstAsync();
        }

        public async Task<IEnumerable<Proyecto>> GetAllProyectos()
        {
            return await _context.Proyectos.Include(p => p.Tareas).ToListAsync();
        }

        public async Task<IEnumerable<Proyecto>> GetProyectosByFechaCreacion(DateTime fecha)
        {
            return await _context.Proyectos.Where(p => p.FechaCreacion == fecha).ToListAsync();
        }

        
    }
}
