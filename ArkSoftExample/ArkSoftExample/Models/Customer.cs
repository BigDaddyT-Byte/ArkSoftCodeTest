namespace ArkSoftExample.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Adress { get; set; }

        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Contact Name")]
        public string contactName { get; set; }

        [Display(Name = "Contact Email")]
        public string contactEmail { get; set; }

        [Display(Name = "VAT Number")]
        [StringLength(10)]
        public string VATNumber { get; set; }
    }
}
