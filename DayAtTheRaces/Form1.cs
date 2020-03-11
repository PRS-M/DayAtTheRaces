using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayAtTheRaces
{
    public partial class Form1 : Form
    {
        Vehicle[] vehiclesArray = new Vehicle[4];
        Bettor[] bettorsArray = new Bettor[3];
        Random MyRandomizer = new Random();

        public Form1()
        {
            InitializeComponent();
            RaceTrackSetup();
        }

        private void RaceTrackSetup()
        {
            vehiclesArray[0] = new Vehicle()
            {
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width,
                Randomizer = MyRandomizer
            };

            vehiclesArray[1] = new Vehicle()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width,
                Randomizer = MyRandomizer
            };

            vehiclesArray[2] = new Vehicle()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width,
                Randomizer = MyRandomizer
            };

            vehiclesArray[3] = new Vehicle()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width,
                Randomizer = MyRandomizer
            };

            bettorsArray[0] = new Bettor()
            {
                Name = "Joe",
                Cash = 50,
                MyRadioButton = joeRadioButton,
                MyLabel = joeBetLabel,
            };

            bettorsArray[1] = new Bettor()
            {
                Name = "Bob",
                Cash = 75,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel,
                
            };

            bettorsArray[2] = new Bettor()
            {
                Name = "Al",
                Cash = 45,
                MyRadioButton = alRadioButton,
                MyLabel = alBetLabel,
            };

            foreach (Bettor bettor in bettorsArray)
            {
                bettor.UpdateLabels();
            }

            minimumBetLabel.Text = "Minimum bet: " + numericUpDown1.Minimum +"$";

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < vehiclesArray.Length; i++)
            {
                if (vehiclesArray[i].Drive())
                {
                    timer1.Stop();
                    // timer1.Enabled = false;
                    int RealNo = i + 1;
                    MessageBox.Show("Car #" + RealNo + " won!");
                    for (int j = 0; j < 3; j++)
                    {
                        bettorsArray[j].Collect(RealNo);
                    }

                    bettingParlor.Enabled = true;

                    break;
                }
            }
        }

        private void RaceButton_Click(object sender, EventArgs e)
        {
            bettingParlor.Enabled = false;

            foreach (Vehicle vehicle in vehiclesArray)
            {
                vehicle.TakeStartingPosition();
            }

            timer1.Start();
        }

        private void BetButton_Click(object sender, EventArgs e)
        {
            int bettorNumber;
            if (joeRadioButton.Checked)
            {
                bettorNumber = 0;
            }
            else if (bobRadioButton.Checked)
            {
                bettorNumber = 1;
            }
            else
            {
                bettorNumber = 2;
            }

            bettorsArray[bettorNumber].PlaceBet((int) numericUpDown1.Value, (int) numericUpDown2.Value);
        }
    }
}
