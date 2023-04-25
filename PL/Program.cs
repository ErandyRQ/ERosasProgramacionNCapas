using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            //  Usuario
             /* while (!salir)
              {
                  Console.WriteLine("Elige una opcón");
                  Console.WriteLine("1. ADD");
                  Console.WriteLine("2. UPDATE");
                  Console.WriteLine("3. DELETE");
                  Console.WriteLine("4. GETALL");
                  Console.WriteLine("5. GETBYID");
                  Console.WriteLine("6. Salir");

                  int opcion = Convert.ToInt32(Console.ReadLine());

                  switch (opcion)
                  {
                      case 1:
                          PL.Usuario.Add();
                          break;

                      case 2:
                          PL.Usuario.Update();
                          break;

                      case 3:
                          PL.Usuario.Delete();
                          break;
                      case 4:
                          PL.Usuario.GetAll();
                          break;
                      case 5:
                          PL.Usuario.GetById();
                          break;
                      case 6:
                          Console.WriteLine("-------------------");
                          salir = true;
                          break;
                      default:
                          Console.WriteLine("Elige una opcion entre 1 y 5");
                          break;
                  }


              }*/


             //Producto
               while (!salir)
               {
                   Console.WriteLine("Elige una opcón");
                   Console.WriteLine("1. ADD");
                   Console.WriteLine("2. UPDATE");
                   Console.WriteLine("3. DELETE");
                   Console.WriteLine("4. GETALL");
                   Console.WriteLine("5. GETBYID");
                   Console.WriteLine("6. Salir");

                   int opcion = Convert.ToInt32(Console.ReadLine());

                   switch (opcion)
                   {
                       case 1:
                           PL.Producto.Add();
                           break;

                       case 2:
                           PL.Producto.UpdateEF();
                           break;

                       case 3:
                           PL.Producto.Delete();
                           break;
                       case 4:
                           PL.Producto.GetAll();
                           break;
                       case 5:
                           PL.Producto.GetByIdEF();
                           break;
                       case 6:
                           Console.WriteLine("-------------------");
                           salir = true;
                           break;
                       
                   }


               }

            //Producto HTTP/WebAPI

           /* while (!salir)
            {
                Console.WriteLine("Elige una opcón");
                Console.WriteLine("1. ADD");
                Console.WriteLine("2. UPDATE");
                Console.WriteLine("3. DELETE");
                Console.WriteLine("4. GETALL");
                Console.WriteLine("5. GETBYID");
                Console.WriteLine("6. Salir");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        PL.Producto.AddAPI();
                        break;

                    case 2:
                        PL.Producto.UpdateAPI();
                        break;

                    case 3:
                        PL.Producto.DeleteAPI();
                        break;
                    case 4:
                        PL.Producto.GetAllAPI();
                        break;
                    case 5:
                        PL.Producto.GetByIdAPI();
                        break;
                    case 6:
                        Console.WriteLine("-------------------");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Elige una opcion entre 1 y 5");
                        break;
                }

            }*/

            //PL.Calculadora.Suma();
            // PL.Calculadora.Division();
            // PL.Calculadora.Multiplicacion();
            //PL.Calculadora.Resta();
        }
    }
}
