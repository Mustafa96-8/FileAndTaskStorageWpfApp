using System;
using System.Windows;
using System.Windows.Input;
using WpfAppFileAndTaskStorage.Models;
using WpfAppFileAndTaskStorage.MVVM;

namespace WpfAppFileAndTaskStorage.ViewModels
{
    /// <summary>
    /// Класс модели представления для документа.
    /// </summary>
    public class DocumentViewModel : BaseViewModel
    {
        #region Поля и свойства
        /// <summary>
        /// Модель документа, связанная с данной моделью представления.
        /// </summary>
        public Document Document { get; set; }

        /// <summary>
        /// Команда для создания цифровой подписи документа.
        /// </summary>
        public ICommand CreateDigitalSignatureCommand { get; private set; }
        

        private bool isDigitalSignatureNull;
        
        /// <summary>
        /// Определяет, имеет ли документ цифорвую подпись.
        /// Значение <see langword="true"/>, если подписи нет. <see langword="false"/>, если есть.
        /// </summary>
        public bool IsDigitalSignatureNull
        {
            get => isDigitalSignatureNull;
            set
            {
                SetProperty(ref isDigitalSignatureNull, value);
                this.CanDocumentChange = !value;
            }
        }

        private bool canDocumentChange;   

        /// <summary>
        /// Определяет, можно ли редактировать документ.
        /// Если цифровая подпись отсутствует, документ можно изменять.
        /// </summary>
        public bool CanDocumentChange 
        { 
            get => canDocumentChange;
            set => SetProperty(ref canDocumentChange, value);
        }

        private Guid? digitalSignature;

        /// <summary>
        /// Цифровая подпись документа. null, если подписи нет.
        /// </summary>
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
                this.Document.SetName(value);
            }
        }

        private string body;

        public string Body
        {
            get => body;
            set
            {
                SetProperty(ref body, value);
                this.Document.SetBody(value);    
            } 
        }

        public string TypeName => "Документ";

        private bool CanCreateDigitalSignature => Document.DigitalSignature != null;

        #endregion


        public DocumentViewModel(Document document)
        {
            this.Document = document;
            this.body = document.Body;
            this.name = document.Name;
            this.IsDigitalSignatureNull = document.DigitalSignature == null;
            this.DigitalSignature = document.DigitalSignature;


            this.CreateDigitalSignatureCommand = new RelayCommand(execute => CreateDigitalSignature(),canExecute => CanCreateDigitalSignature);
        }

        private void CreateDigitalSignature()
        {
            this.Document.CreateDigitalSignature();
            this.IsDigitalSignatureNull = false;
            this.DigitalSignature = Document.DigitalSignature;
        }


    }
}
