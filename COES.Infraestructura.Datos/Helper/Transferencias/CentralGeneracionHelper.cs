using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    public class CentralGeneracionHelper : HelperBase
    {
        public CentralGeneracionHelper() : base(Consultas.CentralGeneracionSql) 
        {
        }

        public CentralGeneracionDTO Create(IDataReader dr)
        {
            CentralGeneracionDTO entity = new CentralGeneracionDTO();

            int iCENTGENECODI = dr.GetOrdinal(this.CENTGENECODI);
            if (!dr.IsDBNull(iCENTGENECODI)) entity.Centgenecodi = dr.GetInt32(iCENTGENECODI);

            int iCENTGENENOMBRE = dr.GetOrdinal(this.CENTGENENOMBRE);
            if (!dr.IsDBNull(iCENTGENENOMBRE)) entity.Centgenenombre = dr.GetString(iCENTGENENOMBRE);

            return entity;
        }

        #region Mapeo de Campos
        public string CENTGENECODI = "EQUICODI";
        public string CENTGENENOMBRE = "EQUINOMB";

        #endregion
    }
}
