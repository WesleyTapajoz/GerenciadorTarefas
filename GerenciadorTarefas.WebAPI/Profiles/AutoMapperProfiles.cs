using AutoMapper;
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

            CreateMap<TarefaModel, TarefaModel>()
               .ReverseMap();
        }
    }
}
