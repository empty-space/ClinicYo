namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Document")]
    public partial class Document
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Path { get; set; }

        public int? MedicalCardId { get; set; }

        public int? AnalisisId { get; set; }

        public virtual Analisis Analisis { get; set; }

        public virtual MedicalCard MedicalCard { get; set; }
    }
}
