namespace DragonAPI.UI
{
    partial class WND_SPLASH
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
            this.ABOUT_TITLE = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ABOUT_TITLE
            // 
            this.ABOUT_TITLE.BackColor = System.Drawing.Color.Transparent;
            this.ABOUT_TITLE.Dock = System.Windows.Forms.DockStyle.Top;
            this.ABOUT_TITLE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ABOUT_TITLE.Font = new System.Drawing.Font("Nirmala UI", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ABOUT_TITLE.Location = new System.Drawing.Point(0, 0);
            this.ABOUT_TITLE.Name = "ABOUT_TITLE";
            this.ABOUT_TITLE.Size = new System.Drawing.Size(448, 53);
            this.ABOUT_TITLE.TabIndex = 0;
            this.ABOUT_TITLE.Text = "DragonAPI";
            this.ABOUT_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "v0.0.1a1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // WND_SPLASH
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.BackgroundImage = global::DragonAPI.Properties.Resources.SplashScreen_Default;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(448, 311);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ABOUT_TITLE);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Poppins", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WND_SPLASH";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading... | DragonAPI";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ABOUT_TITLE;
        private System.Windows.Forms.Label label1;
    }
}