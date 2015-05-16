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
    public class InformePreliminarRepository : RepositoryBase, IInformePreliminarRepository
    {

        public InformePreliminarRepository(string strConn)
            : base(strConn)
        {
        }

        InformePreliminarHelper helper = new InformePreliminarHelper();



        public List<InformePreliminarDTO> GetByCriteria(int periodo, int version)
        {

            List<InformePreliminarDTO> entitys = new List<InformePreliminarDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, periodo);
            dbProvider.AddInParameter(command, helper.VALTOTAEMPVERSION, DbType.Int32, version);
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
