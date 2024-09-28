using System;

namespace WpfAppFileAndTaskStorage.Models
{
    /// <summary>
    /// Класс, представляющий модель задачи. Наследует базовые свойства из <see cref="BaseModel"/>.
    /// </summary>
    public sealed class Task : BaseModel
    {
        #region Свойства

        /// <summary>
        /// Текущий статус задачи.
        /// </summary>
        public TaskStatus Status { get; private set; }

        #endregion

        #region Методы

        /// <summary>
        /// Устанавливает новый статус задачи.
        /// </summary>
        /// <param name="status">Новый статус задачи.</param>
        public void SetStatus(TaskStatus status)
        {
            this.Status = status;
        }

        /// <summary>
        /// Простая фабрика для создания нового экземпляра задачи.
        /// </summary>
        /// <param name="id">Идентификатор задачи.</param>
        /// <param name="name">Название задачи.</param>
        /// <param name="body">Содержание или описание задачи.</param>
        /// <param name="status">Статус задачи по умолчанию: в работе.</param>
        /// <returns>Возвращает созданный экземпляр задачи.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если параметр id меньше 0.</exception>
        public static Task Create(int id,string name,string body, TaskStatus status = TaskStatus.AtWork)
        {
            if (id < 0)
            {
                throw new ArgumentException($"Не удаётся создать Задачу, Параметр {nameof(id)} должен быть больше или равным 0");
            }
            return new Task(id, name, body, status);
        }
        #endregion

        #region Конструктор

        /// <summary>
        /// Приватный конструктор для создания экземпляра задачи.
        /// Используется только через фабричный метод <see cref="Create"/>.
        /// </summary>
        /// <param name="id">Идентификатор задачи.</param>
        /// <param name="name">Название задачи.</param>
        /// <param name="body">Содержание задачи.</param>
        /// <param name="status">Статус задачи: в работе или выполнена.</param>
        private Task(int id, string name, string body, TaskStatus status)
        {
            Id = id;
            Name = name;
            Body = body;
            Status = status;
        }
        #endregion
    }
    /// <summary>
    /// Перечисление, определяющее возможные статусы задачи.
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Задача находится в работе.
        /// </summary>
        AtWork,

        /// <summary>
        /// Задача завершена.
        /// </summary>
        Completed
    }
}
