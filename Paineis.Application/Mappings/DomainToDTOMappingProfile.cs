using AutoMapper;
using Paineis.Application.DTOs;
using Paineis.Domain.Entities;

namespace Paineis.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {

            CreateMap<TGrupoAd, UsuarioDTO>().ReverseMap();

            //GrupoAd
            CreateMap<TGrupoAd, TGrupoAdDTO>().ReverseMap();
            CreateMap<TGrupoAd, TGrupoAdUpDTO>().ReverseMap();
            
            //Alerta
            CreateMap<TAlertum, AlertaDTO>().ReverseMap();
            CreateMap<TAlertum, AlertaUpDTO>().ReverseMap();

            //COR
            CreateMap<TCor, CorDTO>().ReverseMap();
            CreateMap<TCor, CorUpDTO>().ReverseMap();

            //Area
            CreateMap<TArea, AreaDTO>().ReverseMap();
            CreateMap<TArea, AreaUpDTO>().ReverseMap();

            //Painel
            CreateMap<TPainel, PainelDTO>().ReverseMap();
            CreateMap<TPainel, PainelUpDTO>().ReverseMap();

            //Prioridade
            CreateMap<TPrioridade, PrioridadeDTO>().ReverseMap();
            CreateMap<TPrioridade, PrioridadeUpDTO>().ReverseMap();

            //Estado de Operação
            CreateMap<TEstado, TEstadoDTO>().ReverseMap();
            CreateMap<TEstado, TEstadoUpTDO>().ReverseMap();

            //Menu
            CreateMap<TMenu, MenuDTO>().ReverseMap();
            CreateMap<TMenu, MenuUpDTO>().ReverseMap();

            //Menu do Perfil
            CreateMap<TMenuPerfil, MenuPerfiDTO>().ReverseMap();

            //Função do Menu
            CreateMap<TFuncaoMenu, FuncaoMenuDTO>().ReverseMap();

            //Função do Sistema
            CreateMap<TFuncao, FuncaoDTO>().ReverseMap();
            CreateMap<TFuncao, FuncaoUpDTO>().ReverseMap();

            //Função do Perfil
            CreateMap<TPerfil, PerfilDTO>().ReverseMap();
            CreateMap<TPerfil, PerfilUpDTO>().ReverseMap();

            //Matriz
            CreateMap<TMatriz, MatrizDTO>().ReverseMap();

            //MatrizUp
            CreateMap<TMatrizUpdate, TMatrizUpdateDTO>().ReverseMap();
            
            //Fila
            CreateMap<TFila, FilaDTO>().ReverseMap();
        }
    }
}
