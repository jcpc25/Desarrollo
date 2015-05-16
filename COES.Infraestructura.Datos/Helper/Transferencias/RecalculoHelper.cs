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
   public class RecalculoHelper: HelperBase
    {
       public RecalculoHelper() : base(Consultas.RecalculoSql)
       {        }
       
       public RecalculoDTO Create(IDataReader dr)
       {
            RecalculoDTO entity = new RecalculoDTO();

            int iRecacodi = dr.GetOrdinal(this.Recacodi);
            if (!dr.IsDBNull(iRecacodi)) entity.Recacodi = dr.GetInt32(iRecacodi);

            int iRecapericodi = dr.GetOrdinal(this.Recapericodi);
            if (!dr.IsDBNull(iRecapericodi)) entity.Recapericodi = dr.GetInt32(iRecapericodi);

            int iRecafecini = dr.GetOrdinal(this.Recafecini);
            if (!dr.IsDBNull(iRecafecini)) entity.Recafecini = dr.GetDateTime(iRecafecini);

            int iRecafecfin = dr.GetOrdinal(this.Recafecfin);
            if (!dr.IsDBNull(iRecafecfin)) entity.Recafecfin = dr.GetDateTime(iRecafecfin);

            int iRecadesc = dr.GetOrdinal(this.Recadesc);
            if (!dr.IsDBNull(iRecadesc)) entity.Recadesc = dr.GetString(iRecadesc);

            int iRecausername = dr.GetOrdinal(this.Recausername);
            if (!dr.IsDBNull(iRecausername)) entity.Recausername = dr.GetString(iRecausername);

            int iRecafecins = dr.GetOrdinal(this.Recafecins);
            if (!dr.IsDBNull(iRecafecins)) entity.Recafecins = dr.GetDateTime(iRecafecins);

            int iRecafecact = dr.GetOrdinal(this.Recafecact);
            if (!dr.IsDBNull(iRecafecact)) entity.Recafecact = dr.GetDateTime(iRecafecact);

           


          


            return entity;
        }

        #region Mapeo de Campos

        public string Recacodi = "RECACODI";
        public string Recapericodi = "PERICODI"; 
        public string Recafecini = "RECAFECINICIO";
        public string Recafecfin = "RECAFECFINAL";
        public string Recadesc = "RECADESCRIPCION";
        public string Recausername = "RECAUSERNAME";
        public string Recafecins = "RECAFECINS";
        public string Recafecact = "RECAFECACT";
       
      
      

        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }

        public string SqlGetUltimaVersion
        {
            get { return base.GetSqlXml("GetUltimaVersion"); }
        }
    }
}
