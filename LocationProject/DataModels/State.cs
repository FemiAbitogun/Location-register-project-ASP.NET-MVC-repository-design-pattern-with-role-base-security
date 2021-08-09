using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace LocationProject.DataModels
{

    public  class State
    { 
        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }
        public  int ZipCode { get; set; }

    
    public virtual ICollection<LGVT>  LGVTs { get; set; }


    }
}