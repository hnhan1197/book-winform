namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoiceInfo")]
    public partial class InvoiceInfo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string BookID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceID { get; set; }

        public int Count { get; set; }

        public virtual Book Book { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
