using System;
using System.Collections.Generic;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
    /// <summary>
    /// Interface de acceso a datos de la vista VW_SI_EMPRESA
    /// </summary>
    public interface IEmpresaRepository : IRepositoryBase
    {
        EmpresaDTO GetById(System.Int32 id);
        EmpresaDTO GetByCodigo(string nombre);
        List<EmpresaDTO> List();
        List<EmpresaDTO> GetByCriteria(string nombre);
    }
}
