using System.ComponentModel.DataAnnotations;

namespace WebAPI_Productos_ProgramacionIV.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        [Required]
        public int Cantidad { get; set; }

        //public Producto(int IdProducto, string Nombre, string Descripcion, int cantidad)
        //{
        //    this.IdProducto = IdProducto;
        //    this.Nombre = Nombre;
        //    this.Descripcion = Descripcion;
        //    this.Cantidad = cantidad;
        //}

        // Constructor de tipado

        // Constructor para trabajar con Blazor
        //public Producto()
        //{
        //    this.IdProducto = Contador++;
        //}
    }
}
