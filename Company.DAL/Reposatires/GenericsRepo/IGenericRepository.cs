using Company.DAL.Models.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Reposatires.GenericsRepo
{
    public interface IGenericRepository<TEntity> where TEntity :BaseEntity
    {
        public IEnumerable<TEntity> GetAll(bool withTrqacking = false);
        public TEntity GetById(int id);
        public int Add(TEntity item);
        public int Update(TEntity item);
        public int Delete(int id);
    }
}
