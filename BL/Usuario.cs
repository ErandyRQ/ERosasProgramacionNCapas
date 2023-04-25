using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ML;
using System.Data;
using System.Globalization;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())//parametros, instrucciones,query
                    {
                        cmd.CommandText = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento],[Telefono]) VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento,@Telefono)";

                        SqlParameter[] collection = new SqlParameter[5];
                        collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;
                        collection[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;
                        collection[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;
                        collection[3] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.Date);
                        collection[3].Value = usuario.FechaNacimiento;
                        collection[4] = new SqlParameter("Telefono", System.Data.SqlDbType.VarChar);
                        collection[4].Value = usuario.Telefono;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection = context;

                        cmd.Connection.Open();
                        int RowAffected = cmd.ExecuteNonQuery();
                        if (RowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al insertar en la tabla alumno";
                        }



                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE [Usuario] SET [Nombre] = @Nombre,[ApellidoPaterno] = @ApellidoPaterno,[ApellidoMaterno] = @ApellidoMaterno,[FechaNacimiento] = @FechaNacimiento,[Telefono] = @Telefono WHERE [IdUsuario] = @IdUsuario";
                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;
                        collection[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;
                        collection[2] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;
                        collection[3] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;
                        collection[4] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.Date);
                        collection[4].Value = usuario.FechaNacimiento;
                        collection[5] = new SqlParameter("Telefono", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.Telefono;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection = context;

                        cmd.Connection.Open();
                        int RowAffected = cmd.ExecuteNonQuery();
                        if (RowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo actualizar";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;


        }
        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "DELETE FROM [Usuario] WHERE ([IdUsuario] = @IdUsuario)";
                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection = context;

                        cmd.Connection.Open();
                        int RowAffected = cmd.ExecuteNonQuery();
                        if (RowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se elimino el registro";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento],[Telefono]FROM [Usuario]";
                        cmd.Connection = context;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaUsuario = new DataTable();
                            da.Fill(tablaUsuario);

                            if (tablaUsuario.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();

                                foreach (DataRow row in tablaUsuario.Rows)
                                {
                                    ML.Usuario usuario = new ML.Usuario();

                                    usuario.IdUsuario = int.Parse(row[0].ToString());
                                    usuario.Nombre = row[1].ToString();
                                    usuario.ApellidoMaterno = row[2].ToString();
                                    usuario.ApellidoPaterno = row[3].ToString();
                                    usuario.FechaNacimiento = row[4].ToString();
                                    usuario.Telefono = row[5].ToString();


                                    result.Objects.Add(usuario);
                                }
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontraron registros";
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
        public static ML.Result GetById(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento],[Telefono]FROM [Usuario] WHERE IdUsuario = @IdUsuario";
                        cmd.Connection = context;

                        SqlParameter collection = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);


                        collection.Value = usuario.IdUsuario;
                        cmd.Parameters.Add(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaUsuario = new DataTable();
                            da.Fill(tablaUsuario);

                            if (tablaUsuario.Rows.Count > 0)

                            {
                                DataRow row;
                                row = tablaUsuario.Rows[0];

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoMaterno = row[2].ToString();
                                usuario.ApellidoPaterno = row[3].ToString();
                                usuario.FechaNacimiento = row[4].ToString();
                                usuario.Telefono = row[5].ToString();

                                result.Object = usuario;

                                //foreach (DataRow row in tablaUsuario.Rows)
                                //{

                                //    usuario.IdUsuario = int.Parse(row[0].ToString());
                                //    usuario.Nombre = row[1].ToString();
                                //    usuario.ApellidoMaterno = row[2].ToString();
                                //    usuario.ApellidoPaterno = row[3].ToString();
                                //    usuario.FechaNacimiento = DateTime.Parse(row[4].ToString());
                                //    usuario.Telefono = row[5].ToString();


                                //object usuarioU = usuario1;

                                //}
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontraron registros";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result AddSP(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    using (SqlCommand cmd = new SqlCommand())//parametros, instrucciones,query
                    {

                        cmd.CommandText = "UsuarioAdd";

                        SqlParameter[] collection = new SqlParameter[5];
                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;
                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;
                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;
                        collection[3] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.Date);
                        collection[3].Value = usuario.FechaNacimiento;
                        collection[4] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                        collection[4].Value = usuario.Telefono;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection = context;

                        cmd.Connection.Open();

                        cmd.CommandType = CommandType.StoredProcedure;


                        int RowAffected = cmd.ExecuteNonQuery();
                        if (RowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al insertar en la tabla alumno";
                        }



                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }
        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioUpdate";

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;
                        collection[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;
                        collection[2] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;
                        collection[3] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;
                        collection[4] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.Date);
                        collection[4].Value = usuario.FechaNacimiento;
                        collection[5] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.Telefono;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection = context;

                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        int RowAffected = cmd.ExecuteNonQuery();
                        if (RowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo actualizar";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioDelete";
                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection = context;

                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        int RowAffected = cmd.ExecuteNonQuery();
                        if (RowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se elimino el registro";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioGetAll";
                        cmd.Connection = context;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaUsuario = new DataTable();
                            da.Fill(tablaUsuario);

                            if (tablaUsuario.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();

                                foreach (DataRow row in tablaUsuario.Rows)
                                {
                                    ML.Usuario usuario = new ML.Usuario();

                                    usuario.IdUsuario = int.Parse(row[0].ToString());
                                    usuario.Nombre = row[1].ToString();
                                    usuario.ApellidoMaterno = row[2].ToString();
                                    usuario.ApellidoPaterno = row[3].ToString();
                                    usuario.FechaNacimiento = row[4].ToString();
                                    usuario.Telefono = row[5].ToString();


                                    result.Objects.Add(usuario);
                                }
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontraron registros";
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
        public static ML.Result GetByIdSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioGetById";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;


                        SqlParameter collection = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);


                        collection.Value = usuario.IdUsuario;
                        cmd.Parameters.Add(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaUsuario = new DataTable();
                            da.Fill(tablaUsuario);

                            if (tablaUsuario.Rows.Count > 0)

                            {
                                DataRow row;
                                row = tablaUsuario.Rows[0];

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoMaterno = row[2].ToString();
                                usuario.ApellidoPaterno = row[3].ToString();
                                usuario.FechaNacimiento = row[4].ToString();
                                usuario.Telefono = row[5].ToString();

                                result.Object = usuario;
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontraron registros";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())

                {
                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Telefono, usuario.UserName, usuario.Email, usuario.Password, usuario.Sexo, usuario.Celular, usuario.CURP, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    
                    if (query > 0)
                    {
                        result.Correct = true; 
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
               ML.Result result = new ML.Result();


             try
              {
                  using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                  {
                      var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Telefono, usuario.UserName, usuario.Email, usuario.Password, usuario.Sexo, usuario.Celular, usuario.CURP,usuario.Rol.IdRol,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);
                      if (query > 0)
                      {
                          result.Correct = true;
                      }
                      else
                      {
                          result.Correct = false;
                          result.ErrorMessage = "Ocurrio un error";
                      }
                  }
              }
              catch (Exception ex)
              {
                  result.Correct = false;
                  result.ErrorMessage = ex.Message;
                  result.Ex = ex;
              }

              return result;


        }
        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                {
                    var query = context.UsuarioDelete(usuario.IdUsuario);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

             try
             {
                 using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                 {
                     var query = context.UsuarioGetAll().ToList();

                     result.Objects = new List<object>();

                     if (query != null)
                     {
                        foreach (var objeto in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            
                            usuario.IdUsuario = objeto.IdUsuario;
                            usuario.Nombre = objeto.NombreUsuario;
                            usuario.ApellidoPaterno = objeto.ApellidoPaterno;
                            usuario.ApellidoMaterno = objeto.ApellidoMaterno;
                            usuario.FechaNacimiento = objeto.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuario.Telefono = objeto.Telefono;
                            usuario.UserName = objeto.Username;
                            usuario.Email = objeto.Email;
                            usuario.Password = objeto.Password;
                            usuario.Sexo = objeto.Sexo;
                            usuario.Celular = objeto.Celular;
                            usuario.CURP = objeto.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = objeto.IdRol;
                            usuario.Rol.Nombre = objeto.NombreRol;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.Calle = objeto.Calle;
                            usuario.Direccion.NumeroInterior = objeto.NumeroInterior;
                            usuario.Direccion.NumeroExterior = objeto.NumeroExterior;

                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = objeto.IdColonia ??0;
                            usuario.Direccion.Colonia.Nombre = objeto.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = objeto.CodigoPostal;

                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = objeto.IdMunicipio ??0;
                            usuario.Direccion.Colonia.Municipio.Nombre = objeto.NombreMunicipio;

                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objeto.IdEstado ??0;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = objeto.NombreEstado;

                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objeto.IdPais ??0;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objeto.Pais;




                            result.Objects.Add(usuario);

                        }
                        result.Correct = true;
                    }
                     else
                     {
                         result.Correct = false;
                         result.ErrorMessage = "Ocurrio un error";
                     }
                 }
             }
             catch (Exception ex)
             {
                 result.Correct = false;
                 result.ErrorMessage = ex.Message;
                 result.Ex = ex;
             }

             return result;


        }
        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                {
                    var usuarioObj = context.UsuarioGetById(IdUsuario).Single();

                    if (usuarioObj != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = usuarioObj.IdUsuario;
                        usuario.Nombre = usuarioObj.NombreUsuario;
                        usuario.ApellidoPaterno = usuarioObj.ApellidoPaterno;
                        usuario.ApellidoMaterno = usuarioObj.ApellidoMaterno;
                        usuario.FechaNacimiento = usuarioObj.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Telefono = usuarioObj.Telefono;
                        usuario.UserName = usuarioObj.Username;
                        usuario.Email = usuarioObj.Email;
                        usuario.Password = usuarioObj.Password;
                        usuario.Sexo = usuarioObj.Sexo;
                        usuario.Celular = usuarioObj.Celular;
                        usuario.CURP = usuarioObj.CURP;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = usuarioObj.IdRol;
                        // usuario.Rol.Nombre = usuarioObj.NombreRol;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Calle = usuarioObj.Calle;
                        usuario.Direccion.NumeroInterior = usuarioObj.NumeroInterior;
                        usuario.Direccion.NumeroExterior = usuarioObj.NumeroExterior;


                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = usuarioObj.IdColonia ?? 0;
                        usuario.Direccion.Colonia.Nombre = usuarioObj.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = usuarioObj.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = usuarioObj.IdMunicipio ?? 0;
                        usuario.Direccion.Colonia.Municipio.Nombre = usuarioObj.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = usuarioObj.IdEstado ?? 0;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = usuarioObj.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = usuarioObj.IdPais ?? 0;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = usuarioObj.Pais;
                        result.Object = usuario;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }



                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                {
                    DL_EF.Usuario usuarioLINQ = new DL_EF.Usuario();

                    usuarioLINQ.Nombre = usuario.Nombre;
                    usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioLINQ.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);  //DATETIME.PARSE   Tengo que usar el formato del sistema
                    usuarioLINQ.Telefono = usuario.Telefono;
                    usuarioLINQ.UserName = usuario.UserName;
                    usuarioLINQ.Email = usuario.Email;
                    usuarioLINQ.Password = usuario.Password;
                    usuarioLINQ.Sexo = usuario.Sexo;
                    usuarioLINQ.Celular = usuario.Celular;
                    usuarioLINQ.CURP = usuarioLINQ.CURP;

                    //DateParseExact para especificar el formato de la fecha ingresada
                    
                    usuarioLINQ.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioLINQ);

                    int RowAffeted = context.SaveChanges();

                    if (RowAffeted > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                {
                    // DL_EF.Usuario usuarioLinq = new DL_EF.Usuario();

                    var usuarioLINQ = (from obj in context.Usuarios
                                       where obj.IdUsuario == usuario.IdUsuario
                                       select obj).SingleOrDefault();

                    if (usuarioLINQ != null)
                    {
                        
                        usuarioLINQ.IdUsuario = usuario.IdUsuario;
                        usuarioLINQ.Nombre = usuario.Nombre;
                        usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                        usuarioLINQ.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento,"dd-MM-yyyy",CultureInfo.InvariantCulture);
                        usuarioLINQ.Telefono = usuario.Telefono;
                        usuarioLINQ.UserName = usuario.UserName;
                        usuarioLINQ.Email = usuario.Email;
                        usuarioLINQ.Password = usuario.Password;
                        usuarioLINQ.Sexo = usuario.Sexo;
                        usuarioLINQ.Celular = usuario.Celular;
                        usuarioLINQ.CURP = usuario.CURP;
                        usuarioLINQ.Rol.IdRol = usuario.Rol.IdRol;
                        


                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                {
                    var query = (from usuarioLINQ in context.Usuarios where usuarioLINQ.IdUsuario == usuario.IdUsuario select usuarioLINQ).FirstOrDefault();

                    if (query != null)
                    {
                        context.Usuarios.Remove(query);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                {
                    var usuariosLINQ = (from obj in context.Usuarios select obj).ToList();

                    result.Objects = new List<object>();

                    if (usuariosLINQ != null)
                    {
                        foreach (var obj in usuariosLINQ)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuario.Telefono = obj.Telefono;
                            usuario.UserName = obj.UserName;
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Password;
                            usuario.Sexo = obj.Sexo;
                            usuario.Celular = obj.Celular;
                            usuario.CURP = obj.CURP;

                            usuario.UserName = obj.UserName;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.Rol.IdRol;
                            usuario.Rol.Nombre = obj.Rol.Nombre;


                            result.Objects.Add(usuario);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
        public static ML.Result GetByIdLINQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                {
                    var usuarios = (from usuarioLINQ in context.Usuarios where usuarioLINQ.IdUsuario == IdUsuario select usuarioLINQ).Single();

                    if (usuarios != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = usuarios.IdUsuario;
                        usuario.Nombre = usuarios.Nombre;
                        usuario.ApellidoPaterno = usuarios.ApellidoPaterno;
                        usuario.ApellidoMaterno = usuarios.ApellidoMaterno;
                        usuario.FechaNacimiento = usuarios.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Telefono = usuarios.Telefono;
                        usuario.UserName = usuarios.UserName;
                        usuario.Email = usuarios.Email;
                        usuario.Password = usuarios.Password;
                        usuario.Sexo = usuarios.Sexo;
                        usuario.Celular = usuarios.Celular;
                        usuario.CURP = usuarios.CURP;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = usuarios.IdRol;
                        usuario.Rol.Nombre = usuarios.Rol.Nombre;
                        

                        result.Object = usuario;
                        result.Correct = true;


                    }
                    
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
    }

    
 }
