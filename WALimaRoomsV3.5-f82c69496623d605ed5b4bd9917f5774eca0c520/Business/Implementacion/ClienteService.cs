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
    public class ClienteService : IClienteService
    {
        private ITipoDocumentoRepository documentoRepository = new TipoDocumentoRepository();
        private IClienteRepository clienteRepository = new ClienteRepository();
        public bool Delete(int id)
        {
            return clienteRepository.delete(id);
        }

        public List<Cliente> FindAll()
        {
            return clienteRepository.FindAll();
        }

        public Cliente FindById(int? id)
        {
            return clienteRepository.FindbyID(id);
        }

        public bool insert(Cliente t)
        {
            TipoDocumento tipoDocumento = documentoRepository.FindbyID(t.tipoDocumento.TipoDocumentoId);
            t.tipoDocumento = tipoDocumento;
            return clienteRepository.insert(t);
        }

        public bool Update(Cliente t)
        {
            return clienteRepository.update(t);
        }
    }
}
