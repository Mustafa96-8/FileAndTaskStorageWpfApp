using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfAppFileAndTaskStorage.Models;
using WpfAppFileAndTaskStorage.MVVM;
using WpfAppFileAndTaskStorage.Views;
using System;

namespace WpfAppFileAndTaskStorage.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        //Коллекция всех объектов
        public ObservableCollection<object> Items { get; set; } 
        public ICommand CreateDocumentCommand { get; private set; }
        public ICommand CreateTaskCommand { get; private set; }

        public ICommand OpenItemCommand { get; private set; }



        public MainWindowViewModel()
        {
            Items = new ObservableCollection<object>();

            CreateDocumentCommand = new RelayCommand(execute => CreateDocument(), canExecute => true);
            CreateTaskCommand = new RelayCommand(execute=> CreateTask(), canExecute => true);
            OpenItemCommand = new RelayCommand(OpenItem, OpenItemCanExecute);


            CreateDocument(body:"просто некоторый текст для документа с стандартным именем");
            CreateDocument("Грузовики.doc","Mersedes \nScania \nVolvo \nMAN \nMAZ \nDAF");
            CreateDocument("Отчёт.doc","Данные 1 \n Данные 2 \tпоказания \n Данные 3");
            CreateTask("Поверить соответствие корпоративному стилю","Проверить имена и Нотации\nДобавить регионы");
            CreateTask("Изучение методов разработки в компаниях","Изучить:\n1.Agile \n2.CI CD");

        }


        private void CreateDocument(string name="Новый документ", string body="-")
        {
            int id = this.GetNewId();
            Document newDocument = Document.Create( id, name, body, null);
            Items.Add(new DocumentViewModel(newDocument));
        }

        private void CreateTask(string name="Новая задача",string body="-")
        {
            int id = this.GetNewId();
            Task newTask = Task.Create( id, name, body, TaskStatus.AtWork);
            Items.Add(new TaskViewModel(newTask));
        }

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
