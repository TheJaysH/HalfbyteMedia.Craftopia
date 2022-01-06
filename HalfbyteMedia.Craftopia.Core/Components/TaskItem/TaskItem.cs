using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalfbyteMedia.Craftopia.Core.Components.TaskItem
{
    public partial class TaskItem<T> : UserControl
    {
        public TaskStatus TaskStatus { get; set; }

        public Func<T> Action { get; set; }

        public string TaskText
        {
            get => label_TaskText.Text;
            set
            {
                SetTaskText(value);
                Invalidate();
            }
        }

        public async Task<T> Run()
        {
            SetStatusIcon(TaskStatus.RUNNING);

            try
            {
                var result = await Task.Run(Action);

                SetStatusIcon(TaskStatus.COMPLETED);

                return result;
            }
            catch (Exception)
            {
                SetStatusIcon(TaskStatus.ERROR);                
            }

            return default;
        }

        public TaskItem()
        {
            InitializeComponent();
            InitializeTaskItem(string.Empty, null);
        }
      
        public TaskItem(string taskText, Func<T> task)
        {
            InitializeComponent();
            InitializeTaskItem(taskText, task);
        }

        public TaskItem(string taskText)
        {
            InitializeComponent();
            InitializeTaskItem(taskText, null);
        }


        private void InitializeTaskItem(string taskText, Func<T> task)
        {
            SetStatusIcon(TaskStatus.PENDING);
            SetTaskText(taskText);
            InitializeAction(task);
        }

        public void InitializeAction(Func<T> task)
        {
            Action = task;
        }

        public void SetTaskText(string taskText)
        {
            if (label_TaskText.InvokeRequired)
                label_TaskText.Invoke(new MethodInvoker(() =>
                {
                    label_TaskText.Text = taskText;
                }));
            else
                label_TaskText.Text = taskText;

            Invalidate();
        }

        public void SetStatusIcon(TaskStatus taskStatus)
        {
            TaskStatus = taskStatus;

            switch (taskStatus)
            {
                case TaskStatus.PENDING:
                    pictureBox_StatusImage.Image = Properties.Resources.Pending;
                    break;
                case TaskStatus.RUNNING:
                    pictureBox_StatusImage.Image = Properties.Resources.Running;
                    break;
                case TaskStatus.COMPLETED:
                    pictureBox_StatusImage.Image = Properties.Resources.Completed;
                    break;
                case TaskStatus.ERROR:
                    pictureBox_StatusImage.Image = Properties.Resources.Error;
                    break;
                default:
                    break;
            }

            Invalidate();

        }
       
    }
}
