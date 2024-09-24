using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppFileAndTaskStorage.Models;
using WpfAppFileAndTaskStorage.MVVM;

namespace WpfAppFileAndTaskStorage.ViewModels
{
    public class DocumentViewModel :BaseViewModel
    {
        public Document Document { get; set; }

        public ICommand CloseWindowCommand { get; private set; }
        public ICommand CreateDigitalSignatureCommand { get; private set; }


        private bool _isDigitalSignatureNull;

        public bool IsDigitalSignatureNull
        {
            get => _isDigitalSignatureNull;
            set => SetProperty(ref _isDigitalSignatureNull, value);
        }
        
        private Guid? _digitalSignature;

        public Guid? DigitalSignature
        {
            get => _digitalSignature;
            set => SetProperty(ref _digitalSignature, value);
        }
        

        public DocumentViewModel(Document document)
        {
            
            Document = document;
            IsDigitalSignatureNull = Document.DigitalSignature == null;
            DigitalSignature = Document.DigitalSignature;
            CloseWindowCommand = new RelayCommand(execute => CloseWindow(this), canExecute => true);
            CreateDigitalSignatureCommand = new RelayCommand(execute => CreateDigitalSignature(),canExecute => true);

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
                IsDigitalSignatureNull = false;
                DigitalSignature = Document.DigitalSignature;
            }
            else
            {
                /*throw new Exception($"Create a new digital signature for a document with an existing signature on {Document}.");*/
                return;

            }
        }
    }
}
