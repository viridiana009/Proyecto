using Microsoft.EntityFrameworkCore;
using Biblioteca.Models; //importacíon de modelos

namespace Biblioteca.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options):  base(options) 
       
        {
            
        }

        public  DbSet<Libro> Libros { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder) //configuracion de la tabla
        {
            modelBuilder.Entity<Libro>(tb => {

                tb.HasKey(col => col.IdLibro);
                tb.Property(col => col.IdLibro)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Titulo).HasMaxLength(50);
                tb.Property(col => col.Autor).HasMaxLength(50);
                tb.Property(col => col.Genero).HasMaxLength(50);
                tb.Property(col => col.Sinopsis).HasMaxLength(250);
              
            });
   
             modelBuilder.Entity<Libro>().ToTable("Libro");

        }



    }
}
