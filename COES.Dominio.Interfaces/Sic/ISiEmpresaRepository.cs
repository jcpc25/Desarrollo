using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla SI_EMPRESA
    /// </summary>
    public interface ISiEmpresaRepository
    {
        void Save(SiEmpresaDTO entity);
        void Update(SiEmpresaDTO entity);
        void Delete(int emprcodi);
        SiEmpresaDTO GetById(int emprcodi);
        List<SiEmpresaDTO> List(int tipoemprcodi);
        List<SiEmpresaDTO> GetByCriteria(string tiposEmpresa);
        List<SiEmpresaDTO> ObtenerEmpresasSEIN();
        List<SiEmpresaDTO> GetByUser(string userlogin);
        List<SiEmpresaDTO> ObtenerEmpresasxCombustible(string tipocombustible);
        List<SiEmpresaDTO> ObtenerEmpresasxCombustiblexUsuario(string tipocombustible, string usuario);
    }
}
