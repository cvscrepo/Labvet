using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.DAL.Repositorios.Contratos
{
    public interface IFormatoRepository<TModel> where TModel : class
    {
        public Task<TModel> RegistrarFormato(TModel model);
    }
}
