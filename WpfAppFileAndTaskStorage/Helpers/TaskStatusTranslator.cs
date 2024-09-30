using System.Collections.Generic;
using WpfAppFileAndTaskStorage.Enums;
using WpfAppFileAndTaskStorage.Models;

namespace WpfAppFileAndTaskStorage.Helpers
{
    /// <summary>
    /// Статический класс для перевода статусов задачи на русский язык.
    /// </summary>
    public static class TaskStatusTranslator
    {
        /// <summary>
        /// Словарь, содержащий переводы статусов задачи.
        /// Ключ — это значение перечисления <see cref="TaskStatus"/>, а значение — строковое представление на русском языке.
        /// </summary>
        public static readonly Dictionary<TaskStatus, string> StatusTranslations = new Dictionary<TaskStatus, string>
        {
            { TaskStatus.AtWork, "В работе" },  
            { TaskStatus.Completed, "Выполнена" } 
        };

        /// <summary>
        /// Метод для получения переведённого названия статуса задачи.
        /// </summary>
        /// <param name="status">Статус задачи из перечисления <see cref="TaskStatus"/>.</param>
        /// <returns>
        /// Возвращает строковое представление статуса на русском языке, если перевод существует, 
        /// иначе возвращает название статуса по умолчанию.
        /// </returns>
        public static string GetStatusDisplayName(TaskStatus status)
        {
            return StatusTranslations.ContainsKey(status)
                ? StatusTranslations[status]
                : status.ToString();
        }
    }
}
