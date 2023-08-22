namespace test.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plaka")]
    public partial class Plaka
    {
        public int id { get; set; }

        [Column("Plaka")]
        [Required]
        [StringLength(50)]
        public string Plaka1 { get; set; }
    }
}
