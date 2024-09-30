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
        /// Цифровая подпись документа. <see langword="null"/>, если подписи нет.
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
        private bool CanCreateDigitalSignature => DigitalSignature == null;

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
        /// Конструктор для создания модели представления документа с заданным идентификатором, именем и содержимым.
        /// </summary>
        /// <param name="id">Идентификатор документа.</param>
        /// <param name="name">Название документа.</param>
        /// <param name="body">Содержание документа.</param>
        public DocumentViewModel(int id, string name, string body)
        {
            // Инициализация модели документа.
            this.Document = new Document(id);
            this.body = body;
            this.name = name;
            this.IsDigitalSignatureNull = true; // По умолчанию цифровой подписи нет.
            this.DigitalSignature = null;

            // Привязка команды создания цифровой подписи.
            this.CreateDigitalSignatureCommand = new RelayCommand(execute => CreateDigitalSignature(),canExecute => CanCreateDigitalSignature);
        }

        /// <summary>
        /// Конструктор для создания модели представления документа с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор документа.</param>
        public DocumentViewModel(int id)
        {
            this.Document = new Document(id);
            this.isDigitalSignatureNull = true;
            this.digitalSignature = null;
            // Привязка команды создания цифровой подписи.
            this.CreateDigitalSignatureCommand = new RelayCommand(execute => CreateDigitalSignature(), canExecute => CanCreateDigitalSignature);
        }
        #endregion
    }
}
