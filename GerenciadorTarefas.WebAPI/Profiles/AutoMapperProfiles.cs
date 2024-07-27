using AutoMapper;
using GerenciadorTarefas.Domain.Entity;
using GerenciadorTarefas.Domain.Identity;
using GerenciadorTarefas.WebAPI.Model;

namespace GerenciadorTarefas.WebAPI.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserModel>()
                 .ForMember(dest => dest.Id, opt =>
                 {
                     opt.MapFrom(src => src.Id);
                 })
                .ReverseMap();

            CreateMap<User, UserModel>()
                   .ReverseMap();

            CreateMap<Tarefa, TarefaModel>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(src => src.Id);
                })
            
               .ReverseMap();
        }
    }
}
