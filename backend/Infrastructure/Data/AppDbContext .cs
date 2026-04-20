using Microsoft.EntityFrameworkCore;
using taskManager.Domain.Entities;

namespace taskManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        // Define your DbSets here, for example:
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>()
             .HasOne(t => t.Proyecto)
             .WithMany(p => p.Tareas)
             .HasForeignKey(t => t.ProyectoId)
             .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Proyecto>().HasData(
                new Proyecto
                {
                    Id = 1,
                    Titulo = "Proyecto Demo",
                    FechaCreacion = DateTime.Now
                }
            );

            modelBuilder.Entity<Tarea>().HasData(
                new Tarea
                {
                    Id = 1,
                    Titulo = "Tarea Demo",
                    Descripcion = "Tarea Para Demostracion",
                    Estado = "Pendiente",
                    FechaCreacion = DateTime.Now,
                    FechaVencimiento = DateTime.Now.AddDays(30),
                    ProyectoId = 1
                }
            );
        }

    }
}
