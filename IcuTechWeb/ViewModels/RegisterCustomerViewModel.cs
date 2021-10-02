using IcuTechWeb.ServiceModels.RequestModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IcuTechWeb.ViewModels
{

    public class RegisterCustomerViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, Phone]
        public string Mobile { get; set; }
        public int CountryID { get; set; }
        public int aID { get; set; }
        public string SignupIP { get; set; }

        public RegisterRequestModel MapToServiceModel()
            => new RegisterRequestModel
            {
                Email = Email,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName,
                Mobile = Mobile,
                CountryID = 1,
                aID = 1,
                SignupIP = SignupIP
            };
    }
}
