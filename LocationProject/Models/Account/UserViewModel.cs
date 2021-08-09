using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace LocationProject.Models.Account
{
    public class UserViewModel
    {
        [Required]
        public int UserId { get; set; }


        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string RoleName { get; set; }
        
        public string UserImagePath { get; set; }
        public string UserImageFileName { get; set; }




        public HttpPostedFileBase UserImageFile { get; set; }
    }
}