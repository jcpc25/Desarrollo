using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EQ_PROPEQUI
    /// </summary>
    public class EqPropequiHelper : HelperBase
    {
        public EqPropequiHelper(): base(Consultas.EqPropequiSql)
        {
        }

        public EqPropequiDTO Create(IDataReader dr)
        {
            EqPropequiDTO entity = new EqPropequiDTO();

            int iPropcodi = dr.GetOrdinal(this.Propcodi);
            if (!dr.IsDBNull(iPropcodi)) entity.Propcodi = Convert.ToInt32(dr.GetValue(iPropcodi));

            int iEquicodi = dr.GetOrdinal(this.Equicodi);
            if (!dr.IsDBNull(iEquicodi)) entity.Equicodi = Convert.ToInt32(dr.GetValue(iEquicodi));

            int iFechapropequi = dr.GetOrdinal(this.Fechapropequi);
            if (!dr.IsDBNull(iFechapropequi)) entity.Fechapropequi = dr.GetDateTime(iFechapropequi);

            int iValor = dr.GetOrdinal(this.Valor);
            if (!dr.IsDBNull(iValor)) entity.Valor = dr.GetString(iValor);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            return entity;
        }


        #region Mapeo de Campos

        public string Propcodi = "PROPCODI";
        public string Equicodi = "EQUICODI";
        public string Fechapropequi = "FECHAPROPEQUI";
        public string Valor = "VALOR";
        public string Lastuser = "LASTUSER";

        #endregion

        public string SqlPropiedadesFichaTecnicaVigentesxEquipo
        {
            get { return base.GetSqlXml("PropiedadesFichaTecnicaVigentesxEquipo"); }
        }
    }
}
