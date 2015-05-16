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
    /// Clase de acceso a datos de la tabla SI_EMPRESA
    /// </summary>
    public class SiEmpresaRepository: RepositoryBase, ISiEmpresaRepository
    {
        public SiEmpresaRepository(string strConn): base(strConn)
        {
        }

        SiEmpresaHelper helper = new SiEmpresaHelper();

        public void Save(SiEmpresaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Emprnomb, DbType.String, entity.Emprnomb);
            dbProvider.AddInParameter(command, helper.Tipoemprcodi, DbType.Int32, entity.Tipoemprcodi);
            dbProvider.AddInParameter(command, helper.Emprdire, DbType.String, entity.Emprdire);
            dbProvider.AddInParameter(command, helper.Emprtele, DbType.String, entity.Emprtele);
            dbProvider.AddInParameter(command, helper.Emprnumedocu, DbType.String, entity.Emprnumedocu);
            dbProvider.AddInParameter(command, helper.Tipodocucodi, DbType.String, entity.Tipodocucodi);
            dbProvider.AddInParameter(command, helper.Emprruc, DbType.String, entity.Emprruc);
            dbProvider.AddInParameter(command, helper.Emprabrev, DbType.String, entity.Emprabrev);
            dbProvider.AddInParameter(command, helper.Emprorden, DbType.Int32, entity.Emprorden);
            dbProvider.AddInParameter(command, helper.Emprdom, DbType.String, entity.Emprdom);
            dbProvider.AddInParameter(command, helper.Emprsein, DbType.String, entity.Emprsein);
            dbProvider.AddInParameter(command, helper.Emprrazsocial, DbType.String, entity.Emprrazsocial);
            dbProvider.AddInParameter(command, helper.Emprcoes, DbType.String, entity.Emprcoes);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Inddemanda, DbType.String, entity.Inddemanda);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(SiEmpresaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Emprnomb, DbType.String, entity.Emprnomb);
            dbProvider.AddInParameter(command, helper.Tipoemprcodi, DbType.Int32, entity.Tipoemprcodi);
            dbProvider.AddInParameter(command, helper.Emprdire, DbType.String, entity.Emprdire);
            dbProvider.AddInParameter(command, helper.Emprtele, DbType.String, entity.Emprtele);
            dbProvider.AddInParameter(command, helper.Emprnumedocu, DbType.String, entity.Emprnumedocu);
            dbProvider.AddInParameter(command, helper.Tipodocucodi, DbType.String, entity.Tipodocucodi);
            dbProvider.AddInParameter(command, helper.Emprruc, DbType.String, entity.Emprruc);
            dbProvider.AddInParameter(command, helper.Emprabrev, DbType.String, entity.Emprabrev);
            dbProvider.AddInParameter(command, helper.Emprorden, DbType.Int32, entity.Emprorden);
            dbProvider.AddInParameter(command, helper.Emprdom, DbType.String, entity.Emprdom);
            dbProvider.AddInParameter(command, helper.Emprsein, DbType.String, entity.Emprsein);
            dbProvider.AddInParameter(command, helper.Emprrazsocial, DbType.String, entity.Emprrazsocial);
            dbProvider.AddInParameter(command, helper.Emprcoes, DbType.String, entity.Emprcoes);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Inddemanda, DbType.String, entity.Inddemanda);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int emprcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, emprcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public SiEmpresaDTO GetById(int emprcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, emprcodi);
            SiEmpresaDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<SiEmpresaDTO> List(int tipoemprcodi)
        {
            List<SiEmpresaDTO> entitys = new List<SiEmpresaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);
            dbProvider.AddInParameter(command, helper.Tipoemprcodi, DbType.Int32, tipoemprcodi);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys ;
        }

        public List<SiEmpresaDTO> GetByCriteria(string tiposEmpresa)
        {
            List<SiEmpresaDTO> entitys = new List<SiEmpresaDTO>();

            String sql = String.Format(helper.SqlGetByCriteria, tiposEmpresa);
            DbCommand command = dbProvider.GetSqlStringCommand(sql);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<SiEmpresaDTO> GetByUser(string userlogin)
        {
            List<SiEmpresaDTO> entitys = new List<SiEmpresaDTO>();

            String sql = String.Format(helper.SqlGetByUser, userlogin);
            DbCommand command = dbProvider.GetSqlStringCommand(sql);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<SiEmpresaDTO> ObtenerEmpresasSEIN()
        {
            List<SiEmpresaDTO> entitys = new List<SiEmpresaDTO>();
                       
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetEmpresasSein);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<SiEmpresaDTO> ObtenerEmpresasxCombustible(string tipocombustible)
        {
            List<SiEmpresaDTO> entitys = new List<SiEmpresaDTO>();
            string query = string.Format(helper.sqlGetEmpresasxCombustible, tipocombustible);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    SiEmpresaDTO entity = new SiEmpresaDTO();
                    int iEmprnomb = dr.GetOrdinal("Emprnomb");
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);
                    int iEmprcodi = dr.GetOrdinal("Emprcodi");
                    if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));
                    entitys.Add(entity);
                }
            }

            return entitys;

        }

        public List<SiEmpresaDTO> ObtenerEmpresasxCombustiblexUsuario(string tipocombustible, string usuario)
        {
            List<SiEmpresaDTO> entitys = new List<SiEmpresaDTO>();
            string query = string.Format(helper.SqlGetEmpresasxCombustiblexUsuario, tipocombustible, usuario);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    SiEmpresaDTO entity = new SiEmpresaDTO();
                    int iEmprnomb = dr.GetOrdinal("Emprnomb");
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);
                    int iEmprcodi = dr.GetOrdinal("Emprcodi");
                    if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));
                    entitys.Add(entity);
                }
            }

            return entitys;

        }

    }
}
