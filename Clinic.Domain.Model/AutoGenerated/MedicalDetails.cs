namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class MedicalDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? MedicalCardId { get; set; }

        public short? BloodGroup { get; set; }

        public bool? RezusFactor { get; set; }

        [StringLength(400)]
        public string Alergies { get; set; }

        [StringLength(400)]
        public string ChronicDiseases { get; set; }

        public virtual MedicalCard MedicalCard { get; set; }
    }
}
