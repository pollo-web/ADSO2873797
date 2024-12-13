using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ProyectoFinal.Context
{
    public class ProyectoFinalContext : DbContext
    {  
            public ProyectoFinalContext() : base("name=ConexionProyecto")
            {
            }

            public DbSet<Usuarios> Usuarios { get; set; }
            public DbSet<Personas> Personas { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            // Configuración de la entidad Usuarios
                modelBuilder.Entity<Usuarios>()
                    .ToTable("Usuarios")
                    .HasKey(p => p.Id);

                modelBuilder.Entity<Usuarios>()
                    .Property(u => u.Id)
                    .IsRequired()
                .HasColumnName("Id");

                modelBuilder.Entity<Usuarios>()
                    .Property(u => u.Usuario)
                    .IsRequired()
                    .HasColumnName("Usuario")
                .HasMaxLength(50);

                modelBuilder.Entity<Usuarios>()
                    .Property(u => u.Pass)
                    .IsRequired()
                    .HasColumnName("Pass")
                    .HasMaxLength(50);

                modelBuilder.Entity<Usuarios>()
                    .Property(u => u.FechaCreacion)
                    .IsRequired()
                    .HasColumnName("FechaCreacion");
                modelBuilder.Entity<Usuarios>()
                    .Property(u => u.HashKey)
                    .IsRequired()
                    .HasColumnName("HashKey");

                modelBuilder.Entity<Usuarios>()
                    .Property(u => u.HashIV)
                    .IsRequired()
                    .HasColumnName("HashIV");

            // Configuración de la entidad Personas
            modelBuilder.Entity<Personas>()
                    .ToTable("Personas")
                    .HasKey(p => p.Id);

                modelBuilder.Entity<Personas>()
                    .Property(p => p.Nombres)
                    .IsRequired()
                    .HasColumnName("Nombres")
                    .HasMaxLength(50);

                modelBuilder.Entity<Personas>()
                    .Property(p => p.Apellidos)
                    .IsRequired()
                    .HasColumnName("Apellidos")
                    .HasMaxLength(50);

                modelBuilder.Entity<Personas>()
                    .Property(p => p.NumeroIdentificacion)
                    .IsRequired()
                    .HasColumnName("NumeroIdentificacion")
                    .HasMaxLength(50);

                modelBuilder.Entity<Personas>()
                    .Property(p => p.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasMaxLength(50);

                modelBuilder.Entity<Personas>()
                    .Property(p => p.TipoIdentificacion)
                    .IsRequired()
                    .HasColumnName("TipoIdentificacion")
                    .HasMaxLength(50);

                modelBuilder.Entity<Personas>()
                    .Property(p => p.FechaCreacion)
                    .IsRequired()
                    .HasColumnName("FechaCreacion");

                base.OnModelCreating(modelBuilder); // Llama al método base
            }
        
    }
}
