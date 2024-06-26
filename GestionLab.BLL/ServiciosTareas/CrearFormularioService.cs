using AutoMapper;
using GestionLab.BLL.Contrato;
using GestionLab.BLL.ServiciosTareas.Contrato;
using GestionLab.DTO;
using GestionLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.ServiciosTareas
{
    public class CrearFormularioService : ICrearFormularioService
    {
        private readonly GestionlabContext _dbContext;
        private readonly IFormatoService _formatoService;
        private readonly ICampoFormatoService _campoFormatoService;
        private readonly IMapper _mapper;
        public CrearFormularioService(IMapper mapper, IFormatoService formatoService, ICampoFormatoService campoFormatoService) 
        {
            _mapper = mapper;
            _campoFormatoService = campoFormatoService;
            _formatoService = formatoService;
        }
        public async Task<FormatoDTO> CrearFormulario(FormatoDTO formatoDTO)
        {
            using(var trnasanction = _dbContext.Database.BeginTransaction())
            {
                //Lo primero que se debe hacer es guardar 
                try
                {
                    FormatoDTO formatoCreado = await _formatoService.CrearFormato(formatoDTO);
                    foreach (CampoFormatoDTO campo in formatoDTO.CampoFormatos)
                    {
                        campo.IdFormato = formatoCreado.IdFormato;
                        CampoFormatoDTO campoCreado = await _campoFormatoService.CrearCampo(campo);
                    }
                    return formatoCreado;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
