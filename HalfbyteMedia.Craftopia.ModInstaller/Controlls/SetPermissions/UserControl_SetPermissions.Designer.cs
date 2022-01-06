
namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.SetPermissions
{
    partial class UserControl_SetPermissions
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
            this.button_Begin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button_Begin
            // 
            this.button_Begin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Begin.Location = new System.Drawing.Point(1140, 71);
            this.button_Begin.Name = "button_Begin";
            this.button_Begin.Size = new System.Drawing.Size(103, 30);
            this.button_Begin.TabIndex = 6;
            this.button_Begin.Text = "Begin";
            this.button_Begin.UseVisualStyleBackColor = true;
            this.button_Begin.Click += new System.EventHandler(this.button_Begin_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1246, 52);
            this.label1.TabIndex = 4;
            this.label1.Text = "The installer will now start craftopia to locate the app directory. It will then " +
    "modify the permissions of this folder to allow you to dump the application. Clic" +
    "k Begin to start the process.";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 137);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1239, 524);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // UserControl_SetPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button_Begin);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControl_SetPermissions";
            this.Size = new System.Drawing.Size(1246, 664);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Begin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
