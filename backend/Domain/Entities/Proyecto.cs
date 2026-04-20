namespace taskManager.Domain.Entities
{
    public class Proyecto
    {

        public int Id { get; set; }
        public string? Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List <Tarea>? Tareas { get; set; }
    }
}
