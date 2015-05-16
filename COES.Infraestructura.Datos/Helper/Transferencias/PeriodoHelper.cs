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
    public class PeriodoHelper : HelperBase
    {
        public PeriodoHelper() : base(Consultas.PeriodoSql)
        {
        }

        public PeriodoDTO Create(IDataReader dr)
        {
            PeriodoDTO entity = new PeriodoDTO();

            int iPericodi = dr.GetOrdinal(this.Pericodi);
            if (!dr.IsDBNull(iPericodi)) entity.Pericodi = dr.GetInt32(iPericodi);

            int iPerinombre = dr.GetOrdinal(this.Perinombre);
            if (!dr.IsDBNull(iPerinombre)) entity.Perinombre = dr.GetString(iPerinombre);

            int iAniocodi = dr.GetOrdinal(this.Aniocodi);
            if (!dr.IsDBNull(iAniocodi)) entity.Aniocodi = dr.GetInt32(iAniocodi);

            int iMescodi = dr.GetOrdinal(this.Mescodi);
            if (!dr.IsDBNull(iMescodi)) entity.Mescodi = dr.GetInt32(iMescodi);

            int iPerifechavalorizacion = dr.GetOrdinal(this.Perifechavalorizacion);
            if (!dr.IsDBNull(iPerifechavalorizacion)) entity.Perifechavalorizacion = dr.GetDateTime(iPerifechavalorizacion);

            int iPerifechalimite = dr.GetOrdinal(this.Perifechalimite);
            if (!dr.IsDBNull(iPerifechalimite)) entity.Perifechalimite = dr.GetDateTime(iPerifechalimite);

            int iPerifechaobservacion = dr.GetOrdinal(this.Perifechaobservacion);
            if (!dr.IsDBNull(iPerifechaobservacion)) entity.Perifechaobservacion = dr.GetDateTime(iPerifechaobservacion);

            int iPeriestado = dr.GetOrdinal(this.Periestado);
            if (!dr.IsDBNull(iPeriestado)) entity.Periestado = dr.GetString(iPeriestado);

            int iPeriusername = dr.GetOrdinal(this.Periusername);
            if (!dr.IsDBNull(iPeriusername)) entity.Periusername = dr.GetString(iPeriusername);

            int iPerifecins = dr.GetOrdinal(this.Perifecins);
            if (!dr.IsDBNull(iPerifecins)) entity.Perifecins = dr.GetDateTime(iPerifecins);

            int iPerifecact = dr.GetOrdinal(this.Perifecact);
            if (!dr.IsDBNull(iPerifecact)) entity.Perifecact = dr.GetDateTime(iPerifecact);

            int iPerianiomes = dr.GetOrdinal(this.Perianiomes);
            if (!dr.IsDBNull(iPerianiomes)) entity.Perianiomes = dr.GetInt32(iPerianiomes);

            int iPerihoralimite = dr.GetOrdinal(this.Perihoralimite);
            if (!dr.IsDBNull(iPerihoralimite)) entity.Perihoralimite = dr.GetString(iPerihoralimite);

            return entity;
        }

        #region Mapeo de Campos

        public string Pericodi = "PERICODI";
        public string Perinombre = "PERINOMBRE";
        public string Aniocodi = "PERIANIO";
        public string Mescodi = "PERIMES";
        public string Perifechavalorizacion = "PERIFECHAVALORIZACION";
        public string Perifechalimite = "PERIFECHALIMITE";
        public string Perifechaobservacion = "PERIFECHAOBSERVACION";
        public string Periestado = "PERIESTADO";
        public string Periusername = "PERIUSERNAME";
        public string Perifecins = "PERIFECINS";
        public string Perifecact = "PERIFECACT";
        public string Perianiomes = "PERIANIOMES";
        public string Perihoralimite = "PERIHORALIMITE";
        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }
    }
}


