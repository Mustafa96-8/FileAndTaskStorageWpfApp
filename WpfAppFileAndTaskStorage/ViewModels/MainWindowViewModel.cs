using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfAppFileAndTaskStorage.MVVM;
using WpfAppFileAndTaskStorage.Views;

namespace WpfAppFileAndTaskStorage.ViewModels
{

    /// <summary>
    /// Класс модели представления для главного окна представления.
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {

        #region Поля и свойства

        /// <summary>
        /// Коллекция для хранения моделей представления объектов, таких как документы и задачи.
        /// </summary>
        public ObservableCollection<object> Items { get; set; } 
        
        /// <summary>
        /// Команда для создания нового документа.
        /// </summary>
        public ICommand CreateDocumentCommand { get; private set; }

        /// <summary>
        /// Команда для создания новой задачи.
        /// </summary>
        public ICommand CreateTaskCommand { get; private set; }

        /// <summary>
        /// Команда для открытия выбранного элемента в модальном окне.
        /// </summary>
        public ICommand OpenItemCommand { get; private set; }

        #endregion

        #region Методы

        /// <summary>
        /// Определяет можно ли открыть выбранный объект. Не равен ли он <see langword="null"/>.
        /// </summary>
        /// <param name="selectedItem">Выбранный объект для проверки на <see langword="null"/>.</param>
        /// <returns><see langword="true"/> , если объект не <see langword="null"/>. Иначе - <see langword="false"/>.</returns>
        private bool OpenItemCanExecute(object selectedItem)
        {
            return selectedItem != null;
        }

        /// <summary>
        /// Генерирует новый уникальный идентификатор для создаваемого объекта.
        /// </summary>
        /// <returns>Новый идентификатор в виде числа <see langword="int"/>.</returns>
        private int GetNewId()
        {
            return Items.Count + 1;
        }

        /// <summary>
        /// Генерация тестовых данныех для проверки функционала приложения.
        /// Создаёт несколько документов и задач с значениями.
        /// </summary>
        private void GenerateTestData()
        {
            CreateDocument("Новый доумент.doc","просто некоторый текст для документа с стандартным именем");
            CreateDocument("Грузовики.doc", "Mersedes \nScania \nVolvo \nMAN \nMAZ \nDAF");
            CreateDocument("Отчёт.doc", "Данные 1 \n Данные 2 \tпоказания \n Данные 3");
            CreateTask("Поверить соответствие корпоративному стилю", "Проверить имена и Нотации\nДобавить регионы");
            CreateTask("Изучение методов разработки в компаниях", "Изучить:\n1.Agile \n2.CI CD");

        }
        #endregion

        #region События
        /// <summary>
        /// Создаёт новый документ с параметрами.
        /// </summary>
        /// <param name="name">Название нового документа.</param>
        /// <param name="body">Содержание нового документа. По умолчанию - ""</param>
        private void CreateDocument(string name, string body = "")
        {
            int id = this.GetNewId();

            DocumentViewModel documentViewModel = new DocumentViewModel(id, name, body);

            Items.Add(documentViewModel);
        }

        /// <summary>
        /// Создаёт новый документ с настройкой его в модальном окне.
        /// </summary>
        private void CreateDocument()
        {
            int id = this.GetNewId();
            DocumentViewModel documentViewModel = new DocumentViewModel(id);
            OpenItem(documentViewModel);
            if (documentViewModel.Name!=null)
            {
                Items.Add(documentViewModel);
            }
        }

        /// <summary>
        /// Создаёт новую задачу с параметрами.
        /// </summary>
        /// <param name="name">Название новой задачи. По умолчанию - "Новая задача"</param>
        /// <param name="body">Содержание новой задачи. По умолчанию - "-"</param>
        private void CreateTask(string name, string body="")
        {
            int id = this.GetNewId();
            TaskViewModel taskViewModel = new TaskViewModel(id, name, body);
            
            Items.Add(taskViewModel);
        }
        /// <summary>
        /// Создаёт новый документ с настройкой его в модальном окне.
        /// </summary>
        private void CreateTask()
        {
            int id = this.GetNewId();
            TaskViewModel taskViewModel = new TaskViewModel(id);
            OpenItem(taskViewModel);
            if (taskViewModel.Name != null)
            {
                Items.Add(taskViewModel);
            }
        }

        /// <summary>
        /// Открывает выбранный элемента в соответсвующем ему новом модальном окне для редактирования.
        /// </summary>
        /// <param name="selectedItem">Объект, который нужно открыть.</param>
        private void OpenItem(object selectedItem)
        {
            if (selectedItem is DocumentViewModel documentViewModel)
            {
                DocumentView documentView = new DocumentView
                {
                    DataContext = documentViewModel
                };
                documentView.ShowDialog();      
            }
            else if (selectedItem is TaskViewModel taskViewModel)
            {
                TaskView taskView = new TaskView
                {
                    DataContext = taskViewModel
                };
                taskView.ShowDialog();

            }
        }
        #endregion

        #region Конструктор
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MainWindowViewModel"/> и настраивает команды.
        /// Генерирует тестовые данные для проверки работы приложения.
        /// </summary>
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<object>();

            // Привязка команд к методам-обработчикам через объект RelayCommand.
            CreateDocumentCommand = new RelayCommand(execute => CreateDocument(), canExecute => true);
            CreateTaskCommand = new RelayCommand(execute => CreateTask(), canExecute => true);
            OpenItemCommand = new RelayCommand(OpenItem, OpenItemCanExecute);

            // Создание тестовых данных для отображения в приложении.
            GenerateTestData();
        }

        #endregion
    }
}
