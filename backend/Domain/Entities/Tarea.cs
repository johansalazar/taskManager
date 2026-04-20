namespace taskManager.Domain.Entities
{
    public class Tarea
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }       
        public string? Estado { get; set; } // Ejemplo: "Pendiente", "En Progreso" o "Completada"
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        // Relación con Proyecto
        public int ProyectoId { get; set; }
        public Proyecto? Proyecto { get; set; }
    }
}
