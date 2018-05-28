using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeverBoardSoftwareApplicatie
{
    public partial class Background : Form
    {
        public Background()
        {
            
            InitializeComponent();
            
            Show();
            Hide();
            Show();

            BackColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Opacity = 100;
            Graphics gfx = CreateGraphics();
            Pen p = new Pen(Color.Red);
            gfx.DrawRectangle(p,new Rectangle(new Point(0,0),new Size(1919,1079)));
        }
    }
}
