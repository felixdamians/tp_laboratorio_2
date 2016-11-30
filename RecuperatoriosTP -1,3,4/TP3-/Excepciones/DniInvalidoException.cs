using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        string baseMessage;

        public DniInvalidoException() : base("Error. El dni es invalido") { }

        public DniInvalidoException(string message,Exception e) : base(message,e)
        {
            this.baseMessage = message;
        }

        public DniInvalidoException(Exception e) : this(null, e) { }

        public DniInvalidoException(string message) : this(message, null) { }

    }
}
