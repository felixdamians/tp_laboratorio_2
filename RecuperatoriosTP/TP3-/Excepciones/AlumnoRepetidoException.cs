﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
        public AlumnoRepetidoException() : base("El alumno esta repetido en la lista.") { }
    }
}
