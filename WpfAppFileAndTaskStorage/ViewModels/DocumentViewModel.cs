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
        /// Цифровая подпись документа. <see langword="null">, если подписи нет.
        /// </summary>
        public Guid? DigitalSignature
        {
            get => digitalSignature;
            set => SetProperty(ref digitalSignature, value);
        }


        private string name;
        
        /// <summary>
        /// Название документа. При изменении обновляет название в модели документа.
        /// </summary>
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

        /// <summary>
        /// Содержание документа. При изменении обновляет содержание в модели документа.
        /// </summary>
        public string Body
        {
            get => body;
            set
            {
                SetProperty(ref body, value);
                this.Document.SetBody(value);    
            } 
        }

        /// <summary>
        /// Строковое представление типа объекта.
        /// </summary>
        public string TypeName => "Документ";

        /// <summary>
        /// Определяет, можно ли создать цифровую подпись. 
        /// </summary>
        private bool CanCreateDigitalSignature => Document.DigitalSignature == null;

        #endregion

        #region Методы
        /// <summary>
        /// Создаёт цифровую подпись для документа.
        /// Обновляет состояние <see cref="IsDigitalSignatureNull"/> и <see cref="DigitalSignature"/> после создания подписи.
        /// </summary>
        private void CreateDigitalSignature()
        {
            this.Document.CreateDigitalSignature();
            this.IsDigitalSignatureNull = false;
            this.DigitalSignature = Document.DigitalSignature;
        }
        #endregion

        #region Конструктор
        /// <summary>
        /// Инициалиализирует новый экземпляр класса <see cref="DocumentViewModel"/> на основе переданной модели документа.
        /// </summary>
        /// <param name="document">Модель документа, связанная с этой моделью представления.</param>
        public DocumentViewModel(Document document)
        {
            // Инициализация полей модели представления данными из модели документов.
            this.Document = document;
            this.body = document.Body;
            this.name = document.Name;
            this.IsDigitalSignatureNull = document.DigitalSignature == null;
            this.DigitalSignature = document.DigitalSignature;

            // Привязка команд к методам-обработчикам через объект RelayCommand.
            this.CreateDigitalSignatureCommand = new RelayCommand(execute => CreateDigitalSignature(),canExecute => CanCreateDigitalSignature);
        }
        #endregion
    }
}
