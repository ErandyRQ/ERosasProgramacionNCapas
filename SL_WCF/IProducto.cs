using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IProducto" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IProducto
    {
        [OperationContract]
        SL_WCF.Result Add(ML.Producto producto);

        [OperationContract]
        SL_WCF.Result Update(ML.Producto producto);

        [OperationContract]
        SL_WCF.Result Delete(ML.Producto producto);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        SL_WCF.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        SL_WCF.Result GetById(ML.Producto producto);
    }
}
