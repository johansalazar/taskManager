namespace taskManager.Application.DTO
{
    public class TareaDTO
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int ProyectoId { get; set; }

    }
}
