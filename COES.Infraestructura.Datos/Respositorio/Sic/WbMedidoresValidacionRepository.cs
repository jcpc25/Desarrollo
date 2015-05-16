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
    /// Clase de acceso a datos de la tabla WB_MEDIDORES_VALIDACION
    /// </summary>
    public class WbMedidoresValidacionRepository: RepositoryBase, IWbMedidoresValidacionRepository
    {
        public WbMedidoresValidacionRepository(string strConn): base(strConn)
        {
        }

        WbMedidoresValidacionHelper helper = new WbMedidoresValidacionHelper();

        public int Save(WbMedidoresValidacionDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Medivalcodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Ptomedicodimed, DbType.Int32, entity.Ptomedicodimed);
            dbProvider.AddInParameter(command, helper.Ptomedicodidesp, DbType.Int32, entity.Ptomedicodidesp);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Indestado, DbType.String, entity.Indestado);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(WbMedidoresValidacionDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Medivalcodi, DbType.Int32, entity.Medivalcodi);
            dbProvider.AddInParameter(command, helper.Ptomedicodimed, DbType.Int32, entity.Ptomedicodimed);
            dbProvider.AddInParameter(command, helper.Ptomedicodidesp, DbType.Int32, entity.Ptomedicodidesp);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Indestado, DbType.String, entity.Indestado);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int medivalcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Medivalcodi, DbType.Int32, medivalcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public WbMedidoresValidacionDTO GetById(int medivalcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Medivalcodi, DbType.Int32, medivalcodi);
            WbMedidoresValidacionDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<WbMedidoresValidacionDTO> List()
        {
            List<WbMedidoresValidacionDTO> entitys = new List<WbMedidoresValidacionDTO>();
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

        public List<WbMedidoresValidacionDTO> GetByCriteria()
        {
            List<WbMedidoresValidacionDTO> entitys = new List<WbMedidoresValidacionDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    WbMedidoresValidacionDTO entity = new WbMedidoresValidacionDTO();

                    int iEmprNomb = dr.GetOrdinal(this.helper.EmprNomb);
                    if (!dr.IsDBNull(iEmprNomb)) entity.EmprNomb = dr.GetString(iEmprNomb);

                    int iGrupoNomb = dr.GetOrdinal(this.helper.GrupoNomb);
                    if (!dr.IsDBNull(iGrupoNomb)) entity.GrupoNomb = dr.GetString(iGrupoNomb);

                    int iGrupoAbrev = dr.GetOrdinal(this.helper.GrupoAbrev);
                    if (!dr.IsDBNull(iGrupoAbrev)) entity.GrupoAbrev = dr.GetString(iGrupoAbrev);

                    int iPtoMediCodiDesp = dr.GetOrdinal(this.helper.Ptomedicodidesp);
                    if (!dr.IsDBNull(iPtoMediCodiDesp)) entity.Ptomedicodidesp = Convert.ToInt32(dr.GetValue(iPtoMediCodiDesp));

                    int iPtoMediCodiMed = dr.GetOrdinal(this.helper.Ptomedicodimed);
                    if (!dr.IsDBNull(iPtoMediCodiMed)) entity.Ptomedicodimed = Convert.ToInt32(dr.GetValue(iPtoMediCodiMed));

                    entitys.Add(entity);
                }
            }

            return entitys;
        }
    }
}
