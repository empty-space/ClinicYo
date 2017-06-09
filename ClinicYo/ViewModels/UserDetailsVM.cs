using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Domain.Model;

namespace ClinicYo.ViewModels
{
    public class UserDetailsVm
    {

        public UserDetailsVm(User user)
        {
            Id = user.Id;
            PIB = user.PIB;
            Login = user.Login;
            Rights = new List<AccessRightVm>() { new AccessRightVm { Allowed = true, Name = "AlloRight" }, new AccessRightVm { Name = "NeAlloRight" } };
            Menus = new List<MenuVm> { new MenuVm { Allowed = true, Name = "Allo" } , new MenuVm { Name = "NeAllo" } };
        }

        public int Id { get; set; }
        public string PIB { get; set; }
        public string Login { get; set; }
        public List<AccessRightVm> Rights { get; set; }
        public List<MenuVm> Menus { get; set; }

        public class MenuVm
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Allowed { get; set; }
        }
        public class AccessRightVm
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Allowed { get; set; }
        }
    }
}
