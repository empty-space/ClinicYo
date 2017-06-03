namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("MedicalCardRecord")]
    public partial class MedicalCardRecord
    {

        public MedicalCardRecord()
        {
            Analisis = new HashSet<Analisis>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(400)]
        public string Text { get; set; }

        public bool IsCrossedOut { get; set; }

        public int MedicalCardId { get; set; }

        public int WorkerId { get; set; }


        public virtual ICollection<Analisis> Analisis { get; set; }

        public virtual MedicalCard MedicalCard { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
