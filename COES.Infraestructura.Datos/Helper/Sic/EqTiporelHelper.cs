using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EQ_TIPOREL
    /// </summary>
    public class EqTiporelHelper : HelperBase
    {
        public EqTiporelHelper(): base(Consultas.EqTiporelSql)
        {
        }

        public EqTiporelDTO Create(IDataReader dr)
        {
            EqTiporelDTO entity = new EqTiporelDTO();

            int iTiporelcodi = dr.GetOrdinal(this.Tiporelcodi);
            if (!dr.IsDBNull(iTiporelcodi)) entity.Tiporelcodi = Convert.ToInt32(dr.GetValue(iTiporelcodi));

            int iTiporelnomb = dr.GetOrdinal(this.Tiporelnomb);
            if (!dr.IsDBNull(iTiporelnomb)) entity.Tiporelnomb = dr.GetString(iTiporelnomb);

            return entity;
        }


        #region Mapeo de Campos

        public string Tiporelcodi = "TIPORELCODI";
        public string Tiporelnomb = "TIPORELNOMB";

        #endregion
    }
}
