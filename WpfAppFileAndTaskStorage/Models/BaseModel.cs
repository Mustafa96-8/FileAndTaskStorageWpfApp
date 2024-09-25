using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace WpfAppFileAndTaskStorage.Models
{
    public class BaseModel
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        public string Body { get; protected set; }


        public void SetName(string name)
        {
            if (name.Length < 60)
            {
                this.Name = name;
            }
        }

        public void SetBody(string body)
        {
            if (body.Length < 400)
            {
                this.Body = body;
            }
        }
    }
}
