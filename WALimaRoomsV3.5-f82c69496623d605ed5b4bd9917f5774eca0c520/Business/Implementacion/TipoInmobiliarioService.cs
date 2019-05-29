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
    public class TipoInmobiliarioService : ITipoInmobiliarioService
    {
        private ITipoInmobiliarioRepository tipoInmobiliarioRepository = new TipoInmobiliarioRepository();
        private IInmobiliarioRepository inmobiliarioRepository = new InmobiliarioRepository();
        public bool Delete(int id)
        {
            return tipoInmobiliarioRepository.delete(id);
        }

        public List<TipoInmobiliario> FindAll()
        {
            return tipoInmobiliarioRepository.FindAll();
        }

        public TipoInmobiliario FindById(int? id)
        {
            return tipoInmobiliarioRepository.FindbyID(id);
        }

        public bool insert(TipoInmobiliario t)
        {
            return tipoInmobiliarioRepository.insert(t);
        }

        public bool Update(TipoInmobiliario t)
        {
            return tipoInmobiliarioRepository.update(t);
        }
    }
}
