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
        public int Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            return _context.SaveChanges();
        }

        public int Update(TEntity item)
        {
            _context.Set<TEntity>().Update(item);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var item = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(item);
            return _context.SaveChanges();
        }
    }
}
