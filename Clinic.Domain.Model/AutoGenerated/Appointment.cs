namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Appointment")]
    public partial class Appointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(400)]
        public string Comment { get; set; }

        public short State { get; set; }

        public int PatientId { get; set; }

        public int? WorkerId { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
