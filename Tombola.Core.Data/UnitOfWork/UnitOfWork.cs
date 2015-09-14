using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tombola.Core.Data.DB;
using Tombola.Core.Data.Repository;

namespace Tombola.Core.Data.UnitOfWork
{
    public class UnitOfWork:IDisposable
    {
        
        public BaseRepository<User> UseRepository
        {
            get
            {
                if (this.useRepository == null)
                {
                    this.useRepository = new BaseRepository<User>(Context);
                }
                return useRepository;
            }

        }

        public void SubmitChanges()
        {
            Context.SubmitChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public MVCDataContext Context = new MVCDataContext();
        public BaseRepository<User> useRepository;
        private bool disposed = false;
    }
}
