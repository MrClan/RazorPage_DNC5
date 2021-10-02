using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcuTechWeb.ServiceModels.RequestModels
{
    public class LoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ip { get; set; }
    }
}
