using System.ComponentModel.DataAnnotations;

namespace IcuTechWeb.ServiceModels
{
    public class LoginCustomer
    {
        [Required, EmailAddress]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
