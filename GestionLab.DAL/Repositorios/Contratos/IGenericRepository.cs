using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.DAL.Repositorios.Contratos
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        public Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro);
        public Task<TModel> Crear(TModel modelo);
        public Task<bool> Editar(TModel modelo);
        public Task<bool> Eliminar(TModel modelo);
        public Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null);

    }
}
