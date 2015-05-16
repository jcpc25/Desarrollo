using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EN_FORMATO
    /// </summary>
    public class EnFormatoHelper : HelperBase
    {
        public EnFormatoHelper(): base(Consultas.EnFormatoSql)
        {
        }

        public EnFormatoDTO Create(IDataReader dr)
        {
            EnFormatoDTO entity = new EnFormatoDTO();

            int iFormatocodi = dr.GetOrdinal(this.Formatocodi);
            if (!dr.IsDBNull(iFormatocodi)) entity.Formatocodi = Convert.ToInt32(dr.GetValue(iFormatocodi));

            int iFormatodesc = dr.GetOrdinal(this.Formatodesc);
            if (!dr.IsDBNull(iFormatodesc)) entity.Formatodesc = dr.GetString(iFormatodesc);

            int iTipoarchivo = dr.GetOrdinal(this.Tipoarchivo);
            if (!dr.IsDBNull(iTipoarchivo)) entity.Tipoarchivo = Convert.ToInt32(dr.GetValue(iTipoarchivo));

            return entity;
        }


        #region Mapeo de Campos

        public string Formatocodi = "FORMATOCODI";
        public string Formatodesc = "FORMATODESC";
        public string Tipoarchivo = "TIPOARCHIVO";

        #endregion
    }
}
