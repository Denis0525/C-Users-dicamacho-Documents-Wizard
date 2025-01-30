using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ProyectoWizard.Models;

namespace ProyectoWizard.Data
{
    public class ProductosDbContext : DbContext
    {
        public ProductosDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Productos> Productos { get; set;}
        public DbSet<Productos> tc_producto { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}