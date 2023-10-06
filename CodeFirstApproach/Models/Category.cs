namespace CodeFirstApproach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [StringLength(4)]
        public string CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
    }
}
