namespace COVID_19.View.Card
{
    partial class Top3CountryCard
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
            this.lblratiorecovery = new System.Windows.Forms.Label();
            this.progressrecovery = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.lblrecovered1 = new System.Windows.Forms.Label();
            this.lblaffected1 = new System.Windows.Forms.Label();
            this.lblcountry = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblratiorecovery
            // 
            this.lblratiorecovery.Font = new System.Drawing.Font("Poppins", 7.25F);
            this.lblratiorecovery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblratiorecovery.Location = new System.Drawing.Point(13, 17);
            this.lblratiorecovery.Name = "lblratiorecovery";
            this.lblratiorecovery.Size = new System.Drawing.Size(34, 26);
            this.lblratiorecovery.TabIndex = 20;
            this.lblratiorecovery.Text = "23.6%";
            this.lblratiorecovery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblratiorecovery.UseCompatibleTextRendering = true;
            // 
            // progressrecovery
            // 
            this.progressrecovery.Animated = false;
            this.progressrecovery.AnimationInterval = 1;
            this.progressrecovery.AnimationSpeed = 1;
            this.progressrecovery.BackColor = System.Drawing.Color.Transparent;
            this.progressrecovery.CircleMargin = 5;
            this.progressrecovery.Dock = System.Windows.Forms.DockStyle.Left;
            this.progressrecovery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.progressrecovery.ForeColor = System.Drawing.Color.White;
            this.progressrecovery.IsPercentage = true;
            this.progressrecovery.LineProgressThickness = 5;
            this.progressrecovery.LineThickness = 2;
            this.progressrecovery.Location = new System.Drawing.Point(0, 0);
            this.progressrecovery.Name = "progressrecovery";
            this.progressrecovery.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.progressrecovery.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.progressrecovery.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 1F);
            this.progressrecovery.Size = new System.Drawing.Size(60, 60);
            this.progressrecovery.SubScriptColor = System.Drawing.Color.White;
            this.progressrecovery.SubScriptMargin = new System.Windows.Forms.Padding(0);
            this.progressrecovery.SubScriptText = "";
            this.progressrecovery.SuperScriptColor = System.Drawing.Color.White;
            this.progressrecovery.SuperScriptMargin = new System.Windows.Forms.Padding(5, 50, 0, 0);
            this.progressrecovery.SuperScriptText = "%";
            this.progressrecovery.TabIndex = 19;
            this.progressrecovery.Text = "30";
            this.progressrecovery.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.progressrecovery.Value = 30;
            // 
            // lblrecovered1
            // 
            this.lblrecovered1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblrecovered1.Font = new System.Drawing.Font("Poppins", 9.25F);
            this.lblrecovered1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblrecovered1.Location = new System.Drawing.Point(174, 29);
            this.lblrecovered1.Name = "lblrecovered1";
            this.lblrecovered1.Size = new System.Drawing.Size(120, 30);
            this.lblrecovered1.TabIndex = 22;
            this.lblrecovered1.Text = "0 Recovered";
            this.lblrecovered1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblrecovered1.UseCompatibleTextRendering = true;
            // 
            // lblaffected1
            // 
            this.lblaffected1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblaffected1.Font = new System.Drawing.Font("Poppins", 9.25F);
            this.lblaffected1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblaffected1.Location = new System.Drawing.Point(60, 29);
            this.lblaffected1.Name = "lblaffected1";
            this.lblaffected1.Size = new System.Drawing.Size(108, 30);
            this.lblaffected1.TabIndex = 21;
            this.lblaffected1.Text = "0 Affected";
            this.lblaffected1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblaffected1.UseCompatibleTextRendering = true;
            // 
            // lblcountry
            // 
            this.lblcountry.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblcountry.Font = new System.Drawing.Font("Poppins SemiBold", 11F, System.Drawing.FontStyle.Bold);
            this.lblcountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblcountry.Location = new System.Drawing.Point(60, 0);
            this.lblcountry.Name = "lblcountry";
            this.lblcountry.Size = new System.Drawing.Size(234, 29);
            this.lblcountry.TabIndex = 23;
            this.lblcountry.Text = "Example Country Name";
            this.lblcountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblcountry.UseCompatibleTextRendering = true;
            // 
            // Top3CountryCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblrecovered1);
            this.Controls.Add(this.lblaffected1);
            this.Controls.Add(this.lblratiorecovery);
            this.Controls.Add(this.lblcountry);
            this.Controls.Add(this.progressrecovery);
            this.DoubleBuffered = true;
            this.Name = "Top3CountryCard";
            this.Size = new System.Drawing.Size(294, 59);
            this.Load += new System.EventHandler(this.Top3CountryCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblratiorecovery;
        private Bunifu.UI.WinForms.BunifuCircleProgress progressrecovery;
        private System.Windows.Forms.Label lblrecovered1;
        private System.Windows.Forms.Label lblaffected1;
        private System.Windows.Forms.Label lblcountry;
    }
}
