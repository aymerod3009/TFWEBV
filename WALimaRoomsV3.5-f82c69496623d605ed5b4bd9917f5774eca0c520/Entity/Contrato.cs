using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contrato
    {        
        [DisplayName("Id. Contrato")]
        public int ContratoId { get; set; }

        [Required]
        [DisplayName("Fecha Inicio")]
        public DateTime fechaInicio { get; set; }

        [Required]
        [DisplayName("Fecha Fin")]
        public DateTime fechaFin { get; set; }

        [Required]
        [DisplayName("Fecha Pago")]
        public int FechaPago { get; set; }

        [DisplayName("Cliente")]
        public Cliente cliente { get; set; }

        [DisplayName("Inmobiliario")]
        public Inmobiliario inmobiliario { get; set; }
    }
}
