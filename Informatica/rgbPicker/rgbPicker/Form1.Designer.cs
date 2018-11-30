namespace rgbPicker
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.redTrack = new System.Windows.Forms.TrackBar();
            this.greenTrack = new System.Windows.Forms.TrackBar();
            this.blueTrack = new System.Windows.Forms.TrackBar();
            this.redLabel = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.blueLabel = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.rgbTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.redTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // redTrack
            // 
            this.redTrack.LargeChange = 1;
            this.redTrack.Location = new System.Drawing.Point(54, 221);
            this.redTrack.Maximum = 255;
            this.redTrack.Name = "redTrack";
            this.redTrack.Size = new System.Drawing.Size(566, 45);
            this.redTrack.TabIndex = 0;
            this.redTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // greenTrack
            // 
            this.greenTrack.LargeChange = 1;
            this.greenTrack.Location = new System.Drawing.Point(54, 272);
            this.greenTrack.Maximum = 255;
            this.greenTrack.Name = "greenTrack";
            this.greenTrack.Size = new System.Drawing.Size(566, 45);
            this.greenTrack.TabIndex = 1;
            this.greenTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.greenTrack.Value = 200;
            // 
            // blueTrack
            // 
            this.blueTrack.LargeChange = 1;
            this.blueTrack.Location = new System.Drawing.Point(54, 323);
            this.blueTrack.Maximum = 255;
            this.blueTrack.Name = "blueTrack";
            this.blueTrack.Size = new System.Drawing.Size(566, 45);
            this.blueTrack.TabIndex = 2;
            this.blueTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.redLabel.Location = new System.Drawing.Point(12, 221);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(34, 17);
            this.redLabel.TabIndex = 3;
            this.redLabel.Text = "RED";
            // 
            // greenLabel
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.greenLabel.Location = new System.Drawing.Point(12, 272);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(51, 17);
            this.greenLabel.TabIndex = 4;
            this.greenLabel.Text = "GREEN";
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.blueLabel.Location = new System.Drawing.Point(12, 323);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(41, 17);
            this.blueLabel.TabIndex = 5;
            this.blueLabel.Text = "BLUE";
            // 
            // labelColor
            // 
            this.labelColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelColor.Location = new System.Drawing.Point(13, 13);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(607, 151);
            this.labelColor.TabIndex = 6;
            this.labelColor.Click += new System.EventHandler(this.labelColor_Click);
            // 
            // rgbTextbox
            // 
            this.rgbTextbox.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rgbTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rgbTextbox.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgbTextbox.ForeColor = System.Drawing.Color.Ivory;
            this.rgbTextbox.Location = new System.Drawing.Point(15, 178);
            this.rgbTextbox.Name = "rgbTextbox";
            this.rgbTextbox.ReadOnly = true;
            this.rgbTextbox.Size = new System.Drawing.Size(605, 25);
            this.rgbTextbox.TabIndex = 7;
            this.rgbTextbox.Text = "R : 0 / G : 0 / B : 0";
            this.rgbTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(632, 376);
            this.Controls.Add(this.rgbTextbox);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.greenLabel);
            this.Controls.Add(this.redLabel);
            this.Controls.Add(this.blueTrack);
            this.Controls.Add(this.greenTrack);
            this.Controls.Add(this.redTrack);
            this.Name = "Form1";
            this.Text = "rgbPicker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.redTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar redTrack;
        private System.Windows.Forms.TrackBar greenTrack;
        private System.Windows.Forms.TrackBar blueTrack;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.TextBox rgbTextbox;
    }
}

