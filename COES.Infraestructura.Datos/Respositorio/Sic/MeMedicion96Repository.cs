using COES.Base.Core;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Sic;
using COES.Infraestructura.Datos.Helper.Sic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    public class MeMedicion96Repository : RepositoryBase, IMeMedicion96Repository
    {
        public MeMedicion96Repository(string strConn)
            : base(strConn)
        {
        }

        MeMedicion96Helper helper = new MeMedicion96Helper();

        public void Save(MeMedicion96DTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.H96, DbType.Decimal, entity.H96);
            dbProvider.AddInParameter(command, helper.H95, DbType.Decimal, entity.H95);
            dbProvider.AddInParameter(command, helper.H94, DbType.Decimal, entity.H94);
            dbProvider.AddInParameter(command, helper.H93, DbType.Decimal, entity.H93);
            dbProvider.AddInParameter(command, helper.H92, DbType.Decimal, entity.H92);
            dbProvider.AddInParameter(command, helper.H91, DbType.Decimal, entity.H91);
            dbProvider.AddInParameter(command, helper.H90, DbType.Decimal, entity.H90);
            dbProvider.AddInParameter(command, helper.H89, DbType.Decimal, entity.H89);
            dbProvider.AddInParameter(command, helper.H88, DbType.Decimal, entity.H88);
            dbProvider.AddInParameter(command, helper.H87, DbType.Decimal, entity.H87);
            dbProvider.AddInParameter(command, helper.H86, DbType.Decimal, entity.H86);
            dbProvider.AddInParameter(command, helper.H85, DbType.Decimal, entity.H85);
            dbProvider.AddInParameter(command, helper.H84, DbType.Decimal, entity.H84);
            dbProvider.AddInParameter(command, helper.H83, DbType.Decimal, entity.H83);
            dbProvider.AddInParameter(command, helper.H82, DbType.Decimal, entity.H82);
            dbProvider.AddInParameter(command, helper.H81, DbType.Decimal, entity.H81);
            dbProvider.AddInParameter(command, helper.H80, DbType.Decimal, entity.H80);
            dbProvider.AddInParameter(command, helper.H79, DbType.Decimal, entity.H79);
            dbProvider.AddInParameter(command, helper.H78, DbType.Decimal, entity.H78);
            dbProvider.AddInParameter(command, helper.H77, DbType.Decimal, entity.H77);
            dbProvider.AddInParameter(command, helper.H76, DbType.Decimal, entity.H76);
            dbProvider.AddInParameter(command, helper.H75, DbType.Decimal, entity.H75);
            dbProvider.AddInParameter(command, helper.H74, DbType.Decimal, entity.H74);
            dbProvider.AddInParameter(command, helper.H73, DbType.Decimal, entity.H73);
            dbProvider.AddInParameter(command, helper.H72, DbType.Decimal, entity.H72);
            dbProvider.AddInParameter(command, helper.H71, DbType.Decimal, entity.H71);
            dbProvider.AddInParameter(command, helper.H70, DbType.Decimal, entity.H70);
            dbProvider.AddInParameter(command, helper.H69, DbType.Decimal, entity.H69);
            dbProvider.AddInParameter(command, helper.H68, DbType.Decimal, entity.H68);
            dbProvider.AddInParameter(command, helper.H67, DbType.Decimal, entity.H67);
            dbProvider.AddInParameter(command, helper.H66, DbType.Decimal, entity.H66);
            dbProvider.AddInParameter(command, helper.H65, DbType.Decimal, entity.H65);
            dbProvider.AddInParameter(command, helper.H64, DbType.Decimal, entity.H64);
            dbProvider.AddInParameter(command, helper.H63, DbType.Decimal, entity.H63);
            dbProvider.AddInParameter(command, helper.H62, DbType.Decimal, entity.H62);
            dbProvider.AddInParameter(command, helper.H61, DbType.Decimal, entity.H61);
            dbProvider.AddInParameter(command, helper.H60, DbType.Decimal, entity.H60);
            dbProvider.AddInParameter(command, helper.H59, DbType.Decimal, entity.H59);
            dbProvider.AddInParameter(command, helper.H58, DbType.Decimal, entity.H58);
            dbProvider.AddInParameter(command, helper.H57, DbType.Decimal, entity.H57);
            dbProvider.AddInParameter(command, helper.H56, DbType.Decimal, entity.H56);
            dbProvider.AddInParameter(command, helper.H55, DbType.Decimal, entity.H55);
            dbProvider.AddInParameter(command, helper.H54, DbType.Decimal, entity.H54);
            dbProvider.AddInParameter(command, helper.H53, DbType.Decimal, entity.H53);
            dbProvider.AddInParameter(command, helper.H52, DbType.Decimal, entity.H52);
            dbProvider.AddInParameter(command, helper.H51, DbType.Decimal, entity.H51);
            dbProvider.AddInParameter(command, helper.H50, DbType.Decimal, entity.H50);
            dbProvider.AddInParameter(command, helper.H49, DbType.Decimal, entity.H49);
            dbProvider.AddInParameter(command, helper.H48, DbType.Decimal, entity.H48);
            dbProvider.AddInParameter(command, helper.H47, DbType.Decimal, entity.H47);
            dbProvider.AddInParameter(command, helper.H46, DbType.Decimal, entity.H46);
            dbProvider.AddInParameter(command, helper.H45, DbType.Decimal, entity.H45);
            dbProvider.AddInParameter(command, helper.H44, DbType.Decimal, entity.H44);
            dbProvider.AddInParameter(command, helper.H43, DbType.Decimal, entity.H43);
            dbProvider.AddInParameter(command, helper.H42, DbType.Decimal, entity.H42);
            dbProvider.AddInParameter(command, helper.H41, DbType.Decimal, entity.H41);
            dbProvider.AddInParameter(command, helper.H40, DbType.Decimal, entity.H40);
            dbProvider.AddInParameter(command, helper.H39, DbType.Decimal, entity.H39);
            dbProvider.AddInParameter(command, helper.H38, DbType.Decimal, entity.H38);
            dbProvider.AddInParameter(command, helper.H37, DbType.Decimal, entity.H37);
            dbProvider.AddInParameter(command, helper.H36, DbType.Decimal, entity.H36);
            dbProvider.AddInParameter(command, helper.H35, DbType.Decimal, entity.H35);
            dbProvider.AddInParameter(command, helper.H34, DbType.Decimal, entity.H34);
            dbProvider.AddInParameter(command, helper.H33, DbType.Decimal, entity.H33);
            dbProvider.AddInParameter(command, helper.H32, DbType.Decimal, entity.H32);
            dbProvider.AddInParameter(command, helper.H31, DbType.Decimal, entity.H31);
            dbProvider.AddInParameter(command, helper.H30, DbType.Decimal, entity.H30);
            dbProvider.AddInParameter(command, helper.H29, DbType.Decimal, entity.H29);
            dbProvider.AddInParameter(command, helper.H28, DbType.Decimal, entity.H28);
            dbProvider.AddInParameter(command, helper.H27, DbType.Decimal, entity.H27);
            dbProvider.AddInParameter(command, helper.H26, DbType.Decimal, entity.H26);
            dbProvider.AddInParameter(command, helper.H25, DbType.Decimal, entity.H25);
            dbProvider.AddInParameter(command, helper.H24, DbType.Decimal, entity.H24);
            dbProvider.AddInParameter(command, helper.H23, DbType.Decimal, entity.H23);
            dbProvider.AddInParameter(command, helper.H22, DbType.Decimal, entity.H22);
            dbProvider.AddInParameter(command, helper.H21, DbType.Decimal, entity.H21);
            dbProvider.AddInParameter(command, helper.H20, DbType.Decimal, entity.H20);
            dbProvider.AddInParameter(command, helper.H19, DbType.Decimal, entity.H19);
            dbProvider.AddInParameter(command, helper.H18, DbType.Decimal, entity.H18);
            dbProvider.AddInParameter(command, helper.H17, DbType.Decimal, entity.H17);
            dbProvider.AddInParameter(command, helper.H16, DbType.Decimal, entity.H16);
            dbProvider.AddInParameter(command, helper.H15, DbType.Decimal, entity.H15);
            dbProvider.AddInParameter(command, helper.H14, DbType.Decimal, entity.H14);
            dbProvider.AddInParameter(command, helper.H13, DbType.Decimal, entity.H13);
            dbProvider.AddInParameter(command, helper.H12, DbType.Decimal, entity.H12);
            dbProvider.AddInParameter(command, helper.H11, DbType.Decimal, entity.H11);
            dbProvider.AddInParameter(command, helper.H10, DbType.Decimal, entity.H10);
            dbProvider.AddInParameter(command, helper.H9, DbType.Decimal, entity.H9);
            dbProvider.AddInParameter(command, helper.H8, DbType.Decimal, entity.H8);
            dbProvider.AddInParameter(command, helper.H7, DbType.Decimal, entity.H7);
            dbProvider.AddInParameter(command, helper.H6, DbType.Decimal, entity.H6);
            dbProvider.AddInParameter(command, helper.H5, DbType.Decimal, entity.H5);
            dbProvider.AddInParameter(command, helper.H4, DbType.Decimal, entity.H4);
            dbProvider.AddInParameter(command, helper.H3, DbType.Decimal, entity.H3);
            dbProvider.AddInParameter(command, helper.H2, DbType.Decimal, entity.H2);
            dbProvider.AddInParameter(command, helper.H1, DbType.Decimal, entity.H1);
            dbProvider.AddInParameter(command, helper.Mediestado, DbType.String, entity.Mediestado);
            dbProvider.AddInParameter(command, helper.Meditotal, DbType.Decimal, entity.Meditotal);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, entity.Tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, entity.Medifecha);
            dbProvider.AddInParameter(command, helper.Lectcodi, DbType.Int32, entity.Lectcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(MeMedicion96DTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.H96, DbType.Decimal, entity.H96);
            dbProvider.AddInParameter(command, helper.H95, DbType.Decimal, entity.H95);
            dbProvider.AddInParameter(command, helper.H94, DbType.Decimal, entity.H94);
            dbProvider.AddInParameter(command, helper.H93, DbType.Decimal, entity.H93);
            dbProvider.AddInParameter(command, helper.H92, DbType.Decimal, entity.H92);
            dbProvider.AddInParameter(command, helper.H91, DbType.Decimal, entity.H91);
            dbProvider.AddInParameter(command, helper.H90, DbType.Decimal, entity.H90);
            dbProvider.AddInParameter(command, helper.H89, DbType.Decimal, entity.H89);
            dbProvider.AddInParameter(command, helper.H88, DbType.Decimal, entity.H88);
            dbProvider.AddInParameter(command, helper.H87, DbType.Decimal, entity.H87);
            dbProvider.AddInParameter(command, helper.H86, DbType.Decimal, entity.H86);
            dbProvider.AddInParameter(command, helper.H85, DbType.Decimal, entity.H85);
            dbProvider.AddInParameter(command, helper.H84, DbType.Decimal, entity.H84);
            dbProvider.AddInParameter(command, helper.H83, DbType.Decimal, entity.H83);
            dbProvider.AddInParameter(command, helper.H82, DbType.Decimal, entity.H82);
            dbProvider.AddInParameter(command, helper.H81, DbType.Decimal, entity.H81);
            dbProvider.AddInParameter(command, helper.H80, DbType.Decimal, entity.H80);
            dbProvider.AddInParameter(command, helper.H79, DbType.Decimal, entity.H79);
            dbProvider.AddInParameter(command, helper.H78, DbType.Decimal, entity.H78);
            dbProvider.AddInParameter(command, helper.H77, DbType.Decimal, entity.H77);
            dbProvider.AddInParameter(command, helper.H76, DbType.Decimal, entity.H76);
            dbProvider.AddInParameter(command, helper.H75, DbType.Decimal, entity.H75);
            dbProvider.AddInParameter(command, helper.H74, DbType.Decimal, entity.H74);
            dbProvider.AddInParameter(command, helper.H73, DbType.Decimal, entity.H73);
            dbProvider.AddInParameter(command, helper.H72, DbType.Decimal, entity.H72);
            dbProvider.AddInParameter(command, helper.H71, DbType.Decimal, entity.H71);
            dbProvider.AddInParameter(command, helper.H70, DbType.Decimal, entity.H70);
            dbProvider.AddInParameter(command, helper.H69, DbType.Decimal, entity.H69);
            dbProvider.AddInParameter(command, helper.H68, DbType.Decimal, entity.H68);
            dbProvider.AddInParameter(command, helper.H67, DbType.Decimal, entity.H67);
            dbProvider.AddInParameter(command, helper.H66, DbType.Decimal, entity.H66);
            dbProvider.AddInParameter(command, helper.H65, DbType.Decimal, entity.H65);
            dbProvider.AddInParameter(command, helper.H64, DbType.Decimal, entity.H64);
            dbProvider.AddInParameter(command, helper.H63, DbType.Decimal, entity.H63);
            dbProvider.AddInParameter(command, helper.H62, DbType.Decimal, entity.H62);
            dbProvider.AddInParameter(command, helper.H61, DbType.Decimal, entity.H61);
            dbProvider.AddInParameter(command, helper.H60, DbType.Decimal, entity.H60);
            dbProvider.AddInParameter(command, helper.H59, DbType.Decimal, entity.H59);
            dbProvider.AddInParameter(command, helper.H58, DbType.Decimal, entity.H58);
            dbProvider.AddInParameter(command, helper.H57, DbType.Decimal, entity.H57);
            dbProvider.AddInParameter(command, helper.H56, DbType.Decimal, entity.H56);
            dbProvider.AddInParameter(command, helper.H55, DbType.Decimal, entity.H55);
            dbProvider.AddInParameter(command, helper.H54, DbType.Decimal, entity.H54);
            dbProvider.AddInParameter(command, helper.H53, DbType.Decimal, entity.H53);
            dbProvider.AddInParameter(command, helper.H52, DbType.Decimal, entity.H52);
            dbProvider.AddInParameter(command, helper.H51, DbType.Decimal, entity.H51);
            dbProvider.AddInParameter(command, helper.H50, DbType.Decimal, entity.H50);
            dbProvider.AddInParameter(command, helper.H49, DbType.Decimal, entity.H49);
            dbProvider.AddInParameter(command, helper.H48, DbType.Decimal, entity.H48);
            dbProvider.AddInParameter(command, helper.H47, DbType.Decimal, entity.H47);
            dbProvider.AddInParameter(command, helper.H46, DbType.Decimal, entity.H46);
            dbProvider.AddInParameter(command, helper.H45, DbType.Decimal, entity.H45);
            dbProvider.AddInParameter(command, helper.H44, DbType.Decimal, entity.H44);
            dbProvider.AddInParameter(command, helper.H43, DbType.Decimal, entity.H43);
            dbProvider.AddInParameter(command, helper.H42, DbType.Decimal, entity.H42);
            dbProvider.AddInParameter(command, helper.H41, DbType.Decimal, entity.H41);
            dbProvider.AddInParameter(command, helper.H40, DbType.Decimal, entity.H40);
            dbProvider.AddInParameter(command, helper.H39, DbType.Decimal, entity.H39);
            dbProvider.AddInParameter(command, helper.H38, DbType.Decimal, entity.H38);
            dbProvider.AddInParameter(command, helper.H37, DbType.Decimal, entity.H37);
            dbProvider.AddInParameter(command, helper.H36, DbType.Decimal, entity.H36);
            dbProvider.AddInParameter(command, helper.H35, DbType.Decimal, entity.H35);
            dbProvider.AddInParameter(command, helper.H34, DbType.Decimal, entity.H34);
            dbProvider.AddInParameter(command, helper.H33, DbType.Decimal, entity.H33);
            dbProvider.AddInParameter(command, helper.H32, DbType.Decimal, entity.H32);
            dbProvider.AddInParameter(command, helper.H31, DbType.Decimal, entity.H31);
            dbProvider.AddInParameter(command, helper.H30, DbType.Decimal, entity.H30);
            dbProvider.AddInParameter(command, helper.H29, DbType.Decimal, entity.H29);
            dbProvider.AddInParameter(command, helper.H28, DbType.Decimal, entity.H28);
            dbProvider.AddInParameter(command, helper.H27, DbType.Decimal, entity.H27);
            dbProvider.AddInParameter(command, helper.H26, DbType.Decimal, entity.H26);
            dbProvider.AddInParameter(command, helper.H25, DbType.Decimal, entity.H25);
            dbProvider.AddInParameter(command, helper.H24, DbType.Decimal, entity.H24);
            dbProvider.AddInParameter(command, helper.H23, DbType.Decimal, entity.H23);
            dbProvider.AddInParameter(command, helper.H22, DbType.Decimal, entity.H22);
            dbProvider.AddInParameter(command, helper.H21, DbType.Decimal, entity.H21);
            dbProvider.AddInParameter(command, helper.H20, DbType.Decimal, entity.H20);
            dbProvider.AddInParameter(command, helper.H19, DbType.Decimal, entity.H19);
            dbProvider.AddInParameter(command, helper.H18, DbType.Decimal, entity.H18);
            dbProvider.AddInParameter(command, helper.H17, DbType.Decimal, entity.H17);
            dbProvider.AddInParameter(command, helper.H16, DbType.Decimal, entity.H16);
            dbProvider.AddInParameter(command, helper.H15, DbType.Decimal, entity.H15);
            dbProvider.AddInParameter(command, helper.H14, DbType.Decimal, entity.H14);
            dbProvider.AddInParameter(command, helper.H13, DbType.Decimal, entity.H13);
            dbProvider.AddInParameter(command, helper.H12, DbType.Decimal, entity.H12);
            dbProvider.AddInParameter(command, helper.H11, DbType.Decimal, entity.H11);
            dbProvider.AddInParameter(command, helper.H10, DbType.Decimal, entity.H10);
            dbProvider.AddInParameter(command, helper.H9, DbType.Decimal, entity.H9);
            dbProvider.AddInParameter(command, helper.H8, DbType.Decimal, entity.H8);
            dbProvider.AddInParameter(command, helper.H7, DbType.Decimal, entity.H7);
            dbProvider.AddInParameter(command, helper.H6, DbType.Decimal, entity.H6);
            dbProvider.AddInParameter(command, helper.H5, DbType.Decimal, entity.H5);
            dbProvider.AddInParameter(command, helper.H4, DbType.Decimal, entity.H4);
            dbProvider.AddInParameter(command, helper.H3, DbType.Decimal, entity.H3);
            dbProvider.AddInParameter(command, helper.H2, DbType.Decimal, entity.H2);
            dbProvider.AddInParameter(command, helper.Mediestado, DbType.String, entity.Mediestado);
            dbProvider.AddInParameter(command, helper.Meditotal, DbType.Decimal, entity.Meditotal);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
            dbProvider.AddInParameter(command, helper.H1, DbType.Decimal, entity.H1);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, entity.Tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, entity.Medifecha);
            dbProvider.AddInParameter(command, helper.Lectcodi, DbType.Int32, entity.Lectcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int ptomedicodi, int tipoinfocodi, DateTime medifecha, int lectcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, ptomedicodi);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Medifecha, DbType.DateTime, medifecha);
            dbProvider.AddInParameter(command, helper.Lectcodi, DbType.Int32, lectcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public List<MeMedicion96DTO> GetByCriteria(int idTipoInformacion,int idPtoMedicion,int idLectura,DateTime fechaInicio,
            DateTime fechaFin)
        { 
            List<MeMedicion96DTO> entities = new List<MeMedicion96DTO>();
            string queryString = string.Format(helper.SqlGetByCriteria, idTipoInformacion, idPtoMedicion, idLectura, fechaInicio, fechaFin);
            DbCommand command = dbProvider.GetSqlStringCommand(queryString);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entities.Add(helper.Create(dr));
                }
            }
            return entities;
        }

        public void DeleteEnvioInterconexion(DateTime medifecha)
        {
            string sqlDelete = string.Format(helper.SqlDeleteEnvioInterconexion, medifecha.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(sqlDelete);
            dbProvider.ExecuteNonQuery(command);
        }
        /// <summary>
        /// Borra las mediciones enviadas en un archivo
        /// </summary>
        /// <param name="medifecha"></param>
        public void DeleteEnvioArchivo(int idLectura,DateTime fechaInicio, DateTime fechaFin,int idFormato,int idEmpresa)
        {
            string sqlDelete = string.Format(helper.SqlDeleteEnvioArchivo,idLectura, fechaInicio.ToString(ConstantesBase.FormatoFecha),
              fechaInicio.ToString(ConstantesBase.FormatoFecha),idFormato,idEmpresa);

            DbCommand command = dbProvider.GetSqlStringCommand(sqlDelete);
            dbProvider.ExecuteNonQuery(command);
        }

        public List<MeMedicion96DTO> ObtenerConsultaMedidores(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin, int nroPagina, int nroRegistros)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            String sql = String.Format(this.helper.SqlObtenerConsultaTipoGeneracion, tipoInfoCodi, empresas, tipoGrupoCodi, tipoGeneracion,
                fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha), nroPagina, nroRegistros);

            DbCommand command = dbProvider.GetSqlStringCommand(sql);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion96DTO entity = helper.Create(dr);

                    int iEquipadre = dr.GetOrdinal(this.helper.Equipadre);
                    if (!dr.IsDBNull(iEquipadre)) entity.Equipadre = Convert.ToInt32(dr.GetValue(iEquipadre));

                    int iCentral = dr.GetOrdinal(this.helper.Central);
                    if (!dr.IsDBNull(iCentral)) entity.Central = dr.GetString(iCentral);

                    int iEquicodi = dr.GetOrdinal(this.helper.Equicodi);
                    if (!dr.IsDBNull(iEquicodi)) entity.Equicodi = Convert.ToInt32(dr.GetValue(iEquicodi));

                    int iEquinomb = dr.GetOrdinal(this.helper.Equinomb);
                    if (!dr.IsDBNull(iEquinomb)) entity.Equinomb = dr.GetString(iEquinomb);

                    int iEmprcodi = dr.GetOrdinal(this.helper.Emprcodi);
                    if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

                    int iEmprnomb = dr.GetOrdinal(this.helper.Emprnomb);
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);                                   

                    entitys.Add(entity);
                }
            }

            return entitys;

        }

        public List<MeMedicion96DTO> ObtenerConsultaServiciosAuxiliares(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin, int nroPagina, int nroRegistros)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            String sql = String.Format(this.helper.SqlObtenerConsultaServiciosAuxiliares, tipoInfoCodi, empresas, tipoGrupoCodi, tipoGeneracion,
                fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha), nroPagina, nroRegistros);

            DbCommand command = dbProvider.GetSqlStringCommand(sql);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion96DTO entity = helper.Create(dr);

                    int iEquipadre = dr.GetOrdinal(this.helper.Equipadre);
                    if (!dr.IsDBNull(iEquipadre)) entity.Equipadre = Convert.ToInt32(dr.GetValue(iEquipadre));

                    int iCentral = dr.GetOrdinal(this.helper.Central);
                    if (!dr.IsDBNull(iCentral)) entity.Central = dr.GetString(iCentral);

                    int iEquicodi = dr.GetOrdinal(this.helper.Equicodi);
                    if (!dr.IsDBNull(iEquicodi)) entity.Equicodi = Convert.ToInt32(dr.GetValue(iEquicodi));

                    int iEquinomb = dr.GetOrdinal(this.helper.Equinomb);
                    if (!dr.IsDBNull(iEquinomb)) entity.Equinomb = dr.GetString(iEquinomb);

                    int iEmprcodi = dr.GetOrdinal(this.helper.Emprcodi);
                    if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

                    int iEmprnomb = dr.GetOrdinal(this.helper.Emprnomb);
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);

                    entitys.Add(entity);
                }
            }

            return entitys;
        }
        
        public List<MeMedicion96DTO> ObtenerExportacionConsultaMedidores(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            String sql = String.Format(this.helper.SqlObtenerExportacionConsultaMedidores, tipoInfoCodi, empresas, tipoGrupoCodi, tipoGeneracion,
                fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(sql);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion96DTO entity = helper.Create(dr);

                    int iEquipadre = dr.GetOrdinal(this.helper.Equipadre);
                    if (!dr.IsDBNull(iEquipadre)) entity.Equipadre = Convert.ToInt32(dr.GetValue(iEquipadre));

                    int iCentral = dr.GetOrdinal(this.helper.Central);
                    if (!dr.IsDBNull(iCentral)) entity.Central = dr.GetString(iCentral);
                                        
                    int iEquicodi = dr.GetOrdinal(this.helper.Equicodi);
                    if (!dr.IsDBNull(iEquicodi)) entity.Equicodi = Convert.ToInt32(dr.GetValue(iEquicodi));

                    int iEquinomb = dr.GetOrdinal(this.helper.Equinomb);
                    if (!dr.IsDBNull(iEquinomb)) entity.Equinomb = dr.GetString(iEquinomb);                                      

                    int iEmprcodi = dr.GetOrdinal(this.helper.Emprcodi);
                    if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

                    int iEmprnomb = dr.GetOrdinal(this.helper.Emprnomb);
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);

                    if (string.IsNullOrEmpty(entity.Central)) entity.Central = string.Empty;
                    if (string.IsNullOrEmpty(entity.Equinomb)) entity.Equinomb = string.Empty;

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<MeMedicion96DTO> ObtenerExportacionServiciosAuxiliares(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            String sql = String.Format(this.helper.SqlObtenerExportacionServiciosAuxiliares, tipoInfoCodi, empresas, tipoGrupoCodi, tipoGeneracion,
                fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(sql);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion96DTO entity = helper.Create(dr);

                    int iEquipadre = dr.GetOrdinal(this.helper.Equipadre);
                    if (!dr.IsDBNull(iEquipadre)) entity.Equipadre = Convert.ToInt32(dr.GetValue(iEquipadre));

                    int iCentral = dr.GetOrdinal(this.helper.Central);
                    if (!dr.IsDBNull(iCentral)) entity.Central = dr.GetString(iCentral);

                    int iEquicodi = dr.GetOrdinal(this.helper.Equicodi);
                    if (!dr.IsDBNull(iEquicodi)) entity.Equicodi = Convert.ToInt32(dr.GetValue(iEquicodi));

                    int iEquinomb = dr.GetOrdinal(this.helper.Equinomb);
                    if (!dr.IsDBNull(iEquinomb)) entity.Equinomb = dr.GetString(iEquinomb);

                    int iEmprcodi = dr.GetOrdinal(this.helper.Emprcodi);
                    if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

                    int iEmprnomb = dr.GetOrdinal(this.helper.Emprnomb);
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);

                    if (string.IsNullOrEmpty(entity.Central)) entity.Central = string.Empty;
                    if (string.IsNullOrEmpty(entity.Equinomb)) entity.Equinomb = string.Empty;

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<MeMedicion96DTO> ObtenerExportacionMasivaMedidores(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            String sql = String.Format(this.helper.SqlObtenerExportacionMasivaMedidores, tipoInfoCodi, empresas, tipoGrupoCodi, tipoGeneracion,
                fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(sql);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion96DTO entity = helper.Create(dr);

                    int iPtomedielenomb = dr.GetOrdinal(this.helper.Ptomedielenomb);
                    if (!dr.IsDBNull(iPtomedielenomb)) entity.Ptomedielenomb = dr.GetString(iPtomedielenomb);

                    int iEmprnomb = dr.GetOrdinal(this.helper.Emprnomb);
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);
                                        
                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<MeMedicion96DTO> ObtenerExportacionMasivaSSAA(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
           string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            String sql = String.Format(this.helper.SqlObtenerExportacionMasivaSSAA, tipoInfoCodi, empresas, tipoGrupoCodi, tipoGeneracion,
                fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(sql);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion96DTO entity = helper.Create(dr);

                    int iPtomedielenomb = dr.GetOrdinal(this.helper.Ptomedielenomb);
                    if (!dr.IsDBNull(iPtomedielenomb)) entity.Ptomedielenomb = dr.GetString(iPtomedielenomb);

                    int iEmprnomb = dr.GetOrdinal(this.helper.Emprnomb);
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<MeMedicion96DTO> ObtenerTotalConsultaMedidores(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
           string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            String query = String.Format(this.helper.SqlTotalConsultaMedidores, tipoInfoCodi, empresas, tipoGrupoCodi, tipoGeneracion,
                       fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    #region Lectura

                    MeMedicion96DTO suma = new MeMedicion96DTO();
                    MeMedicion96DTO maximo = new MeMedicion96DTO();
                    MeMedicion96DTO minimo = new MeMedicion96DTO();

                    //int iMeditotal = dr.GetOrdinal(this.helper.Meditotal);
                    //if (!dr.IsDBNull(iMeditotal)) suma.Meditotal = dr.GetDecimal(iMeditotal) / 4;
                    //else suma.Meditotal = 0;

                    decimal maxValue = decimal.MinValue;
                    decimal minValue = decimal.MaxValue;
                    decimal totalValue = 0;

                    for (int i = 1; i <= 96; i++)
                    { 
                        decimal valorSuma = 0;
                        decimal valorMaximo = 0;
                        decimal valorMinimo = 0;

                        int iSuma = dr.GetOrdinal("H" + i);
                        if (!dr.IsDBNull(iSuma)) valorSuma = dr.GetDecimal(iSuma) / 4;

                        int iMaximo = dr.GetOrdinal("G" + i);
                        if (!dr.IsDBNull(iMaximo)) valorMaximo = dr.GetDecimal(iMaximo);

                        int iMinimo = dr.GetOrdinal("M" + i);
                        if (!dr.IsDBNull(iMinimo)) valorMinimo = dr.GetDecimal(iMinimo);

                        suma.GetType().GetProperty("H" + i).SetValue(suma, valorSuma);
                        maximo.GetType().GetProperty("H" + i).SetValue(maximo, valorMaximo);
                        minimo.GetType().GetProperty("H" + i).SetValue(minimo, valorMinimo);

                        if (maxValue < valorMaximo) maxValue = valorMaximo;
                        if (minValue > valorMinimo) minValue = valorMinimo;
                        totalValue = totalValue + valorSuma;

                    }

                    suma.Meditotal = totalValue;
                    maximo.Meditotal = maxValue;
                    minimo.Meditotal = minValue;

                    if (tipoInfoCodi == 1)
                    {
                        suma.Gruponomb = "TOTAL ENERGÍA (MWh)";
                        maximo.Gruponomb = "TOTAL POTENCIA MÁXIMA (MW)";
                        minimo.Gruponomb = "TOTAL POTENCIA MÍNIMA (MW)";
                    }

                    if (tipoInfoCodi == 2)
                    {
                        suma.Gruponomb = "TOTAL ENERGÍA REACTIVA(MVarh)";
                        maximo.Gruponomb = "TOTAL POTENCIA REACTIVA MÁXIMA (MVAR)";
                        minimo.Gruponomb = "TOTAL POTENCIA REACTIVA MÍNIMA (MVAR)";
                    }

                    entitys.Add(suma);
                    entitys.Add(maximo);
                    entitys.Add(minimo);                    

                    #endregion
                }
            }

            return entitys;
        }

        public List<MeMedicion96DTO> ObtenerTotalServiciosAuxiliares(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion96DTO> entitys =  new List<MeMedicion96DTO>();

            String query = String.Format(this.helper.SqlTotalServiciosAuxiliares, tipoInfoCodi, empresas, tipoGrupoCodi, tipoGeneracion,
                      fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    #region Lectura

                    MeMedicion96DTO suma = new MeMedicion96DTO();
                    MeMedicion96DTO maximo = new MeMedicion96DTO();
                    MeMedicion96DTO minimo = new MeMedicion96DTO();

                    //int iMeditotal = dr.GetOrdinal(this.helper.Meditotal);
                    //if (!dr.IsDBNull(iMeditotal)) suma.Meditotal = dr.GetDecimal(iMeditotal) / 4;
                    //else suma.Meditotal = 0;
                    decimal totalValue = 0;
                    decimal maxValue = decimal.MinValue;
                    decimal minValue = decimal.MaxValue;


                    for (int i = 1; i <= 96; i++)
                    {
                        decimal valorSuma = 0;
                        decimal valorMaximo = 0;
                        decimal valorMinimo = 0;

                        int iSuma = dr.GetOrdinal("H" + i);
                        if (!dr.IsDBNull(iSuma)) valorSuma = dr.GetDecimal(iSuma) / 4;

                        int iMaximo = dr.GetOrdinal("G" + i);
                        if (!dr.IsDBNull(iMaximo)) valorMaximo = dr.GetDecimal(iMaximo);

                        int iMinimo = dr.GetOrdinal("M" + i);
                        if (!dr.IsDBNull(iMinimo)) valorMinimo = dr.GetDecimal(iMinimo);

                        suma.GetType().GetProperty("H" + i).SetValue(suma, valorSuma);
                        maximo.GetType().GetProperty("H" + i).SetValue(maximo, valorMaximo);
                        minimo.GetType().GetProperty("H" + i).SetValue(minimo, valorMinimo);

                        if (maxValue < valorMaximo) maxValue = valorMaximo;
                        if (minValue > valorMinimo) minValue = valorMinimo;
                        totalValue = totalValue + valorSuma;
                    }

                    suma.Meditotal = totalValue;
                    maximo.Meditotal = maxValue;
                    minimo.Meditotal = minValue;

                    suma.Gruponomb = "TOTAL ENERGÍA SERV. AUX. (MWh)";
                    maximo.Gruponomb = "TOTAL POTENCIA MÁXIMA SERV. AUX. (MW)";
                    minimo.Gruponomb = "TOTAL POTENCIA MÍNIMA SERV. AUX. (MW)";

                    entitys.Add(suma);
                    entitys.Add(maximo);
                    entitys.Add(minimo);

                    #endregion
                }
            }

            return entitys;
        }

        public int ObtenerNroElementosConsultaMedidores(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin)
        {
            String query = String.Format(this.helper.SqlNroRegistrosConsultasTipoGeneracion, tipoInfoCodi, empresas, tipoGrupoCodi, tipoGeneracion,
                   fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(query);
            object count = dbProvider.ExecuteScalar(command);

            if (count != null) return Convert.ToInt32(count);

            return 0;
        }

        public int ObtenerNroElementosServiciosAuxiliares(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin)
        {
            String query = String.Format(this.helper.SqlNroRegistrosServiciosAuxiliares, tipoInfoCodi, empresas, tipoGrupoCodi, tipoGeneracion,
                  fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(query);
            object count = dbProvider.ExecuteScalar(command);

            if (count != null) return Convert.ToInt32(count);

            return 0;
        }

        public List<MeMedicion96DTO> ListarTotalH(DateTime fechaini, DateTime fechafin, string empresas,
          string tiposGeneracion, int central)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            string query = string.Format(helper.SqlListarTotalH, fechaini.ToString(ConstantesBase.FormatoFecha)
                , fechafin.ToString(ConstantesBase.FormatoFecha), empresas, tiposGeneracion, central);

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

        public List<MeMedicion96DTO> ListarDetalle(DateTime fechaini, DateTime fechafin, string empresas,
            string tiposGeneracion, int central)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            string query = string.Format(helper.SqlListarDetalle, fechaini.ToString(ConstantesBase.FormatoFecha)
               , fechafin.ToString(ConstantesBase.FormatoFecha), empresas, tiposGeneracion, central);

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            MeMedicion96DTO entity;
            string Empresanomb = "EMPRESA";
            string Centralnomb = "CENTRAL";
            string Gruponomb = "GRUPO";
            string Tgenernomb = "TGENERNOMB";
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = new MeMedicion96DTO();
                    entity = helper.Create(dr);
                    int iEmpresanomb = dr.GetOrdinal(Empresanomb);
                    if (!dr.IsDBNull(iEmpresanomb)) entity.Emprnomb = dr.GetString(iEmpresanomb);
                    int iCentralnomb = dr.GetOrdinal(Centralnomb);
                    if (!dr.IsDBNull(iCentralnomb)) entity.Central = dr.GetString(iCentralnomb);
                    int iGruponomb = dr.GetOrdinal(Gruponomb);
                    if (!dr.IsDBNull(iGruponomb)) entity.Gruponomb = dr.GetString(iGruponomb);
                    int iTgenernomb = dr.GetOrdinal(Tgenernomb);
                    if (!dr.IsDBNull(iTgenernomb)) entity.Tgenernomb = dr.GetString(iTgenernomb);
                    entitys.Add(entity);
                }
            }

            return entitys;
        }
 
        public List<MeMedicion96DTO> ObtenerReporteMedidores(string empresas, int tipoGrupoCodi, string fuenteEnergia, 
            DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            String query = String.Format(this.helper.SqlObtenerReporteMedidores, empresas, tipoGrupoCodi, fuenteEnergia,
                       fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion96DTO entity = this.helper.Create(dr);

                    int iEquipadre = dr.GetOrdinal(this.helper.Equipadre);
                    if (!dr.IsDBNull(iEquipadre)) entity.Equipadre = Convert.ToInt32(dr.GetValue(iEquipadre));

                    int iCentral = dr.GetOrdinal(this.helper.Central);
                    if (!dr.IsDBNull(iCentral)) entity.Central = dr.GetString(iCentral);

                    int iEquicodi = dr.GetOrdinal(this.helper.Equicodi);
                    if (!dr.IsDBNull(iEquicodi)) entity.Equicodi = Convert.ToInt32(dr.GetValue(iEquicodi));

                    int iEquinomb = dr.GetOrdinal(this.helper.Equinomb);
                    if (!dr.IsDBNull(iEquinomb)) entity.Equinomb = dr.GetString(iEquinomb);

                    int iEmprcodi = dr.GetOrdinal(this.helper.Emprcodi);
                    if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

                    int iEmprnomb = dr.GetOrdinal(this.helper.Emprnomb);
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);

                    int iTgenercodi = dr.GetOrdinal(this.helper.Tgenercodi);
                    if (!dr.IsDBNull(iTgenercodi)) entity.Tgenercodi = Convert.ToInt32(dr.GetValue(iTgenercodi));

                    int iTgenernomb = dr.GetOrdinal(this.helper.Tgenernomb);
                    if (!dr.IsDBNull(iTgenernomb)) entity.Tgenernomb = dr.GetString(iTgenernomb);

                    int iFenergcodi = dr.GetOrdinal(this.helper.Fenergcodi);
                    if (!dr.IsDBNull(iFenergcodi)) entity.Fenergcodi = Convert.ToInt32(dr.GetValue(iFenergcodi));

                    int iFenergnomb = dr.GetOrdinal(this.helper.Fenergnomb);
                    if (!dr.IsDBNull(iFenergnomb)) entity.Fenergnomb = dr.GetString(iFenergnomb);

                    int iFenergabrev = dr.GetOrdinal(this.helper.Fenergabrev);
                    if (!dr.IsDBNull(iFenergabrev)) entity.Fenergabrev = dr.GetString(iFenergabrev);

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<MeMedicion96DTO> ObtenerDatosReporteMD(string empresas, int tipoGrupoCodi, string fuenteEnergia,
            DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            String query = String.Format(this.helper.SqlObtenerDatosReporteMD, empresas, tipoGrupoCodi, fuenteEnergia,
                       fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(this.helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<MeMedicion96DTO> ObtenerEnvioPorEmpresa(int emprcodi,DateTime fechaPeriodo)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();

            String query = String.Format(this.helper.SqlObtenerEnvioPorEmpresa, emprcodi, fechaPeriodo.Year,fechaPeriodo.Month);

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(this.helper.Create(dr));
                }
            }

            return entitys;       

        }

        public void DeleteEnvioPorEmpresa(int emprcodi, DateTime fechaPeriodo)
        {
            String query = String.Format(this.helper.SqlDeleteEnvioPorEmpresa, fechaPeriodo.Year, fechaPeriodo.Month, emprcodi);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            dbProvider.ExecuteNonQuery(command);
        }

        public List<ConsolidadoEnvioDTO> ConsolidadoEnvioXEmpresa(int emprcodi,DateTime fechaPeriodo)
        {
            List<ConsolidadoEnvioDTO> entitys = new List<ConsolidadoEnvioDTO>();
            ConsolidadoEnvioDTO entity;
            String query = String.Format(this.helper.SqlConsolidadoEnvioEmpresa, emprcodi, fechaPeriodo.Year,fechaPeriodo.Month );

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = new ConsolidadoEnvioDTO();
                    int iCentral = dr.GetOrdinal("central");
                    if (!dr.IsDBNull(iCentral)) entity.Central =dr.GetString(iCentral);

                    int iIdCentral = dr.GetOrdinal(this.helper.Central);
                    if (!dr.IsDBNull(iCentral)) entity.Central = dr.GetString(iCentral);

                    int iGrupSSAA = dr.GetOrdinal("GrupSSAA");
                    if (!dr.IsDBNull(iGrupSSAA)) entity.GrupSSAA = dr.GetString(iGrupSSAA);

                    int iTotal = dr.GetOrdinal("Total");
                    if (!dr.IsDBNull(iTotal)) entity.Total = Convert.ToDecimal(dr.GetValue(iTotal));

                    int itipoGeneracion = dr.GetOrdinal("tipoGeneracion");
                    if (!dr.IsDBNull(itipoGeneracion)) entity.tipoGeneracion = Convert.ToInt16(dr.GetValue(itipoGeneracion));

                    //if (entity.idCentral == 0) entity.Central = entity.GrupSSAA;
                    entitys.Add(entity);
                }
            }

            return entitys;   

        }

        public List<MeMedicion96DTO> ObtenerEnvioInterconexion(int emprcodi, DateTime fechaini, DateTime fechafin)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();
            MeMedicion96DTO entity;
            string sqlQuery = string.Format(helper.SqlObtenerEnvioInterconexion, emprcodi, fechaini.ToString(ConstantesBase.FormatoFecha));
            DbCommand command = dbProvider.GetSqlStringCommand(sqlQuery);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = this.helper.Create(dr);
                    entitys.Add(entity);
                }
            }
            return entitys;
        }

        public List<MeMedicion96DTO> ObtenerHistoricoInterconexion(int ptomedicodi, DateTime fechaini, DateTime fechafin)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();
            MeMedicion96DTO entity;
            string sqlQuery = string.Format(helper.SqlObtenerHistoricoInterconexion, ptomedicodi, fechaini.ToString(ConstantesBase.FormatoFecha),
                fechafin.ToString(ConstantesBase.FormatoFecha));
            DbCommand command = dbProvider.GetSqlStringCommand(sqlQuery);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = this.helper.Create(dr);
                    entitys.Add(entity);
                }
            }
            return entitys;
        }

        public int ObtenerTotalHistoricoInterconexion(int ptomedicodi ,DateTime fechaini, DateTime fechafin)
        {
            string sqlTotal = string.Format(helper.SqlTotalHistoricoInterconexion, ptomedicodi,
                fechaini.ToString(ConstantesBase.FormatoFecha), fechafin.ToString(ConstantesBase.FormatoFecha));
            DbCommand command = dbProvider.GetSqlStringCommand(sqlTotal);
            object result = dbProvider.ExecuteScalar(command);
            int total = 0;
            if (result != null) total = Convert.ToInt32(result);
            return total;
        }

        public List<MeMedicion96DTO> ObtenerHistoricoPagInterconexion(int ptomedicodi, DateTime fechaini, DateTime fechafin,int pagina)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();
            MeMedicion96DTO entity;
            string sqlQuery = string.Format(helper.SqlHistoricoPagInterconexion, ptomedicodi, fechaini.ToString(ConstantesBase.FormatoFecha),
                fechafin.ToString(ConstantesBase.FormatoFecha),pagina);
            DbCommand command = dbProvider.GetSqlStringCommand(sqlQuery);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = this.helper.Create(dr);
                    entitys.Add(entity);
                }
            }
            return entitys;
        }


        public List<MeMedicion96DTO> GetEnvioArchivo(int idFormato, int idEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();
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

        public List<MeMedicion96DTO> GetHidrologia(int idLectura, int idOrigenLectura, string idsEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion96DTO> entitys = new List<MeMedicion96DTO>();
            string sqlQuery = string.Format(helper.SqlGetHidrologia, idLectura, idOrigenLectura, idsEmpresa, fechaInicio.ToString(ConstantesBase.FormatoFecha),
                fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(sqlQuery);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeMedicion96DTO entity = helper.Create(dr);
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

