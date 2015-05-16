using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using COES.Dominio.Interfaces.Transferencias;
using COES.Infraestructura.Datos.Helper.Transferencias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Infraestructura.Datos.Respositorio.Transferencias
{
    public class InfoDesbalanceRepository : RepositoryBase, IInfoDesbalanceRepository
    {

          /// <summary>
        /// Clase que contiene las operaciones con la base de datos
        /// </summary>
        public InfoDesbalanceRepository(string strConn)
            : base(strConn)
        {
        }

        InfoDesbalanceHelper helper = new InfoDesbalanceHelper();

        public List<InfoDesbalanceDTO> GetByCriteria(string pericodi)
        {
            List<InfoDesbalanceDTO> entitys = new List<InfoDesbalanceDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.Pericodi, DbType.Int32, pericodi);

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
