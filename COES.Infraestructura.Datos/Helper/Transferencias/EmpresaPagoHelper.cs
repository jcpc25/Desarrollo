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
    public class EmpresaPagoHelper : HelperBase
    {
        public EmpresaPagoHelper() : base(Consultas.EmpresaPagoSql)
        {
        }

        public EmpresaPagoDTO Create(IDataReader dr)
        {
            EmpresaPagoDTO entity = new EmpresaPagoDTO();

            int iEMPPAGOCODI = dr.GetOrdinal(this.EMPPAGOCODI);
            if (!dr.IsDBNull(iEMPPAGOCODI)) entity.EMPPAGOCODI = dr.GetInt32(iEMPPAGOCODI);


            int iVALTOTAEMPCODI = dr.GetOrdinal(this.VALTOTAEMPCODI);
            if (!dr.IsDBNull(iVALTOTAEMPCODI)) entity.VALTOTAEMPCODI = dr.GetInt32(iVALTOTAEMPCODI);


            int iPERICODI = dr.GetOrdinal(this.PERICODI);
            if (!dr.IsDBNull(iPERICODI)) entity.PERICODI = dr.GetInt32(iPERICODI);


            int iEMPCODI = dr.GetOrdinal(this.EMPCODI);
            if (!dr.IsDBNull(iEMPCODI)) entity.EMPCODI = dr.GetInt32(iEMPCODI);

          
            int iVALTOTAEMPVERSION = dr.GetOrdinal(this.VALTOTAEMPVERSION);
            if (!dr.IsDBNull(iVALTOTAEMPVERSION)) entity.VALTOTAEMPVERSION = dr.GetInt32(iVALTOTAEMPVERSION);


            int iEMPPAGOCODEMPPAGO = dr.GetOrdinal(this.EMPPAGOCODEMPPAGO);
            if (!dr.IsDBNull(iEMPPAGOCODEMPPAGO)) entity.EMPPAGOCODEMPPAGO = dr.GetInt32(iEMPPAGOCODEMPPAGO);

            int iEMPPAGOMONTO = dr.GetOrdinal(this.EMPPAGOMONTO);
            if (!dr.IsDBNull(iEMPPAGOMONTO)) entity.EMPPAGOMONTO = dr.GetDecimal(iEMPPAGOMONTO);

            int iEMPPAGUSERNAME = dr.GetOrdinal(this.EMPPAGUSERNAME);
            if (!dr.IsDBNull(iEMPPAGOMONTO)) entity.EMPPAGUSERNAME = dr.GetString(iEMPPAGUSERNAME);


            int iEMPPAGOFECINS = dr.GetOrdinal(this.EMPPAGOFECINS);
            if (!dr.IsDBNull(iEMPPAGOFECINS)) entity.EMPPAGOFECINS = dr.GetDateTime(iEMPPAGOFECINS);

           
            return entity;

        }


        #region Mapeo de Campos


        public string EMPPAGOCODI = "EMPPAGCODI";  
        public string VALTOTAEMPCODI = "VTOTEMPCODI";
        public string PERICODI = "PERICODI"; 
        public string EMPCODI = "EMPRCODI";
        public string VALTOTAEMPVERSION = "EMPPAGVERSION";             
        public string EMPPAGOCODEMPPAGO = "EMPPAGCODEMPPAGO";
        public string EMPPAGOMONTO = "EMPPAGMONTO";
        public string EMPPAGUSERNAME = "EMPPAGUSERNAME";   
        public string EMPPAGOFECINS = "EMPPAGOFECINS";


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
