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
        //static enum

        public Background()
        {
            InitializeComponent();

            Show();
            Hide();
            Show();

            IntroPictureBox.BackColor = Color.Transparent;
        }
    }
}
