using AutoMapper;
using GerenciadorTarefas.Domain.Entity;
using GerenciadorTarefas.Domain.Identity;
using GerenciadorTarefas.WebAPI.Model;
using System;
namespace GerenciadorTarefas.WebAPI.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserModel>()
                .ReverseMap();


            CreateMap<User, UserLoginModel>()
                  .ForMember(dest => dest.Id, opt =>
                  {
                      opt.MapFrom(src => src.Id);
                  })
                  .ReverseMap();

            CreateMap<User, UserAdd>()
                   .ForMember(dest => dest.Password, opt =>
                   {
                       opt.MapFrom(src => src.PasswordHash);
                   })
                .ReverseMap();

            CreateMap<Tarefa, TarefaModel>()
               .ReverseMap();

            CreateMap<Tarefa, TarefaAddModel>()
             .ReverseMap();

            CreateMap<Tarefa, TarefaAlterarModel>()
             .ReverseMap();

        }
    }
}
