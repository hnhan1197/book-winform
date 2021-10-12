namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string DisplayName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
