using System;

namespace WpfAppFileAndTaskStorage.Models
{
    /// <summary>
    /// Класс, представляющий модель документа. Наследует базовые свойства из <see cref="BaseModel"/>.
    /// </summary>
    public sealed class Document : BaseModel
    {
        #region Свойства
        /// <summary>
        /// Цифровая подпись документа. Если подписи нет, значение равно <see langword="null"/>.
        /// </summary>
        public Guid? DigitalSignature {  get; private set; }

        #endregion

        #region Методы
        /// <summary>
        /// Создаёт новую цифровую подпись для документа, если её нет.
        /// </summary>
        public void CreateDigitalSignature()
        {
            this.DigitalSignature = Guid.NewGuid();
        }
        #endregion

        #region Конструктор
        /// <summary>
        /// Инициализирует новый экземпляр документа с указанным идентификатором.
        /// </summary>
        /// <param name="id">Уникальный идентификатор документа.</param>
        public Document(int id)
        {
            this.Id = id;
        }
        #endregion
    }
}
