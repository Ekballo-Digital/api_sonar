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
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<MenuUpDTO[]> Alterar(MenuUpDTO Menu)
        {
            var VarMenu = _mapper.Map<TMenu>(Menu);
            var MenuAlterado = await _menuRepository.Alterar(VarMenu);
            return _mapper.Map<MenuUpDTO[]>(MenuAlterado);
        }

        public async Task<MenuDTO> Excluir(int CodigoMenu)
        {
            var MenuExcluido = await _menuRepository.Excluir(CodigoMenu);
            return _mapper.Map<MenuDTO>(MenuExcluido);
        }

        public async Task<MenuDTO[]> Incluir(MenuDTO Menu)
        {
            var VarMenu = _mapper.Map<TMenu>(Menu);
            var MenuIncluir = await _menuRepository.Incluir(VarMenu);
            return _mapper.Map<MenuDTO[]>(MenuIncluir);
        }

        public async Task<MenuDTO> SelecionarAsync(int CodigoMenu)
        {
            var Menu = await _menuRepository.SelecionarAsync(CodigoMenu);
            return _mapper.Map<MenuDTO>(Menu);
        }

        public async Task<IEnumerable<MenuUpDTO>> SelecionarTodosAsync()
        {
            var Menu = await _menuRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<MenuUpDTO>>(Menu);
        }
    }
}
