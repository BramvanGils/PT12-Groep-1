namespace NeverBoardSoftwareApplicatie
{
    partial class Background
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
            this.IntroPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IntroPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AnimatieTimer
            // 
            this.AnimatieTimer.Enabled = true;
            // 
            // IntroPictureBox
            // 
            this.IntroPictureBox.Location = new System.Drawing.Point(0, 0);
            this.IntroPictureBox.Name = "IntroPictureBox";
            this.IntroPictureBox.Size = new System.Drawing.Size(1904, 1041);
            this.IntroPictureBox.TabIndex = 2;
            this.IntroPictureBox.TabStop = false;
            // 
            // Background
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.ControlBox = false;
            this.Controls.Add(this.IntroPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Background";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.IntroPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer AnimatieTimer;
        private System.Windows.Forms.PictureBox IntroPictureBox;
    }
}

