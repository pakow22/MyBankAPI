using Microsoft.EntityFrameworkCore;
using MyBankAPI.Data;

namespace MyBankAPI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region private fields
        private readonly DataContext _dataContext;
        #endregion
        #region ctor
        public BaseRepository()
        {
            _dataContext = new DataContext();
        }
        #endregion
        public void Add(T entity)
        {
           _dataContext.Add(entity);
           _dataContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dataContext.Update(entity); 
            _dataContext.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
        {
           return _dataContext.Set<T>();
        }

        public virtual T? GetById(int id)
        {
            return _dataContext.Find<T>(id);
        }
      
        public void Update(T entity)
        {
            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
