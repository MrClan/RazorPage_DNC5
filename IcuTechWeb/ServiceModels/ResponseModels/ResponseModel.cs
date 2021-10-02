namespace IcuTechWeb.ServiceModels.ResponseModels
{
    public class BaseResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string ResponseBody { get; set; }
    }
}
