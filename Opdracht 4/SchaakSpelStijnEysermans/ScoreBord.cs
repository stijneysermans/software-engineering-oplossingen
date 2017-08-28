using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchaakSpelStijn
{
    public partial class ScoreBord : UserControl
    {
        SchaakController mController;
        //constructor
        public ScoreBord(SchaakController controller)
        {
            InitializeComponent();
            mController = controller;
        }
        private void ScoreBord_Load(object sender, EventArgs e)
        {
        }
        //score wordt aan scoreboard toegevoegd
        public void addScore(string doodStuk)
        {
            if (doodStuk.Substring(0, 1) == "w")
            {
                txtWhiteLost.Text += Environment.NewLine + doodStuk;
            }
            else
            {
                txtBlackLost.Text += Environment.NewLine + doodStuk;
            }        
        }
    }
}
