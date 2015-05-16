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
   public class TramiteRepository: RepositoryBase,ITramiteRepository
    {
        public TramiteRepository(string strConn) : base(strConn)
        {
        }

        TramiteHelper helper = new TramiteHelper();

        public int Save(TramiteDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Tramcodi, DbType.Int32, GetCodigoGenerado());
            dbProvider.AddInParameter(command, helper.Usuacoescodi, DbType.String, entity.Usuacoescodi);
            dbProvider.AddInParameter(command, helper.Usuaseincodi, DbType.String, entity.Usuaseincodi);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Pericodi, DbType.Int32, entity.Pericodi);
            dbProvider.AddInParameter(command, helper.Tipotramcodi, DbType.Int32, entity.Tipotramcodi);
            dbProvider.AddInParameter(command, helper.Tramcorrinf, DbType.String, entity.Tramcorrinf);
            dbProvider.AddInParameter(command, helper.Tramdescripcion, DbType.String, entity.Tramdescripcion);
            dbProvider.AddInParameter(command, helper.Tramrespuesta, DbType.String, entity.Tramrespuesta);
            dbProvider.AddInParameter(command, helper.Tramfecreg, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Tramfecins, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Tramfecact, DbType.DateTime, DateTime.Now);

            return dbProvider.ExecuteNonQuery(command);
        }

        public void Update(TramiteDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Usuacoescodi, DbType.String, entity.Usuacoescodi);
            dbProvider.AddInParameter(command, helper.Tramcorrinf, DbType.String, entity.Tramcorrinf);
            dbProvider.AddInParameter(command, helper.Tramrespuesta, DbType.String, entity.Tramrespuesta);
            dbProvider.AddInParameter(command, helper.Tramfecres, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Tramfecact, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.Tramcodi, DbType.Int32, entity.Tramcodi);
            dbProvider.ExecuteNonQuery(command);
        }



        public TramiteDTO GetById(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper .SqlGetById);

            dbProvider.AddInParameter(command, helper.Tramcodi, DbType.Int32, id);
            TramiteDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<TramiteDTO> List()
        {

            List<TramiteDTO> entitys = new List<TramiteDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
     

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<TramiteDTO> GetByCriteria(DateTime? fecha, string corrinf, int periodo)
        {
            List<TramiteDTO> entitys = new List<TramiteDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.Tramfecreg, DbType.DateTime, fecha);
            dbProvider.AddInParameter(command, helper.Tramfecreg, DbType.DateTime, fecha);
            dbProvider.AddInParameter(command, helper.Tramcorrinf, DbType.String, corrinf);
            dbProvider.AddInParameter(command, helper.Tramcorrinf, DbType.String, corrinf);
            dbProvider.AddInParameter(command, helper.Pericodi, DbType.Int32, periodo);
            dbProvider.AddInParameter(command, helper.Pericodi, DbType.Int32, periodo);

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
