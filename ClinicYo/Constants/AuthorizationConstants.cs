using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicYo.Constants
{
    public class AuthorizationConstants
    {
        public const string HeaderName = "AuthorizationToken";
        //Для хранения в HttpContext.Items
        public const string UserIdKey = "currentUseId";
    }
}
