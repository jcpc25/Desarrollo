using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla ME_MEDICION1
    /// </summary>
    public class MeMedicion1Helper : HelperBase
    {
        public MeMedicion1Helper(): base(Consultas.MeMedicion1Sql)
        {
        }

        public MeMedicion1DTO Create(IDataReader dr)
        {
            MeMedicion1DTO entity = new MeMedicion1DTO();

            int iLectcodi = dr.GetOrdinal(this.Lectcodi);
            if (!dr.IsDBNull(iLectcodi)) entity.Lectcodi = Convert.ToInt32(dr.GetValue(iLectcodi));

            int iMedifecha = dr.GetOrdinal(this.Medifecha);
            if (!dr.IsDBNull(iMedifecha)) entity.Medifecha = dr.GetDateTime(iMedifecha);

            int iTipoinfocodi = dr.GetOrdinal(this.Tipoinfocodi);
            if (!dr.IsDBNull(iTipoinfocodi)) entity.Tipoinfocodi = Convert.ToInt32(dr.GetValue(iTipoinfocodi));

            int iPtomedicodi = dr.GetOrdinal(this.Ptomedicodi);
            if (!dr.IsDBNull(iPtomedicodi)) entity.Ptomedicodi = Convert.ToInt32(dr.GetValue(iPtomedicodi));

            int iH1 = dr.GetOrdinal(this.H1);
            if (!dr.IsDBNull(iH1)) entity.H1 = dr.GetDecimal(iH1);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);
            return entity;
        }


        #region Mapeo de Campos

        public string Lectcodi = "LECTCODI";
        public string Medifecha = "MEDIFECHA";
        public string Tipoinfocodi = "TIPOINFOCODI";
        public string Ptomedicodi = "PTOMEDICODI";
        public string H1 = "H1";
        public string Lastuser = "LASTUSER";
        public string Lastdate = "LASTDATE";

        #endregion

        public string SqlDeleteEnvioArchivo
        {
            get { return base.GetSqlXml("DeleteEnvioArchivo"); }
        }

        public string SqlGetEnvioArchivo
        {
            get { return base.GetSqlXml("GetEnvioArchivo"); }
        }
        public string SqlGetHidrologia
        {
            get { return base.GetSqlXml("GetHidrologia"); }
        }
    }
}
