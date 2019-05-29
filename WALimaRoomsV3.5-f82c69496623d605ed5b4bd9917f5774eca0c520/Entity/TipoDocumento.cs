using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TipoDocumento
    {
        [DisplayName("Id. Tipo Documento")]
        public int TipoDocumentoId { get; set; }

        [DisplayName("Tipo Documento")]
        public string NombreTipoDocumento { get; set; }
    }
}
