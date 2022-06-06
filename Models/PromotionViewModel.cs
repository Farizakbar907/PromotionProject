using System.Collections.Generic;

namespace ProjectPromotion.Models
{
    public class PromotionViewModel
    {
        public Promotion Promotion { get; set; }
        public IEnumerable<Stores> StoresViewModel { get; set; }
    }
}
