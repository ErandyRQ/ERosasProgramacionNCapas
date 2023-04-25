using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class ProductoController : ApiController
    {
        // GET: api/Producto
        [HttpGet]
        [Route("api/Producto")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Producto/5
        [HttpGet]
        [Route("api/Producto/{IdProducto}")]
        public IHttpActionResult GetById(int IdProducto)
        {

            ML.Producto producto = new ML.Producto();
                producto.IdProducto = IdProducto;
            ML.Result result = BL.Producto.GetById(producto);

             if (result.Correct)
             {
                 return Ok(result);
             }
             else
             {
                 return NotFound();
             }
         }

        // POST: api/Producto
        [HttpPost]
        [Route("api/Producto")]
        public IHttpActionResult Post([FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

       // PUT: api/Producto/5
        [HttpPut]
        [Route("api/Producto/Update")]
        public IHttpActionResult Put([FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.Update(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

         //DELETE: api/Producto/5
        [HttpDelete]
        [Route("api/Producto/{IdProducto}")]
          public IHttpActionResult Delete(int IdProducto)

          {

            ML.Producto producto = new ML.Producto();
            producto.IdProducto = IdProducto;

              ML.Result result = BL.Producto.Delete(producto);
              if (result.Correct)
              {
                  return Ok(result);
              }
              else
              {
                  return NotFound();
              }
          }
    }
}
