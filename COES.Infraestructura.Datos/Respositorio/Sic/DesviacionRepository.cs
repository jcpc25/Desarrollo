using COES.Base.Core;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Sic;
using COES.Infraestructura.Datos.Helper.Sic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    public class DesviacionRepository : RepositoryBase, IDesviacionRepository
    {
        public DesviacionRepository(string strConn)
            : base(strConn)
        {
        }
        DesviacionHelper helper = new DesviacionHelper();

        public int Save(DesviacionDTO entity)
        {
            try
            {
                DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

                dbProvider.AddInParameter(command, helper.Lectcodi, DbType.Int32, entity.Lectcodi);
                dbProvider.AddInParameter(command, helper.Desvfecha, DbType.DateTime, entity.Desvfecha);
                dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
                dbProvider.AddInParameter(command, helper.Medorigdesv, DbType.Int32, entity.Medorigdesv);
                dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
                dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);


                return dbProvider.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }



        }

        public DesviacionDTO GetById(System.Int32 id)
        {
            throw new NotImplementedException();
        }

        public List<DesviacionDTO> List()
        {

            List<DesviacionDTO> entitys = new List<DesviacionDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);
            try
            {
                using (IDataReader dr = dbProvider.ExecuteReader(command))
                {

                    while (dr.Read())
                    {

                        if (helper.Create(dr).Ptomedicodi != 0)
                        {
                            entitys.Add(helper.Create(dr));

                        }
                    }

                }
            }
            catch (Exception e)
            {
                entitys = null;

            }
            return entitys;
        }

        public void Update(DesviacionDTO entity)
        {
            throw new NotImplementedException();

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(DesviacionDTO entity)
        {
            try
            {
                DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);
                dbProvider.AddInParameter(command, helper.Desvfecha, DbType.Date, entity.Desvfecha);
                Debug.WriteLine("Exito  delete repository");

                dbProvider.ExecuteNonQuery(command);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error  delete repository");
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
