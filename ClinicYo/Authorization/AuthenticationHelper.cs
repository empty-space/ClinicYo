using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ClinicYo.Constants;

namespace ClinicYo.Authorization
{
    public class AuthenticationHelper
    {
        internal static int RetrieveCurrentUserId(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.TryGetValue(AuthorizationConstants.HeaderName, out var headerToken))
            {
                if (httpContext.Session.TryGetValue(headerToken, out byte[] value))
                {
                    var userId = BitConverter.ToInt32(value, 0);
                    //store id during request
                    httpContext.Items.Add(AuthorizationConstants.UserIdKey, userId);
                    return userId;
                }
                else
                {
                    throw new Exception("Session does not know provided token! Possible reason: token is invalidated");
                }
            }
            else
            {
                throw new Exception("No AuthorizationToken provided in the header!");
            }
        }
    }
}
