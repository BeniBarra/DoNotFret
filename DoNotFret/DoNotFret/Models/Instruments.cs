using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Models
{
    public class Instruments
    {
        public List<StringInstrument> StringInstruments { get; set; }
        public List<WindInstrument> WindInstruments { get; set; }
    }
}
