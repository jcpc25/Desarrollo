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
    /// Clase de acceso a datos de la tabla EN_ESTFORMATO
    /// </summary>
    public class EnEstformatoRepository: RepositoryBase, IEnEstformatoRepository
    {
        public EnEstformatoRepository(string strConn): base(strConn)
        {
        }

        EnEstformatoHelper helper = new EnEstformatoHelper();

        public void Save(EnEstformatoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Ensayocodi, DbType.Int32, entity.Ensayocodi);
            dbProvider.AddInParameter(command, helper.Formatocodi, DbType.Int32, entity.Formatocodi);
            dbProvider.AddInParameter(command, helper.Estadocodi, DbType.Int32, entity.Estadocodi);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Estformatdescrip, DbType.String, entity.Estformatdescrip);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(EnEstformatoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Ensayocodi, DbType.Int32, entity.Ensayocodi);
            dbProvider.AddInParameter(command, helper.Formatocodi, DbType.Int32, entity.Formatocodi);
            dbProvider.AddInParameter(command, helper.Estadocodi, DbType.Int32, entity.Estadocodi);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Estformatdescrip, DbType.String, entity.Estformatdescrip);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete()
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);


            dbProvider.ExecuteNonQuery(command);
        }

        public EnEstformatoDTO GetById()
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            EnEstformatoDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EnEstformatoDTO> List()
        {
            List<EnEstformatoDTO> entitys = new List<EnEstformatoDTO>();
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
        public List<EnEstformatoDTO> ListFormatoXEstado(int ensayocodi, int iformatocodi)
        {
            List<EnEstformatoDTO> entitys = new List<EnEstformatoDTO>();
            string query = string.Format(helper.SqlListFormatoXEstado, ensayocodi, iformatocodi);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            EnEstformatoDTO entity = new EnEstformatoDTO();
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = helper.Create(dr);                    
                    int iformatodesc = dr.GetOrdinal("formatodesc");
                    int iestadoNombre = dr.GetOrdinal("estadoNombre"); 
                    int iEstadocolor = dr.GetOrdinal("estadocolor");                    
                    if (!dr.IsDBNull(iformatodesc)) entity.formatodesc = dr.GetString(iformatodesc);
                    if (!dr.IsDBNull(iestadoNombre)) entity.estadoNombre = dr.GetString(iestadoNombre);
                    if (!dr.IsDBNull(iEstadocolor)) entity.estadoColor = dr.GetString(iEstadocolor);
                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<EnEstformatoDTO> GetByCriteria()
        {
            List<EnEstformatoDTO> entitys = new List<EnEstformatoDTO>();
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
