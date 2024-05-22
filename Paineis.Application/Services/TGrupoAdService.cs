using AutoMapper;
using Paineis.Application.DTOs;
using Paineis.Application.Interfaces;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;

namespace Paineis.Application.Services
{
    public class TGrupoAdService : ITgrupoAdService
    {
        private readonly ITgrupoAdRepository _tgrupoAdRepository;
        private readonly IMapper _mapper;

        public TGrupoAdService(ITgrupoAdRepository tgrupoAdRepository, IMapper mapper)
        {
            _tgrupoAdRepository = tgrupoAdRepository;
            _mapper = mapper;
        }

        public async Task<TGrupoAdUpDTO[]> Alterar(TGrupoAdUpDTO NomeGrupoAd)
        {
            var grupo = _mapper.Map<TGrupoAd>(NomeGrupoAd);
            var grupoAlterado = await _tgrupoAdRepository.Alterar(grupo);
            return _mapper.Map<TGrupoAdUpDTO[]>(grupoAlterado);
        }

        public async Task<TGrupoAdDTO[]> Excluir(int CodigoGrupoAd)
        {
            var grupoExcluido = await _tgrupoAdRepository.Excluir(CodigoGrupoAd);
            return _mapper.Map<TGrupoAdDTO[]>(grupoExcluido);
        }

        public async Task<TGrupoAdDTO[]> Incluir(TGrupoAdDTO NomeGrupoAd)
        {
            var grupo = _mapper.Map<TGrupoAd>(NomeGrupoAd);
            var grupoIncluir = await _tgrupoAdRepository.Incluir(grupo);
            return _mapper.Map<TGrupoAdDTO[]>(grupoIncluir);
        }

        public async Task<TGrupoAdDTO> SelecionarAsync(int CodigoGrupoAd)
        {
            var grupo = await _tgrupoAdRepository.SelecionarAsync(CodigoGrupoAd);
            return _mapper.Map<TGrupoAdDTO>(grupo);
        }

        public async Task<IEnumerable<TGrupoAdUpDTO>> SelecionarTodosAsync()
        {
            var grupo = await _tgrupoAdRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<TGrupoAdUpDTO>>(grupo);
        }
    }
}
