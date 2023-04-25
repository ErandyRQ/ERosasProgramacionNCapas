using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Saludo" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Saludo.svc o Saludo.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Saludo : ISaludo
    {
        public string Saludar(string Nombre)
        {
            return string.Format("Hola " + Nombre); 
        }
    }
}
