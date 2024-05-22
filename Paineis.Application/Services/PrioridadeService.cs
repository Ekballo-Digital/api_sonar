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
    public class PrioridadeService : IPrioridadeService
    {
        private readonly IPrioridadeRepository _prioridadeRepository;
        private readonly IMapper _mapper;

        public PrioridadeService(IPrioridadeRepository prioridadeRepository, IMapper mapper)
        {
            _prioridadeRepository = prioridadeRepository;
            _mapper = mapper;
        }

        public async Task<PrioridadeUpDTO[]> Alterar(PrioridadeUpDTO Prio)
        {
            var VarPrio = _mapper.Map<TPrioridade>(Prio);
            var PrioAlterado = await _prioridadeRepository.Alterar(VarPrio);
            return _mapper.Map<PrioridadeUpDTO[]>(PrioAlterado);
        }

        public async Task<PrioridadeDTO[]> Excluir(int CodigoPrioridade)
        {
            var PropExcluido = await _prioridadeRepository.Excluir(CodigoPrioridade);
            return _mapper.Map<PrioridadeDTO[]>(PropExcluido);
        }

        public async Task<PrioridadeDTO[]> Incluir(PrioridadeDTO Prio)
        {
            var VarPrio = _mapper.Map<TPrioridade>(Prio);
            var PainelIncluir = await _prioridadeRepository.Incluir(VarPrio);
            return _mapper.Map<PrioridadeDTO[]>(PainelIncluir);
        }

        public async Task<PrioridadeDTO> SelecionarAsync(int CodigoPrioridade)
        {
            var Prio = await _prioridadeRepository.SelecionarAsync(CodigoPrioridade);
            return _mapper.Map<PrioridadeDTO>(Prio);
        }

        public async Task<IEnumerable<PrioridadeDTO>> SelecionarTodosAsync()
        {
            var Prio = await _prioridadeRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<PrioridadeDTO>>(Prio);
        }
    }
}
