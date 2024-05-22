using Microsoft.EntityFrameworkCore;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Infra.Data.Repositories
{
    public class SelectsRepository : ISelect
    {
        private readonly PAINEISContext _paineisContext;

        public SelectsRepository(PAINEISContext paineisContext)
        {
            _paineisContext = paineisContext;
        }

        public async Task<GerarCoresEntities[]> GerarCor()
        {
            var sql = "SELECT CODIGO_COR AS CodigoCor, DESCRICAO_COR AS NomeCor, HEXA_COR_RED AS Red, HEXA_COR_GREEN AS Green, HEXA_COR_BLUE AS Blue FROM T_COR";
            var res = await _paineisContext.GerarCores.FromSqlRaw(sql).ToArrayAsync();
            return res;
        }

        public async Task<GerarAreasEntities[]> GerarArea()
        {
            var sql = "SELECT CODIGO_AREA AS CodigoArea, NOME_AREA AS NomeArea, SIGLA_AREA AS SiglaArea FROM T_AREA WHERE CODIGO_AREA NOT IN (80, 85)";
            var res = await _paineisContext.GerarAreas.FromSqlRaw(sql).ToArrayAsync();
            return res;
        }

        public async Task<GerarPerfilEntities[]> GerarPerfil()
        {
            var sql = "SELECT CODIGO_PERFIL as CodigoPerfil, NOME_PERFIL as NomePerfil FROM T_PERFIL";
            var res = await _paineisContext.GerarPerfil.FromSqlRaw(sql).ToArrayAsync();
            return res;
        }

        public async Task<GerarMenuEntities[]> GerarMenu()
        {
            var sql = "SELECT CODIGO_MENU AS CodigoMenu, NOME_MENU AS NomeMenu FROM T_MENU";
            var res = await _paineisContext.GerarMenus.FromSqlRaw(sql).ToArrayAsync();
            return res;
        }

        public async Task<GerarEstadoEntities[]> GerarEstado()
        {
            var sql = "SELECT CODIGO_ESTADO AS CodigoEstado, DESCRICAO_ESTADO AS DescricaoEstado FROM T_ESTADO ORDER BY CODIGO_AREA_ESTADO ASC --WHERE TIPO_ESTADO != 'L'";
            var res = await _paineisContext.GerarEstados.FromSqlRaw(sql).ToArrayAsync();
            return res;
        }

        public async Task<SelectNomeEstado[]> GetNomeEstado(int cod)
        {
            var sql = $"SELECT DESCRICAO_ESTADO as DescricaoEstado FROM T_ESTADO WHERE CODIGO_ESTADO = {cod}";
            var res = await _paineisContext.SelectNomeEstados.FromSqlRaw(sql).ToArrayAsync();
            return res;
        }

        public async Task<SelectNomeArea[]> GetNomeArea(int cod)
        {
            var sql = $"SELECT NOME_AREA as NomeArea FROM T_AREA WHERE CODIGO_AREA = {cod}";
            var res = await _paineisContext.SelectNomeAreas.FromSqlRaw(sql).ToArrayAsync();
            return res;
        }

        public async Task<SelectNomeAlerta[]> GetNomeAlerta(int cod)
        {
            var sql = $"SELECT DESCRICAO_ALERTA as DescricaoAlerta FROM T_ALERTA WHERE CODIGO_ALERTA = {cod}";
            var res = await _paineisContext.SelectNomeAlertas.FromSqlRaw(sql).ToArrayAsync();
            return res;
        }

        public async Task<SelectNomePrioridade[]> GetNomePrioridade(int cod)
        {
            var sql = $"SELECT NOME_PRIORIDADE as NomePrioridade FROM T_PRIORIDADE WHERE CODIGO_PRIORIDADE = {cod}";
            var res = await _paineisContext.SelectNomePrioridades.FromSqlRaw(sql).ToArrayAsync();
            return res;
        }
    }
}