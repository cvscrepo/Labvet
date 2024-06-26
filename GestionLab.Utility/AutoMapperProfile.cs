using AutoMapper;
using GestionLab.DTO;
using GestionLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region Rol
            CreateMap<Rol, RolDTO>()
                .ReverseMap();
            #endregion

            #region Campo Formato
            CreateMap<CampoFormato, CampoFormatoDTO>()
                .ForMember(destino =>
                    destino.TipoCampo,
                    opt => opt.MapFrom(origen => origen.IdTipoCampoNavigation.Nombre)
                );
            #endregion

            #region Cliente
            CreateMap<Cliente, ClienteDTO>() .ReverseMap();
            #endregion

            #region Formato
            CreateMap<Formato, FormatoDTO>() .ReverseMap();
            #endregion

            #region Paciente
            CreateMap<Paciente, PacienteDTO>().ReverseMap();
            #endregion

            #region Solicitud
            CreateMap<Solicitud, SolicitudDTO>().ReverseMap();
            #endregion

            #region Sucursal
            CreateMap<Sucursal, SucursalDTO>().ReverseMap();
            #endregion

            #region Servicios
            CreateMap<Servicios, ServiciosDTO>().ReverseMap();
            CreateMap<ServiciosDTO, Servicios> ().ReverseMap();
            #endregion

            #region Tipo Campo
            CreateMap<TipoCampo, TipoCampoDTO>().ReverseMap();
            #endregion

            #region Tipo Formato
            CreateMap<TipoFormato, TipoFormatoDTO>().ReverseMap();
            #endregion

            #region Tipo Identificación
            CreateMap<TipoIdentificacion, TipoIdentificacion>().ReverseMap();
            #endregion

            #region Tipo Solicitud
            CreateMap<TipoSolicitud, TipoSolicitudDTO>().ReverseMap();
            #endregion

            #region Usuario
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
            #endregion
        }
    }
}
