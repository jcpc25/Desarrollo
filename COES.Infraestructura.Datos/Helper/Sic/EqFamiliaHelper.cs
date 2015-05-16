using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EQ_FAMILIA
    /// </summary>
    public class EqFamiliaHelper : HelperBase
    {
        public EqFamiliaHelper(): base(Consultas.EqFamiliaSql)
        {
        }

        public EqFamiliaDTO Create(IDataReader dr)
        {
            EqFamiliaDTO entity = new EqFamiliaDTO();

            int iFamcodi = dr.GetOrdinal(this.Famcodi);
            if (!dr.IsDBNull(iFamcodi)) entity.Famcodi = Convert.ToInt32(dr.GetValue(iFamcodi));

            int iFamabrev = dr.GetOrdinal(this.Famabrev);
            if (!dr.IsDBNull(iFamabrev)) entity.Famabrev = dr.GetString(iFamabrev);

            int iTipoecodi = dr.GetOrdinal(this.Tipoecodi);
            if (!dr.IsDBNull(iTipoecodi)) entity.Tipoecodi = Convert.ToInt32(dr.GetValue(iTipoecodi));

            int iTareacodi = dr.GetOrdinal(this.Tareacodi);
            if (!dr.IsDBNull(iTareacodi)) entity.Tareacodi = Convert.ToInt32(dr.GetValue(iTareacodi));

            int iFamnomb = dr.GetOrdinal(this.Famnomb);
            if (!dr.IsDBNull(iFamnomb)) entity.Famnomb = dr.GetString(iFamnomb);

            int iFamnumconec = dr.GetOrdinal(this.Famnumconec);
            if (!dr.IsDBNull(iFamnumconec)) entity.Famnumconec = Convert.ToInt32(dr.GetValue(iFamnumconec));

            int iFamnombgraf = dr.GetOrdinal(this.Famnombgraf);
            if (!dr.IsDBNull(iFamnombgraf)) entity.Famnombgraf = dr.GetString(iFamnombgraf);

            return entity;
        }


        #region Mapeo de Campos

        public string Famcodi = "FAMCODI";
        public string Famabrev = "FAMABREV";
        public string Tipoecodi = "TIPOECODI";
        public string Tareacodi = "TAREACODI";
        public string Famnomb = "FAMNOMB";
        public string Famnumconec = "FAMNUMCONEC";
        public string Famnombgraf = "FAMNOMBGRAF";

        #endregion
    }
}
