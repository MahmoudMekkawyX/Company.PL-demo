using Company.DAL.Contexts;
using Company.DAL.Models.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Reposatires.GenericsRepo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity :BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context) { 
        
            _context = context;
        }
        public IEnumerable<TEntity> GetAll(bool withTrqacking = false)
        {
            if (withTrqacking)
                return _context.Set<TEntity>().ToList();
            else
                return _context.Set<TEntity>().AsNoTracking().ToList();
        }
        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public void Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);

        }

        public void Update(TEntity item)
        {
            _context.Set<TEntity>().Update(item);
        }

        public void Delete(int id)
        {
            var item = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(item);
        }
    }
}
