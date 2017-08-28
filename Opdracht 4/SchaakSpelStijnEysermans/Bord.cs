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
    public partial class Bord : UserControl
    {
        public int posX, posY;
        public string lblInhoud;
        private SchaakController controller;  
        //contructor
        public Bord(SchaakController deController)
        {
            InitializeComponent();            
            controller = deController;
        }       
        private void BoardSquare_Load(object sender, EventArgs e)
        {          
        }
        //click event tile
        private void BoardSquare_Click(object sender, EventArgs e)
        {
            controller.TileClick(this);
        }
    }
}
