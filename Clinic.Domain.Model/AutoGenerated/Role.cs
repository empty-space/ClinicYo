namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Role")]
    public partial class Role
    {

        public Role()
        {
            AccessRight = new HashSet<AccessRight>();
            Menu = new HashSet<Menu>();
            UserRole = new HashSet<UserRole>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }


        public virtual ICollection<AccessRight> AccessRight { get; set; }


        public virtual ICollection<Menu> Menu { get; set; }


        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
