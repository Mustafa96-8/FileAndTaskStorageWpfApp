using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAppFileAndTaskStorage.MVVM
{
    /// <summary>
    /// Базовый класс модели представления, реализует интерфейс  <see cref="INotifyPropertyChanged"/> .
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод который уведомляет интерфейс о том, что параметр, 
        /// на который ссылается метод, изменился и нужно обновить отображение.
        /// </summary>
        /// <param name="propertyName">Название параметра, к которому создана привязка в интерфейсе.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Метод для установки значения свойства и уведомления об изменении, если новое значение отличается от старого.
        /// Если значение изменилось, вызывается событие <see cref="PropertyChanged"/>.
        /// </summary>
        /// <typeparam name="T">Тип данных объекта.</typeparam>
        /// <param name="storage">Ссылка на поле, хранящее текущее значение свойства.</param>
        /// <param name="value">Новое значение для свойства.</param>
        /// <param name="propertyName">Название свойства для уведомления об изменении. По умолчанию принимает имя метода, в котором он был вызван.</param>
        /// <returns>Возвращает <see langword="true"/>, если значение было изменено. Иначе <see langword="false"/>.</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) 
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

    }
}
