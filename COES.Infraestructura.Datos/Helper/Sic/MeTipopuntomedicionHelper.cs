using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla ME_TIPOPUNTOMEDICION
    /// </summary>
    public class MeTipopuntomedicionHelper : HelperBase
    {
        public MeTipopuntomedicionHelper(): base(Consultas.MeTipopuntomedicionSql)
        {
        }

        public MeTipopuntomedicionDTO Create(IDataReader dr)
        {
            MeTipopuntomedicionDTO entity = new MeTipopuntomedicionDTO();

            int iFamcodi = dr.GetOrdinal(this.Famcodi);
            if (!dr.IsDBNull(iFamcodi)) entity.Famcodi = Convert.ToInt32(dr.GetValue(iFamcodi));

            int iTipoptomedinomb = dr.GetOrdinal(this.Tipoptomedinomb);
            if (!dr.IsDBNull(iTipoptomedinomb)) entity.Tipoptomedinomb = dr.GetString(iTipoptomedinomb);

            int iTipoptomedicodi = dr.GetOrdinal(this.Tipoptomedicodi);
            if (!dr.IsDBNull(iTipoptomedicodi)) entity.Tipoptomedicodi = Convert.ToInt32(dr.GetValue(iTipoptomedicodi));

            return entity;
        }


        #region Mapeo de Campos

        public string Famcodi = "FAMCODI";
        public string Tipoptomedinomb = "TIPOPTOMEDINOMB";
        public string Tipoptomedicodi = "TIPOPTOMEDICODI";

        #endregion
    }
}
