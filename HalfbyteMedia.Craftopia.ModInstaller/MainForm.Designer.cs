
namespace HalfbyteMedia.Craftopia.ModInstaller
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer_Header = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Body = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox_Steps = new System.Windows.Forms.ListBox();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Header)).BeginInit();
            this.splitContainer_Header.Panel1.SuspendLayout();
            this.splitContainer_Header.Panel2.SuspendLayout();
            this.splitContainer_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Body)).BeginInit();
            this.splitContainer_Body.Panel1.SuspendLayout();
            this.splitContainer_Body.Panel2.SuspendLayout();
            this.splitContainer_Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_Header
            // 
            this.splitContainer_Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Header.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Header.IsSplitterFixed = true;
            this.splitContainer_Header.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Header.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer_Header.Name = "splitContainer_Header";
            this.splitContainer_Header.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Header.Panel1
            // 
            this.splitContainer_Header.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer_Header.Panel2
            // 
            this.splitContainer_Header.Panel2.Controls.Add(this.splitContainer_Body);
            this.splitContainer_Header.Size = new System.Drawing.Size(856, 510);
            this.splitContainer_Header.SplitterDistance = 87;
            this.splitContainer_Header.SplitterWidth = 5;
            this.splitContainer_Header.TabIndex = 0;
            // 
            // splitContainer_Body
            // 
            this.splitContainer_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Body.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Body.IsSplitterFixed = true;
            this.splitContainer_Body.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Body.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer_Body.Name = "splitContainer_Body";
            // 
            // splitContainer_Body.Panel1
            // 
            this.splitContainer_Body.Panel1.Controls.Add(this.listBox_Steps);
            // 
            // splitContainer_Body.Panel2
            // 
            this.splitContainer_Body.Panel2.Controls.Add(this.splitContainer_Main);
            this.splitContainer_Body.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 4, 16);
            this.splitContainer_Body.Size = new System.Drawing.Size(856, 418);
            this.splitContainer_Body.SplitterDistance = 184;
            this.splitContainer_Body.SplitterWidth = 5;
            this.splitContainer_Body.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(856, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listBox_Steps
            // 
            this.listBox_Steps.BackColor = System.Drawing.Color.White;
            this.listBox_Steps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Steps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Steps.FormattingEnabled = true;
            this.listBox_Steps.ItemHeight = 20;
            this.listBox_Steps.Items.AddRange(new object[] {
            "Disclaimer",
            "Setup",
            "Required Files"});
            this.listBox_Steps.Location = new System.Drawing.Point(0, 0);
            this.listBox_Steps.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox_Steps.Name = "listBox_Steps";
            this.listBox_Steps.Size = new System.Drawing.Size(184, 418);
            this.listBox_Steps.TabIndex = 0;
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            this.splitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer_Main.Size = new System.Drawing.Size(663, 402);
            this.splitContainer_Main.SplitterDistance = 345;
            this.splitContainer_Main.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(580, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(499, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Next >";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(418, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "< Back";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HalfbyteMedia.com";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(856, 510);
            this.Controls.Add(this.splitContainer_Header);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Craftopia | Mod Installer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer_Header.Panel1.ResumeLayout(false);
            this.splitContainer_Header.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Header)).EndInit();
            this.splitContainer_Header.ResumeLayout(false);
            this.splitContainer_Body.Panel1.ResumeLayout(false);
            this.splitContainer_Body.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Body)).EndInit();
            this.splitContainer_Body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_Header;
        private System.Windows.Forms.SplitContainer splitContainer_Body;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox_Steps;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

