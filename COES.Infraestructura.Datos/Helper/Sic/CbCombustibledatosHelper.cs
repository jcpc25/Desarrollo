using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla CB_COMBUSTIBLEDATOS
    /// </summary>
    public class CbCombustibledatosHelper : HelperBase
    {
        public CbCombustibledatosHelper(): base(Consultas.CbCombustibleDatosSql)
        {

        }

        public CbCombustibledatosDTO Create(IDataReader dr)
        {
            CbCombustibledatosDTO entity = new CbCombustibledatosDTO();

            int iCombdatosfecha = dr.GetOrdinal(this.Combdatosfecha);
            if (!dr.IsDBNull(iCombdatosfecha)) entity.Combdatosfecha = dr.GetDateTime(iCombdatosfecha);

            int iCombdatosvalor = dr.GetOrdinal(this.Combdatosvalor);
            if (!dr.IsDBNull(iCombdatosvalor)) entity.Combdatosvalor = dr.GetString(iCombdatosvalor);

            int iConcepcodi = dr.GetOrdinal(this.Concepcodi);
            if (!dr.IsDBNull(iConcepcodi)) entity.Concepcodi = Convert.ToInt32(dr.GetValue(iConcepcodi));

            int iEnviocodi = dr.GetOrdinal(this.Enviocodi);
            if (!dr.IsDBNull(iEnviocodi)) entity.Enviocodi = Convert.ToInt32(dr.GetValue(iEnviocodi));

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);


            return entity;
        }

        
        #region Mapeo de Campos

        public string Combdatosfecha = "COMBDATOSFECHA";
        public string Combdatosvalor = "COMBDATOSVALOR";
        public string Concepcodi = "CONCEPCODI";
        public string Enviocodi = "ENVIOCODI";
        public string Lastuser = "LASTUSER";

        #endregion

        public string SqlGetListPropValor
        {
            get { return base.GetSqlXml("GetListPropValor"); }
        }
    }
}
