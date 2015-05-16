using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla PR_CONCEPTO
    /// </summary>
    public class PrConceptoHelper : HelperBase
    {
        public PrConceptoHelper(): base(Consultas.PrConceptoSql)
        {
        }

        public PrConceptoDTO Create(IDataReader dr)
        {
            PrConceptoDTO entity = new PrConceptoDTO();

            int iCatecodi = dr.GetOrdinal(this.Catecodi);
            if (!dr.IsDBNull(iCatecodi)) entity.Catecodi = Convert.ToInt32(dr.GetValue(iCatecodi));

            int iConcepcodi = dr.GetOrdinal(this.Concepcodi);
            if (!dr.IsDBNull(iConcepcodi)) entity.Concepcodi = Convert.ToInt32(dr.GetValue(iConcepcodi));

            int iConcepabrev = dr.GetOrdinal(this.Concepabrev);
            if (!dr.IsDBNull(iConcepabrev)) entity.Concepabrev = dr.GetString(iConcepabrev);

            int iConcepdesc = dr.GetOrdinal(this.Concepdesc);
            if (!dr.IsDBNull(iConcepdesc)) entity.Concepdesc = dr.GetString(iConcepdesc);

            int iConcepunid = dr.GetOrdinal(this.Concepunid);
            if (!dr.IsDBNull(iConcepunid)) entity.Concepunid = dr.GetString(iConcepunid);

            int iConceptipo = dr.GetOrdinal(this.Conceptipo);
            if (!dr.IsDBNull(iConceptipo)) entity.Conceptipo = dr.GetString(iConceptipo);

            int iConceporden = dr.GetOrdinal(this.Conceporden);
            if (!dr.IsDBNull(iConceporden)) entity.Conceporden = Convert.ToInt32(dr.GetValue(iConceporden));

            return entity;
        }


        #region Mapeo de Campos

        public string Catecodi = "CATECODI";
        public string Concepcodi = "CONCEPCODI";
        public string Concepabrev = "CONCEPABREV";
        public string Concepdesc = "CONCEPDESC";
        public string Concepunid = "CONCEPUNID";
        public string Conceptipo = "CONCEPTIPO";
        public string Conceporden = "CONCEPORDEN";

        #endregion
    }
}
