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
    public class TransferenciaRetiroRepository : RepositoryBase, ITransferenciaRetiroRepository
    {

        public TransferenciaRetiroRepository(string strConn)
            : base(strConn)
        {
        }
        TransferenciaRetiroHelper helper = new TransferenciaRetiroHelper();


        public int Save(TransferenciaRetiroDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            int codi = GetCodigoGenerado();
                dbProvider.AddInParameter(command, helper.TRANRETICODI, DbType.Int32, codi);
                dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, entity.Pericodi);
                dbProvider.AddInParameter(command, helper.BARRCODI, DbType.Int32, entity.Barrcodi); 
                dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, entity.Emprcodi);
                dbProvider.AddInParameter(command, helper.CLICODI, DbType.Int32, entity.Clicodi);
                dbProvider.AddInParameter(command, helper.TRETTABLA, DbType.String, entity.Trettabla);
                dbProvider.AddInParameter(command, helper.TRETCORESOCORESCCODI, DbType.Int32, entity.TRetCoresoCorescCodi);
                dbProvider.AddInParameter(command, helper.SOLICODIRETICODIGO, DbType.String, entity.Solicodireticodigo);
                dbProvider.AddInParameter(command, helper.TRANRETIVERSION, DbType.Int32, entity.Tranretiversion);
                dbProvider.AddInParameter(command, helper.TRANRETITIPOINFORMACION, DbType.String, entity.Tranretitipoinformacion);
                dbProvider.AddInParameter(command, helper.TRANRETIESTADO, DbType.String, "ACT");
                dbProvider.AddInParameter(command, helper.TRETUSERNAME, DbType.String, entity.Tretusername);
                dbProvider.AddInParameter(command, helper.TRANRETIFECINS, DbType.DateTime, DateTime.Now);

            dbProvider.ExecuteNonQuery(command);
            return codi;
        }

        public void Update(TransferenciaRetiroDTO entity)
        {
            
        }

        public void Delete(int emprcodi, int pericodi, int version)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.TRANRETIVERSION, DbType.Int32, version);

            dbProvider.ExecuteNonQuery(command);
        }

        public TransferenciaRetiroDTO GetById(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.TRANRETICODI, DbType.Int32, id);
            TransferenciaRetiroDTO entity = null;
            return entity;
        }



        public List<TransferenciaRetiroDTO> List(int emprcodi, int pericodi, int version)
        {
            List<TransferenciaRetiroDTO> entitys = new List<TransferenciaRetiroDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);


            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.TRANRETIVERSION, DbType.Int32, version);
            dbProvider.AddInParameter(command, helper.TRANRETIVERSION, DbType.Int32, version);
        
           
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    TransferenciaRetiroDTO entity = new TransferenciaRetiroDTO();

                    int iSOLICODIRETICODIGO = dr.GetOrdinal(helper.SOLICODIRETICODIGO);
                    if (!dr.IsDBNull(iSOLICODIRETICODIGO)) entity.Solicodireticodigo = dr.GetString(iSOLICODIRETICODIGO);

                    int iEMPRNOMBRE = dr.GetOrdinal(helper.EMPRNOMBRE);
                    if (!dr.IsDBNull(iEMPRNOMBRE)) entity.Emprnombre = dr.GetString(iEMPRNOMBRE);

                    int iCLINOMBRE = dr.GetOrdinal(helper.CLINOMBRE);
                    if (!dr.IsDBNull(iCLINOMBRE)) entity.Clinombre = dr.GetString(iCLINOMBRE);


                    int iBARRNOMBRE = dr.GetOrdinal(helper.BARRNOMBRE);
                    if (!dr.IsDBNull(iBARRNOMBRE)) entity.Barrnombre = dr.GetString(iBARRNOMBRE);

                    int iTRANRETITIPOINFORMACION = dr.GetOrdinal(helper.TRANRETITIPOINFORMACION);
                    if (!dr.IsDBNull(iTRANRETITIPOINFORMACION)) entity.Tranretitipoinformacion = dr.GetString(iTRANRETITIPOINFORMACION);

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


   

        public List<TransferenciaRetiroDTO> GetByCriteria(string nombre)
      {
            List<TransferenciaRetiroDTO> entitys = new List<TransferenciaRetiroDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);


            //dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            //dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);

            //using (IDataReader dr = dbProvider.ExecuteReader(command))
            //{
            //    while (dr.Read())
            //    {
            //        TransferenciaRetiroDTO entity = new TransferenciaRetiroDTO();

            //        int iSOLICODIRETICODIGO = dr.GetOrdinal(helper.SOLICODIRETICODIGO);
            //        if (!dr.IsDBNull(iSOLICODIRETICODIGO)) entity.Solicodireticodigo = dr.GetString(iSOLICODIRETICODIGO);

            //        int iEMPRNOMBRE = dr.GetOrdinal(helper.EMPRNOMBRE);
            //        if (!dr.IsDBNull(iEMPRNOMBRE)) entity.Emprnombre = dr.GetString(iEMPRNOMBRE);

            //        int iCLINOMBRE = dr.GetOrdinal(helper.CLINOMBRE);
            //        if (!dr.IsDBNull(iCLINOMBRE)) entity.Clinombre = dr.GetString(iCLINOMBRE);


            //        int iBARRNOMBRE = dr.GetOrdinal(helper.BARRNOMBRE);
            //        if (!dr.IsDBNull(iBARRNOMBRE)) entity.Barrnombre = dr.GetString(iBARRNOMBRE);


            //        int iTRANRETITIPOINFORMACION = dr.GetOrdinal(helper.TRANRETITIPOINFORMACION);
            //        if (!dr.IsDBNull(iTRANRETITIPOINFORMACION)) entity.Tranretitipoinformacion = dr.GetString(iTRANRETITIPOINFORMACION);

            //        int iTOTAL = dr.GetOrdinal(helper.TOTAL);
            //        if (!dr.IsDBNull(iTOTAL)) entity.Total = dr.GetDecimal(iTOTAL);


            //        entitys.Add(entity);
                return entitys;
            }

         
        
    }
}
