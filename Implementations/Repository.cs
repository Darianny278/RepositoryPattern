using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Interfaces;

namespace RepositoryPattern.Implementations{
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<Entity> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Entity>();
        }
        public async Task<Entity> AddAsync(Entity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(Entity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(Entity entity)
        {
            _dbSet.Update(entity);
        }
    }
}