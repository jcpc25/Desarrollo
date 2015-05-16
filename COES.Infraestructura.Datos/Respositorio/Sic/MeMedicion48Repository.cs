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
    /// Clase de acceso a datos de la tabla ME_MEDICION48
    /// </summary>
    public class MeMedicion48Repository: RepositoryBase, IMeMedicion48Repository
    {
        public MeMedicion48Repository(string strConn): base(strConn)
        {
        }

        MeMedicion48Helper helper = new MeMedicion48Helper();

        public void Save(MeMedicion48DTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Lectcodi, DbType.Int32, entity.Lectcodi);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, entity.Medifecha);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, entity.Tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
            dbProvider.AddInParameter(command, helper.H1, DbType.Decimal, entity.H1);
            dbProvider.AddInParameter(command, helper.Meditotal, DbType.Decimal, entity.Meditotal);
            dbProvider.AddInParameter(command, helper.Mediestado, DbType.String, entity.Mediestado);
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
            dbProvider.AddInParameter(command, helper.H25, DbType.Decimal, entity.H25);
            dbProvider.AddInParameter(command, helper.H26, DbType.Decimal, entity.H26);
            dbProvider.AddInParameter(command, helper.H27, DbType.Decimal, entity.H27);
            dbProvider.AddInParameter(command, helper.H28, DbType.Decimal, entity.H28);
            dbProvider.AddInParameter(command, helper.H29, DbType.Decimal, entity.H29);
            dbProvider.AddInParameter(command, helper.H30, DbType.Decimal, entity.H30);
            dbProvider.AddInParameter(command, helper.H31, DbType.Decimal, entity.H31);
            dbProvider.AddInParameter(command, helper.H32, DbType.Decimal, entity.H32);
            dbProvider.AddInParameter(command, helper.H33, DbType.Decimal, entity.H33);
            dbProvider.AddInParameter(command, helper.H34, DbType.Decimal, entity.H34);
            dbProvider.AddInParameter(command, helper.H35, DbType.Decimal, entity.H35);
            dbProvider.AddInParameter(command, helper.H36, DbType.Decimal, entity.H36);
            dbProvider.AddInParameter(command, helper.H37, DbType.Decimal, entity.H37);
            dbProvider.AddInParameter(command, helper.H38, DbType.Decimal, entity.H38);
            dbProvider.AddInParameter(command, helper.H39, DbType.Decimal, entity.H39);
            dbProvider.AddInParameter(command, helper.H40, DbType.Decimal, entity.H40);
            dbProvider.AddInParameter(command, helper.H41, DbType.Decimal, entity.H41);
            dbProvider.AddInParameter(command, helper.H42, DbType.Decimal, entity.H42);
            dbProvider.AddInParameter(command, helper.H43, DbType.Decimal, entity.H43);
            dbProvider.AddInParameter(command, helper.H44, DbType.Decimal, entity.H44);
            dbProvider.AddInParameter(command, helper.H45, DbType.Decimal, entity.H45);
            dbProvider.AddInParameter(command, helper.H46, DbType.Decimal, entity.H46);
            dbProvider.AddInParameter(command, helper.H47, DbType.Decimal, entity.H47);
            dbProvider.AddInParameter(command, helper.H48, DbType.Decimal, entity.H48);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(MeMedicion48DTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Lectcodi, DbType.Int32, entity.Lectcodi);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, entity.Medifecha);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, entity.Tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
            dbProvider.AddInParameter(command, helper.H1, DbType.Decimal, entity.H1);
            dbProvider.AddInParameter(command, helper.Meditotal, DbType.Decimal, entity.Meditotal);
            dbProvider.AddInParameter(command, helper.Mediestado, DbType.String, entity.Mediestado);
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
            dbProvider.AddInParameter(command, helper.H25, DbType.Decimal, entity.H25);
            dbProvider.AddInParameter(command, helper.H26, DbType.Decimal, entity.H26);
            dbProvider.AddInParameter(command, helper.H27, DbType.Decimal, entity.H27);
            dbProvider.AddInParameter(command, helper.H28, DbType.Decimal, entity.H28);
            dbProvider.AddInParameter(command, helper.H29, DbType.Decimal, entity.H29);
            dbProvider.AddInParameter(command, helper.H30, DbType.Decimal, entity.H30);
            dbProvider.AddInParameter(command, helper.H31, DbType.Decimal, entity.H31);
            dbProvider.AddInParameter(command, helper.H32, DbType.Decimal, entity.H32);
            dbProvider.AddInParameter(command, helper.H33, DbType.Decimal, entity.H33);
            dbProvider.AddInParameter(command, helper.H34, DbType.Decimal, entity.H34);
            dbProvider.AddInParameter(command, helper.H35, DbType.Decimal, entity.H35);
            dbProvider.AddInParameter(command, helper.H36, DbType.Decimal, entity.H36);
            dbProvider.AddInParameter(command, helper.H37, DbType.Decimal, entity.H37);
            dbProvider.AddInParameter(command, helper.H38, DbType.Decimal, entity.H38);
            dbProvider.AddInParameter(command, helper.H39, DbType.Decimal, entity.H39);
            dbProvider.AddInParameter(command, helper.H40, DbType.Decimal, entity.H40);
            dbProvider.AddInParameter(command, helper.H41, DbType.Decimal, entity.H41);
            dbProvider.AddInParameter(command, helper.H42, DbType.Decimal, entity.H42);
            dbProvider.AddInParameter(command, helper.H43, DbType.Decimal, entity.H43);
            dbProvider.AddInParameter(command, helper.H44, DbType.Decimal, entity.H44);
            dbProvider.AddInParameter(command, helper.H45, DbType.Decimal, entity.H45);
            dbProvider.AddInParameter(command, helper.H46, DbType.Decimal, entity.H46);
            dbProvider.AddInParameter(command, helper.H47, DbType.Decimal, entity.H47);
            dbProvider.AddInParameter(command, helper.H48, DbType.Decimal, entity.H48);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int lectcodi, DateTime medifecha, int tipoinfocodi, int ptomedicodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Lectcodi, DbType.Int32, lectcodi);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, medifecha);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, ptomedicodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public MeMedicion48DTO GetById(int lectcodi, DateTime medifecha, int tipoinfocodi, int ptomedicodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Lectcodi, DbType.Int32, lectcodi);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, medifecha);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, ptomedicodi);
            MeMedicion48DTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<MeMedicion48DTO> List()
        {
            List<MeMedicion48DTO> entitys = new List<MeMedicion48DTO>();
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

        public List<MeMedicion48DTO> GetByCriteria()
        {
            List<MeMedicion48DTO> entitys = new List<MeMedicion48DTO>();
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

        public List<MeMedicion48DTO> GetHidrologia(int idLectura,int idOrigenLectura,string idsEmpresa,string idsCuenca,DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion48DTO> entitys = new List<MeMedicion48DTO>();
            string sqlQuery = string.Format(helper.SqlGetHidrologia, idLectura, idOrigenLectura, idsEmpresa, fechaInicio.ToString(ConstantesBase.FormatoFecha),
                fechaFin.ToString(ConstantesBase.FormatoFecha), idsCuenca);

            DbCommand command = dbProvider.GetSqlStringCommand(sqlQuery);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion48DTO entity = helper.Create(dr);
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

        public List<MeMedicion48DTO> ObtenerGeneracionRER(int idEmpresa, int lectCodi, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion48DTO> entitys = new List<MeMedicion48DTO>();

            string query = String.Format(helper.SqlGetGeneracionRER, lectCodi, fechaInicio.ToString(ConstantesBase.FormatoFecha), 
                fechaFin.ToString(ConstantesBase.FormatoFecha), idEmpresa);

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public void EliminarValoresCargados(int idEmpresa, int lectCodi, DateTime fechaInicio, DateTime fechaFin)
        {
            string query = String.Format(helper.SqlDeleteGeneracionRER, lectCodi, fechaInicio.ToString(ConstantesBase.FormatoFecha),
               fechaFin.ToString(ConstantesBase.FormatoFecha), idEmpresa);

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            dbProvider.ExecuteNonQuery(command);
        }


        public bool ValidarExistenciaDatos(int idEmpresa, int lectCodi, DateTime fechaInicio, DateTime fechaFin)
        {
            String query = String.Format(helper.SqlValidarExistenciaRER, lectCodi, fechaInicio.ToString(ConstantesBase.FormatoFecha),
                   fechaFin.ToString(ConstantesBase.FormatoFecha), idEmpresa);

            DbCommand command = dbProvider.GetSqlStringCommand(query);
            object result = dbProvider.ExecuteScalar(command);

            if (Convert.ToInt32(result) > 0) return true;

            return false;
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

        public List<MeMedicion48DTO> GetEnvioArchivo(int idFormato, int idEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion48DTO> entitys = new List<MeMedicion48DTO>();
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

        public List<MeMedicion48DTO> ObteneReporteValidacionMedidores(string empresas, int tipoGrupoCodi, string fuenteEnergia,
    DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion48DTO> entitys = new List<MeMedicion48DTO>();

            String query = String.Format(this.helper.SqlObteneReporteValidacionMedidores, empresas, tipoGrupoCodi, fuenteEnergia,
                       fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion48DTO entity = new MeMedicion48DTO();

                    int iPtoMediCodi = dr.GetOrdinal(this.helper.Ptomedicodi);
                    if (!dr.IsDBNull(iPtoMediCodi)) entity.Ptomedicodi = Convert.ToInt32(dr.GetValue(iPtoMediCodi));

                    int iH1 = dr.GetOrdinal(this.helper.H1);
                    if (!dr.IsDBNull(iH1)) entity.H1 = dr.GetDecimal(iH1);

                    //for (int i = 1; i <= 48; i++)
                    //{
                    //    int indice = dr.GetOrdinal("H" + i);
                    //    if (!dr.IsDBNull(indice))
                    //    {
                    //        entity.GetType().GetProperty("H" + i).SetValue(entity, dr.GetDecimal(indice));
                    //    }
                    //}

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<MeMedicion48DTO> ObtenerReporteValidacionDespacho(string empresas, int tipoGrupoCodi, string fuenteEnergia,
            DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion48DTO> entitys = new List<MeMedicion48DTO>();

            String query = String.Format(this.helper.SqlObtenerReporteValidacionDespacho, empresas, tipoGrupoCodi, fuenteEnergia,
                       fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion48DTO entity = new MeMedicion48DTO();

                    int iPtoMediCodi = dr.GetOrdinal(this.helper.Ptomedicodi);
                    if (!dr.IsDBNull(iPtoMediCodi)) entity.Ptomedicodi = Convert.ToInt32(dr.GetValue(iPtoMediCodi));

                    int iH1 = dr.GetOrdinal(this.helper.H1);
                    if (!dr.IsDBNull(iH1)) entity.H1 = dr.GetDecimal(iH1);

                    //for (int i = 1; i <= 48; i++)
                    //{
                    //    int indice = dr.GetOrdinal("H" + i);
                    //    if (!dr.IsDBNull(indice))
                    //    {
                    //        entity.GetType().GetProperty("H" + i).SetValue(entity, dr.GetDecimal(indice));
                    //    }
                    //}

                    entitys.Add(entity);
                }
            }

            return entitys;
        }
        

    }
}
