using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayAtTheRaces
{
    public class Bet
    {
        public int Amount;
        public int Car;
        public Bettor bettor;

        public string GetDescription()
        {
            return bettor.Name + " bets " + Amount + " on Vehicle #" + Car;
        }

        public int PayOut(int Winner)
        {
            if (this.Car == Winner)
            {
                return 2*Amount;
            }
            else
            {
                return -Amount;
            }
        }
    }
}
