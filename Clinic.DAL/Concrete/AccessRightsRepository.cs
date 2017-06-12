using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Clinic.Domain.Model;

namespace Clinic.DAL.Concrete
{
    public class AccessRightsRepository : EFGenericRepository<ClinicDbContext, AccessRight>
    {
        public AccessRightsRepository(ClinicDbContext context) : base(context)
        {
        }       
    }
}

