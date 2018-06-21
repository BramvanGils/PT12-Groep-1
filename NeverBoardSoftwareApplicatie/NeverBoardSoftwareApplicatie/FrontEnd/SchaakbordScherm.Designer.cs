namespace NeverBoardSoftwareApplicatie
{
    partial class SchaakbordScherm
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
            this.AnimatieTimer = new System.Windows.Forms.Timer(this.components);
            this.AnimatieBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AnimatieBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AnimatieTimer
            // 
            this.AnimatieTimer.Enabled = true;
            this.AnimatieTimer.Interval = 25;
            this.AnimatieTimer.Tick += new System.EventHandler(this.AnimatieTimer_Tick);
            // 
            // AnimatieBox
            // 
            this.AnimatieBox.Location = new System.Drawing.Point(347, 168);
            this.AnimatieBox.Name = "AnimatieBox";
            this.AnimatieBox.Size = new System.Drawing.Size(101, 104);
            this.AnimatieBox.TabIndex = 0;
            this.AnimatieBox.TabStop = false;
            // 
            // SchaakbordScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.ControlBox = false;
            this.Controls.Add(this.AnimatieBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SchaakbordScherm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SchaakbordScherm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.AnimatieBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer AnimatieTimer;
        private System.Windows.Forms.PictureBox AnimatieBox;
    }
}

