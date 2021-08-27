using DoNotFret.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Models
{
    public class UserCart
    {
        //Join table that connects one user to one cart.
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public AuthUser AuthUser { get; set; }
    }
}
