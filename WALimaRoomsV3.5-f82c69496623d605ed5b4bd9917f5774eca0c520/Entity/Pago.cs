using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pago
    {
        [DisplayName("Id. Pago")]
        public int PagoId { get; set; }

        [Required]
        [DisplayName("Numero Transaccion")]
        public string NroTransaccion { get; set; }

        [Required]
        [DisplayName("Fecha Transaccion")]
        public DateTime FechaTransaccion { get; set; }

        [DisplayName("Cliente")]
        public Contrato Contrato { get; set; }
    }
}
