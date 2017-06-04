using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Clinic.DAL
{
    public class EFClinicDbRepository<TEntity> : EFGenericRepository<ClinicDbContext, TEntity>  where TEntity : class
    {       

        public EFClinicDbRepository(ClinicDbContext context):base(context)
        {
        }        
    }
}
