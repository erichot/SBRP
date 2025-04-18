namespace SBRPWebPortal.Models
{
    public class AppDataModel
    {
    }














    public class ClientHttpContext
    {
        public ClientHttpContext(string _localIpAddress, string _remoteIpAddress)
        {
            LocalIpAddress = _localIpAddress;
            RemoteIpAddress = _remoteIpAddress;
        }

        public ClientHttpContext(IHttpContextAccessor _accessor)
        {
            if (_accessor != null && _accessor.HttpContext != null && _accessor.HttpContext.Connection != null)
            {
                string sRemoteIpAddress = string.Empty;
                if (_accessor.HttpContext.Connection.RemoteIpAddress != null)
                    LocalIpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

                string sLocalIpAddress = string.Empty;
                if (_accessor.HttpContext.Connection.LocalIpAddress != null)
                    RemoteIpAddress = _accessor.HttpContext.Connection.LocalIpAddress.ToString();
            }
        }

        public string RemoteIpAddress { get; set; }
        public string LocalIpAddress { get; set; }

    }

}
