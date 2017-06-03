namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Patient")]
    public partial class Patient
    {

        public Patient()
        {
            Appointment = new HashSet<Appointment>();
            MedicalCard = new HashSet<MedicalCard>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(8)]
        public string Passport { get; set; }

        [StringLength(30)]
        public string Code { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public Guid? CardID { get; set; }

        public bool? IsApproved { get; set; }


        public virtual ICollection<Appointment> Appointment { get; set; }


        public virtual ICollection<MedicalCard> MedicalCard { get; set; }

        public virtual User User { get; set; }
    }
}
