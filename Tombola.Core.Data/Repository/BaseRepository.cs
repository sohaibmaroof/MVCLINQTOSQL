﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Tombola.Core.Data.DB.Interfaces;


namespace Tombola.Core.Data.Repository
{
    public class BaseRepository<EntityType,DBContextType>:IDisposable
        where EntityType : class,ITombolaEntity 
        where DBContextType:DataContext, new()
    {
        public BaseRepository():this(new DBContextType())
        {
            
        }
 
        public BaseRepository(DBContextType context)
        {
            Context = context;
        }

        public IQueryable<EntityType> GetAll()
        {
            return GetTable();
        }

        public EntityType GetById(int id)
        {
            return GetTable().SingleOrDefault(x => x.Id.Equals(id));
        }

        protected Table<EntityType> GetTable()
        {
            return Context.GetTable<EntityType>();     
        }

        public void Delete(EntityType repositoryTypoeClass)
        {
            GetTable().DeleteOnSubmit(repositoryTypoeClass);
        }

        public void DeleteById(int id)
        {
            Delete(GetById(id));
        }
       
        public void Add(EntityType item)
        {
            GetTable().InsertOnSubmit(item);
        }

        public void SubmitChanges()
        {
           Context.SubmitChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public DBContextType Context { get; set; }
    }
}
