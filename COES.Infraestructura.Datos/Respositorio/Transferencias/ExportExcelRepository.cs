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
    public class ExportExcelRepository : RepositoryBase, IEnvioInformacionRepository
    {


         /// Clase que contiene las operaciones con la base de datos
        /// </summary>
        public ExportExcelRepository(string strConn)
            : base(strConn)
        {
        }

        ExportExelHelper helper = new ExportExelHelper();





        public List<ExportExcelDTO> GetByCriteria(int codEmp)
        {
            List<ExportExcelDTO> entitys = new List<ExportExcelDTO>();
        
           

            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);
            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, codEmp);
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
