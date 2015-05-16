using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla CB_ENVIO
    /// </summary>
    public class CbEnvioHelper : HelperBase
    {
        public CbEnvioHelper(): base(Consultas.CbEnvioSql)
        {
        }

        public CbEnvioDTO Create(IDataReader dr)
        {
            CbEnvioDTO entity = new CbEnvioDTO();

            int iEnviocodi = dr.GetOrdinal(this.Enviocodi);
            if (!dr.IsDBNull(iEnviocodi)) entity.Enviocodi = Convert.ToInt32(dr.GetValue(iEnviocodi));

            int ienviofecha = dr.GetOrdinal(this.Enviofecha);
            if (!dr.IsDBNull(ienviofecha)) entity.Enviofecha = dr.GetDateTime(ienviofecha);

            int iusercodi = dr.GetOrdinal(this.Usercodi);
            if (!dr.IsDBNull(iusercodi)) entity.Usercodi = dr.GetString(iusercodi);

            int igrupocodi = dr.GetOrdinal(this.Grupocodi);
            if (!dr.IsDBNull(igrupocodi)) entity.Grupocodi = Convert.ToInt32(dr.GetValue(igrupocodi));

            int iestenvcodi = dr.GetOrdinal(this.Estenvcodi);
            if (!dr.IsDBNull(iestenvcodi)) entity.Estenvcodi = Convert.ToInt32(dr.GetValue(iestenvcodi));

            int itipocombcodi = dr.GetOrdinal(this.Tipocombcodi);
            if (!dr.IsDBNull(itipocombcodi)) entity.Tipocombcodi = Convert.ToInt32(dr.GetValue(itipocombcodi));

            int iemprcodi = dr.GetOrdinal(this.Emprcodi);
            if (!dr.IsDBNull(iemprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iemprcodi));

            int ienvioobservacion = dr.GetOrdinal(this.Envioobservacion);
            if (!dr.IsDBNull(ienvioobservacion)) entity.Envioobservacion = dr.GetString(ienvioobservacion);

            int ienvioestado = dr.GetOrdinal(this.Envioestado);
            if (!dr.IsDBNull(ienvioestado)) entity.Envioestado = dr.GetString(ienvioestado);

            int ienvioplazo = dr.GetOrdinal(this.Envioplazo);
            if (!dr.IsDBNull(ienvioplazo)) entity.Envioplazo = dr.GetString(ienvioplazo);

            int ilastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(ilastdate)) entity.Lastdate = dr.GetDateTime(ilastdate);

            return entity;
        }


        #region Mapeo de Campos

        public string Enviocodi = "ENVIOCODI";
        public string Enviofecha = "ENVIOFECHA";
        public string Usercodi = "USERCODI";
        public string Grupocodi = "GRUPOCODI";
        public string Estenvcodi = "ESTENVCODI";
        public string Tipocombcodi = "TIPOCOMBCODI";
        public string Emprcodi = "EMPRCODI";
        public string Envioobservacion = "ENVIOOBSERVACION";
        public string Envioestado = "ENVIOESTADO";
        public string Envioplazo = "ENVIOPLAZO";
        public string Lastdate = "LASTDATE";
        public string Lastuser = "LASTUSER";
        #endregion

        public string SqlListaDetalle
        {
            get { return GetSqlXml("ListaDetalle"); }
        }

        public string SqlListaDetalleFiltro
        {
            get { return GetSqlXml("ListaDetalleFiltro"); }
        }
        public string SqlUpdateObs
        {
            get { return GetSqlXml("UpdateObs"); }
        }

        public string SqlTotalListaEnvio
        {
            get { return GetSqlXml("TotalListaEnvio"); }
        }

        public string SqlTotalListaEnvioXls
        {
            get { return GetSqlXml("ListaDetalleFiltroXls"); }
        }
        public string SqlGetDiasFeriados
        {
            get { return GetSqlXml("GetDiasFeriados"); }
        }
        
    }
}
