using System;
using System.Windows;
using System.Windows.Input;
using WpfAppFileAndTaskStorage.Models;
using WpfAppFileAndTaskStorage.MVVM;

namespace WpfAppFileAndTaskStorage.ViewModels
{
    public class DocumentViewModel :BaseViewModel
    {


        #region Поля и свойства
        public Document Document { get; set; }

        public ICommand CloseWindowCommand { get; private set; }
        public ICommand CreateDigitalSignatureCommand { get; private set; }
        

        private bool isDigitalSignatureNull;
        public bool IsDigitalSignatureNull
        {
            get => isDigitalSignatureNull;
            set
            {
                SetProperty(ref isDigitalSignatureNull, value);
                CanDocumentChange = !value;
            }
        }

        private bool canDocumentChange;
        public bool CanDocumentChange 
        { 
            get => canDocumentChange;
            set => SetProperty(ref canDocumentChange, value);
        }



        private Guid? digitalSignature;
        public Guid? DigitalSignature
        {
            get => digitalSignature;
            set => SetProperty(ref digitalSignature, value);
        }


        private string name;
        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                Document.SetName(value);
            }
        }

        private string body;

        public string Body
        {
            get => body;
            set {
                SetProperty(ref body, value);
                Document.SetBody(value);    
            } 
        }

        public string TypeName => "Документ";

        #endregion


        public DocumentViewModel(Document document)
        {
            InitDataFromModel(document);
            
            CloseWindowCommand = new RelayCommand(execute => CloseWindow(this), canExecute => true);
            CreateDigitalSignatureCommand = new RelayCommand(execute => CreateDigitalSignature(),canExecute => true);
        }


        
        private void InitDataFromModel(Document document) 
        {
            this.Document = document;
            this.body = document.Body;
            this.name = document.Name;
            this.IsDigitalSignatureNull = document.DigitalSignature == null;
            this.DigitalSignature = document.DigitalSignature;
        }


        private void CloseWindow(object parameter)
        {
            if (parameter is Window window) 
            {
                window.Close();
            }     
        }



        private void CreateDigitalSignature()
        {
            if (Document.DigitalSignature==null)
            {
                Document.CreateDigitalSignature();
                this.IsDigitalSignatureNull = false;
                this.DigitalSignature = Document.DigitalSignature;
            }
            else
            {
                throw new Exception($"Create a new digital signature for a document with an existing signature on {Document}.");

            }
        }
    }
}
