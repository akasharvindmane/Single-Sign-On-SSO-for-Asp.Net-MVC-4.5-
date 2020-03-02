namespace sample2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [Required]
        [StringLength(256)]
        public string username { get; set; }

        [Key]
        [StringLength(256)]
        public string email { get; set; }

        [Required]
        [StringLength(128)]
        public string pwd { get; set; }

        [Required]
        [StringLength(128)]
        public string role { get; set; }
    }
}
