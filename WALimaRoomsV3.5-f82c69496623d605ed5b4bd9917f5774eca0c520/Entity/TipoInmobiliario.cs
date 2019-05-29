using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TipoInmobiliario
    {
        [DisplayName("Id. Tipo Inmobiliario")]
        public int TipoInmobiliarioId { get; set; }

        [DisplayName("Nombre Tipo Inmobiliario")]
        public string NombreTipoInmobiliario { get; set; }
    }
}
