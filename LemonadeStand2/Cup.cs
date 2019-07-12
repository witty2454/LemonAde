using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{

    public class Cup : Supply
    {
        public Cup()
        {
            price = .10;
            name = "cup";
        }
    }
}