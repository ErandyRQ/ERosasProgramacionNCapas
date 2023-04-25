using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Producto" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Producto.svc o Producto.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Producto : IProducto
    {
        public SL_WCF.Result Add(ML.Producto producto)
        {
            var resultML = BL.Producto.Add(producto);
            

            //SL_WCF.Result resultService = new SL_WCF.Result();
            //resultService.Correct = resultML.Correct;
            //resultService.ErrorMessage = resultML.ErrorMessage;

            return new SL_WCF.Result
            {
                Correct = resultML.Correct,
                ErrorMessage = resultML.ErrorMessage
            };
        }
        public SL_WCF.Result Update(ML.Producto producto)
        {
            var resultML = BL.Producto.Update(producto);

            return new SL_WCF.Result
            {
                Correct = resultML.Correct,
                ErrorMessage = resultML.ErrorMessage,
                Object = resultML.Object,
                Objects = resultML.Objects
            };
        }

        
        public SL_WCF.Result Delete(ML.Producto producto)
            {
                var resultML = BL.Producto.Delete(producto);

                return new SL_WCF.Result
                {
                    Correct = resultML.Correct,
                    ErrorMessage = resultML.ErrorMessage,
                    Object = resultML.Object,
                    Objects = resultML.Objects
                };
            }
        

        
        public SL_WCF.Result GetAll()
            {
                ML.Result resultML = BL.Producto.GetAll();

                return new SL_WCF.Result
                {
                    Correct = resultML.Correct,
                    ErrorMessage = resultML.ErrorMessage,
                    Object = resultML.Object,
                    Objects = resultML.Objects
                };
            }



        public SL_WCF.Result GetById(ML.Producto producto)
        {
            ML.Result resultML = BL.Producto.GetById(producto);

                return new SL_WCF.Result
                {
                    Correct = resultML.Correct,
                    ErrorMessage = resultML.ErrorMessage,
                    Object = resultML.Object,
                    Objects = resultML.Objects
                };
            }
        


    }
}
