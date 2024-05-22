using AutoMapper;
using Paineis.Application.DTOs;
using Paineis.Application.Interfaces;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;

namespace Paineis.Application.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Alterar(UsuarioDTO NomeGrupoAd)
        {
            var Usuario = _mapper.Map<TGrupoAd>(NomeGrupoAd);
            var UsuarioAlterado = await _usuarioRepository.Alterar(Usuario);
            return _mapper.Map<UsuarioDTO>(UsuarioAlterado);
        }

        public async Task<UsuarioDTO> Excluir(int CodigoGrupoAd)
        {
            var UsuarioExcluido = await _usuarioRepository.Excluir(CodigoGrupoAd);
            return _mapper.Map<UsuarioDTO>(UsuarioExcluido);
        }

        public async Task<UsuarioDTO> Incluir(UsuarioDTO NomeGrupoAd)
        {
            var Usuario = _mapper.Map<TGrupoAd>(NomeGrupoAd);
            var UsuarioIncluir = await _usuarioRepository.Incluir(Usuario);
            return _mapper.Map<UsuarioDTO>(UsuarioIncluir);
        }

        public async Task<UsuarioDTO> SelecionarAsync(int CodigoGrupoAd)
        {
            var Usuario = await _usuarioRepository.SelecionarAsync(CodigoGrupoAd);
            return _mapper.Map<UsuarioDTO>(Usuario);
        }

        public async Task<IEnumerable<UsuarioDTO>> SelecionarTodosAsync()
        {
            var Usuario = await _usuarioRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(Usuario);
        }
    }
}
