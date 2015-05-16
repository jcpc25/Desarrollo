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
   public class RecalculoRepository: RepositoryBase, IRecalculoRepository
    {
        public RecalculoRepository(string strConn) : base(strConn)
        {
        }

         RecalculoHelper helper = new RecalculoHelper();

        public int Save(RecalculoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);
            int iRecacodi = GetCodigoGenerado(entity.Recapericodi);
            dbProvider.AddInParameter(command, helper.Recacodi, DbType.Int32, iRecacodi);
            dbProvider.AddInParameter(command, helper.Recapericodi, DbType.Int32, entity.Recapericodi);
            dbProvider.AddInParameter(command, helper.Recafecini, DbType.DateTime, entity.Recafecini);
            dbProvider.AddInParameter(command, helper.Recafecfin, DbType.DateTime, entity.Recafecfin);
            dbProvider.AddInParameter(command, helper.Recadesc, DbType.String, entity.Recadesc);
            dbProvider.AddInParameter(command, helper.Recausername, DbType.String, entity.Recausername);
            dbProvider.AddInParameter(command, helper.Recafecins, DbType.DateTime, DateTime.Now);
            dbProvider.ExecuteNonQuery(command);

            return iRecacodi;
        }

        public void Update(RecalculoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Recafecini, DbType.DateTime, entity.Recafecini);
            dbProvider.AddInParameter(command, helper.Recafecfin, DbType.DateTime, entity.Recafecfin);
            dbProvider.AddInParameter(command, helper.Recadesc, DbType.String, entity.Recadesc);
            dbProvider.AddInParameter(command, helper.Recafecact, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Recacodi, DbType.Int32, entity.Recacodi);
            dbProvider.AddInParameter(command, helper.Recapericodi, DbType.Int32, entity.Recapericodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            //dbProvider.AddInParameter(command, helper.Cabecompfecact, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Recacodi, DbType.Int32, id);
           
            dbProvider.ExecuteNonQuery(command);
        }

        public RecalculoDTO GetById(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Recacodi, DbType.Int32, id);
        
            RecalculoDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command)) 
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<RecalculoDTO> List(int id=0)
        {
            List<RecalculoDTO> entitys = new List<RecalculoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);
            dbProvider.AddInParameter(command, helper.Recapericodi, DbType.Int32, id);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<RecalculoDTO> GetByCriteria(string nombre)
        {
            List<RecalculoDTO> entitys = new List<RecalculoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.Recadesc, DbType.String, nombre);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public int GetCodigoGenerado(int iPeriCodi)
        {
            int newId = 0;
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCodigoGenerado);
            dbProvider.AddInParameter(command, helper.Recapericodi, DbType.Int32, iPeriCodi);
            newId = Int32.Parse(dbProvider.ExecuteScalar(command).ToString());

            return newId;
        }

        public int GetUltimaVersion(int pericodi)
        {
            int version = 0;
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetUltimaVersion);
            dbProvider.AddInParameter(command, helper.Recapericodi, DbType.Int32, pericodi);
            version = Int32.Parse(dbProvider.ExecuteScalar(command).ToString());

            return version;
        }


    }
}
