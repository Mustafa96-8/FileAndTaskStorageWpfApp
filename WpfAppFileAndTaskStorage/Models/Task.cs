using System;

namespace WpfAppFileAndTaskStorage.Models
{
    public sealed class Task : BaseModel
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

        /// <summary>
        /// Простая фабрика для создания нового экземпляра Задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="name">Название задачи</param>
        /// <param name="body">Содержание задачи</param>
        /// <param name="status">Статус задачи: В работе, Выполнена</param>
        /// <returns>Возвращает созданный экземпляр задчи, если все параметры прошли проверку, иначе выкидывает ошибку</returns>
        /// <exception cref="ArgumentException">Если параметр не проходит проверку на допустимость</exception>
        public static Task Create(int id,string name,string body, TaskStatus status = TaskStatus.AtWork)
        {
            if (id < 0)
            {
                throw new ArgumentException($"Не удаётся создать Задачу, Параметр {nameof(id)} должен быть больше или равным 0");
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
