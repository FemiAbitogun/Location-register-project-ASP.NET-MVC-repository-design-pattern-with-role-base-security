using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LocationProject.DataModels.Contetxts
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext():base("name=ApplicationConnnection")
        {
            
        }

        public virtual  DbSet<State>  States { get; set; }
        public virtual DbSet<LGVT> LGVTs { get; set; }
        public virtual DbSet<User> Users { get; set; }


    }
}