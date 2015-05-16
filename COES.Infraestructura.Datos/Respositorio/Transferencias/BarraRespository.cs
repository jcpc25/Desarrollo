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
    /// <summary>
    /// Clase que contiene el mapeo de la tabla TRN_BARRA
    /// </summary>
    public class BarraRespository : RepositoryBase, IBarraRepository
    {
        public BarraRespository(string strConn) : base(strConn)
        {
        }

        BarraHelper helper = new BarraHelper();

        public int Save(BarraDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

       

            dbProvider.AddInParameter(command, helper.Barrcodi, DbType.Int32, GetCodigoGenerado());
            dbProvider.AddInParameter(command, helper.Barrnombre, DbType.String, entity.Barrnombre);
            dbProvider.AddInParameter(command, helper.Barrtension, DbType.String, entity.Barrtension);
            dbProvider.AddInParameter(command, helper.Barrpuntosumirer, DbType.String, entity.Barrpuntosumirer);
            dbProvider.AddInParameter(command, helper.Barrbarrabgr, DbType.String, entity.Barrbarrabgr);
            dbProvider.AddInParameter(command, helper.Barrestado, DbType.String, entity.Barrestado);
            dbProvider.AddInParameter(command, helper.Barrflagbarrtran, DbType.String, entity.Barrflagbarrtran);
            dbProvider.AddInParameter(command, helper.Areacodi, DbType.Int32, entity.Areacodi);
            dbProvider.AddInParameter(command, helper.Barrnombbarrtran, DbType.String, entity.Barrnombbarrtran);
            dbProvider.AddInParameter(command, helper.Barrusername, DbType.String, entity.Barrusername);
            dbProvider.AddInParameter(command, helper.Barrfecins, DbType.DateTime, DateTime.Now);

    
          
            return dbProvider.ExecuteNonQuery(command);
        }

        public void Update(BarraDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Barrnombre, DbType.String, entity.Barrnombre);
            dbProvider.AddInParameter(command, helper.Barrtension, DbType.String, entity.Barrtension);
            dbProvider.AddInParameter(command, helper.Barrpuntosumirer, DbType.String, entity.Barrpuntosumirer);
            dbProvider.AddInParameter(command, helper.Barrbarrabgr, DbType.String, entity.Barrbarrabgr);
            dbProvider.AddInParameter(command, helper.Barrestado, DbType.String, entity.Barrestado);
            dbProvider.AddInParameter(command, helper.Barrflagbarrtran, DbType.String, entity.Barrflagbarrtran);
            dbProvider.AddInParameter(command, helper.Areacodi, DbType.Int32, entity.Areacodi);
            dbProvider.AddInParameter(command, helper.Barrnombbarrtran, DbType.String, entity.Barrnombbarrtran);
            dbProvider.AddInParameter(command, helper.Barrfecact, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Barrcodi, DbType.Int32, entity.Barrcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            //dbProvider.AddInParameter(command, helper.Barrfecact, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Barrcodi, DbType.Int32, id);

            dbProvider.ExecuteNonQuery(command);
        }

        public BarraDTO GetById(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Barrcodi, DbType.Int32, id);
            BarraDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<BarraDTO> List()
        {
            List<BarraDTO> entitys = new List<BarraDTO>();
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

        public List<BarraDTO> GetByCriteria(string nombre)
        {
            List<BarraDTO> entitys = new List<BarraDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.Barrnombre, DbType.String, nombre);

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
