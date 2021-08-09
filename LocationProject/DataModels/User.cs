using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocationProject.DataModels
{
    public class User
    {
        [Key]
        public int  UserId { get; set; }

        public string UserName { get; set; }
     
        public string Password { get; set; }
       
        public string Name { get; set; }
   
        public string RoleName { get; set; }

        public string UserImagePath { get; set; }
        public string UserImageFileName { get; set; }
    }
}