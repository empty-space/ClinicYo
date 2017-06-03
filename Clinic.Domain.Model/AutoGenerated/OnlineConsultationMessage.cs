namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("OnlineConsultationMessage")]
    public partial class OnlineConsultationMessage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int OnlineConsultationId { get; set; }

        [Required]
        [StringLength(400)]
        public string Message { get; set; }

        public int UserId { get; set; }

        public virtual OnlineConsultation OnlineConsultation { get; set; }

        public virtual User User { get; set; }
    }
}
