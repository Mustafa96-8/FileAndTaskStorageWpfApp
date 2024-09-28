namespace WpfAppFileAndTaskStorage.Models
{
    /// <summary>
    /// Базовый класс модели, содержащий общие свойства для всех моделей.
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Уникальный идентификатор объекта.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Название объекта.
        /// </summary>  
        public string Name { get; protected set; }

        /// <summary>
        /// Содержимое объекта.
        /// </summary>
        public string Body { get; protected set; }

        /// <summary>
        /// Устанавливает новое название для объекта.
        /// Название должно быть не длиннее 60 символов.
        /// </summary>
        /// <param name="name">Новое название объекта.</param>
        public void SetName(string name)
        {
            if (name.Length < 60)
            {
                this.Name = name;
            }
        }

        /// <summary>
        /// Устанавливает новое содержимое для объекта.
        /// Содержимое должно быть не длиннее 400 символов.
        /// </summary>
        /// <param name="body">Новое содержимое объекта.</param>
        public void SetBody(string body)
        {
            if (body.Length < 400)
            {
                this.Body = body;
            }
        }
    }
}
