using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace N5SportsStore.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }
        
        //подробнее стр 338 и глава 24
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";

    }
}
