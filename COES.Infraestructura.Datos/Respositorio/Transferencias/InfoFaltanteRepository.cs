using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using COES.Dominio.Interfaces.Transferencias;
using COES.Infraestructura.Datos.Helper.Transferencias;
using System.Data;
using System.Data.Common;

namespace COES.Infraestructura.Datos.Respositorio.Transferencias
{
   public class InfoFaltanteRepository: RepositoryBase, IInfoFaltanteRepository
    {
       public InfoFaltanteRepository(string strConn)
            : base(strConn)
        {
        }

       InfoFaltanteHelper helper = new InfoFaltanteHelper();

        public List<InfoFaltanteDTO> GetByCriteria(Int32 PeriCodi)
        {
            List<InfoFaltanteDTO> entitys = new List<InfoFaltanteDTO>();
            
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, PeriCodi);

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
