using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clinic.DAL;
using Clinic.Domain.Model;
using ClinicYo.ViewModels;
using ClinicYo.Authorization;
using ClinicYo.Constants;
using ClinicYo.ViewModels.OnlineConsultaion;
using Clinic.DAL.Concrete;

namespace ClinicYo.Controllers
{
    [Route("api/online-consultation")]
    public class OnlineConsultationController : BaseController
    {
        public OnlineConsultationController(EFClinicDbRepository<AccessRight> rightsRepo)
        {
            var x = rightsRepo.Get();
        }

        [HttpGet("my-consultations")]
        [AuthorizeAccessRight(AccessRightConstants.MyConsultations)]
        public IEnumerable<OnlineConsultationVm> MyConsultations([FromServices]ConsultationsRepository _repo)
        {
            var currentUserId = (int)HttpContext.Items[AuthorizationConstants.UserIdKey];
            var myCons = _repo.GetByUserId(currentUserId)
                .Select(oc => new OnlineConsultationVm()
                {
                    Id = oc.Id,
                    IsClosed = oc.IsClosed,
                    Name = oc.Name,
                    WorkerId = oc.WorkerId,
                    WorkerName = oc.Worker.User.PIB,
                    Messages = oc.OnlineConsultationMessages
                    .Select(m => new OnlineConsultationMessageVm
                    {
                        Id = m.Id,
                        Message = m.Message,
                        userId = m.UserId,
                        senderName = m.User.PIB
                    }).ToList()
                });

            return myCons;
        }

        [HttpGet("{id}")]
        public UserDetailsVm Users(int id)
        {
            var user = ResolveDefaultDbRepository<User>().FindById(id);
            return new UserDetailsVm(user) { };
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
