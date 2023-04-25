using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
   public class Operaciones : IOperaciones
    {
        public int Sumar(int Numero1, int Numero2)
        {
            return Numero1 + Numero2;
        }
        public int Restar(int Numero1, int Numero2)
        {
            return Numero1 - Numero2;
        }
        public int Multiplicar(int Numero1, int Numero2)
        {
            return Numero1 * Numero2;
        }
        public int Dividir(int Numero1, int Numero2)
        {
            return Numero1 / Numero2;
        }

    }
}
