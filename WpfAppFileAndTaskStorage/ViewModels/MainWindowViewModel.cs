using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfAppFileAndTaskStorage.Models;
using WpfAppFileAndTaskStorage.MVVM;
using WpfAppFileAndTaskStorage.Views;

namespace WpfAppFileAndTaskStorage.ViewModels
{

    /// <summary>
    /// Класс модели представления для главного окна представления (MainWindow).
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
            CreateDocument(body: "просто некоторый текст для документа с стандартным именем");
            CreateDocument("Грузовики.doc", "Mersedes \nScania \nVolvo \nMAN \nMAZ \nDAF");
            CreateDocument("Отчёт.doc", "Данные 1 \n Данные 2 \tпоказания \n Данные 3");
            CreateTask("Поверить соответствие корпоративному стилю", "Проверить имена и Нотации\nДобавить регионы");
            CreateTask("Изучение методов разработки в компаниях", "Изучить:\n1.Agile \n2.CI CD");

        }
        #endregion

        #region События
        /// <summary>
        /// Создаёт новый документ с параметрами и открывает его для редактирования в модальном окне.
        /// </summary>
        /// <param name="name">Название нового документа. По умолчанию - "Новый документ"</param>
        /// <param name="body">Содержание нового документа. По умолчанию - "-"</param>
        private void CreateDocument(string name="Новый документ", string body="-")
        {
            int id = this.GetNewId();

            Document newDocument = Document.Create( id, name, body, null);
            DocumentViewModel documentViewModel = new DocumentViewModel(newDocument);
            
            OpenItem(documentViewModel);
            Items.Add(documentViewModel);
        }


        /// <summary>
        /// Создаёт новую задачу с параметрами и открывает её для редактирования в модальном окне.
        /// </summary>
        /// <param name="name">Название новой задачи. По умолчанию - "Новая задача"</param>
        /// <param name="body">Содержание новой задачи. По умолчанию - "-"</param>
        private void CreateTask(string name="Новая задача",string body="-")
        {
            int id = this.GetNewId();
            
            Task newTask = Task.Create( id, name, body, TaskStatus.AtWork);
            TaskViewModel taskViewModel = new TaskViewModel(newTask);
            
            OpenItem(taskViewModel);
            Items.Add(taskViewModel);
        }

        /// <summary>
        /// Открывает выбранный элемента в соответсвующем ему новом модальном окне для редактирования.
        /// </summary>
        /// <param name="selectedItem">Объект, который нужно открыть.</param>
        private void OpenItem(object selectedItem)
        {
            if (selectedItem is DocumentViewModel documentViewModel)
            {
                DocumentView documentView = new DocumentView();
                documentView.DataContext = documentViewModel;
                documentView.ShowDialog();      
            }
            else if (selectedItem is TaskViewModel taskViewModel)
            {
                TaskView taskView = new TaskView();
                taskView.DataContext = taskViewModel;
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
