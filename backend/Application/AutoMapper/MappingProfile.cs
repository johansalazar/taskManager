using AutoMapper;
using taskManager.Application.DTO;
using taskManager.Domain.Entities;

namespace taskManager.Application.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Tarea, TareaDTO>().ReverseMap();
            CreateMap<Proyecto, ProyectoDTO>().ReverseMap();

        }
    }
}
