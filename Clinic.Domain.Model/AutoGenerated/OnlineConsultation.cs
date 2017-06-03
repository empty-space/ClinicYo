namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("OnlineConsultation")]
    public partial class OnlineConsultation
    {

        public OnlineConsultation()
        {
            OnlineConsultationMessage = new HashSet<OnlineConsultationMessage>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsClosed { get; set; }

        public int WorkerId { get; set; }

        public virtual Worker Worker { get; set; }


        public virtual ICollection<OnlineConsultationMessage> OnlineConsultationMessage { get; set; }
    }
}
