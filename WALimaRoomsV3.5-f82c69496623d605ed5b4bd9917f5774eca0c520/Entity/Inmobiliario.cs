using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Inmobiliario
    {
        [DisplayName("Id. Inmobiliario")]
        public int InmobiliarioId { get; set; }

        [Required]
        [DisplayName("Nombre Inmobiliario")]
        public string NombreInmobiliario { get; set; }

        [Required]
        [DisplayName("Direccion")]
        public string DireccionInmobiliario { get; set; }

        [Required]
        [DisplayName("Precio")]
        public int Precio { get; set; }

        [DisplayName("Tipo Inmobiliario")]
        public TipoInmobiliario tipoInmobiliario { get; set; }
    }
}
