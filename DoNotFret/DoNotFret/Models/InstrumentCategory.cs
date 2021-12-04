using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Models
{
    public class InstrumentCategory
    {
        public int CategoryId { get; set; }
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
        public Category Category { get; set; }
    }
}
