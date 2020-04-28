using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dapper_tutorial.Models
{
    public class CoffeesViewModel
    {
        public IEnumerable<CoffeeNameAndId> Coffees { get; set; }
    }
}
