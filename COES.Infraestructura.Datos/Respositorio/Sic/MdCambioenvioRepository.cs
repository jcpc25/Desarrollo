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
    /// Clase de acceso a datos de la tabla MD_CAMBIOENVIO
    /// </summary>
    public class MdCambioenvioRepository: RepositoryBase, IMdCambioenvioRepository
    {
        public MdCambioenvioRepository(string strConn): base(strConn)
        {
        }

        MdCambioenvioHelper helper = new MdCambioenvioHelper();

        public void Save(MdCambioenvioDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, entity.Tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Enviocodiold, DbType.Int32, entity.Enviocodiold);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, entity.Medifecha);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
            dbProvider.AddInParameter(command, helper.Enviocodinew, DbType.Int32, entity.Enviocodinew);
            dbProvider.AddInParameter(command, helper.Cmbvalorold, DbType.Decimal, entity.Cmbvalorold);
            dbProvider.AddInParameter(command, helper.Cmbvalornew, DbType.Decimal, entity.Cmbvalornew);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(MdCambioenvioDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, entity.Tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Enviocodiold, DbType.Int32, entity.Enviocodiold);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, entity.Medifecha);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
            dbProvider.AddInParameter(command, helper.Enviocodinew, DbType.Int32, entity.Enviocodinew);
            dbProvider.AddInParameter(command, helper.Cmbvalorold, DbType.Decimal, entity.Cmbvalorold);
            dbProvider.AddInParameter(command, helper.Cmbvalornew, DbType.Decimal, entity.Cmbvalornew);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int tipoinfocodi, int enviocodiold, DateTime medifecha, int ptomedicodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Enviocodiold, DbType.Int32, enviocodiold);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, medifecha);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, ptomedicodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public MdCambioenvioDTO GetById(int tipoinfocodi, int enviocodiold, DateTime medifecha, int ptomedicodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Enviocodiold, DbType.Int32, enviocodiold);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, medifecha);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, ptomedicodi);
            MdCambioenvioDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<MdCambioenvioDTO> List()
        {
            List<MdCambioenvioDTO> entitys = new List<MdCambioenvioDTO>();
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

        public List<MdCambioenvioDTO> GetByCriteria()
        {
            List<MdCambioenvioDTO> entitys = new List<MdCambioenvioDTO>();
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
