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
    /// Clase de acceso a datos de la tabla ME_HOJAPTOMED
    /// </summary>
    public class MeHojaptomedRepository: RepositoryBase, IMeHojaptomedRepository
    {
        public MeHojaptomedRepository(string strConn): base(strConn)
        {
        }

        MeHojaptomedHelper helper = new MeHojaptomedHelper();


        public void Save(MeHojaptomedDTO entity,int empresa)
        {
            string sqlMax = string.Format(helper.SqlGetMaxOrder, entity.Hojanumero, entity.Formatcodi, empresa);
            DbCommand command = dbProvider.GetSqlStringCommand(sqlMax);
            object result = dbProvider.ExecuteScalar(command);
            int order = 1;
            if (result != null) order = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
            dbProvider.AddInParameter(command, helper.Hojaptolimsup, DbType.Decimal, entity.Hojaptolimsup);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, entity.Tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Formatcodi, DbType.Int32, entity.Formatcodi);
            dbProvider.AddInParameter(command, helper.Hojanumero, DbType.Int32, entity.Hojanumero);
            dbProvider.AddInParameter(command, helper.Hojaptoliminf, DbType.Decimal, entity.Hojaptoliminf);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Hojaptoactivo, DbType.Int32, entity.Hojaptoactivo);
            dbProvider.AddInParameter(command, helper.Hojaptoorden, DbType.Int32,order);
            dbProvider.AddInParameter(command, helper.Hojaptosigno, DbType.Int32, entity.Hojaptosigno);

            dbProvider.ExecuteNonQuery(command);

        }

        public void Update(MeHojaptomedDTO entity)
        {

            string sqlUptade = string.Format(helper.SqlUpdate, entity.Hojaptolimsup == null ? "null" : entity.Hojaptolimsup.ToString(), entity.Hojaptoliminf, entity.Lastuser,
                entity.Lastdate.Value.ToString(ConstantesBase.FormatoFechaExtendido), entity.Hojaptoactivo, entity.Hojaptoorden,
                entity.Ptomedicodi, entity.Tipoinfocodi, entity.Formatcodi, entity.Hojanumero, entity.Hojaptosigno);
            DbCommand command = dbProvider.GetSqlStringCommand(sqlUptade);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int hojanumero, int formatcodi, int tipoinfocodi, int ptomedicodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Hojanumero, DbType.Int32, hojanumero);
            dbProvider.AddInParameter(command, helper.Formatcodi, DbType.Int32, formatcodi);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, ptomedicodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public MeHojaptomedDTO GetById(int hojanumero, int formatcodi, int tipoinfocodi, int ptomedicodi, int hojaptosigno)
        {
            
            
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Hojanumero, DbType.Int32, hojanumero);
            dbProvider.AddInParameter(command, helper.Formatcodi, DbType.Int32, formatcodi);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, ptomedicodi);
            dbProvider.AddInParameter(command, helper.Hojaptosigno, DbType.Int32, hojaptosigno);
            MeHojaptomedDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                    entity.Tipoinfoabrev = dr.GetString(dr.GetOrdinal("Tipoinfoabrev"));
                    entity.Equinomb = dr.GetString(dr.GetOrdinal("Equinomb"));
                    entity.Emprabrev = dr.GetString(dr.GetOrdinal("Emprabrev"));
                    entity.Tipoptomedinomb = dr.GetString(dr.GetOrdinal("Tipoptomedinomb"));
                }
            }

            return entity;
        }

        public List<MeHojaptomedDTO> List()
        {
            List<MeHojaptomedDTO> entitys = new List<MeHojaptomedDTO>();
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

        public List<MeHojaptomedDTO> GetByCriteria(int emprcodi, int formatcodi, int hojacodi)
        {
            List<MeHojaptomedDTO> entitys = new List<MeHojaptomedDTO>();
            string queryString = string.Format(helper.SqlGetByCriteria, emprcodi,formatcodi,hojacodi);
            DbCommand command = dbProvider.GetSqlStringCommand(queryString);
            MeHojaptomedDTO entity = new MeHojaptomedDTO();
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = helper.Create(dr);
                    entity.Tipoinfoabrev = dr.GetString(dr.GetOrdinal("Tipoinfoabrev"));
                    entity.Equinomb = dr.GetString(dr.GetOrdinal("Equinomb"));
                    entity.Emprabrev = dr.GetString(dr.GetOrdinal("Emprabrev"));
                    entity.Tipoptomedicodi = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("Tipoptomedicodi")));
                    entity.Tipoptomedinomb = dr.GetString(dr.GetOrdinal("Tipoptomedinomb"));
                    entitys.Add(entity);
                }
            }

            return entitys;
        }
    }
}
