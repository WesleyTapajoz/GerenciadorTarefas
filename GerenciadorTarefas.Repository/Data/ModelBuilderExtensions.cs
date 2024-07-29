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

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   UserName = "wesley",
                   PrimeiroNome = "Wesley",
                   PasswordHash = "AQAAAAIAAYagAAAAEIZPHiApY/Sayp5F3XK0VQUfYPZxTeQNj1Behq/xreBvWMyjj9bQUFGi8bwAXyN3XQ==",
                   NormalizedUserName = "WESLEY"

               },
               new User
               {
                   Id = 2,
                   UserName = "tapajoz",
                   PrimeiroNome = "TAPAJOZ",
                   PasswordHash = "AQAAAAIAAYagAAAAEIZPHiApY/Sayp5F3XK0VQUfYPZxTeQNj1Behq/xreBvWMyjj9bQUFGi8bwAXyN3XQ==",
                   NormalizedUserName = "TAPAJOZ"

               }
           );

            modelBuilder.Entity<Role>().HasData(
               new Role
               {
                   Id = 1,
                   Name = "ADMINISTRATOR",
                   NormalizedName = "ADMINISTRATOR",
                   ConcurrencyStamp = Guid.NewGuid().ToString()
               },
               new Role
               {
                   Id = 2,
                   Name = "USER",
                   NormalizedName = "USER",
                   ConcurrencyStamp = Guid.NewGuid().ToString()
               }
           );
           modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                   UserId = 1,
                   RoleId = 1,
                },
                new UserRole
                {
                    UserId = 1,
                    RoleId = 2,
                },
                new UserRole
                {
                   UserId = 2,
                   RoleId = 2,
                }
           );

            modelBuilder.Entity<Tarefa>().HasData(
                new Tarefa
                {
                  TarefaId = 1,
                  Data = DateTime.Now,
                  Descricao = "Desenvolver gerenciador de tarefa - para provider-it",
                  Status = 1,
                  Titulo = "Desenvolver gerenciador de tarefa",
                  UserId = 1
                }
            );

            modelBuilder.Entity<Tarefa>().HasData(
                 new Tarefa
                 {
                     TarefaId = 2,
                     Data = DateTime.Now,
                     Descricao = "Desenvolver gerenciador de tarefa - para provider-it",
                     Status = 0,
                     Titulo = "Desenvolver gerenciador de tarefa",
                     UserId = 1
                 }
            );

            modelBuilder.Entity<Tarefa>().HasData(
                new Tarefa
                {
                    TarefaId = 3,
                    Data = DateTime.Now,
                    Descricao = "Desenvolver gerenciador de tarefa - para provider-it",
                    Status = 0,
                    Titulo = "Desenvolver gerenciador de tarefa",
                    UserId = 2
                }
           );

           modelBuilder.Entity<Tarefa>().HasData(
               new Tarefa
               {
                   TarefaId = 4,
                   Data = DateTime.Now,
                   Descricao = "Desenvolver gerenciador de tarefa - para provider-it",
                   Status = 0,
                   Titulo = "Desenvolver gerenciador de tarefa",
                   UserId = 2
               }
          );
        }
    }
}
