namespace CalendarV2
{
    partial class EventHolder
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitleTxt = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.lblDetailsTxt = new System.Windows.Forms.Label();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Enabled = false;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(29, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(64, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title: ";
            // 
            // lblTitleTxt
            // 
            this.lblTitleTxt.AutoSize = true;
            this.lblTitleTxt.Enabled = false;
            this.lblTitleTxt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTxt.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitleTxt.Location = new System.Drawing.Point(89, 23);
            this.lblTitleTxt.Name = "lblTitleTxt";
            this.lblTitleTxt.Size = new System.Drawing.Size(51, 24);
            this.lblTitleTxt.TabIndex = 0;
            this.lblTitleTxt.Text = "Title";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Enabled = false;
            this.lblDetail.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetail.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDetail.Location = new System.Drawing.Point(29, 57);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(78, 22);
            this.lblDetail.TabIndex = 0;
            this.lblDetail.Text = "Details: ";
            // 
            // lblDetailsTxt
            // 
            this.lblDetailsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetailsTxt.Enabled = false;
            this.lblDetailsTxt.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailsTxt.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDetailsTxt.Location = new System.Drawing.Point(108, 57);
            this.lblDetailsTxt.Name = "lblDetailsTxt";
            this.lblDetailsTxt.Size = new System.Drawing.Size(359, 44);
            this.lblDetailsTxt.TabIndex = 0;
            this.lblDetailsTxt.Text = "Details";
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(15, 101);
            this.pnlSide.TabIndex = 1;
            // 
            // EventHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlSide);
            this.Controls.Add(this.lblDetailsTxt);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.lblTitleTxt);
            this.Controls.Add(this.lblTitle);
            this.Name = "EventHolder";
            this.Size = new System.Drawing.Size(470, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTitleTxt;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblDetailsTxt;
        private System.Windows.Forms.Panel pnlSide;
    }
}
