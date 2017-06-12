using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Clinic.DAL;
using Clinic.DAL.Concrete;

namespace ClinicYo.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAccessRightAttribute : Attribute, IAuthorizationFilter
    {    
        private Guid _accessRightGuid;   

        public AuthorizeAccessRightAttribute(string accessRightGuid)
        {
            _accessRightGuid = new Guid(accessRightGuid);
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userId = AuthenticationHelper.RetrieveCurrentUserId(context.HttpContext);
            var userRepo = context.HttpContext.RequestServices.GetService<UserRepository>();
            if (!userRepo.CheckAccessRight(_accessRightGuid, userId))
            {
                throw new Exception("Access denied!");
            }
        }
       
        //public void OnAuthorization(AuthorizationFilterContext context)
        //{
        //    if (context.HttpContext.Request.Headers.TryGetValue("AuthorizationToken", out var headerToken))
        //    {
        //        AuthorizeAccess(headerToken, context);
        //    }
        //    else
        //    {
        //        throw new Exception("No AuthorizationToken provided in the header!");
        //    }
        //}

        //private void AuthorizeAccess(StringValues headerToken,AuthorizationFilterContext context)
        //{
        //    if(context.HttpContext.Session.TryGetValue(headerToken, out byte[] value))
        //    {                
        //        var userId = BitConverter.ToInt32(value, 0);
        //        var userRepo = context.HttpContext.RequestServices.GetService<UserRepository>();
        //        if(!userRepo.CheckAccessRight(_accessRightGuid, userId))
        //        {
        //            throw new Exception("You dont have rights!");
        //        }                
        //        context.HttpContext.Items.Add("currentUserId", userId);
        //    }
        //    else
        //    {
        //        throw new Exception("Invalidated token or sth wrong!");
        //    }            
        //}
    }
}
