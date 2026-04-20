using Microsoft.EntityFrameworkCore;
using taskManager.Domain.Entities;
using taskManager.Domain.Interfaces;
using taskManager.Infrastructure.Data;

namespace taskManager.Infrastructure.Repository
{
    public class TareaRepository : ITareaRepository
    {
        private readonly AppDbContext _context;
        public TareaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tarea> CreateTarea(Tarea Tarea)
        {
            _context.Tareas.Add(Tarea);
            await _context.SaveChangesAsync();
            return Tarea;
        }

        public async Task<Tarea> UpdateTarea(Tarea Tarea)
        {
            _context.Tareas.Update(Tarea);
            await _context.SaveChangesAsync();
            return Tarea;
        }

        public async Task<Tarea> DeleteTarea(Tarea Tarea)
        {
            _context.Tareas.Remove(Tarea);
            await _context.SaveChangesAsync();
            return Tarea;
        }

        public async Task<Tarea> GetTareaById(int id)
        {
            return await _context.Tareas
           .Where(t => t.Id == id).FirstAsync();
        }

        public async Task<IEnumerable<Tarea>> GetTareasByEstado(string estado)
        {
            return await _context.Tareas
            .Where(t => t.Estado == estado)
            .ToListAsync();
        }
                
    }
}
