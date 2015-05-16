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
    public class ValorTransferenciaEmpresaHelper : HelperBase
    {
        public ValorTransferenciaEmpresaHelper() : base(Consultas.ValorTransferenciaEmpresaSql)
        {
        }

        public ValorTransferenciaEmpresaDTO Create(IDataReader dr)
        {
            ValorTransferenciaEmpresaDTO entity = new ValorTransferenciaEmpresaDTO();

            int iVALTRANEMPCODI = dr.GetOrdinal(this.VALTRANEMPCODI);
            if (!dr.IsDBNull(iVALTRANEMPCODI)) entity.Valtranempcodi = dr.GetInt32(iVALTRANEMPCODI);

            int iPERICODI = dr.GetOrdinal(this.PERICODI);
            if (!dr.IsDBNull(iPERICODI)) entity.Pericodi = dr.GetInt32(iPERICODI);

            int iEMPCODI = dr.GetOrdinal(this.EMPCODI);
            if (!dr.IsDBNull(iEMPCODI)) entity.Empcodi = dr.GetInt32(iEMPCODI);

            int iVALTRANEMPVERSION = dr.GetOrdinal(this.VALTRANEMPVERSION);
            if (!dr.IsDBNull(iVALTRANEMPVERSION)) entity.Valtranempversion = dr.GetInt32(iVALTRANEMPVERSION);

            int iVALTRANEMPTOTAL = dr.GetOrdinal(this.VALTRANEMPTOTAL);
            if (!dr.IsDBNull(iVALTRANEMPTOTAL)) entity.Valtranemptotal = dr.GetDecimal(iVALTRANEMPTOTAL);

            int iVTRANEUSERNAME = dr.GetOrdinal(this.VTRANEUSERNAME);
            if (!dr.IsDBNull(iVTRANEUSERNAME)) entity.Vtraneusername = dr.GetString(iVTRANEUSERNAME);
 
            int iVALTRANEMPFECINS = dr.GetOrdinal(this.VALTRANEMPFECINS);
            if (!dr.IsDBNull(iVALTRANEMPFECINS)) entity.Valtranempfrecins = dr.GetDateTime(iVALTRANEMPFECINS);

            return entity;
        }

        #region Mapeo de Campos


            public string VALTRANEMPCODI ="VTRANECODI";
            public string PERICODI = "PERICODI";
            public string EMPCODI = "EMPRCODI";
            public string VALTRANEMPVERSION = "VTRANEVERSION";
            public string VALTRANEMPTOTAL = "VTRANETOTAL";
            public string VTRANEUSERNAME = "VTRANEUSERNAME";
            public string VALTRANEMPFECINS = "VTRANEFECINS";
        

        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }
    }
}
