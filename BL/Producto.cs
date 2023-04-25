using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class Producto
    {
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "INSERT INTO [Producto]([Nombre],[PrecioUnitario],[Stock],[Descripcion],[IdProveedor],[IdDepartamento]) VALUES (@Nombre,@PrecioUnitario,@Stock,@Descripcion,@IdProveedor,@IdDepartamento)";

                        SqlParameter[] colection = new SqlParameter[6];
                        colection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        colection[0].Value = producto.Nombre;
                        colection[1] = new SqlParameter("PrecioUnitario", System.Data.SqlDbType.Float);
                        colection[1].Value = producto.PrecioUnitario;
                        colection[2] = new SqlParameter("Stock", System.Data.SqlDbType.Int);
                        colection[2].Value = producto.Stock;
                        colection[3] = new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar);
                        colection[3].Value = producto.Descripcion;
                        colection[4] = new SqlParameter("IdProveedor", System.Data.SqlDbType.Int);
                        colection[4].Value = producto.Proveedor.IdProveedor;
                        colection[5] = new SqlParameter("IdDepartamento", System.Data.SqlDbType.Int);
                        colection[5].Value = producto.Departamento.IdDepartamento;

                        cmd.Parameters.AddRange(colection);
                        cmd.Connection = context;
                        cmd.Connection.Open();

                        int RowAffected = cmd .ExecuteNonQuery();
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
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE [Producto] SET [Nombre] = @Nombre,[PrecioUnitario] = @PrecioUnitario,[Stock] = @Stock,[Descripcion] = @Descripcion, [IdProveedor]=@IdProveedor, [IdDepartamento] = @IdDepartamento WHERE [IdProducto] = @IdProducto";
                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("IdProducto", System.Data.SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;
                        collection[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = producto.Nombre;
                        collection[2] = new SqlParameter("PrecioUnitario", System.Data.SqlDbType.Decimal);
                        collection[2].Value = producto.PrecioUnitario;
                        collection[3] = new SqlParameter("Stock", System.Data.SqlDbType.Int);
                        collection[3].Value = producto.Stock;
                        collection[4] = new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar);
                        collection[4].Value = producto.Descripcion;

                        collection[5] = new SqlParameter("IdProveedor", System.Data.SqlDbType.Int);
                        collection[5].Value = producto.Proveedor.IdProveedor;
                        collection[6] = new SqlParameter("IdDepartamento", System.Data.SqlDbType.Int);
                        collection[6].Value = producto.Departamento.IdDepartamento;

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
        public static ML.Result Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "DELETE FROM [Producto] WHERE ([IdProducto] = @IdProducto)";
                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdProducto", System.Data.SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;

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
                        cmd.CommandText = "SELECT [IdProducto],[Nombre],[PrecioUnitario],[Stock],[Descripcion],[IdProveedor],[IdDepartamento] FROM [Producto]";
                        cmd.Connection = context;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaProducto = new DataTable();
                            da.Fill(tablaProducto);

                            if (tablaProducto.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();

                                foreach (DataRow row in tablaProducto.Rows)
                                {
                                    ML.Producto producto = new ML.Producto();

                                    producto.IdProducto = int.Parse(row[0].ToString());
                                    producto.Nombre = row[1].ToString();
                                    producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                                    producto.Stock = int.Parse(row[3].ToString());
                                    producto.Descripcion = row[4].ToString();
                                    producto.Proveedor = new ML.Proveedor();
                                    producto.Proveedor.IdProveedor = int.Parse(row[5].ToString());
                                    producto.Departamento = new ML.Departamento();
                                    producto.Departamento.IdDepartamento =int.Parse(row[6].ToString());



                                    result.Objects.Add(producto);
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
        public static ML.Result GetById(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT [IdProducto],[Nombre],[PrecioUnitario],[Stock],[Descripcion],[IdProveedor],[IdDepartamento] FROM [Producto] WHERE IdProducto = @IdProducto";
                        cmd.Connection = context;

                        SqlParameter collection = new SqlParameter("IdProducto", System.Data.SqlDbType.Int);
                        collection.Value = producto.IdProducto;
                        cmd.Parameters.Add(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaProducto = new DataTable();
                            da.Fill(tablaProducto);

                            if (tablaProducto.Rows.Count > 0)

                            {
                                
                                DataRow row;
                                row = tablaProducto.Rows[0];

                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());
                                producto.Descripcion = row[4].ToString();
                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[5].ToString());
                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[6].ToString());


                                result.Object = producto;

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

        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                {
                    var query = context.ProductoAdd(producto.Nombre,producto.PrecioUnitario,producto.Stock,producto.Descripcion,producto.Proveedor.IdProveedor,producto.Departamento.IdDepartamento);
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
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                {
                    var query = context.ProductoUpdate(producto.IdProducto,producto.Nombre,producto.PrecioUnitario,producto.Stock,producto.Descripcion,producto.Proveedor.IdProveedor,producto.Departamento.IdDepartamento);
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
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
        public static ML.Result DeleteEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context = new DL_EF.ERosasProgramacionNCapasEntities1())
                {
                    var query = context.ProductoDelete(producto.IdProducto);

                    if(query > 0)
                    {
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }catch (Exception ex)
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
                    var query = context.ProductoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var objeto in query)
                        {
                            ML.Producto producto= new ML.Producto();

                            producto.IdProducto=objeto.IdProducto;
                            producto.Nombre = objeto.NombreProducto;
                            producto.PrecioUnitario=objeto.PrecioUnitario;
                            producto.Stock = objeto.Stock;
                            producto.Descripcion = objeto.Descripcion;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.Nombre = objeto.NombreProveedor;
                            producto.Proveedor.Telefono = objeto.Telefono;

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.Nombre = objeto.NombreDepartamento;

                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.Nombre = objeto.NombreArea;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetByIdEF(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERosasProgramacionNCapasEntities1 context=new DL_EF.ERosasProgramacionNCapasEntities1())
                {
                    var query = context.ProductoGetById(IdProducto).Single();

                    if(query != null)
                    {
                        ML.Producto producto = new ML.Producto();

                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.NombreProducto;
                        producto.PrecioUnitario = query.PrecioUnitario;
                        producto.Stock = query.Stock;
                        producto.Descripcion = query.Descripcion;

                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.Nombre = query.NombreProveedor;
                        producto.Proveedor.Telefono = query.Telefono;

                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.Nombre = query.NombreDepartamento;

                        producto.Departamento.Area = new ML.Area();
                        producto.Departamento.Area.Nombre = query.NombreArea;

                        result.Object = producto;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }

    }
}
