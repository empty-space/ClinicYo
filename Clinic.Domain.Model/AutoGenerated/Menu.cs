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
            AccessRight = new HashSet<AccessRight>();
            Menus = new HashSet<Menu>();
            UserMenus = new HashSet<UserMenu>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public int? ParentMenuId { get; set; }
        
        public Guid Guid { get; set; }


        public virtual ICollection<AccessRight> AccessRight { get; set; }


        public virtual ICollection<Menu> Menus { get; set; }

        [ForeignKey(nameof(ParentMenuId))]
        public virtual Menu ParentMenu { get; set; }


        public virtual ICollection<UserMenu> UserMenus { get; set; }
    }
}
