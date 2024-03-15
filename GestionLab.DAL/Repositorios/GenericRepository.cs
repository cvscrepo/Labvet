using GestionLab.DAL.DBContext;
using GestionLab.DAL.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;
using SistemaComercial.DAL.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaComercial.DAL.Repositorios
{
    public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
    {
       private readonly GestionlabContext _gestionLabContext;

        public GenericRepository(GestionlabContext gestionLabContext)
        {
            _gestionLabContext = gestionLabContext;
        }

        public async Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
        {
            try
            {
                TModelo modelo = await _gestionLabContext.Set<TModelo>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                //Base de datos.especificarElModeloATrabajar
                _gestionLabContext.Set<TModelo>().Add(modelo);
                await _gestionLabContext.SaveChangesAsync();

                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _gestionLabContext.Set<TModelo>().Update(modelo);
                await _gestionLabContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            try
            {
                _gestionLabContext.Remove(modelo);
                await _gestionLabContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModelo> modelo = filtro == null ? _gestionLabContext.Set<TModelo>() : _gestionLabContext.Set<TModelo>().Where(filtro);
                return modelo;
            }
            catch
            {
                throw;
            }
        }

    }
}
