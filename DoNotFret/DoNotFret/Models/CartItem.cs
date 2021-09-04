using DoNotFret.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Models
{
    public class CartItem
    {
        public int CartId { get; set; }
        public int InstrumentId { get; set; }
        public Cart Cart { get; set; }
        public Instrument Instrument { get; set; }
    }
}
