using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Solonacional.Models;

namespace Solonacional.context
{
    public class Solonacional : DbContext
    {
            public Solonacional() : base("name=conexion")
            {
            }

            public DbSet<Usuarios> Usuarios { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Usuarios>()
                    .ToTable("Usuarios")
                    .HasKey(p => p.Identificador);

                modelBuilder.Entity<Usuarios>()
                    .Property(p => p.Identificador)
                    .IsRequired()
                    .HasColumnName("Identificador");

                modelBuilder.Entity<Usuarios>()
                    .Property(p => p.Usuario)
                    .IsRequired()
                    .HasColumnName("Usuario");

                modelBuilder.Entity<Usuarios>()
                    .Property(p => p.Pass)
                    .IsRequired()
                    .HasColumnName("Pass")
                    .HasMaxLength(50);


                modelBuilder.Entity<Usuarios>()
                    .HasRequired(u => u.Personas)         // Un Usuario requiere una Persona
                    .WithMany()                           // Una Persona puede tener muchos Usuarios (si aplica, o usa WithOne() si es 1:1)
                    .HasForeignKey(u => u.PersonasID);    // La clave foránea es PersonasID


            base.OnModelCreating(modelBuilder);
            }
        
    }
}