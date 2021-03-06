namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {

        public User()
        {
            //Guid = Guid.NewGuid();
            OnlineConsultationMessage = new HashSet<OnlineConsultationMessage>();
            Patient = new HashSet<Patient>();
            UserAccessRight = new HashSet<UserAccessRight>();
            UserMenus = new HashSet<UserMenu>();
            Worker = new HashSet<Worker>();
        }

        public int Id { get; set; }

        //public Guid Guid { get; set; }

        [Required]
        [StringLength(200)]
        public string PIB { get; set; }

        [Required]
        [StringLength(40)]
        public string Login { get; set; }

        [MaxLength(50)]
        public byte[] PasswordHash { get; set; }


        public virtual ICollection<OnlineConsultationMessage> OnlineConsultationMessage { get; set; }


        public virtual ICollection<Patient> Patient { get; set; }


        public virtual ICollection<UserAccessRight> UserAccessRight { get; set; }


        public virtual ICollection<UserMenu> UserMenus { get; set; }


        public virtual ICollection<Worker> Worker { get; set; }
    }
}
