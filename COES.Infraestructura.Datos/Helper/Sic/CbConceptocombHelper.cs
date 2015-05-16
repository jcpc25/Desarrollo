using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla CB_CONCEPTOCOMB
    /// </summary>
    public class CbConceptocombHelper : HelperBase
    {
        public CbConceptocombHelper(): base(Consultas.CbConceptocombSql)
        {
        }

        public CbConceptocombDTO Create(IDataReader dr)
        {
            CbConceptocombDTO entity = new CbConceptocombDTO();

            int iConceptipo = dr.GetOrdinal(this.Conceptipo);
            if (!dr.IsDBNull(iConceptipo)) entity.Conceptipo = dr.GetString(iConceptipo);

            int iConcepabrev = dr.GetOrdinal(this.Concepabrev);
            if (!dr.IsDBNull(iConcepabrev)) entity.Concepabrev = dr.GetString(iConcepabrev);

            int iConceporden = dr.GetOrdinal(this.Conceporden);
            if (!dr.IsDBNull(iConceporden)) entity.Conceporden = Convert.ToInt32(dr.GetValue(iConceporden));

            int iConcepunidad = dr.GetOrdinal(this.Concepunidad);
            if (!dr.IsDBNull(iConcepunidad)) entity.Concepunidad = dr.GetString(iConcepunidad);

            int iTipocombcodi = dr.GetOrdinal(this.Tipocombcodi);
            if (!dr.IsDBNull(iTipocombcodi)) entity.Tipocombcodi = Convert.ToInt32(dr.GetValue(iTipocombcodi));

            int iConcepnomb = dr.GetOrdinal(this.Concepnomb);
            if (!dr.IsDBNull(iConcepnomb)) entity.Concepnomb = dr.GetString(iConcepnomb);

            int iConcepcodi = dr.GetOrdinal(this.Concepcodi);
            if (!dr.IsDBNull(iConcepcodi)) entity.Concepcodi = Convert.ToInt32(dr.GetValue(iConcepcodi));

            return entity;
        }


        #region Mapeo de Campos

        public string Conceptipo = "CONCEPTIPO";
        public string Concepabrev = "CONCEPABREV";
        public string Conceporden = "CONCEPORDEN";
        public string Concepunidad = "CONCEPUNIDAD";
        public string Tipocombcodi = "TIPOCOMBCODI";
        public string Concepnomb = "CONCEPNOMB";
        public string Concepcodi = "CONCEPCODI";

        #endregion
    }
}
