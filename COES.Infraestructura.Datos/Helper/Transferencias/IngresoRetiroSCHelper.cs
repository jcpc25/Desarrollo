using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System.Data;

namespace COES.Infraestructura.Datos.Helper.Transferencias
{
   public class IngresoRetiroSCHelper: HelperBase
    {
        public IngresoRetiroSCHelper() : base(Consultas.IngresoRetiroSCSql)
        {
        }

        public IngresoRetiroSCDTO Create(IDataReader dr)
        {
            IngresoRetiroSCDTO entity = new IngresoRetiroSCDTO();

            int iPeriCodi = dr.GetOrdinal(this.PeriCodi);
            if (!dr.IsDBNull(iPeriCodi)) entity.PeriCodi = dr.GetInt32(iPeriCodi);

            int iIngrscCodi = dr.GetOrdinal(this.Ingrsccodi);
            if (!dr.IsDBNull(iIngrscCodi)) entity.Ingrsccodi = dr.GetInt32(iIngrscCodi);

            int iIngrscVers = dr.GetOrdinal(this.Ingrscversion);
               if (!dr.IsDBNull(iIngrscVers)) entity.Ingrscversion = dr.GetInt32(iIngrscVers);


            int iEmprCodi = dr.GetOrdinal(this.EmprCodi);
            if (!dr.IsDBNull(iEmprCodi)) entity.EmprCodi = dr.GetInt32(iEmprCodi);


            int iIngrscImporte = dr.GetOrdinal(this.Ingrscimporte);
            if (!dr.IsDBNull(iIngrscImporte)) entity.Ingrscimporte = dr.GetDecimal(iIngrscImporte);

            int iIngrscUsername = dr.GetOrdinal(this.Ingrscusername);
            if (!dr.IsDBNull(iIngrscUsername)) entity.Ingrscusername = dr.GetString(iIngrscUsername);

            int iIngrscFecins = dr.GetOrdinal(this.Ingrscfecins);
            if (!dr.IsDBNull(iIngrscFecins)) entity.Ingrscfecins = dr.GetDateTime(iIngrscFecins);

            int iIngrscFecact = dr.GetOrdinal(this.Ingrscfecact);
            if (!dr.IsDBNull(iIngrscFecact)) entity.Ingrscfecact = dr.GetDateTime(iIngrscFecact);

            int iEmprnombre = dr.GetOrdinal(this.EmprNombre);
            if (!dr.IsDBNull(iEmprnombre)) entity.EmprNombre = dr.GetString(iEmprnombre);

            int iPerinombre = dr.GetOrdinal(this.PeriNombre);
            if (!dr.IsDBNull(iPerinombre)) entity.PeriNombre = dr.GetString(iPerinombre);

            int iTotal = dr.GetOrdinal(this.Total);
            if (!dr.IsDBNull(iTotal)) entity.Total = dr.GetDecimal(iTotal);

            return entity;
        }

        #region Mapeo de Campos

        public string Ingrsccodi = "INGSCCODI";
        public string PeriCodi = "PERICODI";
        public string EmprCodi = "EMPRCODI";
        public string Ingrscversion = "INGRSCVERSION";
        public string Ingrscimporte = "INGRSCIMPORTE";
        public string Ingrscusername = "INGRSCUSERNAME";
        public string Ingrscfecins = "INGRSCFECINS";
        public string Ingrscfecact = "INGRSCFECACT";
        public string EmprNombre = "NOMBEMPRESA";
        public string PeriNombre = "NOMBPERIODO";

        public string Total = "TOTAL";

        //public string EmprNombre = "EMPRNOMBRE";
       

        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }

        public string SqlGetByCodigo
        {
            get { return base.GetSqlXml("GetByCodigo"); }

        }
    }
}
