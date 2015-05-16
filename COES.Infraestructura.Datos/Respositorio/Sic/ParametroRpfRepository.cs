using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Scada;
using COES.Base.Core;
using COES.Infraestructura.Datos.Helper.Sic;

namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    public class ParametroRpfRepository: RepositoryBase
    {
        public ParametroRpfRepository(string strConn)
            : base(strConn)
        {

        }

        ParametroRpfHelper helper = new ParametroRpfHelper();

        public void Save(List<ParametroRpfDTO> entitys)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            foreach (ParametroRpfDTO entity in entitys)
            {
                command.Parameters.Clear();

                dbProvider.AddInParameter(command, helper.PARAMRPFCODI, DbType.Int32, entity.PARAMRPFCODI);
                dbProvider.AddInParameter(command, helper.PARAMTIPO, DbType.String, entity.PARAMTIPO);
                dbProvider.AddInParameter(command, helper.PARAMVALUE, DbType.String, entity.PARAMVALUE);
                dbProvider.AddInParameter(command, helper.PARAMMODULO, DbType.String, entity.PARAMMODULO);                

                dbProvider.ExecuteNonQuery(command);
            }
        }

        public void Save(ParametroRpfDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.PARAMRPFCODI, DbType.Int32, entity.PARAMRPFCODI);
            dbProvider.AddInParameter(command, helper.PARAMTIPO, DbType.String, entity.PARAMTIPO);
            dbProvider.AddInParameter(command, helper.PARAMVALUE, DbType.String, entity.PARAMVALUE);
            dbProvider.AddInParameter(command, helper.PARAMMODULO, DbType.String, entity.PARAMMODULO);

            dbProvider.ExecuteNonQuery(command);
        }


        public void Detele(string modulo)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.PARAMMODULO, DbType.String, modulo);

            dbProvider.ExecuteNonQuery(command);
        }
        
        public ParametroRpfDTO GetById(int id)
        {
            ParametroRpfDTO entity = null;
            
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);
            dbProvider.AddInParameter(command, helper.PARAMRPFCODI, DbType.Int32, id);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;        
        }

        public List<ParametroRpfDTO> GetByCriteria(string modulo)
        {
            List<ParametroRpfDTO> entitys = new List<ParametroRpfDTO>();

            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.PARAMMODULO, DbType.String, modulo);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }


        //public List<int> ObtenerPuntosExcluir(DateTime fecha)
        //{
        //    List<int> ids = new List<int>();

        //    DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlObtenerPuntosExcluir);
        //    dbProvider.AddInParameter(command, helper.PARAMMODULO, DbType.String, modulo);

        //    using (IDataReader dr = dbProvider.ExecuteReader(command))
        //    {
        //        while (dr.Read())
        //        {
        //            entitys.Add(helper.Create(dr));
        //        }
        //    }

        //    return ids;
        //}
    }
}
