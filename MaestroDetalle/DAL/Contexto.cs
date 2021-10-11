using MaestroDetalle.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaestroDetalle.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Armarios> Armarios { get; set; }
        public DbSet<Zapatos> Zapatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA/Armarios.db");
        }
    }
}
