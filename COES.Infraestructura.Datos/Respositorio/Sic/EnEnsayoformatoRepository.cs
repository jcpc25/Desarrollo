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
    /// Clase de acceso a datos de la tabla EN_ENSAYOFORMATO
    /// </summary>
    public class EnEnsayoformatoRepository: RepositoryBase, IEnEnsayoformatoRepository
    {
        public EnEnsayoformatoRepository(string strConn): base(strConn)
        {
        }

        EnEnsayoformatoHelper helper = new EnEnsayoformatoHelper();

        public void UpdateEstado(int ensformtestado, int ensayocodi, int formatocodi)
        {
            string query = string.Format(helper.SqlUpdateEstado, ensformtestado, ensayocodi, formatocodi);
            DbCommand command = dbProvider.GetSqlStringCommand(query);
            dbProvider.ExecuteNonQuery(command);
        }
        
        public void Update(EnEnsayoformatoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);
            dbProvider.AddInParameter(command, helper.Ensformatnombfisico, DbType.String, entity.Ensformatnombfisico);
            dbProvider.AddInParameter(command, helper.Ensformatnomblogico, DbType.String, entity.Ensformatnomblogico);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Ensformtestado, DbType.Int32, entity.Ensformtestado);
            dbProvider.AddInParameter(command, helper.Ensayocodi, DbType.Int32, entity.Ensayocodi);
            dbProvider.AddInParameter(command, helper.Formatocodi, DbType.Int32, entity.Formatocodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Save(EnEnsayoformatoDTO entity)
        {          
            string insertQuery = string.Format(helper.SqlSave, entity.Ensayocodi, entity.Formatocodi, entity.Ensformatnombfisico,
            entity.Ensformatnomblogico, ((DateTime)entity.Lastdate).ToString(ConstantesBase.FormatoFechaExtendido), entity.Lastuser, entity.Ensformtestado); 
             DbCommand command = dbProvider.GetSqlStringCommand(insertQuery);
            dbProvider.ExecuteNonQuery(command); 
        }

        public void Delete()
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);


            dbProvider.ExecuteNonQuery(command);
        }

        public EnEnsayoformatoDTO GetById(int ensayocodi, int formatocodi)
        {
            string query = string.Format(helper.SqlGetById, ensayocodi, formatocodi);
            DbCommand command = dbProvider.GetSqlStringCommand(query);
            EnEnsayoformatoDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }


        public List<EnEnsayoformatoDTO> List()
        {
            List<EnEnsayoformatoDTO> entitys = new List<EnEnsayoformatoDTO>();
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

        public List<EnEnsayoformatoDTO> GetByCriteria()
        {
            List<EnEnsayoformatoDTO> entitys = new List<EnEnsayoformatoDTO>();
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

        public List<EnEnsayoformatoDTO> ListaFormatoXEnsayo(int ensayocodi)
        {
            List<EnEnsayoformatoDTO> entitys = new List<EnEnsayoformatoDTO>();
            string query = string.Format(helper.SqlListaFormatoXEnsayo, ensayocodi);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            //DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListaDetalle); 
            EnEnsayoformatoDTO entity = new EnEnsayoformatoDTO();
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = helper.Create(dr);
                    int iformatodesc = dr.GetOrdinal("formatodesc");
                    int iEstenvnomb = dr.GetOrdinal("Estadonombre");
                    int iEstadocolor = dr.GetOrdinal("Estadocolor");
                    if (!dr.IsDBNull(iformatodesc)) entity.formatodesc = dr.GetString(iformatodesc);
                    if (!dr.IsDBNull(iEstenvnomb)) entity.Estenvnomb = dr.GetString(iEstenvnomb);
                    if (!dr.IsDBNull(iEstadocolor)) entity.Estadocolor = dr.GetString(iEstadocolor);
                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<EnEnsayoformatoDTO> ListaFormatoXEnsayoEmpresaCtral(int emprcodi, int equicodi)
        {
            List<EnEnsayoformatoDTO> entitys = new List<EnEnsayoformatoDTO>();
            string query = string.Format(helper.SqlListaFormatosEmpresaCentral, emprcodi, equicodi);
            DbCommand command = dbProvider.GetSqlStringCommand(query);
            EnEnsayoformatoDTO entity = new EnEnsayoformatoDTO();
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = helper.Create(dr);
                    //int iformatodesc = dr.GetOrdinal("formatodesc");
                    //int iEstenvnomb = dr.GetOrdinal("Estadonombre");
                    //int iEstadocolor = dr.GetOrdinal("Estadocolor");
                    //if (!dr.IsDBNull(iformatodesc)) entity.formatodesc = dr.GetString(iformatodesc);
                    //if (!dr.IsDBNull(iEstenvnomb)) entity.Estenvnomb = dr.GetString(iEstenvnomb);
                    //if (!dr.IsDBNull(iEstadocolor)) entity.Estadocolor = dr.GetString(iEstadocolor);
                    entitys.Add(entity);
                }
            }

            return entitys;
        }
    }
}
