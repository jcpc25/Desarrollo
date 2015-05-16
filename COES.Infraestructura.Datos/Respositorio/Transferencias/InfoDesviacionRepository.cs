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
   public class InfoDesviacionRepository: RepositoryBase, IInfoDesviacionRepository
    {
       public InfoDesviacionRepository(string strConn)
            : base(strConn)
        {
        }

        InfoDesviacionHelper helper = new InfoDesviacionHelper();

        public List<InfoDesviacionDTO> GetByCriteria(Int32 AnioMes, Int32 AnioMes1, Int32 AnioMes2, Int32 Dias, Int32 DiasMeses, Decimal Desviacion)
        {
            List<InfoDesviacionDTO> entitys = new List<InfoDesviacionDTO>();
            
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

            dbProvider.AddInParameter(command, helper.AnioMes, DbType.Int32, AnioMes);
            dbProvider.AddInParameter(command, helper.AnioMes1, DbType.Int32, AnioMes1);
            dbProvider.AddInParameter(command, helper.AnioMes2, DbType.Int32, AnioMes2);
            dbProvider.AddInParameter(command, helper.Dias, DbType.Int32, Dias);
            dbProvider.AddInParameter(command, helper.DiasMeses, DbType.Int32, DiasMeses);
            dbProvider.AddInParameter(command, helper.Desviacion, DbType.Decimal, Desviacion);

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
