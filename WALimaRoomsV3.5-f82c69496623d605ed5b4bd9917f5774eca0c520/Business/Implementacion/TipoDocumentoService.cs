using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementacion;
using Entity;

namespace Business.Implementacion
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private ITipoDocumentoRepository documentoRepository = new TipoDocumentoRepository();
        private IClienteRepository clienteRepository = new ClienteRepository();
        public bool Delete(int id)
        {
            return documentoRepository.delete(id);
        }

        public List<TipoDocumento> FindAll()
        {
            return documentoRepository.FindAll();
        }

        public TipoDocumento FindById(int? id)
        {
            return documentoRepository.FindbyID(id);
        }

        public bool insert(TipoDocumento t)
        {
            return documentoRepository.insert(t);
        }

        public bool Update(TipoDocumento t)
        {
            return documentoRepository.update(t);
        }
    }
}
