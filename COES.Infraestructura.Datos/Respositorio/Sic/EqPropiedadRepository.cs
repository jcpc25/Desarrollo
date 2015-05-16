using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Sic;
using COES.Base.Core;
using COES.Infraestructura.Datos.Helper.Sic;

namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    /// <summary>
    /// Clase de acceso a datos de la tabla EQ_PROPIEDAD
    /// </summary>
    public class EqPropiedadRepository: RepositoryBase, IEqPropiedadRepository
    {
        public EqPropiedadRepository(string strConn): base(strConn)
        {
        }

        EqPropiedadHelper helper = new EqPropiedadHelper();

        public int Save(EqPropiedadDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Propcodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Proptabla, DbType.String, entity.Proptabla);
            dbProvider.AddInParameter(command, helper.Propcampo, DbType.String, entity.Propcampo);
            dbProvider.AddInParameter(command, helper.Propfiltro, DbType.String, entity.Propfiltro);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Propmaxelem, DbType.Int32, entity.Propmaxelem);
            dbProvider.AddInParameter(command, helper.Propfichaoficial, DbType.String, entity.Propfichaoficial);
            dbProvider.AddInParameter(command, helper.Propvisible, DbType.String, entity.Propvisible);
            dbProvider.AddInParameter(command, helper.Famcodi, DbType.Int32, entity.Famcodi);
            dbProvider.AddInParameter(command, helper.Propabrev, DbType.String, entity.Propabrev);
            dbProvider.AddInParameter(command, helper.Propnomb, DbType.String, entity.Propnomb);
            dbProvider.AddInParameter(command, helper.Propunidad, DbType.String, entity.Propunidad);
            dbProvider.AddInParameter(command, helper.Orden, DbType.Int32, entity.Orden);
            dbProvider.AddInParameter(command, helper.Propmask, DbType.String, entity.Propmask);
            dbProvider.AddInParameter(command, helper.Proptipo, DbType.String, entity.Proptipo);
            dbProvider.AddInParameter(command, helper.Prophisto, DbType.String, entity.Prophisto);
            dbProvider.AddInParameter(command, helper.Propdefinicion, DbType.String, entity.Propdefinicion);
            dbProvider.AddInParameter(command, helper.Propprincipal, DbType.String, entity.Propprincipal);
            dbProvider.AddInParameter(command, helper.Propfile, DbType.String, entity.Propfile);
            dbProvider.AddInParameter(command, helper.Propcodipadre, DbType.Int32, entity.Propcodipadre);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(EqPropiedadDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Proptabla, DbType.String, entity.Proptabla);
            dbProvider.AddInParameter(command, helper.Propcampo, DbType.String, entity.Propcampo);
            dbProvider.AddInParameter(command, helper.Propfiltro, DbType.String, entity.Propfiltro);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Propmaxelem, DbType.Int32, entity.Propmaxelem);
            dbProvider.AddInParameter(command, helper.Propfichaoficial, DbType.String, entity.Propfichaoficial);
            dbProvider.AddInParameter(command, helper.Propvisible, DbType.String, entity.Propvisible);
            dbProvider.AddInParameter(command, helper.Propcodi, DbType.Int32, entity.Propcodi);
            dbProvider.AddInParameter(command, helper.Famcodi, DbType.Int32, entity.Famcodi);
            dbProvider.AddInParameter(command, helper.Propabrev, DbType.String, entity.Propabrev);
            dbProvider.AddInParameter(command, helper.Propnomb, DbType.String, entity.Propnomb);
            dbProvider.AddInParameter(command, helper.Propunidad, DbType.String, entity.Propunidad);
            dbProvider.AddInParameter(command, helper.Orden, DbType.Int32, entity.Orden);
            dbProvider.AddInParameter(command, helper.Propmask, DbType.String, entity.Propmask);
            dbProvider.AddInParameter(command, helper.Proptipo, DbType.String, entity.Proptipo);
            dbProvider.AddInParameter(command, helper.Prophisto, DbType.String, entity.Prophisto);
            dbProvider.AddInParameter(command, helper.Propdefinicion, DbType.String, entity.Propdefinicion);
            dbProvider.AddInParameter(command, helper.Propprincipal, DbType.String, entity.Propprincipal);
            dbProvider.AddInParameter(command, helper.Propfile, DbType.String, entity.Propfile);
            dbProvider.AddInParameter(command, helper.Propcodipadre, DbType.Int32, entity.Propcodipadre);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int propcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Propcodi, DbType.Int32, propcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public EqPropiedadDTO GetById(int propcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Propcodi, DbType.Int32, propcodi);
            EqPropiedadDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EqPropiedadDTO> List()
        {
            List<EqPropiedadDTO> entitys = new List<EqPropiedadDTO>();
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

        public List<EqPropiedadDTO> GetByCriteria()
        {
            List<EqPropiedadDTO> entitys = new List<EqPropiedadDTO>();
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
    }
}
