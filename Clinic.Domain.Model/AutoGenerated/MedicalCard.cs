namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("MedicalCard")]
    public partial class MedicalCard
    {

        public MedicalCard()
        {
            Documents = new HashSet<Document>();
            MedicalCardRecords = new HashSet<MedicalCardRecord>();
            MedicalDetails = new HashSet<MedicalDetails>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int PatientId { get; set; }

        public short BloodGroup { get; set; }

        public bool RezusFactor { get; set; }
        

        public virtual Patient Patient { get; set; }

        public virtual ICollection<Document> Documents { get; set; }


        public virtual ICollection<MedicalCardRecord> MedicalCardRecords { get; set; }


        public virtual ICollection<MedicalDetails> MedicalDetails { get; set; }
    }
}
