using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using COES.Dominio.Interfaces.Transferencias;
using COES.Infraestructura.Datos.Helper.Transferencias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Infraestructura.Datos.Respositorio.Transferencias
{
    public class TransferenciaEntregaRepository : RepositoryBase, ITransferenciaEntregaRepository
    {


        public TransferenciaEntregaRepository(string strConn)
            : base(strConn)
        {
        }

        TransferenciaEntregaHelper helper = new TransferenciaEntregaHelper();

        public int Save(TransferenciaEntregaDTO entity)
        {

         

            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            int codi = GetCodigoGenerado();

                dbProvider.AddInParameter(command, helper.TRANENTRCODI, DbType.Int32, codi);

                dbProvider.AddInParameter(command, helper.CODENTCODI, DbType.Int32, entity.Codentcodi);
                dbProvider.AddInParameter(command, helper.BARRCODI, DbType.Int32, entity.Barrcodi);
                dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, entity.Pericodi);
                dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, entity.Emprcodi);
                dbProvider.AddInParameter(command, helper.CENTGENECODI, DbType.Int32, entity.Centgenecodi);
                dbProvider.AddInParameter(command, helper.CODIENTRCODIGO, DbType.String, entity.Codientrcodigo);         
                dbProvider.AddInParameter(command, helper.TRANENTRVERSION, DbType.Int32, entity.Tranentrversion);
                dbProvider.AddInParameter(command, helper.TRANENTRTIPOINFORMACION, DbType.String, entity.Tranentripoinformacion);
                dbProvider.AddInParameter(command, helper.TRANENTRESTADO, DbType.String, "ACT");

                dbProvider.AddInParameter(command, helper.TENTUSERNAME, DbType.String, entity.Tentusername);
            
                dbProvider.AddInParameter(command, helper.TRANENTRFECINS, DbType.DateTime, DateTime.Now);


            dbProvider.ExecuteNonQuery(command);
            return codi;
        }

        public void Update(TransferenciaEntregaDTO entity)
        {
            //DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            //dbProvider.AddInParameter(command, helper.Areanombre, DbType.String, entity.Areanombre);
            //dbProvider.AddInParameter(command, helper.Areaestado, DbType.String, "ACT");
            //dbProvider.AddInParameter(command, helper.Areafecact, DbType.DateTime, DateTime.Now);
            //dbProvider.AddInParameter(command, helper.Areacodi, DbType.Int32, entity.Areacodi);

            //dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int emprcodi, int pericodi, int version)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.TRANENTRVERSION, DbType.Int32, version);

            dbProvider.ExecuteNonQuery(command);
        }

        public TransferenciaEntregaDTO GetById(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.TRANENTRCODI, DbType.Int32, id);
            TransferenciaEntregaDTO entity = null;

            //using (IDataReader dr = dbProvider.ExecuteReader(command))
            //{
            //    if (dr.Read())
            //    {
            //        entity = helper.Create(dr);
            //    }
            //}

            return entity;
        }

      

        public List<TransferenciaEntregaDTO> List(int emprcodi, int pericodi,int version)
        {
            List<TransferenciaEntregaDTO> entitys = new List<TransferenciaEntregaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);

            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.TRANENTRVERSION, DbType.Int32, version);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    TransferenciaEntregaDTO entity = new TransferenciaEntregaDTO();

                    int iCODIENTRCODIGO = dr.GetOrdinal(helper.CODIENTRCODIGO);
                    if (!dr.IsDBNull(iCODIENTRCODIGO)) entity.Codientrcodigo = dr.GetString(iCODIENTRCODIGO);

                    int iEMPRNOMBRE = dr.GetOrdinal(helper.EMPRNOMBRE);
                    if (!dr.IsDBNull(iEMPRNOMBRE)) entity.Emprnombre = dr.GetString(iEMPRNOMBRE);

                    int iCENTGENENOMBRE = dr.GetOrdinal(helper.CENTGENENOMBRE);
                    if (!dr.IsDBNull(iCENTGENENOMBRE)) entity.Centgenenombre = dr.GetString(iCENTGENENOMBRE);


                    int iBARRNOMBRE = dr.GetOrdinal(helper.BARRNOMBRE);
                    if (!dr.IsDBNull(iBARRNOMBRE)) entity.Barrnombre = dr.GetString(iBARRNOMBRE);


                    int iTRANENTRTIPOINFORMACION = dr.GetOrdinal(helper.TRANENTRTIPOINFORMACION);
                    if (!dr.IsDBNull(iTRANENTRTIPOINFORMACION)) entity.Tranentripoinformacion = dr.GetString(iTRANENTRTIPOINFORMACION);

                    int iTOTAL = dr.GetOrdinal(helper.TOTAL);
                    if (!dr.IsDBNull(iTOTAL)) entity.Total = dr.GetDecimal(iTOTAL);


                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public int GetCodigoGenerado()
        {
            int newId = 0;
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCodigoGenerado);
            newId = Int32.Parse(dbProvider.ExecuteScalar(command).ToString());

            return newId;
        }


      


        public List<TransferenciaEntregaDTO> GetByCriteria(string nombre)
        {
            List<TransferenciaEntregaDTO> entitys = new List<TransferenciaEntregaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);

            //dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            //dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);

            //using (IDataReader dr = dbProvider.ExecuteReader(command))
            //{
            //    while (dr.Read())
            //    {
            //        TransferenciaEntregaDTO entity = new TransferenciaEntregaDTO();

            //        int iCODIENTRCODIGO = dr.GetOrdinal(helper.CODIENTRCODIGO);
            //        if (!dr.IsDBNull(iCODIENTRCODIGO)) entity.Codientrcodigo = dr.GetString(iCODIENTRCODIGO);

            //        int iEMPRNOMBRE = dr.GetOrdinal(helper.EMPRNOMBRE);
            //        if (!dr.IsDBNull(iEMPRNOMBRE)) entity.Emprnombre = dr.GetString(iEMPRNOMBRE);

            //        int iCENTGENENOMBRE = dr.GetOrdinal(helper.CENTGENENOMBRE);
            //        if (!dr.IsDBNull(iCENTGENENOMBRE)) entity.Centgenenombre = dr.GetString(iCENTGENENOMBRE);


            //        int iBARRNOMBRE = dr.GetOrdinal(helper.BARRNOMBRE);
            //        if (!dr.IsDBNull(iBARRNOMBRE)) entity.Barrnombre = dr.GetString(iBARRNOMBRE);


            //        int iTRANENTRTIPOINFORMACION = dr.GetOrdinal(helper.TRANENTRTIPOINFORMACION);
            //        if (!dr.IsDBNull(iTRANENTRTIPOINFORMACION)) entity.Tranentripoinformacion = dr.GetString(iTRANENTRTIPOINFORMACION);

            //        int iTOTAL = dr.GetOrdinal(helper.TOTAL);
            //        if (!dr.IsDBNull(iTOTAL)) entity.Total = dr.GetDecimal(iTOTAL);


            //        entitys.Add(entity);
            //    }
            //}

            return entitys;
        }
    }
}
