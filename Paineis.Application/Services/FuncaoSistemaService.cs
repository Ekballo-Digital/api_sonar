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
    public class FuncaoSistemaService : IFuncaoSistemaService
    {
        private readonly IFuncaoSistemaRepository _funcaoSistemaRepository;
        private readonly IMapper _mapper;

        public FuncaoSistemaService(IFuncaoSistemaRepository funcaoSistemaRepository, IMapper mapper)
        {
            _funcaoSistemaRepository = funcaoSistemaRepository;
            _mapper = mapper;
        }

        public async Task<FuncaoUpDTO[]> Alterar(FuncaoUpDTO Funcao)
        {
            var VarFuncao = _mapper.Map<TFuncao>(Funcao);
            var FuncaoAlterado = await _funcaoSistemaRepository.Alterar(VarFuncao);
            return _mapper.Map<FuncaoUpDTO[]>(FuncaoAlterado);
        }

        public async Task<FuncaoUpDTO> Excluir(int CodigoFuncao)
        {
            var FuncoExcluido = await _funcaoSistemaRepository.Excluir(CodigoFuncao);
            return _mapper.Map<FuncaoUpDTO>(FuncoExcluido);
        }

        public async Task<FuncaoDTO[]> Incluir(FuncaoDTO Funcao)
        {
            var VarFuncao = _mapper.Map<TFuncao>(Funcao);
            var FuncaoIncluir = await _funcaoSistemaRepository.Incluir(VarFuncao);
            return _mapper.Map<FuncaoDTO[]>(FuncaoIncluir);
        }

        public async Task<FuncaoUpDTO> SelecionarAsync(int CodigoFuncao)
        {
            var Alerta = await _funcaoSistemaRepository.SelecionarAsync(CodigoFuncao);
            return _mapper.Map<FuncaoUpDTO>(Alerta);
        }

        public async Task<IEnumerable<FuncaoUpDTO>> SelecionarTodosAsync()
        {
            var al = await _funcaoSistemaRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<FuncaoUpDTO>>(al);
        }
    }
}
