using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaestroDetalle.Modelos
{
     public class ArmarioDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ArmarioId { get; set; }
        public virtual Zapatos Zapato { get; set; }

    }
}
