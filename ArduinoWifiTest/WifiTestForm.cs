using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoWifiTest
{
    public partial class WifiTestForm : Form
    {
        //Fields
        ArduinoWifi Arduino;
        SqlVerbinding SQL;

        public WifiTestForm()
        {
            InitializeComponent();
        }
        //Methods
        public void StartRead() //Work in progress!
        {
            try
            {
                if (Arduino.Arduino.CanRead)
                {
                    byte[] Bytes = new byte[1024];
                    //Arduino.Arduino.BeginRead(Bytes, 0, Bytes.Length,/* Asynccallback*/, Arduino.Arduino);
                }
            }
            catch (SystemException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        //Eventhandlers
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    try
                    {
                        Arduino.Send(textBoxInvoer.Text);¶
                        textBoxInvoer.Text = "";
                    }
                    catch (SystemException Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPoort.Text != "")
            {
                labelPoort.Text = textBoxPoort.Text;
            }
            else
            {
                labelPoort.Text = "Poort";
            }
        }

        private void buttonVerbinden_Click(object sender, EventArgs e)
        {
            try
            {
                Arduino = new ArduinoWifi(textBoxIpAdres.Text, Convert.ToInt32(textBoxPoort.Text));
                buttonVerbinden.ForeColor = Color.Green;
            }
            catch (SystemException Ex)
            {
                buttonVerbinden.ForeColor = Color.Red;
                MessageBox.Show(Ex.Message);
            }
        }

        private void textBoxIpAdres_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIpAdres.Text != "")
            {
                labelIpAdres.Text = textBoxIpAdres.Text;
            }
            else
            {
                labelIpAdres.Text = "Ip Adres";
            }
        }

        private void trackBarX_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Arduino.Send("%X-" + Convert.ToString(trackBarX.Value));
            }
            catch (SystemException Ex)
            {
                if (Arduino != null)
                {
                    buttonVerbinden.ForeColor = Color.Red;
                }
                MessageBox.Show(Ex.Message);
            }
        }

        private void trackBarY_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Arduino.Send("%Y-" + Convert.ToString(trackBarY.Value));
            }
            catch (SystemException Ex)
            {
                if (Arduino != null)
                {
                    buttonVerbinden.ForeColor = Color.Red;
                }
                MessageBox.Show(Ex.Message);
            }
        }

        private void trackBarZ_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Arduino.Send("%Z-" + Convert.ToString(trackBarZ.Value));
            }
            catch (SystemException Ex)
            {
                if (Arduino != null)
                {
                    buttonVerbinden.ForeColor = Color.Red;
                }
                MessageBox.Show(Ex.Message);
            }
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            try
            {
                SQL.Close();
                listBoxSQL.Items.Clear();
                foreach (string Lijn in SQL.Query(textBoxInvoer.Text))
                {
                    listBoxSQL.Items.Add(Lijn);
                }
            }
            catch (SystemException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQL = new SqlVerbinding(textBoxSQL.Text);
            }
            catch (SystemException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void buttonArduino_Click(object sender, EventArgs e)
        {
            try
            {
                Arduino.Send(textBoxInvoer.Text);
                textBoxInvoer.Text = "";
                if (Arduino.DataAvailable)
                {
                    listBoxSQL.Items.Clear();
                    foreach (string Lijn in Arduino.Receive())
                    {
                        listBoxSQL.Items.Add(Lijn);
                    }
                }
            }
            catch (SystemException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void timerTemp_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Arduino.DataAvailable)
                {
                    listBoxSQL.Items.Clear();
                    foreach (string Lijn in Arduino.Receive())
                    {
                        listBoxSQL.Items.Add(Lijn);
                    }
                }
            }
            catch (SystemException Ex)
            {

            }
        }
    }
}
