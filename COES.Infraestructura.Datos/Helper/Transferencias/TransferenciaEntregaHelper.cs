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
    public class TransferenciaEntregaHelper : HelperBase
    {
        public TransferenciaEntregaHelper() : base(Consultas.TransferenciaEntregaSql)
        {
        }

        public TransferenciaEntregaDTO Create(IDataReader dr)
        {
            TransferenciaEntregaDTO entity = new TransferenciaEntregaDTO();

            int iTRANENTRCODI = dr.GetOrdinal(this.TRANENTRCODI);
            if (!dr.IsDBNull(iTRANENTRCODI)) entity.Tranentrcodi = dr.GetInt32(iTRANENTRCODI);

            int iEMPRCODI = dr.GetOrdinal(this.EMPRCODI);
            if (!dr.IsDBNull(iEMPRCODI)) entity.Emprcodi = dr.GetInt32(iEMPRCODI);

            int iBARRCODI = dr.GetOrdinal(this.BARRCODI);
            if (!dr.IsDBNull(iBARRCODI)) entity.Barrcodi = dr.GetInt32(iBARRCODI);

            int iCODIENTRCODIGO = dr.GetOrdinal(this.CODIENTRCODIGO);
            if (!dr.IsDBNull(iCODIENTRCODIGO)) entity.Codientrcodigo = dr.GetString(iCODIENTRCODIGO);

            int iCENTGENECODI = dr.GetOrdinal(this.CENTGENECODI);
            if (!dr.IsDBNull(iCENTGENECODI)) entity.Centgenecodi = dr.GetInt32(iCENTGENECODI);

            int iPERICODI = dr.GetOrdinal(this.PERICODI);
            if (!dr.IsDBNull(iPERICODI)) entity.Pericodi = dr.GetInt32(iPERICODI);

            int iTRANENTRVERSION = dr.GetOrdinal(this.TRANENTRVERSION);
            if (!dr.IsDBNull(iTRANENTRVERSION)) entity.Tranentrversion = dr.GetInt32(iTRANENTRVERSION);

            int iTRANENTRTIPOINFORMACION = dr.GetOrdinal(this.TRANENTRTIPOINFORMACION);
            if (!dr.IsDBNull(iTRANENTRTIPOINFORMACION)) entity.Tranentripoinformacion = dr.GetString(iTRANENTRTIPOINFORMACION);

            int iTRANENTRESTADO = dr.GetOrdinal(this.TRANENTRESTADO);
            if (!dr.IsDBNull(iTRANENTRESTADO)) entity.Tranentrestado = dr.GetString(iTRANENTRESTADO);

            int iTRANENTRFECINS = dr.GetOrdinal(this.TRANENTRFECINS);
            if (!dr.IsDBNull(iTRANENTRFECINS)) entity.Tranentrfecins = dr.GetDateTime(iTRANENTRFECINS);

            int iTRANENTRFECACT = dr.GetOrdinal(this.TRANENTRFECACT);
            if (!dr.IsDBNull(iTRANENTRFECACT)) entity.Tranentrfecact = dr.GetDateTime(iTRANENTRFECACT);

            return entity;
        }

        #region Mapeo de Campos

        public string TRANENTRCODI = "TENTCODI";

        public string CODENTCODI = "CODENTCODI";

        public string BARRCODI = "BARRCODI";
        public string PERICODI = "PERICODI";
        public string EMPRCODI = "EMPRCODI";
        public string CENTGENECODI = "EQUICODI";
        public string CODIENTRCODIGO = "TENTCODIGO";     
        public string TRANENTRVERSION = "TENTVERSION";
        public string TRANENTRTIPOINFORMACION = "TENTTIPOINFORMACION";
        public string TRANENTRESTADO = "TENTESTADO";

        public string TENTUSERNAME = "TENTUSERNAME";

        public string TRANENTRFECINS = "TRANENTRFECINS";
        public string TRANENTRFECACT = "TRANENTRFECACT";



        public string EMPRNOMBRE = "EMPRNOMBRE";
        public string CENTGENENOMBRE = "CENTGENENOMBRE";
        public string BARRNOMBRE = "BARRNOMBRE";
        public string TOTAL = "TOTAL";
 

        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }

    }
}
