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
   public  class SaldoEmpresaHelper : HelperBase
    {
       public SaldoEmpresaHelper() : base(Consultas.SaldoEmpresaSql)
       {        }

       public SaldoEmpresaDTO Create(IDataReader dr)
       {
           SaldoEmpresaDTO entity = new SaldoEmpresaDTO();

           int iSALEMPCODI = dr.GetOrdinal(this.SALEMPCODI);
           if (!dr.IsDBNull(iSALEMPCODI)) entity.SALEMPCODI = dr.GetInt32(iSALEMPCODI);

           int iPERICODI = dr.GetOrdinal(this.PERICODI);
           if (!dr.IsDBNull(iPERICODI)) entity.PERICODI = dr.GetInt32(iPERICODI);

           int iEMPCODI = dr.GetOrdinal(this.EMPCODI);
           if (!dr.IsDBNull(iEMPCODI)) entity.EMPCODI = dr.GetInt32(iEMPCODI);

           int iSALEMPVERSION = dr.GetOrdinal(this.SALEMPVERSION);
           if (!dr.IsDBNull(iSALEMPVERSION)) entity.SALEMPVERSION = dr.GetInt32(iSALEMPVERSION);

           int iSALEMPSALDO = dr.GetOrdinal(this.SALEMPSALDO);
           if (!dr.IsDBNull(iSALEMPSALDO)) entity.SALEMPSALDO = dr.GetDecimal(iSALEMPSALDO);

           int iSALEMPUSERNAME = dr.GetOrdinal(this.SALEMPUSERNAME);
           if (!dr.IsDBNull(iSALEMPUSERNAME)) entity.SALEMPUSERNAME = dr.GetString(iSALEMPUSERNAME);

           int iSALEMPFECINS = dr.GetOrdinal(this.SALEMPFECINS);
           if (!dr.IsDBNull(iSALEMPFECINS)) entity.SALEMPFECINS = dr.GetDateTime(iSALEMPFECINS);

           return entity;
       }

       #region Mapeo de Campos


       public string SALEMPCODI = "SALEMPCODI";
       public string PERICODI = "PERICODI";
       public string EMPCODI = "EMPRCODI";
       public string SALEMPVERSION = "SALEMPVERSION";
       public string SALEMPSALDO = "SALEMPSALDO";
       public string SALEMPUSERNAME = "SALEMPUSERNAME";
       public string SALEMPFECINS = "SALEMPFECINS";




       #endregion

       public string SqlCodigoGenerado
       {
           get { return base.GetSqlXml("GetMaxId"); }
       }
    }
}
