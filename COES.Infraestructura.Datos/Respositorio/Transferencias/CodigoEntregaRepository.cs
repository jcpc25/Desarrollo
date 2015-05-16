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
    public class CodigoEntregaRepository
        : RepositoryBase, ICodigoEntregaRepository
    {
        public CodigoEntregaRepository(string strConn)
            : base(strConn)
        {
        }

        CodigoEntregaHelper helper = new CodigoEntregaHelper();

        public int Save(CodigoEntregaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);
       
            dbProvider.AddInParameter(command, helper.CODIENTRCODI, DbType.Int32, GetCodigoGenerado());
            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.BARRCODI, DbType.Int32, entity.Barrcodi);
            dbProvider.AddInParameter(command, helper.CENTGENECODI, DbType.Int32, entity.Centgenecodi);
            dbProvider.AddInParameter(command, helper.CODIENTRCODIGO, DbType.String, entity.Codientrcodigo);
            dbProvider.AddInParameter(command, helper.CODIENTRFECHAINICIO, DbType.DateTime,  entity.Codientrfechainicio);
            dbProvider.AddInParameter(command, helper.CODIENTRFECHAFIN, DbType.DateTime, entity.Codientrfechafin);
            dbProvider.AddInParameter(command, helper.CODIENTRESTADO, DbType.String, entity.Codientrestado);
            dbProvider.AddInParameter(command, helper.CODIENTRUSERNAME, DbType.String, entity.Codientrusername);
            dbProvider.AddInParameter(command, helper.CODIENTRFECINS, DbType.DateTime, DateTime.Now.Date);


            return dbProvider.ExecuteNonQuery(command);
        }
  
        public void Update(CodigoEntregaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.BARRCODI, DbType.Int32, entity.Barrcodi);
            dbProvider.AddInParameter(command, helper.CENTGENECODI, DbType.Int32, entity.Centgenecodi);
            dbProvider.AddInParameter(command, helper.CODIENTRCODIGO, DbType.String, entity.Codientrcodigo);
            dbProvider.AddInParameter(command, helper.CODIENTRFECHAINICIO, DbType.DateTime, entity.Codientrfechainicio);
            dbProvider.AddInParameter(command, helper.CODIENTRFECHAFIN, DbType.DateTime, entity.Codientrfechafin);
            dbProvider.AddInParameter(command, helper.CODIENTRESTADO, DbType.String, entity.Codientrestado);
            dbProvider.AddInParameter(command, helper.CODIENTRFECACT, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.CODIENTRCODI, DbType.Int32, entity.Codientrcodi);
            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);
      
            dbProvider.AddInParameter(command, helper.CODIENTRCODI, DbType.Int32, id);

            dbProvider.ExecuteNonQuery(command);
        }

        public CodigoEntregaDTO GetById(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.CODIENTRCODI, DbType.Int32, id);
            CodigoEntregaDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<CodigoEntregaDTO> List()
        {
            List<CodigoEntregaDTO> entitys = new List<CodigoEntregaDTO>();
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

        public List<CodigoEntregaDTO> GetByCriteria(string nombreEmp, string centralgene, string barrTrans, DateTime? fechini, DateTime? fechafin, string estado)
        {
      
            //BUSCA LISTA SEGUN CODIGO DE CODIGODE ENTREGA
            List<CodigoEntregaDTO> entitys = new List<CodigoEntregaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

                dbProvider.AddInParameter(command, helper.EMPRNOMB, DbType.String, nombreEmp);
                dbProvider.AddInParameter(command, helper.EMPRNOMB, DbType.String, nombreEmp);

                dbProvider.AddInParameter(command, helper.BARRNOMBBARRTRAN, DbType.String, barrTrans);
                dbProvider.AddInParameter(command, helper.BARRNOMBBARRTRAN, DbType.String, barrTrans);

                dbProvider.AddInParameter(command, helper.CENTGENENOMBRE, DbType.String, centralgene);
                dbProvider.AddInParameter(command, helper.CENTGENENOMBRE, DbType.String, centralgene);

                dbProvider.AddInParameter(command, helper.CODIENTRFECHAINICIO, DbType.DateTime, fechini);
                dbProvider.AddInParameter(command, helper.CODIENTRFECHAINICIO, DbType.DateTime, fechini);

                dbProvider.AddInParameter(command, helper.CODIENTRFECHAFIN, DbType.DateTime, fechafin);
                dbProvider.AddInParameter(command, helper.CODIENTRFECHAFIN, DbType.DateTime, fechafin);

                dbProvider.AddInParameter(command, helper.CODIENTRESTADO, DbType.String, estado);
                dbProvider.AddInParameter(command, helper.CODIENTRESTADO, DbType.String, estado);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public int GetCodigoGenerado()
        {
            int newId = 0;
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCodigoGenerado);
            newId = Int32.Parse(dbProvider.ExecuteScalar(command).ToString());

            return newId;
        }
 
        public CodigoEntregaDTO GetByCodiEntrCodigo(System.String codientrCodigo)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCodigoEntregaCodigo);
            dbProvider.AddInParameter(command, helper.CODIENTRCODIGO, DbType.String, codientrCodigo);
            CodigoEntregaDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
            if (dr.Read())
            {
                entity = helper.Create(dr);
            }
            }

            return entity;
        }


        
    }
}
