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
    /// Clase de acceso a datos de la tabla ME_MEDICION24
    /// </summary>
    public class MeMedicion24Repository: RepositoryBase, IMeMedicion24Repository
    {
        public MeMedicion24Repository(string strConn): base(strConn)
        {
        }

        MeMedicion24Helper helper = new MeMedicion24Helper();

        public void Save(MeMedicion24DTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Lectcodi, DbType.Int32, entity.Lectcodi);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, entity.Medifecha);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, entity.Tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
            dbProvider.AddInParameter(command, helper.Meditotal, DbType.Decimal, entity.Meditotal);
            dbProvider.AddInParameter(command, helper.Mediestado, DbType.String, entity.Mediestado);
            dbProvider.AddInParameter(command, helper.H1, DbType.Decimal, entity.H1);
            dbProvider.AddInParameter(command, helper.H2, DbType.Decimal, entity.H2);
            dbProvider.AddInParameter(command, helper.H3, DbType.Decimal, entity.H3);
            dbProvider.AddInParameter(command, helper.H4, DbType.Decimal, entity.H4);
            dbProvider.AddInParameter(command, helper.H5, DbType.Decimal, entity.H5);
            dbProvider.AddInParameter(command, helper.H6, DbType.Decimal, entity.H6);
            dbProvider.AddInParameter(command, helper.H7, DbType.Decimal, entity.H7);
            dbProvider.AddInParameter(command, helper.H8, DbType.Decimal, entity.H8);
            dbProvider.AddInParameter(command, helper.H9, DbType.Decimal, entity.H9);
            dbProvider.AddInParameter(command, helper.H10, DbType.Decimal, entity.H10);
            dbProvider.AddInParameter(command, helper.H11, DbType.Decimal, entity.H11);
            dbProvider.AddInParameter(command, helper.H12, DbType.Decimal, entity.H12);
            dbProvider.AddInParameter(command, helper.H13, DbType.Decimal, entity.H13);
            dbProvider.AddInParameter(command, helper.H14, DbType.Decimal, entity.H14);
            dbProvider.AddInParameter(command, helper.H15, DbType.Decimal, entity.H15);
            dbProvider.AddInParameter(command, helper.H16, DbType.Decimal, entity.H16);
            dbProvider.AddInParameter(command, helper.H17, DbType.Decimal, entity.H17);
            dbProvider.AddInParameter(command, helper.H18, DbType.Decimal, entity.H18);
            dbProvider.AddInParameter(command, helper.H19, DbType.Decimal, entity.H19);
            dbProvider.AddInParameter(command, helper.H20, DbType.Decimal, entity.H20);
            dbProvider.AddInParameter(command, helper.H21, DbType.Decimal, entity.H21);
            dbProvider.AddInParameter(command, helper.H22, DbType.Decimal, entity.H22);
            dbProvider.AddInParameter(command, helper.H23, DbType.Decimal, entity.H23);
            dbProvider.AddInParameter(command, helper.H24, DbType.Decimal, entity.H24);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);


            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(MeMedicion24DTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Lectcodi, DbType.Int32, entity.Lectcodi);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, entity.Medifecha);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, entity.Tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
            dbProvider.AddInParameter(command, helper.Meditotal, DbType.Decimal, entity.Meditotal);
            dbProvider.AddInParameter(command, helper.Mediestado, DbType.String, entity.Mediestado);
            dbProvider.AddInParameter(command, helper.H1, DbType.Decimal, entity.H1);
            dbProvider.AddInParameter(command, helper.H2, DbType.Decimal, entity.H2);
            dbProvider.AddInParameter(command, helper.H3, DbType.Decimal, entity.H3);
            dbProvider.AddInParameter(command, helper.H4, DbType.Decimal, entity.H4);
            dbProvider.AddInParameter(command, helper.H5, DbType.Decimal, entity.H5);
            dbProvider.AddInParameter(command, helper.H6, DbType.Decimal, entity.H6);
            dbProvider.AddInParameter(command, helper.H7, DbType.Decimal, entity.H7);
            dbProvider.AddInParameter(command, helper.H8, DbType.Decimal, entity.H8);
            dbProvider.AddInParameter(command, helper.H9, DbType.Decimal, entity.H9);
            dbProvider.AddInParameter(command, helper.H10, DbType.Decimal, entity.H10);
            dbProvider.AddInParameter(command, helper.H11, DbType.Decimal, entity.H11);
            dbProvider.AddInParameter(command, helper.H12, DbType.Decimal, entity.H12);
            dbProvider.AddInParameter(command, helper.H13, DbType.Decimal, entity.H13);
            dbProvider.AddInParameter(command, helper.H14, DbType.Decimal, entity.H14);
            dbProvider.AddInParameter(command, helper.H15, DbType.Decimal, entity.H15);
            dbProvider.AddInParameter(command, helper.H16, DbType.Decimal, entity.H16);
            dbProvider.AddInParameter(command, helper.H17, DbType.Decimal, entity.H17);
            dbProvider.AddInParameter(command, helper.H18, DbType.Decimal, entity.H18);
            dbProvider.AddInParameter(command, helper.H19, DbType.Decimal, entity.H19);
            dbProvider.AddInParameter(command, helper.H20, DbType.Decimal, entity.H20);
            dbProvider.AddInParameter(command, helper.H21, DbType.Decimal, entity.H21);
            dbProvider.AddInParameter(command, helper.H22, DbType.Decimal, entity.H22);
            dbProvider.AddInParameter(command, helper.H23, DbType.Decimal, entity.H23);
            dbProvider.AddInParameter(command, helper.H24, DbType.Decimal, entity.H24);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);


            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete()
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);


            dbProvider.ExecuteNonQuery(command);
        }

        public MeMedicion24DTO GetById()
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            MeMedicion24DTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<MeMedicion24DTO> List()
        {
            List<MeMedicion24DTO> entitys = new List<MeMedicion24DTO>();
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

        public List<MeMedicion24DTO> GetByCriteria()
        {
            List<MeMedicion24DTO> entitys = new List<MeMedicion24DTO>();
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

        /// <summary>
        /// Borra las mediciones enviadas en un archivo
        /// </summary>
        /// <param name="medifecha"></param>
        public void DeleteEnvioArchivo(int idLectura, DateTime fechaInicio, DateTime fechaFin, int idFormato, int idEmpresa)
        {
            string sqlDelete = string.Format(helper.SqlDeleteEnvioArchivo, idLectura, fechaInicio.ToString(ConstantesBase.FormatoFecha),
              fechaInicio.ToString(ConstantesBase.FormatoFecha), idFormato, idEmpresa);

            DbCommand command = dbProvider.GetSqlStringCommand(sqlDelete);
            dbProvider.ExecuteNonQuery(command);
        }

        public List<MeMedicion24DTO> GetEnvioArchivo(int idFormato,int idEmpresa,DateTime fechaInicio,DateTime fechaFin)
        {
            List<MeMedicion24DTO> entitys = new List<MeMedicion24DTO>();
            string queryString = string.Format(helper.SqlGetEnvioArchivo, idFormato, idEmpresa, fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));
            DbCommand command = dbProvider.GetSqlStringCommand(queryString);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<MeMedicion24DTO> GetHidrologia(int idLectura, int idOrigenLectura, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion24DTO> entitys = new List<MeMedicion24DTO>();
            string sqlQuery = string.Format(helper.SqlGetHidrologia, idLectura, idOrigenLectura, fechaInicio.ToString(ConstantesBase.FormatoFecha),
                fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(sqlQuery);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion24DTO entity = helper.Create(dr);
                    int iEquinomb = dr.GetOrdinal("Equinomb");
                    if (!dr.IsDBNull(iEquinomb)) entity.Equinomb = dr.GetString(iEquinomb);
                    int iTipoptomedinomb = dr.GetOrdinal("Tipoptomedinomb");
                    if (!dr.IsDBNull(iEquinomb)) entity.Tipoptomedinomb = dr.GetString(iTipoptomedinomb);
                    int iTipoinfoabrev = dr.GetOrdinal("Tipoinfoabrev");
                    if (!dr.IsDBNull(iTipoinfoabrev)) entity.Tipoinfoabrev = dr.GetString(iTipoinfoabrev);
                    entitys.Add(entity);
                }
            }

            return entitys;
        }

    }
}
