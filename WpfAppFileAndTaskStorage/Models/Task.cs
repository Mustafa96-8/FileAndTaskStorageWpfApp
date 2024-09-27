using System;

namespace WpfAppFileAndTaskStorage.Models
{
    public class Task : BaseModel
    {
        private Task(int id, string name, string body, TaskStatus status)
        {
            Id = id;
            Name = name;
            Body = body;
            Status = status;
        }

        public TaskStatus Status { get; private set; }
        
        public void SetStatus(TaskStatus status)
        {
            this.Status = status;
        }


        public static Task Create(int id,string name,string body, TaskStatus status = TaskStatus.AtWork)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"{nameof(id)} is not valid");
            }
            return new Task(id, name, body, status);
        }

    }

    public enum TaskStatus
    {
        AtWork,
        Completed
    }
}
