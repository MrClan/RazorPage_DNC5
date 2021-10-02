using IcuTechWeb.ServiceModels.RequestModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IcuTechWeb.ViewModels
{

    public class LoginCustomerViewModel
    {
        [Required, EmailAddress]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string IP { get; set; }

        public LoginRequestModel MapToServiceModel()
            => new LoginRequestModel { Username = Username, Password = Password, Ip = IP };
    }
}
