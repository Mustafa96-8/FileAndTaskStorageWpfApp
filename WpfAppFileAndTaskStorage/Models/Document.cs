using System;

namespace WpfAppFileAndTaskStorage.Models
{
    public class Document
    {
        private Document(int id, string name, string body, Guid? digitalSignature)
        {
            Id = id;
            Name = name;
            Body = body;
            DigitalSignature = digitalSignature;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Body { get; private set; }

        public Guid? DigitalSignature {  get; private set; }




        public void CreateDigitalSignature()
        {
            DigitalSignature = Guid.NewGuid();
        }

        /// <summary>
        /// Simple document factory
        /// </summary>
        /// <param name="id">Documnet inuque number</param>
        /// <param name="name">Document name</param>
        /// <param name="body">Document body</param>
        /// <param name="digitalSignature">Digital sign can be null if document not signed</param>
        /// <returns>Return new Document if params are valid, else throw Exception</returns>
        /// <exception cref="ArgumentException">If params are not valid</exception>
        public static Document Create(int id, string name, string body, Guid? digitalSignature = null)
        {
            if(id < 0)
            {
                throw new ArgumentException($"{nameof(id)} is not valid");
            }


            return new Document(id, name, body, digitalSignature);
        }



    }
}
