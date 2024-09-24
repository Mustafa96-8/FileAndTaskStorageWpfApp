using System;

namespace WpfAppFileAndTaskStorage.Models
{
    public class Task
    {
        private Task(int id, string name, string body, TaskStatus status)
        {
            Id = id;
            Name = name;
            Body = body;
            Status = status;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Body { get; private set; }

        public TaskStatus Status { get; private set; }
        

        public static Task Create(int id,string name,string body, TaskStatus status)
        {
            if (id == 0)
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
