using System;
using System.Collections.Generic;
using System.Linq;
using WpfAppFileAndTaskStorage.Models;
using WpfAppFileAndTaskStorage.MVVM;

namespace WpfAppFileAndTaskStorage.ViewModels
{
    /// <summary>
    /// Класс модели представления для задачи.
    /// </summary>
    public class TaskViewModel : BaseViewModel
    {
        #region Поля и свойства
        public Task Task { get; set; }
        
        private IEnumerable<TaskStatus> statuses;

        /// <summary>
        /// Коллекция возможных статусов задачи.
        /// </summary>
        public IEnumerable<TaskStatus> Statuses
        {
            get => statuses;  
            set
            {
                SetProperty(ref statuses, value);
            }
        }

        private string name;

        /// <summary>
        /// Название задачи. При изменении обновляет название в модели задачи.
        /// </summary>
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

        /// <summary>
        /// Содержание задачи. При изменении обновляет содержание в модели задачи.
        /// </summary>
        public string Body
        {
            get => body;
            set
            {
                SetProperty(ref body, value);
                this.Task.SetBody(value);
            }
        }

        private TaskStatus status;
        
        /// <summary>
        /// Текущий cтатус задачи. При изменении обновляет статус в модели задачи.
        /// </summary>
        public TaskStatus Status
        {
            get => status;
            set
            {
                SetProperty(ref status, value);
                this.Task.SetStatus(value);
            }
        }

        /// <summary>
        /// Строковое название типа объекта.
        /// </summary>
        public string TypeName => "Задача";
        #endregion


        #region Конструктор
        /// <summary>
        /// Конструктор для создания модели представления задачи с заданным идентификатором, именем и содержанием.
        /// </summary>
        /// <param name="id">Идентификатор задачи.</param>
        /// <param name="name">Название задачи.</param>
        /// <param name="body">Содержание задачи.</param>
        public TaskViewModel(int id, string name, string body)
        {
            // Инициализация полей модели представления данными из модели задачи.
            this.Task = new Task(id);
            this.Name = name;
            this.Body = body;
            this.Status = TaskStatus.AtWork; 
            // Заполнение коллекции возможных статусов задачи на основе перечисления TaskStatus.
            this.Statuses = Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>();

        }
        /// <summary>
        /// Конструктор для создания модели представления задачи с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор задачи.</param>
        public TaskViewModel(int id)
        {
            // Инициализация модели задачи.
            this.Task = new Task(id);
            // Заполнение коллекции возможных статусов на основе перечисления TaskStatus.
            this.Statuses = Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>();
        }
        #endregion
    }
}
