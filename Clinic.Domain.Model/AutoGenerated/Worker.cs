namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Worker")]
    public partial class Worker
    {

        public Worker()
        {
            Appointment = new HashSet<Appointment>();
            MedicalCardRecord = new HashSet<MedicalCardRecord>();
            OnlineConsultation = new HashSet<OnlineConsultation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int? WorkerKindId { get; set; }


        public virtual ICollection<Appointment> Appointment { get; set; }


        public virtual ICollection<MedicalCardRecord> MedicalCardRecord { get; set; }


        public virtual ICollection<OnlineConsultation> OnlineConsultation { get; set; }

        public virtual User User { get; set; }

        public virtual WorkerKind WorkerKind { get; set; }
    }
}
