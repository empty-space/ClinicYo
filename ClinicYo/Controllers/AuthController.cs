using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clinic.DAL;
using Clinic.Domain.Model;
using ClinicYo.ViewModels;
using Microsoft.AspNetCore.Http;
using ClinicYo.Authorization;
using Clinic.DAL.Concrete;

namespace ClinicYo.Controllers
{
    public class AuthController : BaseController
    {
        private readonly UserRepository _userRepo;

        public AuthController(UserRepository userRepo)
        {
            _userRepo = userRepo;

        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpPost]
        //!Нельзя чтоб имя действия и имя типа или свойства входящего параметра совпадали!
        public UserCreatentials Login([FromForm]LoginUserVm login)
        {
            var user = _userRepo.LogIn(login.UserLogin, login.Password);
            var token = Guid.NewGuid().ToString();
            HttpContext.Session.Set(token, BitConverter.GetBytes(user.Id));

            return new UserCreatentials { AccessToken = token,
                Login = user.Login,
                MenuNames = _userRepo.GetMenuNames(user.Id) };
        }


        [HttpPost]
        public ActionResult Register(RegisterUserVm userVm)
        {
            var user = new User() { Login = userVm.Login, PIB = userVm.PIB };
            _userRepo.Register(user, userVm.Password);
            return Ok();
        }

        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return new RedirectResult(Url.Action(nameof(HomeController.Index), "Home"));
        }

        [HttpPost]
        public bool IsAthorized(string token)
        {
            //Проверяем есть ли хедер "AuthorizationToken" и знает ли сессия этот токен
            var checkResult = // HttpContext.Request.Headers.TryGetValue("AuthorizationToken", out var headerToken) && 
                HttpContext.Session.TryGetValue(token, out var x);

            return checkResult;
        }
    }
}
