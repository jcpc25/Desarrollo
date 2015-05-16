using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla ME_AMPLIACIONFECHA
    /// </summary>
    public class MeAmpliacionfechaHelper : HelperBase
    {
        public MeAmpliacionfechaHelper(): base(Consultas.MeAmpliacionfechaSql)
        {
        }

        public MeAmpliacionfechaDTO Create(IDataReader dr)
        {
            MeAmpliacionfechaDTO entity = new MeAmpliacionfechaDTO();

            int iAmplifecha = dr.GetOrdinal(this.Amplifecha);
            if (!dr.IsDBNull(iAmplifecha)) entity.Amplifecha = dr.GetDateTime(iAmplifecha);

            int iEmprcodi = dr.GetOrdinal(this.Emprcodi);
            if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

            int iFormatcodi = dr.GetOrdinal(this.Formatcodi);
            if (!dr.IsDBNull(iFormatcodi)) entity.Formatcodi = Convert.ToInt32(dr.GetValue(iFormatcodi));

            int iAmplifechaplazo = dr.GetOrdinal(this.Amplifechaplazo);
            if (!dr.IsDBNull(iAmplifechaplazo)) entity.Amplifechaplazo = dr.GetDateTime(iAmplifechaplazo);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);

            return entity;
        }


        #region Mapeo de Campos

        public string Amplifecha = "AMPLIFECHA";
        public string Emprcodi = "EMPRCODI";
        public string Formatcodi = "FORMATCODI";
        public string Amplifechaplazo = "AMPLIFECHAPLAZO";
        public string Lastuser = "LASTUSER";
        public string Lastdate = "LASTDATE";

        #endregion

        public string SqlListaAmpliacion
        {
            get { return base.GetSqlXml("ListaAmpliacion"); }
        }
    }
}
