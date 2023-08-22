namespace test.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kantar")]
    public partial class Kantar
    {
        public int id { get; set; }

        [StringLength(50)]
        public string UretimYeri { get; set; }

        [StringLength(50)]
        public string KantarNo { get; set; }

        [StringLength(50)]
        public string Plaka { get; set; }

        public string Base64 { get; set; }

        [StringLength(50)]
        public string confidences { get; set; }

        [StringLength(50)]
        public string displayNames { get; set; }

        [StringLength(50)]
        public string ids { get; set; }

        [StringLength(50)]
        public string deployedModelId { get; set; }

        public string model { get; set; }

        [StringLength(50)]
        public string modelDisplayName { get; set; }

        [StringLength(50)]
        public string modelVersionId { get; set; }

        public DateTime? AddTimeStamp { get; set; }

        [StringLength(50)]
        public string APITimeStamp { get; set; }
    }
}
