using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Infraestructura.Datos.Helper.Transferencias
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla TRN_CODIGO_RETIRO_SOLICITUD
    /// </summary>
    public class CodigoRetiroHelper : HelperBase
    {
        public CodigoRetiroHelper() : base(Consultas.CodigoRetiroSql)
        {
        }

        public CodigoRetiroDTO Create(IDataReader dr)
        {
            CodigoRetiroDTO entity = new CodigoRetiroDTO();

            int iSOLICODIRETICODI = dr.GetOrdinal(this.SOLICODIRETICODI);
            if (!dr.IsDBNull(iSOLICODIRETICODI)) entity.Solicodireticodi = dr.GetInt32(iSOLICODIRETICODI);

            int iEMPRCODI = dr.GetOrdinal(this.EMPRCODI);
            if (!dr.IsDBNull(iEMPRCODI)) entity.Emprcodi = dr.GetInt32(iEMPRCODI);

            int iBARRCODI = dr.GetOrdinal(this.BARRCODI);
            if (!dr.IsDBNull(iBARRCODI)) entity.Barrcodi = dr.GetInt32(iBARRCODI);

            int iUSUACODI = dr.GetOrdinal(this.USUACODI);
            if (!dr.IsDBNull(iUSUACODI)) entity.Usuacodi = dr.GetString(iUSUACODI);

             int iTIPOCONTCODI = dr.GetOrdinal(this.TIPOCONTCODI);
            if (!dr.IsDBNull(iTIPOCONTCODI)) entity.Tipocontcodi = dr.GetInt32(iTIPOCONTCODI);

            int iTIPOUSUACODI = dr.GetOrdinal(this.TIPOUSUACODI);
            if (!dr.IsDBNull(iTIPOUSUACODI)) entity.Tipousuacodi = dr.GetInt32(iTIPOUSUACODI);

            int iCLICODI = dr.GetOrdinal(this.CLICODI);
            if (!dr.IsDBNull(iCLICODI)) entity.Clicodi = dr.GetInt32(iCLICODI);

            int iSOLICODIRETICODIGO = dr.GetOrdinal(this.SOLICODIRETICODIGO);
            if (!dr.IsDBNull(iSOLICODIRETICODIGO)) entity.Solicodireticodigo = dr.GetString(iSOLICODIRETICODIGO);

            int iSOLICODIRETIFECHAREGISTRO = dr.GetOrdinal(this.SOLICODIRETIFECHAREGISTRO);
            if (!dr.IsDBNull(iSOLICODIRETIFECHAREGISTRO)) entity.Solicodiretifecharegistro = dr.GetDateTime(iSOLICODIRETIFECHAREGISTRO);

            int iSOLICODIRETIDESCRIPCION = dr.GetOrdinal(this.SOLICODIRETIDESCRIPCION);
            if (!dr.IsDBNull(iSOLICODIRETIDESCRIPCION)) entity.Solicodiretidescripcion = dr.GetString(iSOLICODIRETIDESCRIPCION);

            int iSOLICODIRETIDETALLEAMPLIO = dr.GetOrdinal(this.SOLICODIRETIDETALLEAMPLIO);
            if (!dr.IsDBNull(iSOLICODIRETIDETALLEAMPLIO)) entity.Solicodiretidetalleamplio = dr.GetString(iSOLICODIRETIDETALLEAMPLIO);


            int iSOLICODIRETIFECHAINICIO = dr.GetOrdinal(this.SOLICODIRETIFECHAINICIO);
            if (!dr.IsDBNull(iSOLICODIRETIFECHAINICIO)) entity.Solicodiretifechainicio = dr.GetDateTime(iSOLICODIRETIFECHAINICIO);

             int iSOLICODIRETIFECHAFIN = dr.GetOrdinal(this.SOLICODIRETIFECHAFIN);
            if (!dr.IsDBNull(iSOLICODIRETIFECHAFIN)) entity.Solicodiretifechafin = dr.GetDateTime(iSOLICODIRETIFECHAFIN);

            int iSOLICODIRETIOBSERVACION = dr.GetOrdinal(this.SOLICODIRETIOBSERVACION);
            if (!dr.IsDBNull(iSOLICODIRETIOBSERVACION)) entity.Solicodiretiobservacion = dr.GetString(iSOLICODIRETIOBSERVACION);


            int iSOLICODIRETIESTADO = dr.GetOrdinal(this.SOLICODIRETIESTADO);
            if (!dr.IsDBNull(iSOLICODIRETIESTADO)) entity.Solicodiretiestado = dr.GetString(iSOLICODIRETIESTADO);

            int iCOESUSERNAME = dr.GetOrdinal(this.COESUSERNAME);
            if (!dr.IsDBNull(iCOESUSERNAME)) entity.Coesusername = dr.GetString(iCOESUSERNAME);
            
            int iSOLICODIRETIFECINS = dr.GetOrdinal(this.SOLICODIRETIFECINS);
            if (!dr.IsDBNull(iSOLICODIRETIFECINS)) entity.Solicodiretifecins = dr.GetDateTime(iSOLICODIRETIFECINS);


            int iSOLICODIRETIFECACT = dr.GetOrdinal(this.SOLICODIRETIFECACT);
            if (!dr.IsDBNull(iSOLICODIRETIFECACT)) entity.Solicodiretifecact = dr.GetDateTime(iSOLICODIRETIFECACT);


            int iSOLICODIRETIFECHASOLBAJA = dr.GetOrdinal(this.SOLICODIRETIFECHASOLBAJA);
            if (!dr.IsDBNull(iSOLICODIRETIFECHASOLBAJA)) entity.Solicodiretifechasolbaja = dr.GetDateTime(iSOLICODIRETIFECHASOLBAJA);


            int iSOLICODIRETIFECHADEBAJA = dr.GetOrdinal(this.SOLICODIRETIFECHADEBAJA);
            if (!dr.IsDBNull(iSOLICODIRETIFECHADEBAJA)) entity.Solicodiretifechadebaja = dr.GetDateTime(iSOLICODIRETIFECHADEBAJA);

            int iEMPRNOMB = dr.GetOrdinal(this.EMPRNOMB);
            if (!dr.IsDBNull(iEMPRNOMB)) entity.Emprnombre = dr.GetString(iEMPRNOMB);

            int iBARRNOMBBARRTRAN = dr.GetOrdinal(this.BARRNOMBBARRTRAN);
            if (!dr.IsDBNull(iBARRNOMBBARRTRAN)) entity.Barrnombbarrtran = dr.GetString(iBARRNOMBBARRTRAN);

      
            
            int iTIPOCONTNOMBRE = dr.GetOrdinal(this.TIPOCONTNOMBRE);
            if (!dr.IsDBNull(iTIPOCONTNOMBRE)) entity.Tipocontnombre = dr.GetString(iTIPOCONTNOMBRE);

                  
            int iTIPOUSUANOMBRE = dr.GetOrdinal(this.TIPOUSUANOMBRE);
            if (!dr.IsDBNull(iTIPOUSUANOMBRE)) entity.Tipousuanombre = dr.GetString(iTIPOUSUANOMBRE);
           
            int iCLINOMBRE = dr.GetOrdinal(this.CLINOMBRE);
            if (!dr.IsDBNull(iCLINOMBRE)) entity.Clinombre = dr.GetString(iCLINOMBRE);

            return entity;
        }

        

        #region Mapeo de Campos
        public string SOLICODIRETICODI = "CORESOCODI";
        public string EMPRCODI = "GENEMPRCODI";
        public string BARRCODI = "BARRCODI";
        public string USUACODI = "SEINUSERNAME";
        public string TIPOCONTCODI = "TIPCONCODI";
        public string TIPOUSUACODI = "TIPUSUCODI";
        public string CLICODI = "CLIEMPRCODI";
        public string SOLICODIRETICODIGO = "CORESOCODIGO";
        public string SOLICODIRETIFECHAREGISTRO = "CORESOFECHAREGISTRO";
        public string SOLICODIRETIDESCRIPCION = "CORESODESCRIPCION";
        public string SOLICODIRETIDETALLEAMPLIO = "CORESODETALLE";
        public string SOLICODIRETIFECHAINICIO = "CORESOFECHAINICIO";
        public string SOLICODIRETIFECHAFIN = "CORESOFECHAFIN";
        public string SOLICODIRETIOBSERVACION = "CORESOOBSERVACION";
        public string SOLICODIRETIESTADO = "CORESOESTADO";
        public string COESUSERNAME = "COESUSERNAME";
        public string SOLICODIRETIFECINS = "CORESOFECINS";
        public string SOLICODIRETIFECACT = "CORESOFECACT";
        public string SOLICODIRETIFECHASOLBAJA = "CORESOFECHASOLICITUDBAJA";
        public string SOLICODIRETIFECHADEBAJA = "CORESOFECHADEBAJA";

        public string EMPRNOMB = "EMPRNOMB";
        public string BARRNOMBBARRTRAN = "BARRBARRATRANSFERENCIA";
        public string TIPOCONTNOMBRE = "TIPCONNOMBRE";
        public string TIPOUSUANOMBRE = "TIPUSUNOMBRE";
        public string CLINOMBRE = "CLINOMBRE";


        //Para la vista
        public string TRETCODIGO = "TRETCODIGO";
        public string TRETCORESOCORESCCODI = "TRETCORESOCORESCCODI";
        public string TRETTABLA = "TRETTABLA";
        public string FECHAINICIO = "FECHAINICIO";
        public string FECHAFIN = "FECHAFIN";

        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }

        public string SqlObtenerPorCodigoRetiroCodigo
        {
            get { return base.GetSqlXml("GetBySoliCodireticodigo"); }
        }
    }
}
