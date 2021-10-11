using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaestroDetalle.Modelos
{
   public class Armarios
    {
        [Key]
        public int ArmarioId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("ArmarioId")]
        public virtual List<ArmarioDetalle> ArmarioDetalle { get; set; } = new List<ArmarioDetalle>();
    }
}
