using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Paineis.API.Models;
using Paineis.Application.DTOs;
using Paineis.Domain.Account;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;
using Paineis.Infra.Ioc;
using System.Net.Http.Headers;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class TabelaMatrizController : Controller
    {
        private readonly ITabelaMatriz _tabelaMatriz;

       public TabelaMatrizController(ITabelaMatriz tabelaMatriz)
        {
            _tabelaMatriz = tabelaMatriz;
        }

        [HttpPost("GerarSilgasTabelaMatriz")]
        [Authorize]
        public async Task<IActionResult> GerarSilgasTabelaMatriz()
        {
            try
            {
                var var = await _tabelaMatriz.GerarSilgasTabela();
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GerarEstadosTabelaMatriz")]
        [Authorize]
        public async Task<IActionResult> GerarEstadosTabelaMatriz(GerarEstadosTabelaMatriz body)
        {
            try
            {
                var var = await _tabelaMatriz.GerarEstadoTabela(body.CodigoArea);
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GerarAlertasTabelaMatriz")]
        [Authorize]
        public async Task<IActionResult> GerarAlertasTabelaMatriz(GerarAlertasTabelaMatriz body)
        {
            try
            {
                var var = await _tabelaMatriz.GerarAlertasTabela(body.CodigoEstado);
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
