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
                  Titulo = "Desenvolver gerenciador de tarefa"
              });
            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = 1,
                     CPF = "019.266.931-16",
                     UserName = "Shakespeare",
                     Endereco = "Stratford-upon-Avon, Reino Unido",
                     Email = "shakespeare@outlook.com",
                     Ativo = true,
                     Telefone = "65 99999-9999",
                     FullName = "shakespeare"
                 },
                 new User
                 {
                     Id = 2,
                     CPF = "019.266.931-17",
                     UserName = "machadoassis",
                     Endereco = "Rio de Janeiro, Brasil",
                     Email = "machadosssis@outlook.com",
                     Ativo = true,
                     Telefone = "65 99999-9999",
                     FullName = "Machado de Assis"

                 },
                 new User
                 {
                     Id = 3,
                     CPF = "019.266.931-17",
                     UserName = "wesley",
                     Endereco = "Cuiabá, Brasil",
                     Email = "wesley@outlook.com",
                     Ativo = true,
                     Telefone = "65 99999-9999",
                     FullName = "Wesley Tapajoz"

                 },
                 new User
                 {
                     Id = 4,
                     CPF = "019.266.931-17",
                     UserName = "douglas",
                     Endereco = "Várzea Grande, Brasil",
                     Email = "tapajoz@outlook.com",
                     Ativo = true,
                     Telefone = "65 99999-9999",
                     FullName = "Wesley Douglas"

                 }
             );
        }
    }
}
