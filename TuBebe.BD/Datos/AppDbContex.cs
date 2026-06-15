using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TuBebe.BD.Datos.Entity;

namespace TuBebe.BD.Datos
{
    public class AppDbContex : DbContext
    {
        public DbSet<Pantalon> Pantalones { get; set; }

        public AppDbContex(DbContextOptions options) : base(options) 
        { }


    }
}
