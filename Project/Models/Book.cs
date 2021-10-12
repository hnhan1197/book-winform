namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            InvoiceInfoes = new HashSet<InvoiceInfo>();
        }

        [StringLength(10)]
        public string BookID { get; set; }

        [Required]
        [StringLength(255)]
        public string BookName { get; set; }

        public int PublishingYear { get; set; }

        public int QuantityInStock { get; set; }

        public double Price { get; set; }

        public int AuthorID { get; set; }

        public int PubCompID { get; set; }

        [Required]
        [StringLength(3)]
        public string CategoryID { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual PublishingCompany PublishingCompany { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceInfo> InvoiceInfoes { get; set; }
    }
}
