using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EQ_AREA
    /// </summary>
    public class EqAreaHelper : HelperBase
    {
        public EqAreaHelper(): base(Consultas.EqAreaSql)
        {
        }

        public EqAreaDTO Create(IDataReader dr)
        {
            EqAreaDTO entity = new EqAreaDTO();

            int iAreacodi = dr.GetOrdinal(this.Areacodi);
            if (!dr.IsDBNull(iAreacodi)) entity.Areacodi = Convert.ToInt32(dr.GetValue(iAreacodi));

            int iTareacodi = dr.GetOrdinal(this.Tareacodi);
            if (!dr.IsDBNull(iTareacodi)) entity.Tareacodi = Convert.ToInt32(dr.GetValue(iTareacodi));

            int iAreaabrev = dr.GetOrdinal(this.Areaabrev);
            if (!dr.IsDBNull(iAreaabrev)) entity.Areaabrev = dr.GetString(iAreaabrev);

            int iAreanomb = dr.GetOrdinal(this.Areanomb);
            if (!dr.IsDBNull(iAreanomb)) entity.Areanomb = dr.GetString(iAreanomb);

            int iAreapadre = dr.GetOrdinal(this.Areapadre);
            if (!dr.IsDBNull(iAreapadre)) entity.Areapadre = Convert.ToInt32(dr.GetValue(iAreapadre));

            return entity;
        }


        #region Mapeo de Campos

        public string Areacodi = "AREACODI";
        public string Tareacodi = "TAREACODI";
        public string Areaabrev = "AREAABREV";
        public string Areanomb = "AREANOMB";
        public string Areapadre = "AREAPADRE";
        public string Tareanomb = "TAREANOMB";

        #endregion

        public string SqlAreasPorFiltro
        {
            get { return base.GetSqlXml("AreasPorFiltro"); }
        }
        public string SqlCantidadAreasPorFiltro
        {
            get { return base.GetSqlXml("CantidadAreasPorFiltro"); }
        }
    }
}
