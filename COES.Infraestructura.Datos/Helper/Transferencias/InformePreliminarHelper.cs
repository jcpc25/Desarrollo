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
    public class InformePreliminarHelper : HelperBase
    {
        public InformePreliminarHelper() : base(Consultas.InformePreliminarSql)
        {
        }

        public InformePreliminarDTO Create(IDataReader dr)
        {
            InformePreliminarDTO entity = new InformePreliminarDTO();

            int iEMPRESA = dr.GetOrdinal(this.EMPRESA);
            if (!dr.IsDBNull(iEMPRESA)) entity.NombEmp = dr.GetString(iEMPRESA);

            int iVALORIZACION = dr.GetOrdinal(this.VALORIZACION);
            if (!dr.IsDBNull(iVALORIZACION)) entity.Valorizacion = (dr.GetDecimal(iVALORIZACION));

            int iCOMPENSACION = dr.GetOrdinal(this.COMPENSACION);
            if (!dr.IsDBNull(iCOMPENSACION)) entity.Compensacion = (dr.GetDecimal(iCOMPENSACION));

            int iIP = dr.GetOrdinal(this.IP);
            if (!dr.IsDBNull(iIP)) entity.IngresoPotencia = (dr.GetDecimal(iIP));

            int iSALDOTRANSMISION = dr.GetOrdinal(this.SALDOTRANSMISION);
            if (!dr.IsDBNull(iSALDOTRANSMISION)) entity.SaldoTransmision = (dr.GetDecimal(iSALDOTRANSMISION));

            int iVALTOTAEMPTOTAL = dr.GetOrdinal(this.VALTOTAEMPTOTAL);
            if (!dr.IsDBNull(iVALTOTAEMPTOTAL)) entity.ValorTotalEmp = (dr.GetDecimal(iVALTOTAEMPTOTAL));

            return entity;
        }

        #region Mapeo de Campos

        public string EMPRESA = "EMPRESA";
        public string VALORIZACION = "VALORIZACION";
        public string COMPENSACION = "COMPENSACION";
        public string IP = "IP";
        public string SALDOTRANSMISION = "SALDOTRANSMISION";
        public string VALTOTAEMPTOTAL = "VTOTEMTOTAL";
        public string PERICODI = "PERICODI";
        public string VALTOTAEMPVERSION = "VTOTEMVERSION";
        #endregion

        //public string SqlCodigoGenerado
        //{
        //    get { return base.GetSqlXml("GetMaxId"); }
        //}
    }
}

