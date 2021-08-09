using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace LocationProject.DataModels
{
    public class LGVT
    {
        [Key]
        public int LGVTId { get; set; }
        public string LGVTName { get; set; }

       
        public int StateId { get; set; }

        //navigation
        [ForeignKey("StateId")]
        public virtual  State State { get; set; }

    }
}