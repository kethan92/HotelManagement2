using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagerReponsity_MVC.ViewModel
{
    public class LoginUser
    {
        [Required(ErrorMessage="Username không được bỏ trống!")]
        public string username { get; set; }
        [Required(ErrorMessage ="Password không được bỏ trống")]
        [DataType(DataType.Password)]
        public string password { get; set; }

      
    }
}