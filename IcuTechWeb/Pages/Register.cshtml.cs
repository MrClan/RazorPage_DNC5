using IcuTechWeb.Services;
using IcuTechWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IcuTechWeb.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly IIcuTechService icuTechService;

        public RegisterModel(ILogger<RegisterModel> logger, IIcuTechService _icuTechService)
        {
            _logger = logger;
            icuTechService = _icuTechService;
        }

        [BindProperty]
        public RegisterCustomerViewModel RegisterCustomer { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            RegisterCustomer.SignupIP = HttpContext.Connection.RemoteIpAddress?.ToString();

            var registerResponse = icuTechService.RegisterNewCustomer(RegisterCustomer.MapToServiceModel());

            TempData["IsSuccess"] = registerResponse.IsSuccess;
            TempData["Message"] = registerResponse.Message;
            TempData["CustomerInfo"] = registerResponse.ResponseBody;
            return RedirectToPage("/Register");
        }
    }

}
