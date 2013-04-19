namespace UV_DLP_3D_Printer.GUI
{
    partial class frmControl
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
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdUp = new System.Windows.Forms.Button();
            this.txtdist = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdistX = new System.Windows.Forms.TextBox();
            this.cmdXDown = new System.Windows.Forms.Button();
            this.cmdXUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdistY = new System.Windows.Forms.TextBox();
            this.cmdYDown = new System.Windows.Forms.Button();
            this.cmdYUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdDown
            // 
            this.cmdDown.Image = global::UV_DLP_3D_Printer.Properties.Resources.Down1Blue;
            this.cmdDown.Location = new System.Drawing.Point(268, 152);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(72, 72);
            this.cmdDown.TabIndex = 1;
            this.cmdDown.UseVisualStyleBackColor = true;
            this.cmdDown.Click += new System.EventHandler(this.cmdDown_Click);
            // 
            // cmdUp
            // 
            this.cmdUp.Image = global::UV_DLP_3D_Printer.Properties.Resources.Up1Blue;
            this.cmdUp.Location = new System.Drawing.Point(268, 30);
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(72, 72);
            this.cmdUp.TabIndex = 0;
            this.cmdUp.UseVisualStyleBackColor = true;
            this.cmdUp.Click += new System.EventHandler(this.cmdUp_Click);
            // 
            // txtdist
            // 
            this.txtdist.Location = new System.Drawing.Point(268, 118);
            this.txtdist.Name = "txtdist";
            this.txtdist.Size = new System.Drawing.Size(72, 22);
            this.txtdist.TabIndex = 2;
            this.txtdist.Text = ".05";
            this.txtdist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "mm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "mm";
            // 
            // txtdistX
            // 
            this.txtdistX.Location = new System.Drawing.Point(12, 118);
            this.txtdistX.Name = "txtdistX";
            this.txtdistX.Size = new System.Drawing.Size(72, 22);
            this.txtdistX.TabIndex = 6;
            this.txtdistX.Text = ".05";
            this.txtdistX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdXDown
            // 
            this.cmdXDown.Image = global::UV_DLP_3D_Printer.Properties.Resources.Down1Blue;
            this.cmdXDown.Location = new System.Drawing.Point(12, 152);
            this.cmdXDown.Name = "cmdXDown";
            this.cmdXDown.Size = new System.Drawing.Size(72, 72);
            this.cmdXDown.TabIndex = 5;
            this.cmdXDown.UseVisualStyleBackColor = true;
            this.cmdXDown.Click += new System.EventHandler(this.cmdXDown_Click);
            // 
            // cmdXUp
            // 
            this.cmdXUp.Image = global::UV_DLP_3D_Printer.Properties.Resources.Up1Blue;
            this.cmdXUp.Location = new System.Drawing.Point(12, 30);
            this.cmdXUp.Name = "cmdXUp";
            this.cmdXUp.Size = new System.Drawing.Size(72, 72);
            this.cmdXUp.TabIndex = 4;
            this.cmdXUp.UseVisualStyleBackColor = true;
            this.cmdXUp.Click += new System.EventHandler(this.cmdXUp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "ZAxis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "XAxis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "YAxis";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "mm";
            // 
            // txtdistY
            // 
            this.txtdistY.Location = new System.Drawing.Point(139, 118);
            this.txtdistY.Name = "txtdistY";
            this.txtdistY.Size = new System.Drawing.Size(72, 22);
            this.txtdistY.TabIndex = 12;
            this.txtdistY.Text = ".05";
            this.txtdistY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdYDown
            // 
            this.cmdYDown.Image = global::UV_DLP_3D_Printer.Properties.Resources.Down1Blue;
            this.cmdYDown.Location = new System.Drawing.Point(139, 152);
            this.cmdYDown.Name = "cmdYDown";
            this.cmdYDown.Size = new System.Drawing.Size(72, 72);
            this.cmdYDown.TabIndex = 11;
            this.cmdYDown.UseVisualStyleBackColor = true;
            this.cmdYDown.Click += new System.EventHandler(this.cmdYDown_Click);
            // 
            // cmdYUp
            // 
            this.cmdYUp.Image = global::UV_DLP_3D_Printer.Properties.Resources.Up1Blue;
            this.cmdYUp.Location = new System.Drawing.Point(139, 30);
            this.cmdYUp.Name = "cmdYUp";
            this.cmdYUp.Size = new System.Drawing.Size(72, 72);
            this.cmdYUp.TabIndex = 10;
            this.cmdYUp.UseVisualStyleBackColor = true;
            this.cmdYUp.Click += new System.EventHandler(this.cmdYUp_Click);
            // 
            // frmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 268);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtdistY);
            this.Controls.Add(this.cmdYDown);
            this.Controls.Add(this.cmdYUp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdistX);
            this.Controls.Add(this.cmdXDown);
            this.Controls.Add(this.cmdXUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdist);
            this.Controls.Add(this.cmdDown);
            this.Controls.Add(this.cmdUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Printer Control";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdUp;
        private System.Windows.Forms.Button cmdDown;
        private System.Windows.Forms.TextBox txtdist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdistX;
        private System.Windows.Forms.Button cmdXDown;
        private System.Windows.Forms.Button cmdXUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtdistY;
        private System.Windows.Forms.Button cmdYDown;
        private System.Windows.Forms.Button cmdYUp;
    }
}