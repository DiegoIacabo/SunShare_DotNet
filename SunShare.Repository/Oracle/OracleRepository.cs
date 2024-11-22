using Microsoft.EntityFrameworkCore;
using SunShare.Database;

namespace SunShare.Repository.Oracle
{
    public class OracleRepository<T> : IRepository<T> where T : class
    {
        private readonly OracleDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public OracleRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }
    }
}
