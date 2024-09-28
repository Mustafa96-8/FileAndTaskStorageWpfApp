﻿using System;

namespace WpfAppFileAndTaskStorage.Models
{
    public sealed class Document : BaseModel
    {
        private Document(int id, string name, string body, Guid? digitalSignature)
        {
            this.Id = id;
            this.Name = name;
            this.Body = body;
            this.DigitalSignature = digitalSignature;
        }

        public Guid? DigitalSignature {  get; private set; }




        //Должна ли быть функция в модели или должна находится в вью модел???
        //Если в модели то как указать что показание обновилось???
        //Если в вьюмодел то нужно сделать сеттер для свойств
        public void CreateDigitalSignature()
        {
            this.DigitalSignature = Guid.NewGuid();
        }

        /// <summary>
        /// Простая фабрика для создания нового экземпляра Документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <param name="name">Название документа</param>
        /// <param name="body">Содержание документа</param>
        /// <param name="digitalSignature">Цифровая подпись документа, если её нет принимает значение null</param>
        /// <returns>Возвращает созданный экземпляр документа, если все параметры прошли валидацию, иначе выкидывает ошибку</returns>
        /// <exception cref="ArgumentException">Если параметр не проходит проверку на допустимость</exception>
        public static Document Create(int id, string name, string body, Guid? digitalSignature = null)
        {
            if(id < 0)
            {
                throw new ArgumentException($"Не удаётся создать Документ, Параметр {nameof(id)} должен быть больше или равным 0");
            }

            return new Document(id, name, body, digitalSignature);
        }



    }
}
