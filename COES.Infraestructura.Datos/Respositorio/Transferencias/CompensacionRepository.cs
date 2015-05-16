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
    public class CompensacionRepository: RepositoryBase, ICompensacionRepository
    {
          public CompensacionRepository(string strConn) : base(strConn)
        {
        }

         CompensacionHelper helper = new CompensacionHelper();

        public int Save(CompensacionDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Cabecompcodi, DbType.Int32, GetCodigoGenerado());
            dbProvider.AddInParameter(command, helper.Cabecompnombre, DbType.String, entity.Cabecompnombre);
            dbProvider.AddInParameter(command, helper.Cabecompver, DbType.String, entity.Cabecompver);
            dbProvider.AddInParameter(command, helper.Cabecompestado, DbType.String, entity.Cabecompestado);
            dbProvider.AddInParameter(command, helper.Cabecompusername, DbType.String, entity.Cabecompusername);
            dbProvider.AddInParameter(command, helper.Cabecompfecins, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Cabecomppericodi, DbType.Int32, entity.Cabecomppericodi);
            
            
            return dbProvider.ExecuteNonQuery(command);
        }

        public void Update(CompensacionDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Cabecompnombre, DbType.String, entity.Cabecompnombre);
            dbProvider.AddInParameter(command, helper.Cabecompver, DbType.String, entity.Cabecompver);
            dbProvider.AddInParameter(command, helper.Cabecompestado, DbType.String, entity.Cabecompestado);
            dbProvider.AddInParameter(command, helper.Cabecompfecact, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Cabecompcodi, DbType.Int32, entity.Cabecompcodi);
            dbProvider.AddInParameter(command, helper.Cabecomppericodi, DbType.Int32, entity.Cabecomppericodi);
           

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            //dbProvider.AddInParameter(command, helper.Cabecompfecact, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Cabecompcodi, DbType.Int32, id);
           

            dbProvider.ExecuteNonQuery(command);
        }

        public CompensacionDTO GetById(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Cabecompcodi, DbType.Int32, id);
        
            CompensacionDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command)) 
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public CompensacionDTO GetByCodigo(string nombre, int pericodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCodigo);

            dbProvider.AddInParameter(command, helper.Cabecompnombre, DbType.String, nombre);
            dbProvider.AddInParameter(command, helper.Cabecomppericodi, DbType.Int32, pericodi);
            CompensacionDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<CompensacionDTO> List(int id=0)
        {
            List<CompensacionDTO> entitys = new List<CompensacionDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);
            dbProvider.AddInParameter(command, helper.Cabecomppericodi, DbType.Int32, id);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<CompensacionDTO> GetByCriteria(string nombre)
        {
            List<CompensacionDTO> entitys = new List<CompensacionDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.Cabecompnombre, DbType.String, nombre);

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

    }
    }

