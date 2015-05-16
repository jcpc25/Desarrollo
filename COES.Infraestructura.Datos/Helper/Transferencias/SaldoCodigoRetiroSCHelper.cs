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
   public class SaldoCodigoRetiroSCHelper : HelperBase
    {
       public SaldoCodigoRetiroSCHelper()
           : base(Consultas.SaldoCodigoRetiroSCSql)
       {        }

       public SaldoCodigoRetiroscDTO Create(IDataReader dr)
       {
           SaldoCodigoRetiroscDTO entity = new SaldoCodigoRetiroscDTO();

           int iSALEMPCODI = dr.GetOrdinal(this.SALRSCCODI);
           if (!dr.IsDBNull(iSALEMPCODI)) entity.SALRSCCODI = dr.GetInt32(iSALEMPCODI);

           int iPERICODI = dr.GetOrdinal(this.PERICODI);
           if (!dr.IsDBNull(iPERICODI)) entity.PERICODI = dr.GetInt32(iPERICODI);

           int iEMPCODI = dr.GetOrdinal(this.EMPRCODI);
           if (!dr.IsDBNull(iEMPCODI)) entity.EMPRCODI = dr.GetInt32(iEMPCODI);

           int iSALEMPVERSION = dr.GetOrdinal(this.SALRSCVERSION);
           if (!dr.IsDBNull(iSALEMPVERSION)) entity.SALRSCVERSION = dr.GetInt32(iSALEMPVERSION);

           int iSALEMPSALDO = dr.GetOrdinal(this.SALRSCSALDO);
           if (!dr.IsDBNull(iSALEMPSALDO)) entity.SALRSCSALDO = dr.GetDecimal(iSALEMPSALDO);

           int iSALEMPUSERNAME = dr.GetOrdinal(this.SALRSCUSERNAME);
           if (!dr.IsDBNull(iSALEMPUSERNAME)) entity.SALRSCUSERNAME = dr.GetString(iSALEMPUSERNAME);

           int iSALEMPFECINS = dr.GetOrdinal(this.SALRSCFECINS);
           if (!dr.IsDBNull(iSALEMPFECINS)) entity.SALRSCFECINS = dr.GetDateTime(iSALEMPFECINS);

           return entity;
       }

       #region Mapeo de Campos


       public string SALRSCCODI = "SALRSCCODI";
       public string PERICODI = "PERICODI";
       public string EMPRCODI = "EMPRCODI";
       public string SALRSCVERSION = "SALRSCVERSION";
       public string SALRSCSALDO = "SALRSCSALDO";
       public string SALRSCUSERNAME = "SALRSCUSERNAME";
       public string SALRSCFECINS = "SALRSCFECINS";




       #endregion

       public string SqlCodigoGenerado
       {
           get { return base.GetSqlXml("GetMaxId"); }
       }
    }
}