namespace Clinic.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("UserAccessRight")]
    public partial class UserAccessRight
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int AccessRightId { get; set; }

        public virtual AccessRight AccessRight { get; set; }

        public virtual User User { get; set; }
    }
}
