using GerenciadorTarefas.Domain.Entity;
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
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public Task<T[]> GetAllAsync<T>() where T : class
        {
            return _context.Set<T>().ToArrayAsync();
        }

        public async Task<T> GetById<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public IEnumerable<Tarefa> GetByIdAndUserId(int id)
        {
            var ur = _context.UserRoles.Where(s => s.UserId == id).Select(s=>s.RoleId).ToList();

            var roles = _context.Tarefas.Where(s => ur.Contains(s.UserId));
            return _context.Tarefas.Where(s => ur.Contains(s.UserId));
        }

        public bool PermissaoUsuario(int id)
        {
            var ur = _context.UserRoles.Where(s => s.UserId == id).Select(s => s.RoleId).ToList();

            var roles = _context.Tarefas.Where(s => ur.Contains(s.UserId));
            return _context.Tarefas.Any(s => ur.Contains(s.UserId)); 
        }

    }
}
