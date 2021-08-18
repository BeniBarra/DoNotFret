using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Models
{
    public class Instruments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public InstrumentType InstrumentType { get; set; }

    }

    public enum InstrumentType
    {
        String,
        Woodwind,
        Brass,
        Keyboard,
        Percussion
    }
}
