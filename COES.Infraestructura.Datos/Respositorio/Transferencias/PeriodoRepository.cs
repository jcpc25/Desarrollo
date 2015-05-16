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
    public class PeriodoRepository : RepositoryBase, IPeriodoRepository
    {
        public PeriodoRepository(string strConn)
            : base(strConn)
        {
        }
  
        PeriodoHelper helper = new PeriodoHelper();

        public int Save(PeriodoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);
            int iPeriCodi = GetCodigoGenerado();
            dbProvider.AddInParameter(command, helper.Pericodi, DbType.Int32, iPeriCodi);
            dbProvider.AddInParameter(command, helper.Perinombre, DbType.String, entity.Perinombre);
            dbProvider.AddInParameter(command, helper.Aniocodi, DbType.Int32, entity.Aniocodi);
            dbProvider.AddInParameter(command, helper.Mescodi, DbType.Int32, entity.Mescodi);
            dbProvider.AddInParameter(command, helper.Perifechavalorizacion, DbType.DateTime, entity.Perifechavalorizacion);
            dbProvider.AddInParameter(command, helper.Perifechalimite, DbType.DateTime, entity.Perifechalimite);
            dbProvider.AddInParameter(command, helper.Perifechaobservacion, DbType.DateTime, entity.Perifechaobservacion);
            dbProvider.AddInParameter(command, helper.Periestado, DbType.String, entity.Periestado);
            dbProvider.AddInParameter(command, helper.Periusername, DbType.String, entity.Periusername);
            dbProvider.AddInParameter(command, helper.Perifecins, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Perianiomes, DbType.Int32, entity.Perianiomes);
            dbProvider.AddInParameter(command, helper.Perihoralimite, DbType.String, entity.Perihoralimite);
            dbProvider.ExecuteNonQuery(command);
            return iPeriCodi;
        }

        public void Update(PeriodoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Perinombre, DbType.String, entity.Perinombre);
            dbProvider.AddInParameter(command, helper.Aniocodi, DbType.Int32, entity.Aniocodi);
            dbProvider.AddInParameter(command, helper.Mescodi, DbType.Int32, entity.Mescodi);
            dbProvider.AddInParameter(command, helper.Perifechavalorizacion, DbType.DateTime, entity.Perifechavalorizacion);
            dbProvider.AddInParameter(command, helper.Perifechalimite, DbType.DateTime, entity.Perifechalimite);
            dbProvider.AddInParameter(command, helper.Perifechaobservacion, DbType.DateTime, entity.Perifechaobservacion);
            dbProvider.AddInParameter(command, helper.Periestado, DbType.String, entity.Periestado);
            dbProvider.AddInParameter(command, helper.Perifecact, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Perianiomes, DbType.Int32, entity.Perianiomes);
            dbProvider.AddInParameter(command, helper.Perihoralimite, DbType.String, entity.Perihoralimite);
            dbProvider.AddInParameter(command, helper.Pericodi, DbType.Int32, entity.Pericodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            //dbProvider.AddInParameter(command, helper.Perifecact, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Pericodi, DbType.Int32, id);

            dbProvider.ExecuteNonQuery(command);
        }

        public PeriodoDTO GetById(System.Int32? id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Pericodi, DbType.Int32, id);
            PeriodoDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<PeriodoDTO> List()
        {
            List<PeriodoDTO> entitys = new List<PeriodoDTO>();
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

        public List<PeriodoDTO> GetByCriteria(string nombre)
        {
            List<PeriodoDTO> entitys = new List<PeriodoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.Perinombre, DbType.String, nombre);

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
