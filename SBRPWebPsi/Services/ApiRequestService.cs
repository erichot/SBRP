using System.Text;
using System.Text.Json;



namespace SBRPWebPsi.Services
{
    public class ApiRequestService
    {
        private const string m_ServiceID = "ApiReque";
        private AppSettingsModel m_AppSettings { get; set; }
        private readonly IHttpClientFactory m_HttpClientFactory;


        public ApiRequestService(Microsoft.Extensions.Options.IOptions<AppSettingsModel> appSettings, IHttpClientFactory httpClientFactory)
        {
            m_AppSettings = appSettings.Value;
            m_HttpClientFactory = httpClientFactory;
        }





        public async Task<string> AuthenticateApiJwtToken(
            string _apiUrlRoot
            , WebUserTokenRequestEntity _webUserTokenRequestInfo)
        {
            string retJwtToken = string.Empty;
            string uri = _apiUrlRoot + ClientCallRequestModel.API_PATH_WebLogin;


            StringContent requestContent =
               new StringContent(
                       JsonSerializer.Serialize(_webUserTokenRequestInfo)
                       , Encoding.UTF8
                       , "application/json"
                   );
            var httpClient = m_HttpClientFactory.CreateClient(ClientCallRequestModel.HttpClientName);




            //try
            //{
               
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            using (var response = await httpClient.PostAsync(uri, requestContent))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                ApiTokenSignInResponseEntity responseJwt = JsonSerializer.Deserialize<ApiTokenSignInResponseEntity>(apiResponse);
                retJwtToken = responseJwt.token;
            }


            return retJwtToken;
        }




    }
}
