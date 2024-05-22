using AutoMapper;
using Paineis.Application.DTOs;
using Paineis.Application.Interfaces;
using Paineis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Services
{
    public class FilaService : IFilaService
    {
        private readonly IFilaRepository _filaRepository;
        private readonly IMapper _mapper;

        public FilaService(IFilaRepository filaRepository, IMapper mapper)
        {
            _filaRepository = filaRepository;
            _mapper = mapper;
        }

        public async Task<FilaDTO[]> Excluir(int CodigoFilaMsg)
        {
            var FilaExcluido = await _filaRepository.DeletaFila(CodigoFilaMsg);
            return _mapper.Map<FilaDTO[]>(FilaExcluido);
        }

        public async Task<IEnumerable<FilaDTO>> SelectFilaEnvio(string matricula, int CodigoPainel)
        {
            var Cor = await _filaRepository.SelectFilaEnvio(matricula, CodigoPainel);
            return _mapper.Map<IEnumerable<FilaDTO>>(Cor);
        }

        public async Task<IEnumerable<FilaDTO>> SelectFilaEnvioGeral(int CodigoPainel)
        {
            var Cor = await _filaRepository.SelectFilaEnvioGeral(CodigoPainel);
            return _mapper.Map<IEnumerable<FilaDTO>>(Cor);
        }
    }
}
