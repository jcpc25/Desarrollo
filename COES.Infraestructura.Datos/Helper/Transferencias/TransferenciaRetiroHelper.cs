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
    public class TransferenciaRetiroHelper : HelperBase
    {
        public TransferenciaRetiroHelper() : base(Consultas.TransferenciaRetiroSql)
        {
        }

        public TransferenciaRetiroDTO Create(IDataReader dr)
        {
            TransferenciaRetiroDTO entity = new TransferenciaRetiroDTO();

            int iTRANRETICODI = dr.GetOrdinal(this.TRANRETICODI);
            if (!dr.IsDBNull(iTRANRETICODI)) entity.Tranreticodi = dr.GetInt32(iTRANRETICODI);

            int iPERICODI = dr.GetOrdinal(this.PERICODI);
            if (!dr.IsDBNull(iPERICODI)) entity.Pericodi = dr.GetInt32(iPERICODI);

            int iBARRCODI = dr.GetOrdinal(this.BARRCODI);
            if (!dr.IsDBNull(iBARRCODI)) entity.Barrcodi = dr.GetInt32(iBARRCODI);

            int iEMPRCODI = dr.GetOrdinal(this.EMPRCODI);
            if (!dr.IsDBNull(iEMPRCODI)) entity.Emprcodi = dr.GetInt32(iEMPRCODI);

            int iCLICODI = dr.GetOrdinal(this.CLICODI);
            if (!dr.IsDBNull(iCLICODI)) entity.Clicodi = dr.GetInt32(iCLICODI);

            int iTRETTABLA = dr.GetOrdinal(this.TRETTABLA);
            if (!dr.IsDBNull(iTRETTABLA)) entity.Trettabla = dr.GetString(iTRETTABLA);

            int iTRETCORESOCORESCCODI = dr.GetOrdinal(this.TRETCORESOCORESCCODI);
            if (!dr.IsDBNull(iTRETCORESOCORESCCODI)) entity.TRetCoresoCorescCodi = dr.GetInt32(iTRETCORESOCORESCCODI);

            int iSOLICODIRETICODIGO = dr.GetOrdinal(this.SOLICODIRETICODIGO);
            if (!dr.IsDBNull(iSOLICODIRETICODIGO)) entity.Solicodireticodigo = dr.GetString(iSOLICODIRETICODIGO);

            int iTRANRETIVERSION = dr.GetOrdinal(this.TRANRETIVERSION);
            if (!dr.IsDBNull(iTRANRETIVERSION)) entity.Tranretiversion = dr.GetInt32(iTRANRETIVERSION);

            int iTRANRETITIPOINFORMACION = dr.GetOrdinal(this.TRANRETITIPOINFORMACION);
            if (!dr.IsDBNull(iTRANRETITIPOINFORMACION)) entity.Tranretitipoinformacion = dr.GetString(iTRANRETITIPOINFORMACION);

            int iTRANRETIESTADO = dr.GetOrdinal(this.TRANRETIESTADO);
            if (!dr.IsDBNull(iTRANRETIESTADO)) entity.Tranretiestado = dr.GetString(iTRANRETIESTADO);

            int iTRETUSERNAME = dr.GetOrdinal(this.TRETUSERNAME);
            if (!dr.IsDBNull(iTRETUSERNAME)) entity.Tretusername = dr.GetString(iTRETUSERNAME);

            int iTRANRETIFECINS = dr.GetOrdinal(this.TRANRETIFECINS);
            if (!dr.IsDBNull(iTRANRETIFECINS)) entity.Tranretifecins = dr.GetDateTime(iTRANRETIFECINS);

            int iTRANRETIFECACT = dr.GetOrdinal(this.TRANRETIFECACT);
            if (!dr.IsDBNull(iTRANRETIFECACT)) entity.Tranretifecact = dr.GetDateTime(iTRANRETIFECACT);

            return entity;
        }

        #region Mapeo de Campos

            public string TRANRETICODI = "TRETICODI";
            public string PERICODI = "PERICODI";
            public string BARRCODI = "BARRCODI";
            public string EMPRCODI = "GENEMPRCODI";
            public string CLICODI = "CLIEMPRCODI";
            public string TRETTABLA = "TRETTABLA";
            public string TRETCORESOCORESCCODI = "TRETCORESOCORESCCODI";
            public string SOLICODIRETICODIGO = "TRETCODIGO";
            public string TRANRETIVERSION = "TRETVERSION";
            public string TRANRETITIPOINFORMACION = "TRETTIPOINFORMACION";
            public string TRANRETIESTADO = "TRETESTADO";
            public string TRETUSERNAME = "TRETUSERNAME";
            public string TRANRETIFECINS = "TRETFECINS";
            public string TRANRETIFECACT = "TRETFECACT";

            public string EMPRNOMBRE = "EMPRNOMBRE";
            public string CLINOMBRE = "CLINOMBRE";
            public string BARRNOMBRE = "BARRNOMBRE";
            public string TOTAL = "TOTAL";

  
        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }

      

    }
}
