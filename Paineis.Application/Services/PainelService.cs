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
    public class PainelService : IPainelService
    {

        private readonly IPainelRepository _painelRepository;
        private readonly IMapper _mapper;

        public PainelService(IPainelRepository painelRepository, IMapper mapper)
        {
            _painelRepository = painelRepository;
            _mapper = mapper;
        }

        public async Task<PainelUpDTO[]> Alterar(PainelUpDTO Painel)
        {
            var VarPainel = _mapper.Map<TPainel>(Painel);
            var PainelAlterado = await _painelRepository.Alterar(VarPainel);
            return _mapper.Map<PainelUpDTO[]>(PainelAlterado);
        }

        public async Task<PainelDTO[]> Excluir(int CodigoPainel)
        {
            var PainelExcluido = await _painelRepository.Excluir(CodigoPainel);
            return _mapper.Map<PainelDTO[]>(PainelExcluido);
        }

        public async Task<PainelDTO[]> Incluir(PainelDTO Painel)
        {
            var VarPainel = _mapper.Map<TPainel>(Painel);
            var PainelIncluir = await _painelRepository.Incluir(VarPainel);
            return _mapper.Map<PainelDTO[]>(PainelIncluir);
        }

        public async Task<PainelDTO> SelecionarAsync(int CodigoPainel)
        {
            var Painel = await _painelRepository.SelecionarAsync(CodigoPainel);
            return _mapper.Map<PainelDTO>(Painel);
        }

        public async Task<IEnumerable<PainelUpDTO>> SelecionarTodosAsync()
        {
            var Painel = await _painelRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<PainelUpDTO>>(Painel);
        }
    }
}
