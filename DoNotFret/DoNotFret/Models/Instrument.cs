using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public string InstrumentType { get; set; }
        public string Brand { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
    }
}
