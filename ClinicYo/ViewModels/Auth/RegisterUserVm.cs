using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicYo.ViewModels
{
    public class RegisterUserVm
    {
        [Required]
        [StringLength(200)]
        public string PIB { get; set; }

        [Required]
        [StringLength(40)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

    }
}
