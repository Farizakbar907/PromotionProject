using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPromotion.Models
{
    [Keyless]
    public class Stores
    {
        [MaxLength(3)]
        public string Store { get; set; }

        [MaxLength(30)]
        public string StoreName { get; set; }
    }
}
