using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Scada;
using COES.Base.Core;
using COES.Infraestructura.Datos.Helper.Sic;

namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    public class EveTipoEventoRepository: RepositoryBase
    {
        public EveTipoEventoRepository(string strConn)
            : base(strConn)
        {

        }

        TipoEventoHelper helper = new TipoEventoHelper();               

        public List<TipoEventoDTO> ListarTipoEvento()
        {                       
            DbCommand command = dbProvider.GetSqlStringCommand(this.helper.SqlGetByCriteria);
            List<TipoEventoDTO> entitys = new List<TipoEventoDTO>();

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }
    }
}
