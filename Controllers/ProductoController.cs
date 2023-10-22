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
        [HttpGet("{IdProducto}")]
        public async Task<IActionResult> Get(int IdProducto)
        {
            /*
                First or Default: Manda el objeto correcto o si no manda un objeto nulo (Busca arreglo de datos)
                Single or Default: Manda el objeto correcto o si no manda un objeto nulo (Busca un solo dato)

                DBContext representa y me muevo a la base de datos
                DbContext e invocando a Producto represento y me muevo mediante la tabla
             */

            // Opcion 1 de búsqueda
            // Producto foundedProduct = await _db.Producto.FindAsync(IdProducto);

            // Opción 2 de búsqueda
            Producto foundedProduct = await _db.Producto.FirstOrDefaultAsync( x => x.IdProducto == IdProducto );

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

            // En caso de que el framework no valide que ya exista un ID que ya existe debemos validar nosotros
            Producto foundedProduct = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == newProduct.IdProducto);

            if (newProduct == null || foundedProduct != null) 
            {

                return BadRequest();

            }

            await _db.Producto.AddAsync(newProduct);
            await _db.SaveChangesAsync();

            return Ok(newProduct);

        }

        // PUT api/<Producto2Controller>/5
        [HttpPut("{IdProducto}")]
        public async Task<IActionResult> Put(int IdProducto, [FromBody] Producto newProduct)
        {
            // Forma 1 de buscar
            //Producto productToReplace = await _db.Producto.FindAsync(IdProducto);

            // Forma 2 de buscar
            Producto productToReplace = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == IdProducto);

            if (newProduct == null || productToReplace == null)
            {

                return BadRequest();

            }

            // Valido los datos mediante operadores ternarios
            productToReplace.Nombre = newProduct.Nombre != null ? newProduct.Nombre : productToReplace.Nombre;
            productToReplace.Descripcion = newProduct.Descripcion != null ? newProduct.Descripcion : productToReplace.Descripcion;
            productToReplace.Cantidad = newProduct.Cantidad != null ? newProduct.Cantidad : productToReplace.Cantidad;

            /* 
                DBContext rastrea los objetos que devuelve en una consulta y si se cambiaron las propiedades
                pues DBContext se da cuenta y al momento de llamar a SaveChanges los cambios se reflejarán
                en la base de datos
            */

            await _db.SaveChangesAsync();

            return Ok(productToReplace);
        }

        // DELETE api/<Producto2Controller>/5
        [HttpDelete("{IdProducto}")]
        public async Task<IActionResult> Delete(int IdProducto)
        {
            // Forma 1 de buscar
            //Producto productToDelete = await _db.Producto.FindAsync(IdProducto);

            // Forma 2 de buscar
            Producto productToDelete = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == IdProducto);

            if (productToDelete == null)
            {

                return BadRequest();

            }

            _db.Producto.Remove(productToDelete);

            await _db.SaveChangesAsync();

            return Ok("Producto eliminado correctamente");
        }
    }
}
