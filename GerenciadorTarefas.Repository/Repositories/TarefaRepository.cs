using GerenciadorTarefas.Domain.Identity;
using GerenciadorTarefas.Repository.Data;
using GerenciadorTarefas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Repository.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DataContext _context;

        public TarefaRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T[]> GetAllAsync<T>() where T : class
        {
            _context.Tarefas.Include(o => o.User).Load();
            return _context.Set<T>().ToArrayAsync();
        }

        public Task<T> GetById<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }


    }
}
