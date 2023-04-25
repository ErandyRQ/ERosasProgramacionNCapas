using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PL
{
    internal class Producto
    {
        public static void Add()
        {

            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el nombre del producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el precio unitario");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la descripcion del producto");
            producto.Descripcion = Console.ReadLine();
        
            

            //ML.Result result = BL.Usuario.Add(usuario);
            //ML.Result result = BL.Usuario.AddSP(usuario);
            //ML.Result result = BL.Usuario.AddEF(usuario);
            //ML.Result result = BL.Usuario.AddLINQ(usuario);
            ServicioProducto.ProductoClient servicioProducto = new ServicioProducto.ProductoClient();
            var result = servicioProducto.Add(producto);

            if (result.Correct)
            {
                Console.WriteLine("El registro fue exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }
        }

        public static void Update()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Ingrese el indice del producto a actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del producto ");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el precio unitario ");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el stock");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la descripción");
            producto.Descripcion = Console.ReadLine();



            // ML.Result result = BL.Usuario.UpdateLINQ(usuario);
            ServicioProducto.ProductoClient servicioProducto = new ServicioProducto.ProductoClient();
            var result = servicioProducto.Update(producto);

            if (result.Correct)
            {
                Console.WriteLine("Se actualizo correctamente");
            }
            else
            {
                Console.WriteLine("Error al actualizar" + result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Ingrese el indice del producto a eliminar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Delete(usuario);
            ServicioProducto.ProductoClient servicioProducto = new ServicioProducto.ProductoClient();
            var result = servicioProducto.Delete(producto);


            if (result.Correct)
            {
                Console.WriteLine("Registro eliminado");
            }
            else
            {
                Console.WriteLine("Error al eliminar" + result.ErrorMessage);
            }
        }

        public static void GetAll()
        {
            //ML.Result result = BL.Usuario.GetAll();
            ServicioProducto.ProductoClient servicioProducto = new ServicioProducto.ProductoClient();
            var result = servicioProducto.GetAll();

            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("Id: " + producto.IdProducto);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("PrecioUnitario: " + producto.PrecioUnitario);
                    Console.WriteLine("Stock: " + producto.Stock);
                    Console.WriteLine("Descripcion: " + producto.Descripcion);
                    Console.WriteLine("Proveedor: " + producto.Proveedor.Nombre);
                    Console.WriteLine("Departamento: " + producto.Departamento.Nombre);
                  

                }
            }
            else
            {
                Console.WriteLine("Ocurrio error" + result.ErrorMessage);
            }

        }

        public static void GetById()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el indice del producto a mostrar");
            producto.IdProducto = int.Parse(Console.ReadLine());


            ServicioProducto.ProductoClient servicioProducto = new ServicioProducto.ProductoClient();
            var result = servicioProducto.GetById(producto);

            if (result.Correct)
            {

                ML.Producto producto1 = (ML.Producto)result.Object;
              

                Console.WriteLine("Id: " + producto1.IdProducto);
                Console.WriteLine("Nombre: " + producto1.Nombre);
                Console.WriteLine("Precio Unitario: " + producto1.PrecioUnitario);
                Console.WriteLine("Stock: " + producto1.Stock);
                Console.WriteLine("Descripción: " + producto1.Descripcion);
 

                Console.WriteLine("________________________________");
                Console.ReadKey();

               
            }
            else
            {
                Console.WriteLine("Ocurrio error" + result.ErrorMessage);
            }

        }

        public static void  AddAPI()
        {
            
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Nombre del producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Precio Unitario del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Descripción del producto");
            producto.Descripcion = Console.ReadLine();

            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:16436/api/");

                var url = ConfigurationManager.AppSettings["WebApiURL"].ToString();
                client.BaseAddress = new Uri(url);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ML.Producto>("Producto", producto);

                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    
                    Console.WriteLine("Ingresado correctamente");

                }
                else
                {
                    Console.WriteLine("No se realizo registro");
                }
            }
        }
        public static void UpdateAPI()
        {
            // ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(Val);
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el id del producto a actualizar");
            producto.IdProducto=int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el precio unitario");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el stock");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la descripcion");
            producto.Descripcion = Console.ReadLine();

            using (HttpClient client = new HttpClient())
            {
                // client.BaseAddress = new Uri("http://localhost:16436/api/");

                var url = ConfigurationManager.AppSettings["WebApiURL"].ToString();
                client.BaseAddress = new Uri(url);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<ML.Producto>("Producto/Update",producto);

                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {

                    Console.WriteLine("Actualizado correctamente");

                }
                else
                {
                    Console.WriteLine("No se actualizo registro");
                }
            }
        }
        public static void DeleteAPI()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el producto a eliminar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            using (HttpClient client = new HttpClient())
            {
                // client.BaseAddress = new Uri("http://localhost:16436/api/");

                var url = ConfigurationManager.AppSettings["WebApiURL"].ToString();
                client.BaseAddress = new Uri(url);

                //HTTP POST
                var deleteTask = client.DeleteAsync("Producto/" + producto.IdProducto);
                deleteTask.Wait();


                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {

                    Console.WriteLine("Eliminado correctamente");

                }
                else
                {
                    Console.WriteLine("No se realizo eliminación");
                }
            }


        }
        public static void GetAllAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:16436/api/");
                var url = ConfigurationManager.AppSettings["WebApiURL"].ToString();
                client.BaseAddress = new Uri(url);
                //HTTP GET
                var responseTask = client.GetAsync("Producto");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var productoItem in readTask.Result.Objects)
                    {
                        ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(productoItem.ToString());

                        Console.WriteLine("IdProducto: " + resultItemList.IdProducto);
                        Console.WriteLine("Nombre: " + resultItemList.Nombre);
                        Console.WriteLine("Precio Unitario: " + resultItemList.PrecioUnitario);
                        Console.WriteLine("Stock: " + resultItemList.Stock);
                        Console.WriteLine("Descripcion: " + resultItemList.Descripcion);
                        Console.WriteLine("_____________________________________");
                        
                    }
                    Console.ReadKey();

                }
            }
        }
        public static void GetByIdAPI()
        {
            Console.WriteLine("Ingrese el id del producto");
            int IdProducto =int.Parse(Console.ReadLine());

            using (var client = new HttpClient())
            {
                var url = ConfigurationManager.AppSettings["WebApiURL"].ToString();
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("Producto/" + IdProducto);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    ML.Producto producto = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(readTask.Result.Object.ToString());

                    Console.WriteLine("IdProducto: " + producto.IdProducto);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("PrecioUnitario: " + producto.PrecioUnitario);
                    Console.WriteLine("Stock: " + producto.Stock);
                    Console.WriteLine("Descripcion: " + producto.Descripcion);
                    
                }
            }
        }


        public static void AddEF()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Ingrese el Nombre del producto");
            producto.Nombre= Console.ReadLine();
            Console.WriteLine("Ingrese el Precio Unitario");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Stock");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la descripcion");
            producto.Descripcion = Console.ReadLine();
            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("Ingrese el Id del Proveedor");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            producto.Departamento = new ML.Departamento();
            Console.WriteLine("Ingrese el Id del Departamento");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.AddEF(producto);

            if (result.Correct)
            {
                Console.WriteLine("El registro fue exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }
        }
        public static void UpdateEF()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del producto");
            producto.IdProducto = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Nombre del producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Precio Unitario");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Stock");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la descripcion");
            producto.Descripcion = Console.ReadLine();
            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("Ingrese el Id del Proveedor");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            producto.Departamento = new ML.Departamento();
            Console.WriteLine("Ingrese el Id del Departamento");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.UpdateEF(producto);

            if (result.Correct)
            {
                Console.WriteLine("La actualizacion fue exitosa");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }
        }
        public static void DeleteEF()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del producto");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.DeleteEF(producto);
            if (result.Correct)
            {
                Console.WriteLine("La eliminación fue exitosa");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }
        }
        public static void GetAllEF()
        {
            ML.Result result = BL.Producto.GetAllEF();
            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("Nombre " + producto.Nombre);
                    Console.WriteLine("Precio Unitario " + producto.PrecioUnitario);
                    Console.WriteLine("Stock " + producto.Stock);
                    Console.WriteLine("Descripcion " + producto.Descripcion);
                    Console.WriteLine("Proveedor " + producto.Proveedor.Nombre);
                    Console.WriteLine("Telefono Proveedor " + producto.Proveedor.Telefono);
                    Console.WriteLine("Departamento " + producto.Departamento.Nombre);
                    Console.WriteLine("Area " + producto.Departamento.Area.Nombre);
                    Console.WriteLine("___________________________________");

                }
            }
            else
            {
                Console.WriteLine("Ocurrio error" + result.ErrorMessage);
            }
        }
        public static void GetByIdEF()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id Prodcto");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.GetByIdEF(producto.IdProducto);

            if (result.Correct)
            {
                ML.Producto prod = (ML.Producto)result.Object;

                Console.WriteLine("Nombre: " + prod.Nombre);
                Console.WriteLine("Precio Unitario: " + prod.PrecioUnitario);
                Console.WriteLine("Stock: " + prod.Stock);
                Console.WriteLine("Descripcion: " + prod.Descripcion);
                Console.WriteLine("Proveedor: " + prod.Proveedor.Nombre);
                Console.WriteLine("Telefono Proveedor: " + prod.Proveedor.Telefono);
                Console.WriteLine("Departamento: "+ prod.Departamento.Nombre);
                Console.WriteLine("Area: "+ prod.Departamento.Area.Nombre);

            }
            else
            {
                Console.WriteLine("Ocurrio error" + result.ErrorMessage);
            }
        }

    }
}
