using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectPromotion.Models
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Promotion Id")]
        public string IdPromotion { get; set; }

        [Display(Name = "Promotion Description")]
        [MaxLength(50)]
        public string PromoDescription { get; set; }

        [Display(Name = "Promotion Type")]
        public string PromoType { get; set; }

        [Display(Name = "Promotion Duration")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string PromoDuration { get; set; }

        [Display(Name = "Value Type")]
        public int? ValueType { get; set; }

        [Display(Name = "Item")]
        [NotMapped]
        public IFormFile Item { get; set; }
    }
}
