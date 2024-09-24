using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using WpfAppFileAndTaskStorage.Models;
using WpfAppFileAndTaskStorage.MVVM;
using WpfAppFileAndTaskStorage.Views;

namespace WpfAppFileAndTaskStorage.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        //Коллекция всех объектов
        public ObservableCollection<object> Items { get; set; } 
        public ICommand CreateDocumentCommand { get; private set; }
        public ICommand CreateTaskCommand { get; private set; }

        public ICommand OpenItemCommand { get; private set; }

        private object _selectedItem;

        public object SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        } 


        public MainWindowViewModel()
        {
            Items = new ObservableCollection<object>();

            CreateDocumentCommand = new RelayCommand(execute => CreateDocument(), canExecute => true);
            CreateTaskCommand = new RelayCommand(execute=> CreateTask(), canExecute => true);
            OpenItemCommand = new RelayCommand(OpenItem, OpenItemCanExecute);


            CreateDocument(Body:"Some Text to doc without name");
            CreateDocument("My Trucks","Mersedes \n Scania \n Volvo \n MAN \n MAZ \n ");
            CreateDocument("Salary Report","Mark 2500 \n John 1980 \t Loid 2100 \n Kate 2150");

        }



        private void CreateDocument(string Name="New Doc", string Body="-")
        {
            Document newDocument = Document.Create( this.GetNewId(), Name, Body, null);
            Items.Add(newDocument);
        }

        private void CreateTask()
        {
            Task newTask = Task.Create(this.GetNewId(), "New Task", "--", TaskStatus.AtWork);
            Items.Add(newTask);
        }

        private void OpenItem(object selectedItem)
        {
            if (selectedItem is Document document)
            {
                DocumentView window = new DocumentView();
                window.DataContext = new DocumentViewModel(document);

                // Открываем окно в модальном режиме
                window.ShowDialog();
            }
            else if (selectedItem is Task)
            {

            }
            

        }
        private bool OpenItemCanExecute(object selectedItem)
        {
            if (selectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private int GetNewId()
        {
            return Items.Count+1;
        }



    }
}
