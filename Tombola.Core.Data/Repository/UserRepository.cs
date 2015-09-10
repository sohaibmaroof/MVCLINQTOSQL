using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tombola.Core.Data.DB;

namespace Tombola.Core.Data.Repository
{
    public class UserRepository : BaseRepository<User, MVCDataContext>
    {
        public UserRepository():base()
        {
            
        }
        public UserRepository(MVCDataContext context)
            : base(context)
        {

        }
    }
}
