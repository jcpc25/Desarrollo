using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla EQ_EQUIPO
    /// </summary>
    public interface IEqEquipoRepository
    {
        int Save(EqEquipoDTO entity);
        void Update(EqEquipoDTO entity);
        void Delete(int equicodi);
        EqEquipoDTO GetById(int equicodi);
        List<EqEquipoDTO> List();
        List<EqEquipoDTO> GetByCriteria();
        List<EqEquipoDTO> GetByEmprFam(int emprcodi, int famcodi);
        List<EqEquipoDTO> ListadoCentralesOsinergmin();
        List<EqEquipoDTO> ListarEquiposxFiltro(int idEmpresa, string sEstado, int idTipoEquipo, int idTipoEmpresa, string sNombreEquipo, int idPadre);
        List<EqEquipoDTO> BuscarEquipoxNombre(string coincidencia, int nroPagina, int nroFilas);
        List<EqEquipoDTO> ListarEquipoxFamilias(params int[] iCodFamilias);
        //List<EqEquipoDTO> ListarEquiposPorPadre(int idPadre, int idFamilia, int nroPagina, int nroFilas);
        List<EqEquipoDTO> ListarCentralesXCombustible(int emprcodi, int tipocombustible);
        List<EqEquipoDTO> ListarEquipoxFamilias2(string sCodFamilias,string sCodEmpresas);
        List<EqEquipoDTO> ListarCentralesXEmpresaGEN(string emprcodi);
        List<EqEquipoDTO> ListarEquiposEnsayo(string equicodi);
    }
}
