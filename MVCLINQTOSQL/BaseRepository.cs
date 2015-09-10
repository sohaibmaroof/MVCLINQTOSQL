using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tombola.Core.Data.DB.Interfaces;


namespace Tombola.Core.Data.Repository
{
   public class BaseRepository<dbClass,dContext>:IDisposable
        where dbClass : class,ITombolaEntity 
        where dContext:DataContext, new()
    {
        public BaseRepository():this(new dContext())
        {
            
        } 
        public BaseRepository(dContext context)
        {
            Context = context;
        }

        public IQueryable<dbClass> GetAll()
        {
            return GetTable();
        }

       public dbClass GetById(int id)
       {
           return GetTable().FirstOrDefault(x => x.Id.Equals(id));
       }
        protected Table<dbClass> GetTable()
        {
            return Context.GetTable<dbClass>();
            
        }
        public void Delete(dbClass repositoryTypoeClass)
        {
            GetTable().DeleteOnSubmit(repositoryTypoeClass);
        }

        public void DeleteById(int id)
        {
            Delete(GetById(id));
        }
        public void Add(dbClass item)
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

        public dContext Context { get; set; }
    }
}
