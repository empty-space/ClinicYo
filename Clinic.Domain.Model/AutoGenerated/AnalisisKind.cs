namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("AnalisisKind")]
    public partial class AnalisisKind
    {

        public AnalisisKind()
        {
            Analisis = new HashSet<Analisis>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }


        public virtual ICollection<Analisis> Analisis { get; set; }
    }
}
