﻿using GestionLab.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        }
    }
}
