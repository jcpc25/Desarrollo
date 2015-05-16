using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Transferencias;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Transferencias
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla SI_EMPRESA
    /// </summary>
    public class EmpresaHelper : HelperBase
    {
        public EmpresaHelper(): base(Consultas.EmpresaSql) 
        {
        }

        public EmpresaDTO Create(IDataReader dr)
        {
            EmpresaDTO entity = new EmpresaDTO();

            int iEmprCodi = dr.GetOrdinal(this.EmprCodi);
            if (!dr.IsDBNull(iEmprCodi)) entity.EmprCodi = dr.GetInt32(iEmprCodi);

            int iEmprNombre = dr.GetOrdinal(this.EmprNombre);
            if (!dr.IsDBNull(iEmprNombre)) entity.EmprNombre = dr.GetString(iEmprNombre);

            int iTipoEmprCodi = dr.GetOrdinal(this.TipoEmprCodi);
            if (!dr.IsDBNull(iTipoEmprCodi)) entity.TipoEmprCodi = dr.GetInt32(iTipoEmprCodi);

            return entity;
        }


        #region Mapeo de Campos


       
        public string EmprCodi = "EMPRCODI";
        public string EmprNombre = "EMPRNOMB";
        public string TipoEmprCodi = "TIPOEMPRCODI";
        
        #endregion

        public string SqlObtenerPorTipo
        {
            get { return base.GetSqlXml("ObtenerPorTipo"); }
        }

        public string SqlGetByCodigo
        {
            get { return base.GetSqlXml("GetByCodigo"); }

        }
    }
}
