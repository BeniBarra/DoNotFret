using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Instruments { get; set; } = new List<CartItem>();
    }
}
