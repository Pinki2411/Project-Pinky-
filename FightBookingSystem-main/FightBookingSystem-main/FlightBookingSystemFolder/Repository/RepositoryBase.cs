using Microsoft.EntityFrameworkCore;
using FlightBookingSystemFolder.DataAccessLayer; 
using System;  
using System.Collections.Generic;  
using System.Linq;


namespace FlightBookingSystemFolder.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
       private readonly flightContext _Fcontext;
        private DbSet<T> dbEntity=null;
        public RepositoryBase(flightContext Flightcontext)
        {
            _Fcontext = Flightcontext;
            dbEntity = _Fcontext.Set<T>();
        } 

        public IEnumerable<T> GetModel()
        {
            return dbEntity.ToList();
        }

        public T GetModelbyID(int modelId)
        {
            return dbEntity.Find(modelId);
        }

        public void InsertModel(T model)
        { 
                if (model == null)
                {
                    throw new ArgumentNullException("model");
                }
                dbEntity.Add(model);
                _Fcontext.SaveChanges();
        }

        public void UpdateModel(T model)
        {
            _Fcontext.Entry(model).State = EntityState.Modified;
        }
    }
}

