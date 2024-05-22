using AutoMapper;
using Paineis.Application.DTOs;
using Paineis.Application.Interfaces;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Services
{
    public class MenuPerfilService : IMenuPerfilService
    {
        private readonly IMenuPerfilRepository _menuPerfilRepository;
        private readonly IMapper _mapper;

        public MenuPerfilService(IMenuPerfilRepository menuPerfilRepository, IMapper mapper)
        {
            _menuPerfilRepository = menuPerfilRepository;
            _mapper = mapper;
        }

        /*public async Task<MenuPerfiDTO[]> Alterar(MenuPerfiDTO MenPer)
        {
            var VarMenPer = _mapper.Map<TMenuPerfil>(MenPer);
            var MenPerAlterado = await _menuPerfilRepository.Alterar(VarMenPer);
            return _mapper.Map<MenuPerfiDTO[]>(MenPerAlterado);
        }*/

        public async Task<MenuPerfiDTO> Excluir(int CodigoMenu, int CodigoPerfil)
        {
            var MenPerfExcluido = await _menuPerfilRepository.Excluir(CodigoMenu, CodigoPerfil);
            return _mapper.Map<MenuPerfiDTO>(MenPerfExcluido);
        }

        public async Task<MenuPerfiDTO[]> Incluir(MenuPerfiDTO MenPer)
        {
            var VarMenPerf = _mapper.Map<TMenuPerfil>(MenPer);
            var MenPerfIncluir = await _menuPerfilRepository.Incluir(VarMenPerf);
            return _mapper.Map<MenuPerfiDTO[]>(MenPerfIncluir);
        }

        public async Task<MenuPerfiDTO> SelecionarAsync(int CodigoMenu, int CodigoPerfil)
        {
            var Alerta = await _menuPerfilRepository.SelecionarAsync(CodigoMenu, CodigoPerfil);
            return _mapper.Map<MenuPerfiDTO>(Alerta);
        }

        public async Task<IEnumerable<MenuPerfiDTO>> SelecionarTodosAsync()
        {
            var MenPer = await _menuPerfilRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<MenuPerfiDTO>>(MenPer);
        }
    }
}
