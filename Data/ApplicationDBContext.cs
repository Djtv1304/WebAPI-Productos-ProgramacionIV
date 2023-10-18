using Microsoft.EntityFrameworkCore;
using WebAPI_Productos_ProgramacionIV.Models;

namespace WebAPI_Productos_ProgramacionIV.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext
            ( 
        
                DbContextOptions<ApplicationDBContext> options 
            
            ) : base(options) // Es como un super en herencia
        {
            


        }
        
        // Creo la tabla de esta manera en la DB
        public DbSet<Producto> Producto {  get; set; }

        // Agregar datos a través de código con esta función
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(

                    new Producto
                    {

                        IdProducto = 1,
                        Nombre = "Producto 1",
                        Descripcion = "Descripcion Producto 1",
                        Cantidad = 34

                    },
                    new Producto
                    {
                        IdProducto = 2,
                        Nombre = "Producto 2",
                        Descripcion = "Descripción Producto 2",
                        Cantidad = 25

                    }

                );
        }
        /*
         
            Siempre que haga una actualizacion en el DBContext debo hacer una migracion 

         */
    }
}
