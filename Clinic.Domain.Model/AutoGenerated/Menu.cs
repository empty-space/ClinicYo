namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Menu")]
    public partial class Menu
    {

        public Menu()
        {
            Menu1 = new HashSet<Menu>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public int RoleId { get; set; }

        public int? ParentMenuId { get; set; }


        public virtual ICollection<Menu> Menu1 { get; set; }

        public virtual Menu Menu2 { get; set; }

        public virtual Role Role { get; set; }
    }
}
