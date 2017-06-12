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

namespace ClinicYo.Controllers
{
    public class SampleDataController : BaseController
    {
        public SampleDataController(EFClinicDbRepository<AccessRight> rightsRepo)
        {
            var x = rightsRepo.Get();
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        
        [AuthorizeAccessRight(AccessRightConstants.UserList)]
        public IEnumerable<User> Users()
        {
            var users = ResolveDefaultDbRepository<User>().Get();
            return users;
        }

        [HttpGet("[action]/{id}")]
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
