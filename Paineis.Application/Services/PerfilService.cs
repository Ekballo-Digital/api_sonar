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
    public class PerfilService : IPerfilService
    {

        private readonly IPerfilRepository _perfilRepository;
        private readonly IMapper _mapper;

        public PerfilService(IPerfilRepository perfilRepository, IMapper mapper)
        {
            _perfilRepository = perfilRepository;
            _mapper = mapper;
        }

        public async Task<PerfilUpDTO[]> Alterar(PerfilUpDTO Perfil)
        {
            var VarPerfil = _mapper.Map<TPerfil>(Perfil);
            var AlertaAlterado = await _perfilRepository.Alterar(VarPerfil);
            return _mapper.Map<PerfilUpDTO[]>(AlertaAlterado);
        }

        public async Task<PerfilDTO[]> Excluir(int CodigoPerfil)
        {
            var PerfilExcluido = await _perfilRepository.Excluir(CodigoPerfil);
            return _mapper.Map<PerfilDTO[]>(PerfilExcluido);
        }

        public async Task<PerfilDTO[]> Incluir(PerfilDTO Perfil)
        {
            var VarPerfil = _mapper.Map<TPerfil>(Perfil);
            var PerfilIncluir = await _perfilRepository.Incluir(VarPerfil);
            return _mapper.Map<PerfilDTO[]>(PerfilIncluir);
        }

        public async Task<PerfilDTO> SelecionarAsync(int CodigoPerfil)
        {
            var Perfil = await _perfilRepository.SelecionarAsync(CodigoPerfil);
            return _mapper.Map<PerfilDTO>(Perfil);
        }

        public async Task<IEnumerable<PerfilUpDTO>> SelecionarTodosAsync()
        {
            var Perfil = await _perfilRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<PerfilUpDTO>>(Perfil);
        }
    }
}
