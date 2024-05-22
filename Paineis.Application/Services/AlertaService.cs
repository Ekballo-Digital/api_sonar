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
    public class AlertaService : IAlertaService
    {

        private readonly IAlertaRepository _alertaRepository;
        private readonly IMapper _mapper;

        public AlertaService(IAlertaRepository alertaRepository, IMapper mapper)
        {
            _alertaRepository = alertaRepository;
            _mapper = mapper;
        }

        public async Task<AlertaUpDTO[]> Alterar(AlertaUpDTO Alerta)
        {
            var VarAlerta = _mapper.Map<TAlertum>(Alerta);
            var AlertaAlterado = await _alertaRepository.Alterar(VarAlerta);
            return _mapper.Map<AlertaUpDTO[]>(AlertaAlterado);
        }

        public async Task<AlertaDTO[]> Excluir(int CodigoAlerta)
        {
            var AlertaExcluido = await _alertaRepository.Excluir(CodigoAlerta);
            return _mapper.Map<AlertaDTO[]>(AlertaExcluido);
        }

        public async Task<AlertaDTO[]> Incluir(AlertaDTO Alerta)
        {
            var VarAlerta = _mapper.Map<TAlertum>(Alerta);
            var AlertaIncluir = await _alertaRepository.Incluir(VarAlerta);
            return _mapper.Map<AlertaDTO[]>(AlertaIncluir);
        }

        public async Task<AlertaDTO> SelecionarAsync(int CodigoAlerta)
        {
            var Alerta = await _alertaRepository.SelecionarAsync(CodigoAlerta);
            return _mapper.Map<AlertaDTO>(Alerta);
        }

        public async Task<IEnumerable<AlertaUpDTO>> SelecionarTodosAsync()
        {
            var Alerta = await _alertaRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<AlertaUpDTO>>(Alerta);
        }
    }
}
