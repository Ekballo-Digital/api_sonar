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
    public class FuncaoMenuService : IFuncaoMenuService
    {
        private readonly IFuncaoMenuRepository _funcaoMenuRepository;
        private readonly IMapper _mapper;

        public FuncaoMenuService(IFuncaoMenuRepository funcaoMenuRepository, IMapper mapper)
        {
            _funcaoMenuRepository = funcaoMenuRepository;
            _mapper = mapper;
        }

        /*public async Task<FuncaoMenuDTO[]> Alterar(FuncaoMenuDTO FuncMen)
        {
            var VarFuncMen = _mapper.Map<TFuncaoMenu>(FuncMen);
            var AlertaAlterado = await _funcaoMenuRepository.Alterar(VarFuncMen);
            return _mapper.Map<FuncaoMenuDTO[]>(AlertaAlterado);
        }*/

        public async Task<FuncaoMenuDTO> Excluir(int CodigoMenu, int CodigoFuncao)
        {
            var FuncaoMenExcluido = await _funcaoMenuRepository.Excluir(CodigoMenu, CodigoFuncao);
            return _mapper.Map<FuncaoMenuDTO>(FuncaoMenExcluido);
        }

        public async Task<FuncaoMenuDTO[]> Incluir(FuncaoMenuDTO FuncMen)
        {
            var VarFuncMen = _mapper.Map<TFuncaoMenu>(FuncMen);
            var AlertaIncluir = await _funcaoMenuRepository.Incluir(VarFuncMen);
            return _mapper.Map<FuncaoMenuDTO[]>(AlertaIncluir);
        }

        public async Task<FuncaoMenuDTO> SelecionarAsync(int CodigoMenu, int CodigoFuncao)
        {
            var FunMen = await _funcaoMenuRepository.SelecionarAsync(CodigoMenu, CodigoFuncao);
            return _mapper.Map<FuncaoMenuDTO>(FunMen);
        }

        public async Task<IEnumerable<FuncaoMenuDTO>> SelecionarTodosAsync()
        {
            var FunMen = await _funcaoMenuRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<FuncaoMenuDTO>>(FunMen);
        }
    }
}
