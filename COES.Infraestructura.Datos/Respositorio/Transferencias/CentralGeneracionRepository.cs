using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using COES.Dominio.Interfaces.Transferencias;
using COES.Infraestructura.Datos.Helper.Sic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Infraestructura.Datos.Respositorio.Transferencias
{
    public class CentralGeneracionRepository : RepositoryBase, ICentralGeneracionRepository
    {
        public CentralGeneracionRepository(string strConn)
            : base(strConn)
        {
        }

        CentralGeneracionHelper helper = new CentralGeneracionHelper();
        public List<CentralGeneracionDTO> List()
        {
            List<CentralGeneracionDTO> entitys = new List<CentralGeneracionDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);

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
