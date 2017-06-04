using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clinic.DAL;
using Clinic.Domain.Model;
using ClinicYo.ViewModels;
using Microsoft.AspNetCore.Http;

namespace ClinicYo.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly UserRepository _userRepo;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthController(UserRepository userRepo, IHttpContextAccessor contextAccessor)
        {
            _userRepo = userRepo;
            _contextAccessor = contextAccessor;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpPost("[action]")]
        public string Login(LoginUserVm login)
        {
            var user = _userRepo.LogIn(login.Login, login.Password);
            var guid = Guid.NewGuid().ToString();
            _contextAccessor.HttpContext.Session.Set(guid, BitConverter.GetBytes(user.Id));
            return guid;
        }

        [HttpPost]
        public ActionResult Register(RegisterUserVm userVm)
        {
            var user = new User() { Login = userVm.Login, PIB = userVm.PIB };
            _userRepo.Register(user, userVm.Password);
            return new RedirectResult(Url.Action(nameof(HomeController.Index), "Home"));
        }

        public ActionResult LogOut()
        {
            _contextAccessor.HttpContext.Session.Clear();
            return new RedirectResult(Url.Action(nameof(HomeController.Index), "Home"));
        }
    }
}
