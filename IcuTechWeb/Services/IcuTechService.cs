using IcuTechServiceGateway;
using IcuTechWeb.ServiceModels.RequestModels;
using IcuTechWeb.ServiceModels.ResponseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace IcuTechWeb.Services
{
    public interface IIcuTechService
    {
        public LoginResponseModel Login(LoginRequestModel loginRequest);

        public RegisterResponseModel RegisterNewCustomer(RegisterRequestModel request);

        public string GetVersion();
    }

    public class IcuTechService : IIcuTechService
    {
        private readonly ICUTechClient client;

        public IcuTechService()
        {
            client = new ICUTechClient();
        }

        public string GetVersion() => client.GetVersion();

        public LoginResponseModel Login(LoginRequestModel loginRequest)
        {
            var responseJson = client.Login(loginRequest.Username, loginRequest.Password, loginRequest.Ip);

            var responseObj = JObject.Parse(responseJson);

            return new LoginResponseModel
            {
                IsSuccess = !String.IsNullOrWhiteSpace(responseObj["EntityId"]?.ToString()),
                ResponseBody = responseObj.ToString(),
                Message = responseObj["ResultMessage"]?.ToString()
            };
        }

        public RegisterResponseModel RegisterNewCustomer(RegisterRequestModel request)
        {
            var responseJson = client.RegisterNewCustomer(request.Email, request.Password, request.FirstName, request.LastName, request.Mobile, request.CountryID, request.aID, request.SignupIP);

            var responseObj = JObject.Parse(responseJson);

            return new RegisterResponseModel
            {
                IsSuccess = responseObj.ContainsKey("EntityId") && responseObj["EntityId"]?.ToString() != "-1",
                ResponseBody = responseObj.ToString(),
                Message = responseObj["ResultMessage"]?.ToString()
            };
        }
    }
}
