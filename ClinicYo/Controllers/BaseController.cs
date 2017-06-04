using Clinic.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicYo.Controllers
{
    public class BaseController:Controller
    {
        protected EFClinicDbRepository<TEntity> ResolveDefaultDbRepository<TEntity>() where TEntity : class 
        {
            return (EFClinicDbRepository<TEntity>)HttpContext.RequestServices.GetService(typeof(EFClinicDbRepository<TEntity>));
        }     
        protected EFGenericRepository<TContext,TEntity> ResolveRepository<TContext,TEntity>() where TEntity : class where TContext:DbContext
        {
            return (EFGenericRepository<TContext,TEntity>)HttpContext.RequestServices.GetService(typeof(EFGenericRepository<TContext,TEntity>));
        }

    }
}
