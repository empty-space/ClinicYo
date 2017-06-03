namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("WorkerKind")]
    public partial class WorkerKind
    {

        public WorkerKind()
        {
            Worker = new HashSet<Worker>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(400)]
        public string Description { get; set; }


        public virtual ICollection<Worker> Worker { get; set; }
    }
}
