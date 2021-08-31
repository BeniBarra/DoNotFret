﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Models
{
    public class Category
    {
        [Required]
        public string Name { get; set; }
        public IList<Instrument> Instruments { get; set; }
    }
}
