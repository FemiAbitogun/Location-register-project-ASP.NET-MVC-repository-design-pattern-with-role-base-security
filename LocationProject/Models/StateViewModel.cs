using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LocationProject.Models
{
    public class StateViewModel
    {
        [Required]
        public int StateId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ZipCode { get; set; }

    }
}