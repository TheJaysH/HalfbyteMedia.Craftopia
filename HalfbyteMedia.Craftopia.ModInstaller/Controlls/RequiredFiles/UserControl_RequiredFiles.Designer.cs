
namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.ReqiredFiles
{
    partial class UserControl_RequiredFiles
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
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button_Begin = new System.Windows.Forms.Button();
            this.listView_Files = new System.Windows.Forms.ListView();
            this.columnHeader_Application = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1246, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "The installer will now download and install required files. Click Begin to start " +
    "the process.";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(4, 57);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1239, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            // 
            // button_Begin
            // 
            this.button_Begin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Begin.Location = new System.Drawing.Point(1140, 86);
            this.button_Begin.Name = "button_Begin";
            this.button_Begin.Size = new System.Drawing.Size(103, 30);
            this.button_Begin.TabIndex = 3;
            this.button_Begin.Text = "Begin";
            this.button_Begin.UseVisualStyleBackColor = true;
            this.button_Begin.Click += new System.EventHandler(this.button_Begin_Click);
            // 
            // listView_Files
            // 
            this.listView_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Application,
            this.columnHeader_Status});
            this.listView_Files.HideSelection = false;
            this.listView_Files.Location = new System.Drawing.Point(4, 122);
            this.listView_Files.Name = "listView_Files";
            this.listView_Files.Size = new System.Drawing.Size(1239, 539);
            this.listView_Files.TabIndex = 4;
            this.listView_Files.UseCompatibleStateImageBehavior = false;
            this.listView_Files.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_Application
            // 
            this.columnHeader_Application.Text = "Application";
            this.columnHeader_Application.Width = 216;
            // 
            // columnHeader_Status
            // 
            this.columnHeader_Status.Text = "Status";
            this.columnHeader_Status.Width = 172;
            // 
            // UserControl_RequiredFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.listView_Files);
            this.Controls.Add(this.button_Begin);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControl_RequiredFiles";
            this.Size = new System.Drawing.Size(1246, 664);
            this.Load += new System.EventHandler(this.UserControl_RequiredFiles_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_Begin;
        private System.Windows.Forms.ListView listView_Files;
        private System.Windows.Forms.ColumnHeader columnHeader_Application;
        private System.Windows.Forms.ColumnHeader columnHeader_Status;
    }
}
