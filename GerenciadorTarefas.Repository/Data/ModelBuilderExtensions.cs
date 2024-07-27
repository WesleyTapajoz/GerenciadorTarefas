using GerenciadorTarefas.Domain.Entity;
using GerenciadorTarefas.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Repository.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tarefa>().HasData(
              new Tarefa
              {
                  TarefaId = 1,
                  Id = 1,
                  Data = DateTime.Now,
                  Descricao = "Desenvolver gerenciador de tarefa - para provider-it",
                  Status = 1,
                  Titulo = "Desenvolver gerenciador de tarefa",
                  
              });
            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = 1,
                     UserName = "Shakespeare",
                     FullName = "shakespeare",
                     Email = "shakespeare@outlook.com",

                 },
                 new User
                 {
                     Id = 2,
                     UserName = "machadoassis",
                     Email = "machadosssis@outlook.com",
                     FullName = "Machado de Assis"

                 },
                 new User
                 {
                     Id = 3,
                     UserName = "wesley", 
                     Email = "wesley@outlook.com",
                     FullName = "Wesley Tapajoz"

                 },
                 new User
                 {
                     Id = 4,
                     UserName = "douglas",
                     Email = "douglas@outlook.com",
                     FullName = "Wesley Douglas"
                 }
             );
        }
    }
}
