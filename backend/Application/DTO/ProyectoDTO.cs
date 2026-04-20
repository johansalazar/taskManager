namespace taskManager.Application.DTO
{
    public class ProyectoDTO
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }    
        public DateTime FechaCreacion { get; set; }
        public List<TareaDTO>? Tareas { get; set; }
    }
}
