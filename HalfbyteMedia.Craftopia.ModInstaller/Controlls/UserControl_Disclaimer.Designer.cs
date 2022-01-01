
namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls
{
    partial class UserControl_Disclaimer
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
            this.checkBox_DisclaimerAccepted = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // checkBox_DisclaimerAccepted
            // 
            this.checkBox_DisclaimerAccepted.AutoSize = true;
            this.checkBox_DisclaimerAccepted.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox_DisclaimerAccepted.Location = new System.Drawing.Point(0, 300);
            this.checkBox_DisclaimerAccepted.Name = "checkBox_DisclaimerAccepted";
            this.checkBox_DisclaimerAccepted.Padding = new System.Windows.Forms.Padding(4, 16, 0, 0);
            this.checkBox_DisclaimerAccepted.Size = new System.Drawing.Size(600, 40);
            this.checkBox_DisclaimerAccepted.TabIndex = 2;
            this.checkBox_DisclaimerAccepted.Text = "I agree to the terms and conditions";
            this.checkBox_DisclaimerAccepted.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(600, 300);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // UserControl_Disclaimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.checkBox_DisclaimerAccepted);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControl_Disclaimer";
            this.Size = new System.Drawing.Size(600, 452);
            this.Load += new System.EventHandler(this.UserControl_Disclaimer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox_DisclaimerAccepted;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
