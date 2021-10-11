using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaestroDetalle.Modelos
{
    public class Zapatos
    {
        [Key]
        public int ZapatoId { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public float Size { get; set; }
        public string Color { get; set; }
    }
}
