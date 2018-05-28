namespace ArduinoWifiTest
{
    partial class WifiTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.buttonArduino = new System.Windows.Forms.Button();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.textBoxInvoer = new System.Windows.Forms.TextBox();
            this.listBoxSQL = new System.Windows.Forms.ListBox();
            this.textBoxIpAdres = new System.Windows.Forms.TextBox();
            this.labelIpAdres = new System.Windows.Forms.Label();
            this.buttonVerbinden = new System.Windows.Forms.Button();
            this.textBoxPoort = new System.Windows.Forms.TextBox();
            this.labelPoort = new System.Windows.Forms.Label();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.trackBarZ = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSQL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timerTijdelijk = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarX
            // 
            this.trackBarX.LargeChange = 1;
            this.trackBarX.Location = new System.Drawing.Point(904, 116);
            this.trackBarX.Maximum = 180;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(130, 69);
            this.trackBarX.TabIndex = 11;
            this.trackBarX.ValueChanged += new System.EventHandler(this.trackBarX_ValueChanged);
            // 
            // buttonArduino
            // 
            this.buttonArduino.Location = new System.Drawing.Point(527, 400);
            this.buttonArduino.Name = "buttonArduino";
            this.buttonArduino.Size = new System.Drawing.Size(87, 32);
            this.buttonArduino.TabIndex = 10;
            this.buttonArduino.Text = "Arduino";
            this.buttonArduino.UseVisualStyleBackColor = true;
            this.buttonArduino.Click += new System.EventHandler(this.buttonArduino_Click);
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(434, 400);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(87, 32);
            this.buttonQuery.TabIndex = 8;
            this.buttonQuery.Text = "Query";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // textBoxInvoer
            // 
            this.textBoxInvoer.Location = new System.Drawing.Point(12, 403);
            this.textBoxInvoer.Name = "textBoxInvoer";
            this.textBoxInvoer.Size = new System.Drawing.Size(416, 26);
            this.textBoxInvoer.TabIndex = 7;
            // 
            // listBoxSQL
            // 
            this.listBoxSQL.FormattingEnabled = true;
            this.listBoxSQL.ItemHeight = 20;
            this.listBoxSQL.Location = new System.Drawing.Point(12, 12);
            this.listBoxSQL.Name = "listBoxSQL";
            this.listBoxSQL.Size = new System.Drawing.Size(775, 384);
            this.listBoxSQL.TabIndex = 6;
            // 
            // textBoxIpAdres
            // 
            this.textBoxIpAdres.Location = new System.Drawing.Point(794, 12);
            this.textBoxIpAdres.Name = "textBoxIpAdres";
            this.textBoxIpAdres.Size = new System.Drawing.Size(100, 26);
            this.textBoxIpAdres.TabIndex = 12;
            this.textBoxIpAdres.TextChanged += new System.EventHandler(this.textBoxIpAdres_TextChanged);
            // 
            // labelIpAdres
            // 
            this.labelIpAdres.AutoSize = true;
            this.labelIpAdres.Location = new System.Drawing.Point(900, 12);
            this.labelIpAdres.Name = "labelIpAdres";
            this.labelIpAdres.Size = new System.Drawing.Size(69, 20);
            this.labelIpAdres.TabIndex = 13;
            this.labelIpAdres.Text = "Ip Adres";
            // 
            // buttonVerbinden
            // 
            this.buttonVerbinden.Location = new System.Drawing.Point(794, 75);
            this.buttonVerbinden.Name = "buttonVerbinden";
            this.buttonVerbinden.Size = new System.Drawing.Size(100, 27);
            this.buttonVerbinden.TabIndex = 14;
            this.buttonVerbinden.Text = "Verbinden";
            this.buttonVerbinden.UseVisualStyleBackColor = true;
            this.buttonVerbinden.Click += new System.EventHandler(this.buttonVerbinden_Click);
            // 
            // textBoxPoort
            // 
            this.textBoxPoort.Location = new System.Drawing.Point(794, 43);
            this.textBoxPoort.Name = "textBoxPoort";
            this.textBoxPoort.Size = new System.Drawing.Size(100, 26);
            this.textBoxPoort.TabIndex = 15;
            this.textBoxPoort.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // labelPoort
            // 
            this.labelPoort.AutoSize = true;
            this.labelPoort.Location = new System.Drawing.Point(900, 43);
            this.labelPoort.Name = "labelPoort";
            this.labelPoort.Size = new System.Drawing.Size(47, 20);
            this.labelPoort.TabIndex = 16;
            this.labelPoort.Text = "Poort";
            // 
            // trackBarY
            // 
            this.trackBarY.LargeChange = 1;
            this.trackBarY.Location = new System.Drawing.Point(904, 175);
            this.trackBarY.Maximum = 180;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Size = new System.Drawing.Size(130, 69);
            this.trackBarY.TabIndex = 17;
            this.trackBarY.ValueChanged += new System.EventHandler(this.trackBarY_ValueChanged);
            // 
            // trackBarZ
            // 
            this.trackBarZ.LargeChange = 1;
            this.trackBarZ.Location = new System.Drawing.Point(904, 233);
            this.trackBarZ.Maximum = 180;
            this.trackBarZ.Name = "trackBarZ";
            this.trackBarZ.Size = new System.Drawing.Size(130, 69);
            this.trackBarZ.TabIndex = 18;
            this.trackBarZ.ValueChanged += new System.EventHandler(this.trackBarZ_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(874, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(874, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(875, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Z:";
            // 
            // textBoxSQL
            // 
            this.textBoxSQL.Location = new System.Drawing.Point(793, 307);
            this.textBoxSQL.Name = "textBoxSQL";
            this.textBoxSQL.Size = new System.Drawing.Size(342, 26);
            this.textBoxSQL.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(793, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 27);
            this.button1.TabIndex = 23;
            this.button1.Text = "SQL ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerTijdelijk
            // 
            this.timerTijdelijk.Enabled = true;
            this.timerTijdelijk.Interval = 5000;
            this.timerTijdelijk.Tick += new System.EventHandler(this.timerTemp_Tick);
            // 
            // WifiTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 438);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxSQL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarZ);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.labelPoort);
            this.Controls.Add(this.textBoxPoort);
            this.Controls.Add(this.buttonVerbinden);
            this.Controls.Add(this.labelIpAdres);
            this.Controls.Add(this.textBoxIpAdres);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.buttonArduino);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.textBoxInvoer);
            this.Controls.Add(this.listBoxSQL);
            this.Name = "WifiTestForm";
            this.Text = "ArduinoWifi";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.Button buttonArduino;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.TextBox textBoxInvoer;
        private System.Windows.Forms.ListBox listBoxSQL;
        private System.Windows.Forms.TextBox textBoxIpAdres;
        private System.Windows.Forms.Label labelIpAdres;
        private System.Windows.Forms.Button buttonVerbinden;
        private System.Windows.Forms.TextBox textBoxPoort;
        private System.Windows.Forms.Label labelPoort;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.TrackBar trackBarZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSQL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerTijdelijk;
    }
}

