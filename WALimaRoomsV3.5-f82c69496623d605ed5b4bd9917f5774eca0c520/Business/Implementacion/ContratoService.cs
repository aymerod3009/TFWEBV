using Data;
using Data.Implementacion;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementacion
{
    public class ContratoService : IContratoService
    {
        private IContratoRepository contratoRepository = new ContratoRepository();
        private ITipoInmobiliarioRepository tipoInmobiliarioRepository = new TipoInmobiliarioRepository();
        private IInmobiliarioRepository inmobiliarioRepository = new InmobiliarioRepository();
        private ITipoDocumentoRepository documentoRepository = new TipoDocumentoRepository();
        private IClienteRepository clienteRepository = new ClienteRepository();

        public bool Delete(int id)
        {
            return contratoRepository.delete(id);
        }

        public List<Contrato> FindAll()
        {
            return contratoRepository.FindAll();
        }

        public Contrato FindById(int? id)
        {
            return contratoRepository.FindbyID(id);
        }

        public bool insert(Contrato t)
        {
            Cliente cliente = clienteRepository.FindbyID(t.cliente.ClienteId);            
            Inmobiliario inmobiliario = inmobiliarioRepository.FindbyID(t.inmobiliario.InmobiliarioId);
            t.cliente = cliente;
            t.inmobiliario = inmobiliario;
            return contratoRepository.insert(t);
        }

        public bool Update(Contrato t)
        {
            return contratoRepository.update(t);
        }
    }
}
