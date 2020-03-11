using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayAtTheRaces
{
    public class Bettor
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyRadioButton.Text = this.Name + " has " + Cash + "$";

            if (MyBet == null)
            {
                MyLabel.Text = this.Name + " has not placed a bet.";
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }

        }

        public void ClearBet()
        {
            this.MyBet = null;
        }

        public bool PlaceBet(int BetAmount, int VehicleToWin)
        {
            if (BetAmount <= Cash)
            {
                MyBet = new Bet()
                { Amount = BetAmount, Car = VehicleToWin, bettor = this };

                UpdateLabels();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Collect(int Winner)
        {
            if (MyBet != null)
            Cash += MyBet.PayOut(Winner);

            ClearBet();
            UpdateLabels();
        }
    }
}
