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
    public class EstadoOperacaoService : IEstadoOperacaoService
    {
        private readonly IEstadoOperacaoRepository _estadoOperacaoRepository;
        private readonly IMapper _mapper;

        public EstadoOperacaoService(IEstadoOperacaoRepository estadoOperacaoRepository, IMapper mapper)
        {
            _estadoOperacaoRepository = estadoOperacaoRepository;
            _mapper = mapper;
        }

        public async Task<TEstadoUpTDO[]> Alterar(TEstadoUpTDO Estado)
        {
            var VarEstado = _mapper.Map<TEstado>(Estado);
            var EstadoAlterado = await _estadoOperacaoRepository.Alterar(VarEstado);
            return _mapper.Map<TEstadoUpTDO[]>(EstadoAlterado);
        }

        public async Task<TEstadoDTO[]> Excluir(int CodigoEstado)
        {
            var EstadoExcluido = await _estadoOperacaoRepository.Excluir(CodigoEstado);
            return _mapper.Map<TEstadoDTO[]>(EstadoExcluido);
        }

        public async Task<TEstadoDTO[]> Incluir(TEstadoDTO Estado)
        {
            var VarEstado = _mapper.Map<TEstado>(Estado);
            var EstadoIncluir = await _estadoOperacaoRepository.Incluir(VarEstado);
            return _mapper.Map<TEstadoDTO[]>(EstadoIncluir);
        }

        public async Task<TEstadoDTO> SelecionarAsync(int CodigoEstado)
        {
            var Estado = await _estadoOperacaoRepository.SelecionarAsync(CodigoEstado);
            return _mapper.Map<TEstadoDTO>(Estado);
        }

        public async Task<IEnumerable<TEstadoUpTDO>> SelecionarTodosAsync()
        {
            var Alerta = await _estadoOperacaoRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<TEstadoUpTDO>>(Alerta);
        }
    }
}
