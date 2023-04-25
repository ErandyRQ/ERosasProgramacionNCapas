using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISaludo" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISaludo
    {
        [OperationContract]
        string Saludar(string Nombre);
    }
    //Result -> SL_WCF

    [DataContract] //Decoradores
    public class Result
    {
        [DataMember]
        public bool Correct { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public object Object { get; set; }
        [DataMember]
        public List<object> Objects { get; set; }
        [DataMember]
        public Exception Ex { get; set; }

    }
}
