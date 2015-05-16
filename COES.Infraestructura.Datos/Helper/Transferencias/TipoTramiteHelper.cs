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
   public class TipoTramiteHelper:HelperBase
    {
        public TipoTramiteHelper() : base(Consultas.TipoTramiteSql)
        {
        }

        public TipoTramiteDTO Create(IDataReader dr)
        {
            TipoTramiteDTO entity = new TipoTramiteDTO();

            int iTipotramcodi = dr.GetOrdinal(this.Tipotramcodi);
            if (!dr.IsDBNull(iTipotramcodi)) entity.Tipotramcodi = dr.GetInt32(iTipotramcodi);

            int iTipotramnombre = dr.GetOrdinal(this.Tipotramnombre);
            if (!dr.IsDBNull(iTipotramnombre)) entity.Tipotramnombre = dr.GetString(iTipotramnombre);

            int iTipotramestado = dr.GetOrdinal(this.Tipotramestado);
            if (!dr.IsDBNull(iTipotramestado)) entity.Tipotramestado = dr.GetString(iTipotramestado);

            int iTipotramusername = dr.GetOrdinal(this.Tipotramusername);
            if (!dr.IsDBNull(iTipotramusername)) entity.Tipotramusername = dr.GetString(iTipotramusername);

            int iTipotramfecins = dr.GetOrdinal(this.Tipotramfecins);
            if (!dr.IsDBNull(iTipotramfecins)) entity.Tipotramfecins = dr.GetDateTime(iTipotramfecins);

           

            return entity;
        }

        #region Mapeo de Campos

        public string Tipotramcodi = "TIPTRMCODI";

        public string Tipotramnombre = "TIPTRMNOMBRE";

        public string Tipotramestado = "TIPTRMESTADO";

        public string Tipotramusername = "TIPTRMUSERNAME";

        public string Tipotramfecins = "TIPTRMFECINS";

        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }
    }
}
