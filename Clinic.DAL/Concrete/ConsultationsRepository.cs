using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Clinic.Domain.Model;

namespace Clinic.DAL.Concrete
{
    public class ConsultationsRepository : EFGenericRepository<ClinicDbContext, OnlineConsultation>
    {
        public ConsultationsRepository(ClinicDbContext context) : base(context)
        {
        }

        public List<OnlineConsultation> GetByUserId(int userId)
        {
            return _dbSet.Include(oc => oc.OnlineConsultationMessages)
                .Include(oc => oc.Worker)
                .ThenInclude(w => w.User)
                .Include(oc => oc.Patient)
                .ThenInclude(p => p.User)
                .Where(oc => oc.Patient.UserId == userId)
                .ToList();
        }
    }
}

