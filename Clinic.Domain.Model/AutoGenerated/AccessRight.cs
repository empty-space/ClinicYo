namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("AccessRight")]
    public partial class AccessRight
    {

        public AccessRight()
        {
            UserAccessRight = new HashSet<UserAccessRight>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public Guid Guid { get; set; }

        public int? MenuId { get; set; }

        public virtual Menu Menu { get; set; }


        public virtual ICollection<UserAccessRight> UserAccessRight { get; set; }
    }
}
