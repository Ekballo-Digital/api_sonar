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
    public class AreaService : IAreaService
    {

        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;

        public AreaService(IAreaRepository areaRepository, IMapper mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }

        public async Task<AreaUpDTO[]> Alterar(AreaUpDTO Area)
        {
            var VarArea = _mapper.Map<TArea>(Area);
            var AreaAlterado = await _areaRepository.Alterar(VarArea);
            return _mapper.Map<AreaUpDTO[]>(AreaAlterado);
        }

        public async Task<AreaDTO[]> Excluir(int CodigoArea)
        {
            var AreaExcluido = await _areaRepository.Excluir(CodigoArea);
            return _mapper.Map<AreaDTO[]>(AreaExcluido);
        }

        public async Task<AreaDTO[]> Incluir(AreaDTO Area)
        {
            var VarArea = _mapper.Map<TArea>(Area);
            var AreaIncluir = await _areaRepository.Incluir(VarArea);
            return _mapper.Map<AreaDTO[]>(AreaIncluir);
        }

        public async Task<AreaDTO> SelecionarAsync(int CodigoArea)
        {
            var Area = await _areaRepository.SelecionarAsync(CodigoArea);
            return _mapper.Map<AreaDTO>(Area);
        }

        public async Task<IEnumerable<AreaUpDTO>> SelecionarTodosAsync()
        {
            var Area = await _areaRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<AreaUpDTO>>(Area);
        }
    }
}
