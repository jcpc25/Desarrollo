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
    /// Clase que contiene el mapeo de la tabla TRN_CODIGO_RETIRO_SINCONTRATO
    /// </summary>
    public class CodigoRetiroSinContratoHelper : HelperBase
    {
        public CodigoRetiroSinContratoHelper()   : base(Consultas.CodigoRetiroSinContratoSql)
        {
        }

        public CodigoRetiroSinContratoDTO Create(IDataReader dr)
        {
            CodigoRetiroSinContratoDTO entity = new CodigoRetiroSinContratoDTO();

            int iCODRETISINCONCODI = dr.GetOrdinal(this.CODRETISINCONCODI);
            if (!dr.IsDBNull(iCODRETISINCONCODI)) entity.Codretisinconcodi = dr.GetInt32(iCODRETISINCONCODI);

            int iCLICODI = dr.GetOrdinal(this.CLICODI);
            if (!dr.IsDBNull(iCLICODI)) entity.Clicodi = dr.GetInt32(iCLICODI);

            int iBARRCODI = dr.GetOrdinal(this.BARRCODI);
            if (!dr.IsDBNull(iBARRCODI)) entity.Barrcodi = dr.GetInt32(iBARRCODI);

            int iCODRETISINCONCODIGO = dr.GetOrdinal(this.CODRETISINCONCODIGO);
            if (!dr.IsDBNull(iCODRETISINCONCODIGO)) entity.Codretisinconcodigo = dr.GetString(iCODRETISINCONCODIGO);


            int iCODRETISINCONIFECHAINICIO = dr.GetOrdinal(this.CODRETISINCONIFECHAINICIO);
            if (!dr.IsDBNull(iCODRETISINCONIFECHAINICIO)) entity.Codretisinconfechainicio = dr.GetDateTime(iCODRETISINCONIFECHAINICIO);

            int iCODRETISINCONFECHAFIN = dr.GetOrdinal(this.CODRETISINCONFECHAFIN);
            if (!dr.IsDBNull(iCODRETISINCONFECHAFIN)) entity.Codretisinconfechafin = dr.GetDateTime(iCODRETISINCONFECHAFIN);

            int iCODRETISINCONESTADO = dr.GetOrdinal(this.CODRETISINCONESTADO);
            if (!dr.IsDBNull(iCODRETISINCONESTADO)) entity.Codretisinconestado = dr.GetString(iCODRETISINCONESTADO);

            int iCODRETISINCONUSERNAME = dr.GetOrdinal(this.CODRETISINCONUSERNAME);
            if (!dr.IsDBNull(iCODRETISINCONUSERNAME)) entity.Codretisinconusername = dr.GetString(iCODRETISINCONUSERNAME);

            int iCODRETISINCONFECINS = dr.GetOrdinal(this.CODRETISINCONFECINS);
            if (!dr.IsDBNull(iCODRETISINCONFECINS)) entity.Codretisinconfecins = dr.GetDateTime(iCODRETISINCONFECINS);

            int iCODRETISINCONFECACT = dr.GetOrdinal(this.CODRETISINCONFECACT);
            if (!dr.IsDBNull(iCODRETISINCONFECACT)) entity.Codretisinconfecact = dr.GetDateTime(iCODRETISINCONFECACT);

            int iGENEMPRCODI = dr.GetOrdinal(this.GENEMPRCODI);
            if (!dr.IsDBNull(iGENEMPRCODI)) entity.Genemprcodi = dr.GetInt32(iGENEMPRCODI);

            

            int iCLINOMBRE = dr.GetOrdinal(this.CLINOMBRE);
            if (!dr.IsDBNull(iCLINOMBRE)) entity.Clinombre = dr.GetString(iCLINOMBRE);

            int iBARRNOMBBARRTRAN = dr.GetOrdinal(this.BARRNOMBBARRTRAN);
            if (!dr.IsDBNull(iBARRNOMBBARRTRAN)) entity.Barrnombbarrtran = dr.GetString(iBARRNOMBBARRTRAN);

            return entity;

        }

        #region Mapeo de Campos

        public string CODRETISINCONCODI = "CORESCCODI";
        public string CLICODI = "CLIEMPRCODI";
        public string BARRCODI = "BARRCODI";
        public string CODRETISINCONCODIGO = "CORESCCODIGO";       
        public string CODRETISINCONIFECHAINICIO = "CORESCFECHAINICIO";
        public string CODRETISINCONFECHAFIN = "CORESCFECHAFIN";     
        public string CODRETISINCONESTADO = "CORESCESTADO";
        public string CODRETISINCONUSERNAME = "CORESCUSERNAME";
        public string CODRETISINCONFECINS = "CORESCFECINS";
        public string CODRETISINCONFECACT = "CORESCFECACT";

        public string GENEMPRCODI = "GENEMPRCODI";
        
        public string CLINOMBRE = "EMPRNOMB";
        public string BARRNOMBBARRTRAN = "BARRBARRATRANSFERENCIA";

        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }

        public string SqlCodigoRetiroSinContratoCodigo
        {
            get { return base.GetSqlXml("GetByCodigoRetiroSinContratoCodigo"); }
        }

    }
}
