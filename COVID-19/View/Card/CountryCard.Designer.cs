namespace COVID_19.View.Card
{
    partial class CountryCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountryCard));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblcountry = new System.Windows.Forms.Label();
            this.lblcases = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblcountry
            // 
            this.lblcountry.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblcountry.Font = new System.Drawing.Font("Poppins", 10.25F);
            this.lblcountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblcountry.Location = new System.Drawing.Point(45, 0);
            this.lblcountry.Name = "lblcountry";
            this.lblcountry.Size = new System.Drawing.Size(77, 48);
            this.lblcountry.TabIndex = 20;
            this.lblcountry.Text = "Germany";
            this.lblcountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblcountry.UseCompatibleTextRendering = true;
            // 
            // lblcases
            // 
            this.lblcases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblcases.Font = new System.Drawing.Font("Poppins SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcases.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblcases.Location = new System.Drawing.Point(122, 0);
            this.lblcases.Name = "lblcases";
            this.lblcases.Size = new System.Drawing.Size(65, 48);
            this.lblcases.TabIndex = 21;
            this.lblcases.Text = "10,000";
            this.lblcases.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblcases.UseCompatibleTextRendering = true;
            // 
            // CountryCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblcases);
            this.Controls.Add(this.lblcountry);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "CountryCard";
            this.Size = new System.Drawing.Size(187, 48);
            this.Load += new System.EventHandler(this.CountryCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblcountry;
        private System.Windows.Forms.Label lblcases;
    }
}
