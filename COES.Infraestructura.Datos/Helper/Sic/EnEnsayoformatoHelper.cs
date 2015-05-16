using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EN_ENSAYOFORMATO
    /// </summary>
    public class EnEnsayoformatoHelper : HelperBase
    {
        public EnEnsayoformatoHelper(): base(Consultas.EnEnsayoformatoSql)
        {
        }

        public EnEnsayoformatoDTO Create(IDataReader dr)
        {
            EnEnsayoformatoDTO entity = new EnEnsayoformatoDTO();

            int iEnsayocodi = dr.GetOrdinal(this.Ensayocodi);
            if (!dr.IsDBNull(iEnsayocodi)) entity.Ensayocodi = Convert.ToInt32(dr.GetValue(iEnsayocodi));

            int iFormatocodi = dr.GetOrdinal(this.Formatocodi);
            if (!dr.IsDBNull(iFormatocodi)) entity.Formatocodi = Convert.ToInt32(dr.GetValue(iFormatocodi));

            int iEnsformatnombfisico = dr.GetOrdinal(this.Ensformatnombfisico);
            if (!dr.IsDBNull(iEnsformatnombfisico)) entity.Ensformatnombfisico = dr.GetString(iEnsformatnombfisico);

            int iEnsformatnomblogico = dr.GetOrdinal(this.Ensformatnomblogico);
            if (!dr.IsDBNull(iEnsformatnomblogico)) entity.Ensformatnomblogico = dr.GetString(iEnsformatnomblogico);

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iEnsformtestado = dr.GetOrdinal(this.Ensformtestado);
            if (!dr.IsDBNull(iEnsformtestado)) entity.Ensformtestado = Convert.ToInt32(dr.GetValue(iEnsformtestado));

            return entity;
        }


        #region Mapeo de Campos

        public string Ensayocodi = "ENSAYOCODI";
        public string Formatocodi = "FORMATOCODI";
        public string Ensformatnombfisico = "ENSFORMATNOMBFISICO";
        public string Ensformatnomblogico = "ENSFORMATNOMBLOGICO";
        public string Lastdate = "LASTDATE";
        public string Lastuser = "LASTUSER";
        public string Ensformtestado = "ENSFORMTESTADO";

        #endregion

        public string SqlListaFormatoXEnsayo
        {
            get { return GetSqlXml("ListFormatoXEnsayo"); }
        }
        public string SqlUpdateEstado
        {
            get { return GetSqlXml("UpdateEstado"); }
        }
        public string SqlListaFormatosEmpresaCentral
        {
            get { return GetSqlXml("ListaFormatosEmpresaCentral"); }
        }
    }
}
