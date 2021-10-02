using System.ComponentModel.DataAnnotations;

namespace IcuTechWeb.ServiceModels
{
    public class RegisterCustomer
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
    }
}
