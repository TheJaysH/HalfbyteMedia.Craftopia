
namespace HalfbyteMedia.Craftopia.Core.Components.TaskItem
{
    partial class TaskItem<T>
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
            this.label_TaskText = new System.Windows.Forms.Label();
            this.pictureBox_StatusImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_StatusImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label_TaskText
            // 
            this.label_TaskText.BackColor = System.Drawing.Color.White;
            this.label_TaskText.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_TaskText.Location = new System.Drawing.Point(32, 0);
            this.label_TaskText.Name = "label_TaskText";
            this.label_TaskText.Size = new System.Drawing.Size(449, 32);
            this.label_TaskText.TabIndex = 1;
            this.label_TaskText.Text = "Task Description";
            this.label_TaskText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox_StatusImage
            // 
            this.pictureBox_StatusImage.BackColor = System.Drawing.Color.White;
            this.pictureBox_StatusImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox_StatusImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_StatusImage.Name = "pictureBox_StatusImage";
            this.pictureBox_StatusImage.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_StatusImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_StatusImage.TabIndex = 0;
            this.pictureBox_StatusImage.TabStop = false;
            // 
            // TaskItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label_TaskText);
            this.Controls.Add(this.pictureBox_StatusImage);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TaskItem";
            this.Size = new System.Drawing.Size(484, 32);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_StatusImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_TaskText;
        private System.Windows.Forms.PictureBox pictureBox_StatusImage;
    }
}
