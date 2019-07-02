using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Customer
    {
        public double buyProbability;

        public Customer(Demand demand)
        {
            CustomerBuyProbability(demand);
        }
        public double CustomerBuyProbability(Demand demand)
        {
            Random rnd = new Random();
            buyProbability = rnd.Next(50, 90) / demand.priceDemand / demand.weatherDemand;
            return buyProbability;
        }
    }
}
