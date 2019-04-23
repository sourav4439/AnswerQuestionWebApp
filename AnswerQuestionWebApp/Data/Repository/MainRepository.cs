using AnswerQuestionWebApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Data.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Db;


        public MainRepository(ApplicationDbContext context)
        {
            Db = context;
        }
        public int Count(Func<T, bool> predicate)
        {
            return Db.Set<T>().Where(predicate).Count();
                
        }

        public void Create(T entity)
        {
            Db.Add(entity);
            Save();
        }       
        public void Delete(T entity)
        {
            Db.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
           return Db.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return Db.Set<T>();
        }

        public T GetById(int id)
        {
           return Db.Set<T>().Find(id);
        }

        

        public void Update(T entity)
        {
           Db.Entry(entity).State = EntityState.Modified;
           Save();
        }

        protected void Save()
        {
            Db.SaveChanges();
        }
    }
}
