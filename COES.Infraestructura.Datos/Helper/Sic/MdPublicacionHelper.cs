using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla MD_PUBLICACION
    /// </summary>
    public class MdPublicacionHelper : HelperBase
    {
        public MdPublicacionHelper(): base(Consultas.MdPublicacionSql)
        {
        }

        public MdPublicacionDTO Create(IDataReader dr)
        {
            MdPublicacionDTO entity = new MdPublicacionDTO();

            int iPubliarchivo = dr.GetOrdinal(this.Publiarchivo);
            if (!dr.IsDBNull(iPubliarchivo)) entity.Publiarchivo = dr.GetString(iPubliarchivo);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);

            int iPubliplazofecha = dr.GetOrdinal(this.Publiplazofecha);
            if (!dr.IsDBNull(iPubliplazofecha)) entity.Publiplazofecha = dr.GetDateTime(iPubliplazofecha);

            int iEmprcodi = dr.GetOrdinal(this.Emprcodi);
            if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

            int iUsercodi = dr.GetOrdinal(this.Usercodi);
            if (!dr.IsDBNull(iUsercodi)) entity.Usercodi = dr.GetString(iUsercodi);

            int iPublimes = dr.GetOrdinal(this.Publimes);
            if (!dr.IsDBNull(iPublimes)) entity.Publimes = dr.GetDateTime(iPublimes);

            int iPublifecha = dr.GetOrdinal(this.Publifecha);
            if (!dr.IsDBNull(iPublifecha)) entity.Publifecha = dr.GetDateTime(iPublifecha);

            int iPublipin = dr.GetOrdinal(this.Publipin);
            if (!dr.IsDBNull(iPublipin)) entity.Publipin = dr.GetString(iPublipin);

            return entity;
        }


        #region Mapeo de Campos

        public string Publiarchivo = "PUBLIARCHIVO";
        public string Lastuser = "LASTUSER";
        public string Lastdate = "LASTDATE";
        public string Publiplazofecha = "PUBLIPLAZOFECHA";
        public string Emprcodi = "EMPRCODI";
        public string Usercodi = "USERCODI";
        public string Publimes = "PUBLIMES";
        public string Publifecha = "PUBLIFECHA";
        public string Publipin = "PUBLIPIN";

        #endregion

        public string SqlGetLastPubEmpresa
        {
            get { return base.GetSqlXml("GetLastPubEmpresa"); }
        }
    }
}
