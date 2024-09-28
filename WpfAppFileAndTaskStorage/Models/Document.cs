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

        /// <summary>
        /// Простая фабрика для создания нового экземпляра документа.
        /// </summary>
        /// <param name="id">Идентификатор документа.</param>
        /// <param name="name">Название документа.</param>
        /// <param name="body">Содержание документа.</param>
        /// <param name="digitalSignature">Цифровая подпись документа, если она есть. Принимает значение <see langword="null"/>, если подпись отсутствует.</param>
        /// <returns>Возвращает созданный экземпляр документа.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если параметр <paramref name="id"/> меньше 0.</exception>
        public static Document Create(int id, string name, string body, Guid? digitalSignature = null)
        {
            if(id < 0)
            {
                throw new ArgumentException($"Не удаётся создать Документ, Параметр {nameof(id)} должен быть больше или равным 0");
            }

            return new Document(id, name, body, digitalSignature);
        }
        #endregion
        
        #region Конструктор
        /// <summary>
        /// Приватный конструктор для создания документа.
        /// Используется только через фабричный метод <see cref="Create"/>.
        /// </summary>
        /// <param name="id">Идентификатор документа.</param>
        /// <param name="name">Название документа.</param>
        /// <param name="body">Содержание документа.</param>
        /// <param name="digitalSignature">Цифровая подпись документа, если есть.</param>
        private Document(int id, string name, string body, Guid? digitalSignature)
        {
            this.Id = id;
            this.Name = name;
            this.Body = body;
            this.DigitalSignature = digitalSignature;
        }
        #endregion
    }
}
