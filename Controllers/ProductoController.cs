using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Productos_ProgramacionIV.Data;
using WebAPI_Productos_ProgramacionIV.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_Productos_ProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // Todo atributo private debe ir con guion bajo
        private readonly ApplicationDBContext _db;

        public ProductoController(ApplicationDBContext db)
        {
            // Inyección de dependencias, inyecto la dependencia de la DB
            _db = db;

        }

        // GET: ProductoController
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Async y Await para que sea asíncronos
            List<Producto> products = await _db.Producto.ToListAsync();
            return Ok(products);
        }

        // GET api/<Producto2Controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            Producto foundedProduct = await _db.Producto.FindAsync(id);

            if (foundedProduct == null)
            {
                return NotFound();
            }

            return Ok(foundedProduct);
        }

        // POST api/<Producto2Controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto newProduct)
        {
            if (newProduct == null) 
            {

                return BadRequest();

            }

            await _db.Producto.AddAsync(newProduct);
            await _db.SaveChangesAsync();

            return Ok(newProduct);

        }

        // PUT api/<Producto2Controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto newProductToReplace)
        {

            Producto productToReplace = await _db.Producto.FindAsync(id);

            if (newProductToReplace == null || productToReplace == null)
            {

                return BadRequest();

            }

            productToReplace.Nombre = newProductToReplace.Nombre;
            productToReplace.Descripcion = newProductToReplace.Descripcion;
            productToReplace.Cantidad = newProductToReplace.Cantidad;

            /* 
                DBContext rastrea los objetos que devuelve en una consulta y si se cambiaron las propiedades
                pues DBContext se da cuenta y al momento de llamar a SaveChanges los cambios se reflejarán
                en la base de datos
            */

            await _db.SaveChangesAsync();

            return Ok(productToReplace);
        }

        // DELETE api/<Producto2Controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            Producto productToDelete = await _db.Producto.FindAsync(id);

            if (productToDelete == null)
            {

                return BadRequest();

            }

            _db.Producto.Remove(productToDelete);

            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
