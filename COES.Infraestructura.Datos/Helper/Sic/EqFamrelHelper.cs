using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EQ_FAMREL
    /// </summary>
    public class EqFamrelHelper : HelperBase
    {
        public EqFamrelHelper(): base(Consultas.EqFamrelSql)
        {
        }

        public EqFamrelDTO Create(IDataReader dr)
        {
            EqFamrelDTO entity = new EqFamrelDTO();

            int iTiporelcodi = dr.GetOrdinal(this.Tiporelcodi);
            if (!dr.IsDBNull(iTiporelcodi)) entity.Tiporelcodi = Convert.ToInt32(dr.GetValue(iTiporelcodi));

            int iFamcodi1 = dr.GetOrdinal(this.Famcodi1);
            if (!dr.IsDBNull(iFamcodi1)) entity.Famcodi1 = Convert.ToInt32(dr.GetValue(iFamcodi1));

            int iFamcodi2 = dr.GetOrdinal(this.Famcodi2);
            if (!dr.IsDBNull(iFamcodi2)) entity.Famcodi2 = Convert.ToInt32(dr.GetValue(iFamcodi2));

            int iFamnumconec = dr.GetOrdinal(this.Famnumconec);
            if (!dr.IsDBNull(iFamnumconec)) entity.Famnumconec = Convert.ToInt32(dr.GetValue(iFamnumconec));

            int iFamreltension = dr.GetOrdinal(this.Famreltension);
            if (!dr.IsDBNull(iFamreltension)) entity.Famreltension = dr.GetString(iFamreltension);

            return entity;
        }


        #region Mapeo de Campos

        public string Tiporelcodi = "TIPORELCODI";
        public string Famcodi1 = "FAMCODI1";
        public string Famcodi2 = "FAMCODI2";
        public string Famnumconec = "FAMNUMCONEC";
        public string Famreltension = "FAMRELTENSION";

        #endregion
    }
}
