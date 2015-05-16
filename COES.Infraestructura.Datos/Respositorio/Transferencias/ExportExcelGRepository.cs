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
    public class ExportExcelGRepository : RepositoryBase, IExportExcelRepository
    {

        
         /// Clase que contiene las operaciones con la base de datos
        /// </summary>
        public ExportExcelGRepository(string strConn)
            : base(strConn)
        {
        }

        ExportExelHelper helper = new ExportExelHelper();



        public List<ExportExcelDTO> GetByPeriVer(int pericodi, int version)
        {
            List<ExportExcelDTO> entitys = new List<ExportExcelDTO>();



            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteriaPeriVer);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.VTRANVERSION, DbType.Int32, version);
       
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    ExportExcelDTO entity = new ExportExcelDTO();

                    int iEMPRCODI = dr.GetOrdinal(this.helper.EMPRCODI);
                    if (!dr.IsDBNull(iEMPRCODI)) entity.EMPRCODI = dr.GetInt32(iEMPRCODI);


                    int iEMPRNOMB = dr.GetOrdinal(this.helper.EMPRNOMB);
                    if (!dr.IsDBNull(iEMPRNOMB)) entity.Emprnomb = dr.GetString(iEMPRNOMB);

                    int iVT = dr.GetOrdinal(this.helper.VT);
                    if (!dr.IsDBNull(iVT)) entity.ValorizacionTransferencia = dr.GetDecimal(iVT);

                    int iST = dr.GetOrdinal(this.helper.ST);
                    if (!dr.IsDBNull(iST)) entity.SaldoTransmision = dr.GetDecimal(iST);

                    int iCOMPENSACION = dr.GetOrdinal(this.helper.COMPENSACION);
                    if (!dr.IsDBNull(iCOMPENSACION)) entity.Compensacion = dr.GetDecimal(iCOMPENSACION);


                    int iTOTAL = dr.GetOrdinal(this.helper.TOTAL);
                    if (!dr.IsDBNull(iTOTAL)) entity.TotalEmp = dr.GetDecimal(iTOTAL);


                    int iPERICODI = dr.GetOrdinal(this.helper.PERICODI);
                    if (!dr.IsDBNull(iPERICODI)) entity.Pericodi = dr.GetInt32(iPERICODI);

                    int iVTRANVERSION = dr.GetOrdinal(this.helper.VTRANVERSION);
                    if (!dr.IsDBNull(iVTRANVERSION)) entity.Vtranversion = dr.GetInt32(iVTRANVERSION);


                    entitys.Add(entity);
                    
                }
            }

            return entitys;
        }

        public List<ExportExcelDTO> GetByEmprPeriVersion(int emprcodi, int pericodi, int version)
        {
            List<ExportExcelDTO> entitys = new List<ExportExcelDTO>();


            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteriaEmprPeriVer);
            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.INGCOMVERSION, DbType.Int32, version);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    ExportExcelDTO entity = new ExportExcelDTO();

                    int iPERICODI = dr.GetOrdinal(this.helper.PERICODI);
                    if (!dr.IsDBNull(iPERICODI)) entity.Pericodi = dr.GetInt32(iPERICODI);

                    int iINGCOMVERSION = dr.GetOrdinal(this.helper.INGCOMVERSION);
                    if (!dr.IsDBNull(iINGCOMVERSION)) entity.IngComversion = dr.GetInt32(iINGCOMVERSION);

                    int iEMPRCODI = dr.GetOrdinal(this.helper.EMPRCODI);
                    if (!dr.IsDBNull(iEMPRCODI)) entity.EMPRCODI = dr.GetInt32(iEMPRCODI);

                    int iINGCOMIMPORTE = dr.GetOrdinal(this.helper.INGCOMIMPORTE);
                    if (!dr.IsDBNull(iINGCOMIMPORTE)) entity.IngComImporte = dr.GetDecimal(iINGCOMIMPORTE);


                    int iCABCOMNOMBRE = dr.GetOrdinal(this.helper.CABCOMNOMBRE);
                    if (!dr.IsDBNull(iCABCOMNOMBRE)) entity.CabComnombre = dr.GetString(iCABCOMNOMBRE);                 


                    entitys.Add(entity);
                }
            }

            return entitys;
        }

          public List<EmpresaPagoDTO> GetMatrizByPeriVersion(int emprcodi, int pericodi, int version)
        {
            List<EmpresaPagoDTO> entitys = new List<EmpresaPagoDTO>();


            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetGetMatrizByCriteriPeriVer);

            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.EMPPAGVERSION, DbType.Int32, version);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    EmpresaPagoDTO entity = new EmpresaPagoDTO();


                   
                    int iEMPRNOMB = dr.GetOrdinal(this.helper.EMPRNOMB);
                    if (!dr.IsDBNull(iEMPRNOMB)) entity.EMPRNOMB = dr.GetString(iEMPRNOMB);

                    int iEMPRNOMBPAGO = dr.GetOrdinal(this.helper.EMPRNOMBPAGO);
                    if (!dr.IsDBNull(iEMPRNOMBPAGO)) entity.EMPRNOMBPAGO = dr.GetString(iEMPRNOMBPAGO);

                    int iEMPPAGMONTO = dr.GetOrdinal(this.helper.EMPPAGMONTO);
                    if (!dr.IsDBNull(iEMPPAGMONTO)) entity.EMPPAGOMONTO = dr.GetDecimal(iEMPPAGMONTO);

                

                    entitys.Add(entity);
                }
            }

            return entitys;
        }


          public List<EmpresaPagoDTO> GetMatrizEmprByPeriVersion(int pericodi, int version)
          {
              List<EmpresaPagoDTO> entitys = new List<EmpresaPagoDTO>();


              DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMatrizEmprByCriteriPeriVer);

              dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
              dbProvider.AddInParameter(command, helper.EMPPAGVERSION, DbType.Int32, version);
              using (IDataReader dr = dbProvider.ExecuteReader(command))
              {
                  while (dr.Read())
                  {
                      EmpresaPagoDTO entity = new EmpresaPagoDTO();

                      int iEMPRCODI = dr.GetOrdinal(this.helper.EMPRCODI);
                      if (!dr.IsDBNull(iEMPRCODI)) entity.EMPCODI = dr.GetInt32(iEMPRCODI);


                      int iEMPRNOMB = dr.GetOrdinal(this.helper.EMPRNOMB);
                      if (!dr.IsDBNull(iEMPRNOMB)) entity.EMPRNOMB = dr.GetString(iEMPRNOMB);




                      entitys.Add(entity);
                  }
              }

              return entitys;
          }

       
    }
}
