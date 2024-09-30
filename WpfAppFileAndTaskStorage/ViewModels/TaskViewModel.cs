using System;
using System.Collections.Generic;
using System.Linq;
using WpfAppFileAndTaskStorage.Enums;
using WpfAppFileAndTaskStorage.Helpers;
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

        /// <summary>
        /// Модель задачи
        /// </summary>
        public Task Task { get; set; }

        private IEnumerable<KeyValuePair<TaskStatus, string>> statusDisplayNames;

        /// <summary>
        /// Коллекция статусов с их отображаемыми названиями.
        /// </summary>
        public IEnumerable<KeyValuePair<TaskStatus, string>> StatusDisplayNames
        {
            get => statusDisplayNames;
            set
            {
                SetProperty(ref statusDisplayNames, value);
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
        /// Текущий статус задачи. При изменении обновляет статус в модели задачи.
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

        #region Конструкторы

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

            // Инициализация коллекции статусов с их отображаемыми названиями.
            InitializeStatusDisplayNames();
        }

        /// <summary>
        /// Конструктор для создания модели представления задачи с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор задачи.</param>
        public TaskViewModel(int id)
        {
            // Инициализация модели задачи.
            this.Task = new Task(id);

            // Инициализация коллекции статусов с их отображаемыми названиями.
            InitializeStatusDisplayNames();
        }

        /// <summary>
        /// Метод для инициализации коллекции статусов с их отображаемыми названиями.
        /// </summary>
        private void InitializeStatusDisplayNames()
        {
            this.StatusDisplayNames = Enum.GetValues(typeof(TaskStatus))
                .Cast<TaskStatus>()
                .Select(status => new KeyValuePair<TaskStatus, string>(status, TaskStatusTranslator.GetStatusDisplayName(status)))
                .ToList();
        }

        #endregion
    }
}
