using System;
using System.Collections.Generic;
using System.Linq;
using WpfAppFileAndTaskStorage.Models;
using WpfAppFileAndTaskStorage.MVVM;

namespace WpfAppFileAndTaskStorage.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        #region Поля и свойства
        public Task Task { get; set; }
        
        private IEnumerable<TaskStatus> statuses;

        public IEnumerable<TaskStatus> Statuses
        {
            get => statuses;  
            set
            {
                SetProperty(ref statuses, value);
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                this.Task.SetName(value);
            }
        }

        private string body;

        public string Body
        {
            get => body;
            set
            {
                SetProperty(ref body, value);
                Task.SetBody(value);
            }
        }

        private TaskStatus status;
        public TaskStatus Status
        {
            get => status;
            set
            {
                SetProperty(ref status, value);
                this.Task.SetStatus(value);
            }
        }

        public string TypeName => "Задача"; 
        #endregion

        public TaskViewModel(Task task)
        {
            this.Statuses = Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>();
            this.Task = task;
            this.Status = task.Status;
            this.Body = task.Body;
            this.Name = task.Name;
        }
    }
}
