using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SBRPAPIPsi.Services
{
    public class ClientIpCheckActionFilter: ActionFilterAttribute
    {


        private readonly ILogger _logger;
        private readonly string _safelist;
        private readonly bool m_IsDevelopment;
        public ClientIpCheckActionFilter(string safelist, ILogger logger, bool _isDevelopment)
        {
            _safelist = safelist;
            _logger = logger;
            m_IsDevelopment = _isDevelopment;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (m_IsDevelopment)
            {
                base.OnActionExecuting(context);
                return;
            }

            var remoteIp = context.HttpContext.Connection.RemoteIpAddress;
            _logger.LogDebug("Remote IpAddress: {RemoteIp}", remoteIp);

            
            var safeIpList = _safelist.Split(';');
            var badIp = true;           

            if (remoteIp.IsIPv4MappedToIPv6)
            {
                remoteIp = remoteIp.MapToIPv4();
            }

            // ::1
            if (remoteIp == null || string.IsNullOrEmpty(remoteIp.ToString()) || remoteIp.ToString() == "::1")
                return;



            foreach (var safeIpAddress in safeIpList)
            {
                var safeIp = IPAddress.Parse(safeIpAddress);

                if (safeIp.Equals(remoteIp))
                {
                    badIp = false;
                    break;
                }
            }

            if (badIp)
            {
                _logger.LogWarning("Forbidden Request from IP: {RemoteIp}", remoteIp);
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                return;
            }

            base.OnActionExecuting(context);
        }


    }
}
