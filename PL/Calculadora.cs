using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Calculadora
    {
        public static void Suma()
        {
            ServiceCalculadora.CalculatorSoapClient calculadora = new ServiceCalculadora.CalculatorSoapClient();
            var result = calculadora.Add(15,4);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static void Resta()
        {
            ServiceCalculadora.CalculatorSoapClient calculadora = new ServiceCalculadora.CalculatorSoapClient();
            var result = calculadora.Subtract(15, 4);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        public static void Multiplicacion()
        {
            ServiceCalculadora.CalculatorSoapClient calculadora = new ServiceCalculadora.CalculatorSoapClient();
            var result = calculadora.Multiply(15, 4);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        public static void Division()
        {
            ServiceCalculadora.CalculatorSoapClient calculadora = new ServiceCalculadora.CalculatorSoapClient();
            var result = calculadora.Divide(15, 4);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
