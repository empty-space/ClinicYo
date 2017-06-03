namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Analisis
    {

        public Analisis()
        {
            Documents = new HashSet<Document>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public short State { get; set; }

        public int AnalisisKindId { get; set; }

        public int? MedicalCardRecordId { get; set; }

        [Required]
        [StringLength(400)]
        public string Comment { get; set; }

        public virtual AnalisisKind AnalisisKind { get; set; }

        public virtual MedicalCardRecord MedicalCardRecord { get; set; }


        public virtual ICollection<Document> Documents { get; set; }
    }
}
