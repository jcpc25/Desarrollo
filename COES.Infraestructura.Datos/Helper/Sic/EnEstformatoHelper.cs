using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EN_ESTFORMATO
    /// </summary>
    public class EnEstformatoHelper : HelperBase
    {
        public EnEstformatoHelper(): base(Consultas.EnEstformatoSql)
        {
        }

        public EnEstformatoDTO Create(IDataReader dr)
        {
            EnEstformatoDTO entity = new EnEstformatoDTO();

            int iEnsayocodi = dr.GetOrdinal(this.Ensayocodi);
            if (!dr.IsDBNull(iEnsayocodi)) entity.Ensayocodi = Convert.ToInt32(dr.GetValue(iEnsayocodi));

            int iFormatocodi = dr.GetOrdinal(this.Formatocodi);
            if (!dr.IsDBNull(iFormatocodi)) entity.Formatocodi = Convert.ToInt32(dr.GetValue(iFormatocodi));

            int iEstadocodi = dr.GetOrdinal(this.Estadocodi);
            if (!dr.IsDBNull(iEstadocodi)) entity.Estadocodi = Convert.ToInt32(dr.GetValue(iEstadocodi));

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iEstformatdescrip = dr.GetOrdinal(this.Estformatdescrip);
            if (!dr.IsDBNull(iEstformatdescrip)) entity.Estformatdescrip = dr.GetString(iEstformatdescrip);

            return entity;
        }


        #region Mapeo de Campos

        public string Ensayocodi = "ENSAYOCODI";
        public string Formatocodi = "FORMATOCODI";
        public string Estadocodi = "ESTADOCODI";
        public string Lastdate = "LASTDATE";
        public string Lastuser = "LASTUSER";
        public string Estformatdescrip = "ESTFORMATDESCRIP";

        #endregion

        public string SqlListFormatoXEstado
        {
            get { return GetSqlXml("ListFormatoXEstado"); }
        }
    }
}
