namespace CodeFirstApproach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brand")]
    public partial class Brand
    {
        [StringLength(4)]
        public string BrandId { get; set; }

        [Required]
        [StringLength(100)]
        public string BrandName { get; set; }
    }
}
