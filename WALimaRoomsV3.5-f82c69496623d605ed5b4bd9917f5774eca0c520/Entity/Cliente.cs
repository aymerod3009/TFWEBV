using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cliente
    {
        [DisplayName("Id. Cliente")]
        public int ClienteId { get; set; }

        [Required]
        [DisplayName("Nombre Cliente")]
        public string NombreCliente { get; set; }

        [Required]
        [DisplayName("Apellido Paterno")]
        public string apellPaterno { get; set; }

        [Required]
        [DisplayName("Apellido Materno")]
        public string apellMaterno { get; set; }

        [Required]
        [DisplayName("Nacionalidad")]
        public string Nacionalidad { get; set; }

        [Required]
        [DisplayName("Phone")]
        public string Telefono { get; set; }

        [Required]
        [DisplayName("email")]
        public string Correo { get; set; }

        [Required]
        [DisplayName("Tipo Documento")]
        public TipoDocumento tipoDocumento { get; set; }

        [Required]
        [DisplayName("Nro Documento")]
        public string NroDocumento { get; set; }
    }
}
