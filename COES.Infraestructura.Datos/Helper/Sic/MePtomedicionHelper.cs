using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla ME_PTOMEDICION
    /// </summary>
    public class MePtomedicionHelper : HelperBase
    {
        public MePtomedicionHelper(): base(Consultas.MePtomedicionSql)
        {
        }

        public MePtomedicionDTO Create(IDataReader dr)
        {
            MePtomedicionDTO entity = new MePtomedicionDTO();

            int iPtomedicodi = dr.GetOrdinal(this.Ptomedicodi);
            if (!dr.IsDBNull(iPtomedicodi)) entity.Ptomedicodi = Convert.ToInt32(dr.GetValue(iPtomedicodi));

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iEmprcodi = dr.GetOrdinal(this.Emprcodi);
            if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

            int iGrupocodi = dr.GetOrdinal(this.Grupocodi);
            if (!dr.IsDBNull(iGrupocodi)) entity.Grupocodi = Convert.ToInt32(dr.GetValue(iGrupocodi));

            int iTipoinfocodi = dr.GetOrdinal(this.Tipoinfocodi);
            if (!dr.IsDBNull(iTipoinfocodi)) entity.Tipoinfocodi = Convert.ToInt32(dr.GetValue(iTipoinfocodi));

            int iOsicodi = dr.GetOrdinal(this.Osicodi);
            if (!dr.IsDBNull(iOsicodi)) entity.Osicodi = dr.GetString(iOsicodi);

            int iEquicodi = dr.GetOrdinal(this.Equicodi);
            if (!dr.IsDBNull(iEquicodi)) entity.Equicodi = Convert.ToInt32(dr.GetValue(iEquicodi));

            int iCodref = dr.GetOrdinal(this.Codref);
            if (!dr.IsDBNull(iCodref)) entity.Codref = Convert.ToInt32(dr.GetValue(iCodref));

            int iPtomedidesc = dr.GetOrdinal(this.Ptomedidesc);
            if (!dr.IsDBNull(iPtomedidesc)) entity.Ptomedidesc = dr.GetString(iPtomedidesc);

            int iOrden = dr.GetOrdinal(this.Orden);
            if (!dr.IsDBNull(iOrden)) entity.Orden = Convert.ToInt32(dr.GetValue(iOrden));

            int iPtomedielenomb = dr.GetOrdinal(this.Ptomedielenomb);
            if (!dr.IsDBNull(iPtomedielenomb)) entity.Ptomedielenomb = dr.GetString(iPtomedielenomb);

            int iPtomedibarranomb = dr.GetOrdinal(this.Ptomedibarranomb);
            if (!dr.IsDBNull(iPtomedibarranomb)) entity.Ptomedibarranomb = dr.GetString(iPtomedibarranomb);

            int iOriglectcodi = dr.GetOrdinal(this.Origlectcodi);
            if (!dr.IsDBNull(iOriglectcodi)) entity.Origlectcodi = Convert.ToInt32(dr.GetValue(iOriglectcodi));

            //int iTipoptomedicodi = dr.GetOrdinal(this.Tipoptomedicodi); 
            //if (!dr.IsDBNull(iTipoptomedicodi)) entity.Tipoptomedicodi = Convert.ToInt16(dr.GetValue(iTipoptomedicodi));

            //int iPtomediestado = dr.GetOrdinal(this.Ptomediestado);
            //if (!dr.IsDBNull(iPtomediestado)) entity.Ptomediestado = dr.GetString(iPtomediestado);

            return entity;
        }


        #region Mapeo de Campos

        public string Ptomedicodi = "PTOMEDICODI";
        public string Lastdate = "LASTDATE";
        public string Lastuser = "LASTUSER";
        public string Emprcodi = "EMPRCODI";
        public string Grupocodi = "GRUPOCODI";
        public string Tipoinfocodi = "TIPOINFOCODI";
        public string Osicodi = "OSICODI";
        public string Equicodi = "EQUICODI";
        public string Codref = "CODREF";
        public string Ptomedidesc = "PTOMEDIDESC";
        public string Orden = "ORDEN";
        public string Ptomedielenomb = "PTOMEDIELENOMB";
        public string Ptomedibarranomb = "PTOMEDIBARRANOMB";
        public string Origlectcodi = "ORIGLECTCODI";
        public string Tipoptomedicodi = "TIPOPTOMEDICODI";
        public string Ptomediestado = "PTOMEDIESTADO";

        #endregion

        public string SqlListarPtoMedicion
        {
            get { return base.GetSqlXml("ListarPtoMedicion"); }
        }

        public string SqlGetByIdEquipo
        {
            get { return base.GetSqlXml("GetByIdEquipo"); }
        }

        public string SqlGetPtoDuplicado
        {
            get { return base.GetSqlXml("GetPtoDuplicado"); }
        }
        public string SqlListarDetallePtoMedicionFiltro
        {
            get { return base.GetSqlXml("ListarDetallePtoMedicionFiltro"); }
        }
        public string SqlTotalListaPtoMedicion
        {
            get { return base.GetSqlXml("TotalListaPtoMedicion"); }
        }
        
    }
}
