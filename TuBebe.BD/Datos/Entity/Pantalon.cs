using System;
using System.Collections.Generic;
using System.Text;

namespace TuBebe.BD.Datos.Entity
{
    internal class Pantalon : EntityBase
    {
        public int Id { get; set; }
        public string Talle { get; set; }
        public string Color { get; set; }
    }
}
