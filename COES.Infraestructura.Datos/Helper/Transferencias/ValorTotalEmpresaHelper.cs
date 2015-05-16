﻿using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Infraestructura.Datos.Helper.Transferencias
{
    public class ValorTotalEmpresaHelper : HelperBase
    {
        public ValorTotalEmpresaHelper() : base(Consultas.ValorTotalEmpresaSql)
        {
        }

        public ValorTotalEmpresaDTO Create(IDataReader dr)
        {
            ValorTotalEmpresaDTO entity = new ValorTotalEmpresaDTO();

            int iVALTOTAEMPCODI = dr.GetOrdinal(this.VALTOTAEMPCODI);
            if (!dr.IsDBNull(iVALTOTAEMPCODI)) entity.VALTOTAEMPCODI = dr.GetInt32(iVALTOTAEMPCODI);

            int iPERICODI = dr.GetOrdinal(this.PERICODI);
            if (!dr.IsDBNull(iPERICODI)) entity.PERICODI = dr.GetInt32(iPERICODI);

            int iEMPCODI = dr.GetOrdinal(this.EMPCODI);
            if (!dr.IsDBNull(iEMPCODI)) entity.EMPCODI = dr.GetInt32(iEMPCODI);

            int iVALTOTAEMPVERSION = dr.GetOrdinal(this.VALTOTAEMPVERSION);
            if (!dr.IsDBNull(iVALTOTAEMPVERSION)) entity.VALTOTAEMPVERSION = dr.GetInt32(iVALTOTAEMPVERSION);

            int iVALTOTAEMPTOTAL = dr.GetOrdinal(this.VALTOTAEMPTOTAL);
            if (!dr.IsDBNull(iVALTOTAEMPTOTAL)) entity.VALTOTAEMPTOTAL = dr.GetDecimal(iVALTOTAEMPTOTAL);

            int iVOTEMUSERNAME = dr.GetOrdinal(this.VOTEMUSERNAME);
            if (!dr.IsDBNull(iVOTEMUSERNAME)) entity.VOTEMUSERNAME = dr.GetString(iVOTEMUSERNAME);

            int iVALTOTAEMPFECINS = dr.GetOrdinal(this.VALTOTAEMPFECINS);
            if (!dr.IsDBNull(iVALTOTAEMPFECINS)) entity.VALTOTAEMPFECINS = dr.GetDateTime(iVALTOTAEMPFECINS);

            return entity;
        }

        #region Mapeo de Campos
           
         

    
        public string VALTOTAEMPCODI = "VTOTEMCODI";
        public string EMPCODI = "EMPRCODI";
        public string VALTOTAEMPVERSION = "VTOTEMVERSION";
        public string VALTOTAEMPTOTAL = "VTOTEMTOTAL";
        public string PERICODI = "PERICODI";
        public string VALTOTAEMPFECINS = "VTOTEMFECINS";
        public string TOTAL = "TOTAL";

        public string VOTEMUSERNAME = "VTOTEMUSERNAME";
          

        

        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }


        public string SqlGetEmpresaPositiva
        {
            get { return base.GetSqlXml("GetEmpresaPositivaByCriteria"); }
        }

        public string SqlGetEmpresaNegativa
        {
            get { return base.GetSqlXml("GetEmpresaNegativaByCriteria"); }
        }

    }
}
