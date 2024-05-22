using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface ISelect
    {
        Task<GerarCoresEntities[]> GerarCor();
        Task<GerarAreasEntities[]> GerarArea();
        Task<GerarPerfilEntities[]> GerarPerfil();
        Task<GerarMenuEntities[]> GerarMenu();
        Task<GerarEstadoEntities[]> GerarEstado();

        Task<SelectNomeEstado[]> GetNomeEstado(int cod);
        Task<SelectNomeArea[]> GetNomeArea(int cod);
        Task<SelectNomeAlerta[]> GetNomeAlerta(int cod);
        Task<SelectNomePrioridade[]> GetNomePrioridade(int cod);


    }
}
