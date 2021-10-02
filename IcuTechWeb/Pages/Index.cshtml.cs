using IcuTechWeb.Services;
using IcuTechWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IcuTechWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IIcuTechService icuTechService;

        public IndexModel(ILogger<IndexModel> logger, IIcuTechService _icuTechService)
        {
            _logger = logger;
            icuTechService = _icuTechService;
        }

        [BindProperty]
        public LoginCustomerViewModel LoginCustomer { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            LoginCustomer.IP = HttpContext.Connection.RemoteIpAddress?.ToString();

            var loginResponse = icuTechService.Login(LoginCustomer.MapToServiceModel());

            TempData["IsSuccess"] = loginResponse.IsSuccess;
            TempData["Message"] = loginResponse.Message;
            TempData["CustomerInfo"] = loginResponse.ResponseBody;
            return RedirectToPage("/Index");
        }
    }

}
