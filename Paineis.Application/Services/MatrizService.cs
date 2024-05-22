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
    public class MatrizService : IMatrizService
    {

        private readonly IMatrizRepository _matrizRepository;
        private readonly IMapper _mapper;

        public MatrizService(IMatrizRepository matrizRepository, IMapper mapper)
        {
            _matrizRepository = matrizRepository;
            _mapper = mapper;
        }

        public async Task<TMatrizUpdateDTO[]> Alterar(TMatrizUpdateDTO Matriz)
        {
            var VarMatriz = _mapper.Map<TMatrizUpdate>(Matriz);
            var MatrizAlterado = await _matrizRepository.Alterar(VarMatriz);
            return _mapper.Map<TMatrizUpdateDTO[]>(MatrizAlterado);
        }

        public async Task<MatrizDTO> Excluir(int CodigoEstado, int CodigoArea, int CodigoAlerta, int CodigoPrioridade)
        {
            var MatrizExcluido = await _matrizRepository.Excluir(CodigoEstado, CodigoArea, CodigoAlerta, CodigoPrioridade);
            return _mapper.Map<MatrizDTO>(MatrizExcluido);
        }

        public async Task<MatrizDTO[]> Incluir(MatrizDTO Matriz)
        {
            var VarMatriz = _mapper.Map<TMatriz>(Matriz);
            var MatrizIncluir = await _matrizRepository.Incluir(VarMatriz);
            return _mapper.Map<MatrizDTO[]>(MatrizIncluir);
        }

        public async Task<MatrizDTO> SelecionarAsync(int CodigoEstado, int CodigoArea)
        {
            var Alerta = await _matrizRepository.SelecionarAsync(CodigoEstado, CodigoArea);
            return _mapper.Map<MatrizDTO>(Alerta);
        }

        public async Task<IEnumerable<MatrizDTO>> SelecionarTodosAsync()
        {
            var Matriz = await _matrizRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<MatrizDTO>>(Matriz);
        }
    }
}
