﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica2
{
    public class Logic
    {
        public static void Method()
        {
            throw new AmbiguousMatchException();
        }

        public static void CustomMethod()
        {
            throw new MyCustomException("Mensaje genérico de mi excepción personalizada.");
        }
    }
}
