namespace CodeFirstApproach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [StringLength(4)]
        public string ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        public int? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfPurchase { get; set; }

        public int? AvailableStatus { get; set; }

        [StringLength(4)]
        public string CategoryId { get; set; }

        [StringLength(2)]
        public string BrandId { get; set; }

        public int? Active { get; set; }

        public string Image { get; set; }
    }
}
