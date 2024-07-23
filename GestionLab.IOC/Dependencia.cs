using GestionLab.BLL;
using GestionLab.BLL.Contrato;
using GestionLab.BLL.ServiciosTareas;
using GestionLab.BLL.ServiciosTareas.Contrato;
using GestionLab.DAL.DBContext;
using GestionLab.DAL.Repositorios.Contratos;
using GestionLab.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaComercial.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection service, IConfiguration configuration )
        {
            service.AddDbContext<GestionlabContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("cadenaSQL"))
            );
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddAutoMapper(typeof(AutoMapperProfile));
            service.AddScoped<IUsuarioService, UsuarioService>();
            service.AddScoped<IServiciosService, ServiciosService>();
            service.AddScoped<ILoginService, LoginService>();
            service.AddScoped<IRolService, RolService>();
        }
    }
}
