using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace LocationProject.Models
{
    public class LGVTViewModel
    {
        [Required]
        public int LGVTId { get; set; }
        [Required]
        public string LGVTName { get; set; }
        [Required]
        public int StateId { get; set; }

        public int StateZipCode { get; set; }

    }
}