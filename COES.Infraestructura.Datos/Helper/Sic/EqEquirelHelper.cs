using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EQ_EQUIREL
    /// </summary>
    public class EqEquirelHelper : HelperBase
    {
        public EqEquirelHelper(): base(Consultas.EqEquirelSql)
        {
        }

        public EqEquirelDTO Create(IDataReader dr)
        {
            EqEquirelDTO entity = new EqEquirelDTO();

            int iEquicodi1 = dr.GetOrdinal(this.Equicodi1);
            if (!dr.IsDBNull(iEquicodi1)) entity.Equicodi1 = Convert.ToInt32(dr.GetValue(iEquicodi1));

            int iTiporelcodi = dr.GetOrdinal(this.Tiporelcodi);
            if (!dr.IsDBNull(iTiporelcodi)) entity.Tiporelcodi = Convert.ToInt32(dr.GetValue(iTiporelcodi));

            int iEquicodi2 = dr.GetOrdinal(this.Equicodi2);
            if (!dr.IsDBNull(iEquicodi2)) entity.Equicodi2 = Convert.ToInt32(dr.GetValue(iEquicodi2));

            return entity;
        }


        #region Mapeo de Campos

        public string Equicodi1 = "EQUICODI1";
        public string Tiporelcodi = "TIPORELCODI";
        public string Equicodi2 = "EQUICODI2";

        #endregion
    }
}
