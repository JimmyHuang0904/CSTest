using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();
    
        List<string> icons = new List<string>()
       {
           "!", "!", "N", "N", ",", ",", "k", "k",
           "b", "b", "v", "v", "w", "w", "z", "z"
       };

        Label firstClicked = null;
        Label secondClicked = null;

        int count = 0;
        

        private void AssignIconsToSquare()
        {
            foreach (Control controlasdf in tableLayoutPanel1.Controls)
            {
                Label iconLabel = controlasdf as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];

                    iconLabel.ForeColor = iconLabel.BackColor;

                    //iconLabel.ForeColor = Color.Black;
                    //iconLabel.Visible = false;

                    icons.RemoveAt(randomNumber);
                }
            }
        }

        
       public Form1()
       {
           InitializeComponent();
           AssignIconsToSquare();
           timer2.Start();
       }

       private void label_Click(object sender, EventArgs e)
       {
           // The timer is only on after two non-matching
           // icons have been shown to the player,
           // so ignore any clicks if the timer is running
           if (timer1.Enabled == true)
               return;
           
           Label clickedLabel = sender as Label;

           if (clickedLabel != null)
           {
               //If the clicked label is black, the player clicked an icon
               //that's already been revealed and ignore the click

               if (clickedLabel.ForeColor == Color.Black)
                   return;

               if (firstClicked == null)
               {
                   firstClicked = clickedLabel;
                   clickedLabel.ForeColor = Color.Black;

                   return;
               }

               // If the player gets this far, the timer isn't
               // running and firstClicked isn't null,
               // so this must be the second icon the player clicked
               // Set its color to black
               secondClicked = clickedLabel;
               clickedLabel.ForeColor = Color.Black;

               if (secondClicked.Text == firstClicked.Text)
               {
                   firstClicked = null;
                   secondClicked = null;
                   CheckForWinner();
                   return;                   
               }


               timer1.Start();



               /* -- TESTING
               if (clickedLabel.Visible == true)
                   return;
               clickedLabel.Visible = true;
               */
           }
       }

       private void timer1_Tick(object sender, EventArgs e)
       {
           timer1.Stop();

           firstClicked.ForeColor = firstClicked.BackColor;
           secondClicked.ForeColor = secondClicked.BackColor;

           firstClicked = null;
           secondClicked = null;
       }

       private void CheckForWinner()
       {
           foreach (Control control in tableLayoutPanel1.Controls)
           {
               Label iconLabel = control as Label;

               //if (iconLabel != null)  <-- take out 3 x // 
               //{
                   if (iconLabel.ForeColor == iconLabel.BackColor)
                       return;
               //}
           }
           timer2.Stop();
           MessageBox.Show("You matched all the icons!", "Congratulations");
           Close();
       }

       private void timer2_Tick(object sender, EventArgs e)
       {
           count++;
           timeLabel.Text = count + " s";
           
       }

    }
}
