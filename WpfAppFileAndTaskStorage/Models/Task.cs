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

        #endregion

        #region Конструктор

        /// <summary>
        /// Инициализирует новый экземпляр задачи с указанным идентификатором.
        /// </summary>
        /// <param name="id">Уникальный идентификатор задачи.</param>
        public Task(int id) 
        { 
            this.Id = id; 
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
