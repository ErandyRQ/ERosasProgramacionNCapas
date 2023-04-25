using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        public static void Add()
        {
          
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el nombre del usuario");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de nacimiento del usuario");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del usuario");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el username del usuario");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingrese el email del usuario");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese el password del usuario");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingrese el sexo del usuario");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingrese el celular del usuario");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingrese la CURP del usuario");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("Ingrese el Id del Rol");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre de la calle");
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Calle = Console.ReadLine();
            Console.WriteLine("Ingrese el numero interior");
            usuario.Direccion.NumeroInterior = Console.ReadLine();
            Console.WriteLine("Ingrese el numero exterior");
            usuario.Direccion.NumeroExterior = Console.ReadLine();
            Console.WriteLine("Ingrese el Id de la colonia");
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Add(usuario);
            //ML.Result result = BL.Usuario.AddSP(usuario);
            ML.Result result = BL.Usuario.AddEF(usuario);
            //ML.Result result = BL.Usuario.AddLINQ(usuario);

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
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el indice del usuario a actualizar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del usuario a actualizar");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido paterno del usuario a actualizar");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido materno del usuario a actualizar");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de nacimiento del usuario a actualizar");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del usuario a actualizar");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el username del usuario a actualizar");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingrese el email del usuario a actualizar");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese el password del usuario a actualizar");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingrese el sexo del usuario a actualizar");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingrese el celular del usuario a actualizar");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingrese el la CURP del usuario a actualizar");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("Ingrese el Id del Rol del usuario a actualizar");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre de la calle a actualizar");
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Calle = Console.ReadLine();
            Console.WriteLine("Ingrese el numero interior a actualizar");
            usuario.Direccion.NumeroInterior = Console.ReadLine();
            Console.WriteLine("Ingrese el numero exterior a actualizar");
            usuario.Direccion.NumeroExterior = Console.ReadLine();

            Console.WriteLine("Ingrese el Id de la colonia a actualizar");
            usuario.Direccion.Colonia= new ML.Colonia();
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            //ML.Result result= BL.Usuario.UpdateLINQ(usuario);
            ML.Result result = BL.Usuario.UpdateEF(usuario);
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
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el indice del usuario a eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Delete(usuario);
            //ML.Result result = BL.Usuario.DeleteLINQ(usuario);
            ML.Result result = BL.Usuario.DeleteEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro eliminado");
            }
            else
            {
                Console.WriteLine("Error al eliminar"+ result.ErrorMessage);
            }
        }
        public static void GetAll()
        {
            //ML.Result result = BL.Usuario.GetAll();
            //ML.Result result = BL.Usuario.GetAllLINQ();
            ML.Result result = BL.Usuario.GetAllEF();
            if (result.Correct)
            {
                foreach(ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("Id: " + usuario.IdUsuario);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Fecha Nacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("Telefono: " + usuario.Telefono);
                    Console.WriteLine("UserName: " + usuario.UserName);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("Password: " + usuario.Password);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Celular: " + usuario.Celular);
                    Console.WriteLine("CURP: " + usuario.CURP);

                    Console.WriteLine("IdRol: " + usuario.Rol.IdRol);
                    Console.WriteLine("Rol del Usuario: " + usuario.Rol.Nombre);
                    Console.WriteLine("Calle del Usuaro: "+usuario.Direccion.Calle);
                    Console.WriteLine("Numero Interior del Usuaro: "+usuario.Direccion.NumeroInterior);
                    Console.WriteLine("Numero Exterior del Usuaro: "+usuario.Direccion.NumeroExterior);
                    Console.WriteLine("Id de la Colonia del Usuaro: "+ usuario.Direccion.Colonia.IdColonia);
                    Console.WriteLine("Nombre de la Colonia: "+ usuario.Direccion.Colonia.Nombre);
                    Console.WriteLine("Nombre del código postal: "+ usuario.Direccion.Colonia.CodigoPostal);
                    Console.WriteLine("Id del municipio de usuario: "+ usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    Console.WriteLine("Nombre del municipio: "+ usuario.Direccion.Colonia.Municipio.Nombre);
                    Console.WriteLine("Id del Estado: "+ usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    Console.WriteLine("Nombre del Estado: "+ usuario.Direccion.Colonia.Municipio.Estado.Nombre);
                    Console.WriteLine("Id del Pais: "+ usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    Console.WriteLine("Nombre del Pais: "+ usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre);


                    Console.WriteLine("________________________________");

                }
            }
            else
            {
                Console.WriteLine("Ocurrio error" + result.ErrorMessage);
            }
            
        }
        public static void GetById()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el indice del usuario a mostrar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            // ML.Result result = BL.Usuario.GetById(usuario);
            // ML.Result result = BL.Usuario.GetByIdLINQ(usuario.IdUsuario);
            ML.Result result = BL.Usuario.GetByIdEF(usuario.IdUsuario);

            if (result.Correct)
            {

                ML.Usuario usuario1 = (ML.Usuario)result.Object;//nuevo objeto
                ML.Rol rol = new ML.Rol();

                Console.WriteLine("Id: " + usuario1.IdUsuario);
                Console.WriteLine("Nombre: " + usuario1.Nombre);
                Console.WriteLine("Apellido Paterno: " + usuario1.ApellidoPaterno);
                Console.WriteLine("Apellido Maerno: " + usuario1.ApellidoMaterno);
                Console.WriteLine("Fecha Nacimiento: " + usuario1.FechaNacimiento);
                Console.WriteLine("Telefono: " + usuario1.Telefono);
                Console.WriteLine("UserName: " + usuario1.UserName);
                Console.WriteLine("Email: " + usuario1.Email);
                Console.WriteLine("Password: " + usuario1.Password);
                Console.WriteLine("Sexo: " + usuario1.Sexo);
                Console.WriteLine("Celular: " + usuario1.Celular);
                Console.WriteLine("CURP: " + usuario1.CURP);
                Console.WriteLine("IdRol: "+ usuario1.Rol.IdRol);
                //Console.WriteLine("Rol: " + usuario1.Rol.Nombre);

                Console.WriteLine("Calle: " + usuario1.Direccion.Calle);
                Console.WriteLine("Numero Interior: "+usuario1.Direccion.NumeroInterior);
                Console.WriteLine("Numero Exterior: " + usuario1.Direccion.NumeroExterior);
                Console.WriteLine("Id de la Colonia: " + usuario1.Direccion.Colonia.IdColonia);

                Console.WriteLine("________________________________");
                Console.ReadKey();

                //foreach (ML.Usuario usuarioU in result.Object)
                //{
                //    Console.WriteLine("Id: " + usuarioU.IdUsuario);
                //    Console.WriteLine("Nombre: " + usuarioU.Nombre);
                //    Console.WriteLine("Apellido Paterno: " + usuarioU.ApellidoPaterno);
                //    Console.WriteLine("Apellido Materno: " + usuarioU.ApellidoMaterno);
                //    Console.WriteLine("Fecha Nacimiento: " + usuarioU.FechaNacimiento);
                //    Console.WriteLine("Telefono: " + usuarioU.Telefono);
                //    Console.WriteLine("________________________________");

                //}
            }
            else
            {
                Console.WriteLine("Ocurrio error" + result.ErrorMessage);
            }

        }

        

    }
}
