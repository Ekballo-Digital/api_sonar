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
    public class CorService : ICorService
    {
        private readonly ICorRepository _corRepository;
        private readonly IMapper _mapper;

        public CorService(ICorRepository corRepository, IMapper mapper)
        {
            _corRepository = corRepository;
            _mapper = mapper;
        }

        public async Task<CorUpDTO[]> Alterar(CorUpDTO Cor)
        {
            var VarCor = _mapper.Map<TCor>(Cor);
            var CorAlterado = await _corRepository.Alterar(VarCor);
            return _mapper.Map<CorUpDTO[]>(CorAlterado);
        }

        public async Task<CorDTO[]> Excluir(int CodigoCor)
        {
            var CorExcluido = await _corRepository.Excluir(CodigoCor);
            return _mapper.Map<CorDTO[]>(CorExcluido);
        }

        public async Task<CorDTO[]> Incluir(CorDTO Cor)
        {
            var VarCor = _mapper.Map<TCor>(Cor);
            var CorIncluir = await _corRepository.Incluir(VarCor);
            return _mapper.Map <CorDTO[]>(CorIncluir);
        }

        public async Task<CorDTO> SelecionarAsync(int CodigoCor)
        {
            var Cor = await _corRepository.SelecionarAsync(CodigoCor);
            return _mapper.Map<CorDTO>(Cor);
        }

        public async Task<IEnumerable<CorUpDTO>> SelecionarTodosAsync()
        {
            var Cor = await _corRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<CorUpDTO>>(Cor);
        }
    }
}
