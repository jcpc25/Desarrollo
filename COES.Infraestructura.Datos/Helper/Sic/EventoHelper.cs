using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    public class EventoHelper : HelperBase
    {
        public EventoHelper()
            : base(Consultas.EventoSql)
        {

        }


        public EventoDTO Create(IDataReader dr)
        {
            EventoDTO entity = new EventoDTO();

            int iEQUIABREV = dr.GetOrdinal(this.EQUIABREV);
            if (!dr.IsDBNull(iEQUIABREV)) entity.EQUIABREV = dr.GetString(iEQUIABREV);

            int iEVENCODI = dr.GetOrdinal(this.EVENCODI);
            if (!dr.IsDBNull(iEVENCODI)) entity.EVENCODI = Convert.ToInt32(dr.GetValue(iEVENCODI));

            int iEMPRCODI = dr.GetOrdinal(this.EMPRCODI);
            if (!dr.IsDBNull(iEMPRCODI)) entity.EMPRCODI = Convert.ToInt32(dr.GetValue(iEMPRCODI));

            int iEQUICODI = dr.GetOrdinal(this.EQUICODI);
            if (!dr.IsDBNull(iEQUICODI)) entity.EQUICODI = Convert.ToInt32(dr.GetValue(iEQUICODI));

            int iTIPOEVENCODI = dr.GetOrdinal(this.TIPOEVENCODI);
            if (!dr.IsDBNull(iTIPOEVENCODI)) entity.TIPOEVENCODI = Convert.ToInt32(dr.GetValue(iTIPOEVENCODI));

            int iEVENINI = dr.GetOrdinal(this.EVENINI);
            if (!dr.IsDBNull(iEVENINI)) entity.EVENINI = dr.GetDateTime(iEVENINI);

            int iEVENFIN = dr.GetOrdinal(this.EVENFIN);
            if (!dr.IsDBNull(iEVENFIN)) entity.EVENFIN = dr.GetDateTime(iEVENFIN);

            int iEVENPADRE = dr.GetOrdinal(this.EVENPADRE);
            if (!dr.IsDBNull(iEVENPADRE)) entity.EVENPADRE = Convert.ToInt32(dr.GetValue(iEVENPADRE));

            int iFAMCODI = dr.GetOrdinal(this.FAMCODI);
            if (!dr.IsDBNull(iFAMCODI)) entity.FAMCODI = Convert.ToInt32(dr.GetValue(iFAMCODI));

            int iAREACODI = dr.GetOrdinal(this.AREACODI);
            if (!dr.IsDBNull(iAREACODI)) entity.AREACODI = Convert.ToInt32(dr.GetValue(iAREACODI));

            int iSUBCAUSAABREV = dr.GetOrdinal(this.SUBCAUSAABREV);
            if (!dr.IsDBNull(iSUBCAUSAABREV)) entity.SUBCAUSAABREV = dr.GetString(iSUBCAUSAABREV);

            int iSUBCAUSACODI = dr.GetOrdinal(this.SUBCAUSACODI);
            if (!dr.IsDBNull(iSUBCAUSACODI)) entity.SUBCAUSACODI = Convert.ToInt32(dr.GetValue(iSUBCAUSACODI));

            int iTIPOEVENABREV = dr.GetOrdinal(this.TIPOEVENABREV);
            if (!dr.IsDBNull(iTIPOEVENABREV)) entity.TIPOEVENABREV = dr.GetString(iTIPOEVENABREV);

            int iAREANOMB = dr.GetOrdinal(this.AREANOMB);
            if (!dr.IsDBNull(iAREANOMB)) entity.AREANOMB = dr.GetString(iAREANOMB);

            int iEVENINTERRUP = dr.GetOrdinal(this.EVENINTERRUP);
            if (!dr.IsDBNull(iEVENINTERRUP)) entity.EVENINTERRUP = dr.GetString(iEVENINTERRUP);

            int iFAMABREV = dr.GetOrdinal(this.FAMABREV);
            if (!dr.IsDBNull(iFAMABREV)) entity.FAMABREV = dr.GetString(iFAMABREV);

            int iTAREAABREV = dr.GetOrdinal(this.TAREAABREV);
            if (!dr.IsDBNull(iTAREAABREV)) entity.TAREAABREV = dr.GetString(iTAREAABREV);

            int iEMPRNOMB = dr.GetOrdinal(this.EMPRNOMB);
            if (!dr.IsDBNull(iEMPRNOMB)) entity.EMPRNOMB = dr.GetString(iEMPRNOMB);

            int iTAREACODI = dr.GetOrdinal(this.TAREACODI);
            if (!dr.IsDBNull(iTAREACODI)) entity.TAREACODI = Convert.ToInt32(dr.GetValue(iTAREACODI));

            int iLASTUSER = dr.GetOrdinal(this.LASTUSER);
            if (!dr.IsDBNull(iLASTUSER)) entity.LASTUSER = dr.GetString(iLASTUSER);

            int iLASTDATE = dr.GetOrdinal(this.LASTDATE);
            if (!dr.IsDBNull(iLASTDATE)) entity.LASTDATE = dr.GetDateTime(iLASTDATE);

            int iEVENASUNTO = dr.GetOrdinal(this.EVENASUNTO);
            if (!dr.IsDBNull(iEVENASUNTO)) entity.EVENASUNTO = dr.GetString(iEVENASUNTO);

            int iEVENPRELIMINAR = dr.GetOrdinal(this.EVENPRELIMINAR);
            if (!dr.IsDBNull(iEVENPRELIMINAR)) entity.EVENPRELIMINAR = dr.GetString(iEVENPRELIMINAR);

            int iCAUSAEVENABREV = dr.GetOrdinal(this.CAUSAEVENABREV);
            if (!dr.IsDBNull(iCAUSAEVENABREV)) entity.CAUSAEVENABREV = dr.GetString(iCAUSAEVENABREV);

            int iEVENRELEVANTE = dr.GetOrdinal(this.EVENRELEVANTE);
            if (!dr.IsDBNull(iEVENRELEVANTE)) entity.EVENRELEVANTE = Convert.ToInt32(dr.GetValue(iEVENRELEVANTE));

            int iTIPOEMPRDESC = dr.GetOrdinal(this.TIPOEMPRDESC);
            if (!dr.IsDBNull(iTIPOEMPRDESC)) entity.TIPOEMPRDESC = dr.GetString(iTIPOEMPRDESC);

            int iEQUITENSION = dr.GetOrdinal(this.EQUITENSION);
            if (!dr.IsDBNull(iEQUITENSION)) entity.EQUITENSION = dr.GetDecimal(iEQUITENSION);

            int iENERGIAINTERRUMPIDA = dr.GetOrdinal(this.ENERGIAINTERRUMPIDA);
            if (!dr.IsDBNull(iENERGIAINTERRUMPIDA)) entity.ENERGIAINTERRUMPIDA = dr.GetDecimal(iENERGIAINTERRUMPIDA);

            int iINTERRUPCIONMW = dr.GetOrdinal(this.INTERRUPCIONMW);
            if (!dr.IsDBNull(iINTERRUPCIONMW)) entity.INTERRUPCIONMW = dr.GetDecimal(iINTERRUPCIONMW);

            int iDISMINUCIONMW = dr.GetOrdinal(this.DISMINUCIONMW);
            if (!dr.IsDBNull(iDISMINUCIONMW)) entity.DISMINUCIONMW = dr.GetDecimal(iDISMINUCIONMW);           
            
            if (entity.EVENFIN != null)
            {
                TimeSpan ts = ((DateTime)entity.EVENFIN).Subtract((DateTime)entity.EVENINI);
                entity.DURACION = ts.TotalMinutes;
            }
            

            return entity;
        }

        public string EQUIABREV = "EQUIABREV";
        public string EVENCODI = "EVENCODI";
        public string EMPRCODI = "EMPRCODI";
        public string EQUICODI = "EQUICODI";
        public string TIPOEMPRCODI = "TIPOEMPRCODI";
        public string TIPOEVENCODI = "TIPOEVENCODI";
        public string EVENINI = "EVENINI";
        public string EVENFIN = "EVENFIN";
        public string EVENPADRE = "EVENPADRE";
        public string FAMCODI = "FAMCODI";
        public string FAMNOMB = "FAMNOMB";
        public string AREACODI = "AREACODI";
        public string SUBCAUSAABREV = "SUBCAUSAABREV";
        public string SUBCAUSACODI = "SUBCAUSACODI";
        public string TIPOEVENABREV = "TIPOEVENABREV";
        public string AREANOMB = "AREANOMB";
        public string EVENINTERRUP = "EVENINTERRUP";
        public string FAMABREV = "FAMABREV";
        public string TAREAABREV = "TAREAABREV";
        public string EMPRNOMB = "EMPRNOMB";
        public string TAREACODI = "TAREACODI";
        public string LASTUSER = "LASTUSER";
        public string LASTDATE = "LASTDATE";
        public string EVENASUNTO = "EVENASUNTO";
        public string EVENPRELIMINAR = "EVENPRELIMINAR";
        public string CAUSAEVENABREV = "CAUSAEVENABREV";
        public string EVENRELEVANTE = "EVENRELEVANTE";
        public string EMPRCODIRESPON = "EMPRCODIRESPON";
        public string EVENCLASECODI = "EVENCLASECODI";
        public string EVENMWINDISP = "EVENMWINDISP";
        public string EVENPREINI = "EVENPREINI";
        public string EVENPOSTFIN = "EVENPOSTFIN";
        public string EVENDESC = "EVENDESC";
        public string EVENTENSION = "EVENTENSION";
        public string EVENAOPERA = "EVENAOPERA";
        public string EVENCTAF = "EVENCTAF";
        public string EVENINFFALLA = "EVENINFFALLA";
        public string EVENINFFALLAN2 = "EVENINFFALLAN2";
        public string DELETED = "DELETED";
        public string EVENTIPOFALLA = "EVENTIPOFALLA";
        public string EVENTIPOFALLAFASE = "EVENTIPOFALLAFASE";
        public string SMSENVIADO = "SMSENVIADO";
        public string SMSENVIAR = "SMSENVIAR";
        public string EVENACTUACION = "EVENACTUACION";
        public string EQUINOMB = "EQUINOMB";
        public string EVENCOMENTARIOS = "EVENCOMENTARIOS";
        public string EVENPERTURBACION = "EVENPERTURBACION";
        public string TIPOEMPRDESC = "TIPOEMPRDESC";       
        public string EQUITENSION = "EQUITENSION";
        public string ENERGIAINTERRUMPIDA = "ENERGIAINTERRUMPIDA";
        public string INTERRUPCIONMW = "INTERRUPCIONMW";
        public string DISMINUCIONMW = "DISMINUCIONMW";


        public string SqlBusquedaEquipoEvento
        {
            get { return base.GetSqlXml("SqlBuscarEquipo"); }
        }

        public string SqlTotalRecordsEquipo
        {
            get { return base.GetSqlXml("SqlObtenerNroRegistroEquipo"); }
        }    

        public string SqlActualizarInformePerturbacion
        {
            get { return base.GetSqlXml("SqlActualizarInformePerturbacion"); }
        }  

        public string SqlListarEmpresas
        {
            get { return base.GetSqlXml("SqlListarEmpresas"); }
        }

        public string SqlListarEmpresasPorTipo
        {
            get { return base.GetSqlXml("SqlListarEmpresasPorTipo"); }
        }

        public string SqlListarFamilias
        {
            get { return base.GetSqlXml("SqlListarFamilias"); }
        }

        public string SqlObtenerEvento
        {
            get { return base.GetSqlXml("SqlObtenerEvento"); }
        }

        public string SqlObtenerResumenEvento
        {
            get { return base.GetSqlXml("SqlObtenerResumenEvento"); }
        }

        public string SqlObtenerAreaPorEmpresa
        {
            get { return base.GetSqlXml("SqlObtenerAreaPorEmpresa"); }
        }
    }
}
