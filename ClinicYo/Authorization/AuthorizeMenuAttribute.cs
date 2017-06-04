using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Clinic.DAL;

namespace ClinicYo.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeMenuAttribute : Attribute, IAuthorizationFilter
    {
        public AuthorizeMenuAttribute()
        {
        }

        public AuthorizeMenuAttribute(string menuGuid)
        {
            MenuGuid = new Guid(menuGuid);
        }

        public Guid MenuGuid { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.Request.Headers.TryGetValue("auth_token",out var headerToken))
            {
                ValidateMenuAccess(headerToken, context);
            }
            else
            {
                throw new Exception("No auth_token provided in the header!");
            }            
        }

        private void ValidateMenuAccess(StringValues headerToken,AuthorizationFilterContext context)
        {
            if(context.HttpContext.Session.TryGetValue(headerToken, out byte[] value))
            {                
                var userId = BitConverter.ToInt32(value, 0);
                var userRepo = context.HttpContext.RequestServices.GetService<UserRepository>();
                if(!userRepo.CheckMenuAccess(MenuGuid, userId))
                {
                    throw new Exception("Not allowed menu!");
                }
            }
            else
            {
                throw new Exception("Invalidated token or sth wrong!");
            }            
        }

        //protected virtual void FailAccess(AuthorizationFilterContext context, ECheckAccessResult result)
        //{
        //    if (context == null)
        //        throw new ArgumentNullException(nameof(context));
        //    context.Result = new StatusCodeResult((int)result);
        //}
    }
}
