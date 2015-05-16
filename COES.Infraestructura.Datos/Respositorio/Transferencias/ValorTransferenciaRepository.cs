using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using COES.Dominio.Interfaces.Transferencias;
using COES.Infraestructura.Datos.Helper.Transferencias;

namespace COES.Infraestructura.Datos.Respositorio.Transferencias
{
    public class ValorTransferenciaRepository : RepositoryBase, IValorTransferenciaRepository
    {
        public ValorTransferenciaRepository(string strConn) : base(strConn)
        {
        }

        ValorTransferenciaHelper helper = new ValorTransferenciaHelper();

        public int Save(ValorTransferenciaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.ValoTranCodi, DbType.Int32, GetCodigoGenerado());
            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, entity.PeriCodi);
            dbProvider.AddInParameter(command, helper.BarrCodi, DbType.Int32, entity.BarrCodi);
            dbProvider.AddInParameter(command, helper.EmpCodi, DbType.Int32, entity.EmpCodi);
           
            dbProvider.AddInParameter(command, helper.CostMargCodi, DbType.Int32, entity.CostMargCodi);
            dbProvider.AddInParameter(command, helper.ValoTranFlag, DbType.String, entity.ValoTranFlag);
            dbProvider.AddInParameter(command, helper.ValoTranCodEntRet, DbType.String, entity.ValoTranCodEntRet);
            dbProvider.AddInParameter(command, helper.ValoTranVersion, DbType.Int32, entity.ValoTranVersion);
            dbProvider.AddInParameter(command, helper.ValoTranDia, DbType.Int32, entity.ValoTranDia);


            dbProvider.AddInParameter(command, helper.VTTotalDia, DbType.Double, entity.VTTotalDia);          
            dbProvider.AddInParameter(command, helper.VTTotalEnergia, DbType.Double, entity.VTTotalEnergia);
            dbProvider.AddInParameter(command, helper.VTTipoinformacion, DbType.String, entity.VTTipoinformacion);

            dbProvider.AddInParameter(command, helper.VT1, DbType.Double, entity.VT1);
            dbProvider.AddInParameter(command, helper.VT2, DbType.Double, entity.VT2);
            dbProvider.AddInParameter(command, helper.VT3, DbType.Double, entity.VT3);
            dbProvider.AddInParameter(command, helper.VT4, DbType.Double, entity.VT4);
            dbProvider.AddInParameter(command, helper.VT5, DbType.Double, entity.VT5);
            dbProvider.AddInParameter(command, helper.VT6, DbType.Double, entity.VT6);
            dbProvider.AddInParameter(command, helper.VT7, DbType.Double, entity.VT7);
            dbProvider.AddInParameter(command, helper.VT8, DbType.Double, entity.VT8);
            dbProvider.AddInParameter(command, helper.VT9, DbType.Double, entity.VT9);
            dbProvider.AddInParameter(command, helper.VT10, DbType.Double, entity.VT10);
            dbProvider.AddInParameter(command, helper.VT11, DbType.Double, entity.VT11);
            dbProvider.AddInParameter(command, helper.VT12, DbType.Double, entity.VT12);
            dbProvider.AddInParameter(command, helper.VT13, DbType.Double, entity.VT13);
            dbProvider.AddInParameter(command, helper.VT14, DbType.Double, entity.VT14);
            dbProvider.AddInParameter(command, helper.VT15, DbType.Double, entity.VT15);
            dbProvider.AddInParameter(command, helper.VT16, DbType.Double, entity.VT16);
            dbProvider.AddInParameter(command, helper.VT17, DbType.Double, entity.VT17);
            dbProvider.AddInParameter(command, helper.VT18, DbType.Double, entity.VT18);
            dbProvider.AddInParameter(command, helper.VT19, DbType.Double, entity.VT19);
            dbProvider.AddInParameter(command, helper.VT20, DbType.Double, entity.VT20);
            dbProvider.AddInParameter(command, helper.VT21, DbType.Double, entity.VT21);
            dbProvider.AddInParameter(command, helper.VT22, DbType.Double, entity.VT22);
            dbProvider.AddInParameter(command, helper.VT23, DbType.Double, entity.VT23);
            dbProvider.AddInParameter(command, helper.VT24, DbType.Double, entity.VT24);
            dbProvider.AddInParameter(command, helper.VT25, DbType.Double, entity.VT25);
            dbProvider.AddInParameter(command, helper.VT26, DbType.Double, entity.VT26);
            dbProvider.AddInParameter(command, helper.VT27, DbType.Double, entity.VT27);
            dbProvider.AddInParameter(command, helper.VT28, DbType.Double, entity.VT28);
            dbProvider.AddInParameter(command, helper.VT29, DbType.Double, entity.VT29);
            dbProvider.AddInParameter(command, helper.VT30, DbType.Double, entity.VT30);
            dbProvider.AddInParameter(command, helper.VT31, DbType.Double, entity.VT31);
            dbProvider.AddInParameter(command, helper.VT32, DbType.Double, entity.VT32);
            dbProvider.AddInParameter(command, helper.VT33, DbType.Double, entity.VT33);
            dbProvider.AddInParameter(command, helper.VT34, DbType.Double, entity.VT34);
            dbProvider.AddInParameter(command, helper.VT35, DbType.Double, entity.VT35);
            dbProvider.AddInParameter(command, helper.VT36, DbType.Double, entity.VT36);
            dbProvider.AddInParameter(command, helper.VT37, DbType.Double, entity.VT37);
            dbProvider.AddInParameter(command, helper.VT38, DbType.Double, entity.VT38);
            dbProvider.AddInParameter(command, helper.VT39, DbType.Double, entity.VT39);
            dbProvider.AddInParameter(command, helper.VT40, DbType.Double, entity.VT40);
            dbProvider.AddInParameter(command, helper.VT41, DbType.Double, entity.VT41);
            dbProvider.AddInParameter(command, helper.VT42, DbType.Double, entity.VT42);
            dbProvider.AddInParameter(command, helper.VT43, DbType.Double, entity.VT43);
            dbProvider.AddInParameter(command, helper.VT44, DbType.Double, entity.VT44);
            dbProvider.AddInParameter(command, helper.VT45, DbType.Double, entity.VT45);
            dbProvider.AddInParameter(command, helper.VT46, DbType.Double, entity.VT46);
            dbProvider.AddInParameter(command, helper.VT47, DbType.Double, entity.VT47);
            dbProvider.AddInParameter(command, helper.VT48, DbType.Double, entity.VT48);
            dbProvider.AddInParameter(command, helper.VT49, DbType.Double, entity.VT49);
            dbProvider.AddInParameter(command, helper.VT50, DbType.Double, entity.VT50);
            dbProvider.AddInParameter(command, helper.VT51, DbType.Double, entity.VT51);
            dbProvider.AddInParameter(command, helper.VT52, DbType.Double, entity.VT52);
            dbProvider.AddInParameter(command, helper.VT53, DbType.Double, entity.VT53);
            dbProvider.AddInParameter(command, helper.VT54, DbType.Double, entity.VT54);
            dbProvider.AddInParameter(command, helper.VT55, DbType.Double, entity.VT55);
            dbProvider.AddInParameter(command, helper.VT56, DbType.Double, entity.VT56);
            dbProvider.AddInParameter(command, helper.VT57, DbType.Double, entity.VT57);
            dbProvider.AddInParameter(command, helper.VT58, DbType.Double, entity.VT58);
            dbProvider.AddInParameter(command, helper.VT59, DbType.Double, entity.VT59);
            dbProvider.AddInParameter(command, helper.VT60, DbType.Double, entity.VT60);
            dbProvider.AddInParameter(command, helper.VT61, DbType.Double, entity.VT61);
            dbProvider.AddInParameter(command, helper.VT62, DbType.Double, entity.VT62);
            dbProvider.AddInParameter(command, helper.VT63, DbType.Double, entity.VT63);
            dbProvider.AddInParameter(command, helper.VT64, DbType.Double, entity.VT64);
            dbProvider.AddInParameter(command, helper.VT65, DbType.Double, entity.VT65);
            dbProvider.AddInParameter(command, helper.VT66, DbType.Double, entity.VT66);
            dbProvider.AddInParameter(command, helper.VT67, DbType.Double, entity.VT67);
            dbProvider.AddInParameter(command, helper.VT68, DbType.Double, entity.VT68);
            dbProvider.AddInParameter(command, helper.VT69, DbType.Double, entity.VT69);
            dbProvider.AddInParameter(command, helper.VT70, DbType.Double, entity.VT70);
            dbProvider.AddInParameter(command, helper.VT71, DbType.Double, entity.VT71);
            dbProvider.AddInParameter(command, helper.VT72, DbType.Double, entity.VT72);
            dbProvider.AddInParameter(command, helper.VT73, DbType.Double, entity.VT73);
            dbProvider.AddInParameter(command, helper.VT74, DbType.Double, entity.VT74);
            dbProvider.AddInParameter(command, helper.VT75, DbType.Double, entity.VT75);
            dbProvider.AddInParameter(command, helper.VT76, DbType.Double, entity.VT76);
            dbProvider.AddInParameter(command, helper.VT77, DbType.Double, entity.VT77);
            dbProvider.AddInParameter(command, helper.VT78, DbType.Double, entity.VT78);
            dbProvider.AddInParameter(command, helper.VT79, DbType.Double, entity.VT79);
            dbProvider.AddInParameter(command, helper.VT80, DbType.Double, entity.VT80);
            dbProvider.AddInParameter(command, helper.VT81, DbType.Double, entity.VT81);
            dbProvider.AddInParameter(command, helper.VT82, DbType.Double, entity.VT82);
            dbProvider.AddInParameter(command, helper.VT83, DbType.Double, entity.VT83);
            dbProvider.AddInParameter(command, helper.VT84, DbType.Double, entity.VT84);
            dbProvider.AddInParameter(command, helper.VT85, DbType.Double, entity.VT85);
            dbProvider.AddInParameter(command, helper.VT86, DbType.Double, entity.VT86);
            dbProvider.AddInParameter(command, helper.VT87, DbType.Double, entity.VT87);
            dbProvider.AddInParameter(command, helper.VT88, DbType.Double, entity.VT88);
            dbProvider.AddInParameter(command, helper.VT89, DbType.Double, entity.VT89);
            dbProvider.AddInParameter(command, helper.VT90, DbType.Double, entity.VT90);
            dbProvider.AddInParameter(command, helper.VT91, DbType.Double, entity.VT91);
            dbProvider.AddInParameter(command, helper.VT92, DbType.Double, entity.VT92);
            dbProvider.AddInParameter(command, helper.VT93, DbType.Double, entity.VT93);
            dbProvider.AddInParameter(command, helper.VT94, DbType.Double, entity.VT94);
            dbProvider.AddInParameter(command, helper.VT95, DbType.Double, entity.VT95);
            dbProvider.AddInParameter(command, helper.VT96, DbType.Double, entity.VT96);
       
            dbProvider.AddInParameter(command, helper.USERNAME, DbType.String, entity.Vtranusername);
            dbProvider.AddInParameter(command, helper.ValoTranFecIns, DbType.DateTime, DateTime.Now);
          
            


            return dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(System.Int32 PeriCod, System.Int32 ValoTranVersion)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, PeriCod);
            dbProvider.AddInParameter(command, helper.ValoTranVersion, DbType.Int32, ValoTranVersion);

            dbProvider.ExecuteNonQuery(command);
        }

        public int GetCodigoGenerado()
        {
            int newId = 0;
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCodigoGenerado);
            newId = Int32.Parse(dbProvider.ExecuteScalar(command).ToString());

            return newId;
        }

        public List<ValorTransferenciaDTO> List(int pericodi,int version)
        {
            
  

            List<ValorTransferenciaDTO> entitys = new List<ValorTransferenciaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.ValoTranVersion, DbType.Int32, version);
            
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    ValorTransferenciaDTO entity = new ValorTransferenciaDTO();

                    int iEmpCodi = dr.GetOrdinal(this.helper.EmpCodi);
                    if (!dr.IsDBNull(iEmpCodi)) entity.EmpCodi = dr.GetInt32(iEmpCodi);

                    int iPeriCodi = dr.GetOrdinal(this.helper.PeriCodi);
                    if (!dr.IsDBNull(iPeriCodi)) entity.PeriCodi = dr.GetInt32(iPeriCodi);

                      int iValoTranVersion = dr.GetOrdinal(this.helper.ValoTranVersion);
                    if (!dr.IsDBNull(iValoTranVersion)) entity.ValoTranVersion = dr.GetInt32(iValoTranVersion);


                    int iENTREGA = dr.GetOrdinal(this.helper.ENTREGA);
                    if (!dr.IsDBNull(iENTREGA)) entity.VTEmpresaEntrega = dr.GetDecimal(iENTREGA);


                    int iRETIRO = dr.GetOrdinal(this.helper.RETIRO);
                    if (!dr.IsDBNull(iRETIRO)) entity.VTEmpresaRetiro = dr.GetDecimal(iRETIRO);


                    entitys.Add(entity);

                }
            }

            return entitys;

        }




        public List<ValorTransferenciaDTO> GetByCriteria(int? empcodi, int? barrcodi, int? pericodi) //int pericodi, string barrcodi
        {
            List<ValorTransferenciaDTO> entitys = new List<ValorTransferenciaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

            dbProvider.AddInParameter(command, helper.EmpCodi, DbType.Int32, empcodi);
            dbProvider.AddInParameter(command, helper.EmpCodi, DbType.Int32, empcodi);
            dbProvider.AddInParameter(command, helper.BarrCodi, DbType.Int32, barrcodi);
            dbProvider.AddInParameter(command, helper.BarrCodi, DbType.Int32, barrcodi);
            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
          
           
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {

                while (dr.Read())
                {
                    ValorTransferenciaDTO entity = new ValorTransferenciaDTO();
     
                    int iEMPRNOMB = dr.GetOrdinal(this.helper.EMPRNOMB);
                    if (!dr.IsDBNull(iEMPRNOMB)) entity.Emprnomb = dr.GetString(iEMPRNOMB);

                    int iBARRNOMBRE = dr.GetOrdinal(this.helper.BARRNOMBRE);
                    if (!dr.IsDBNull(iBARRNOMBRE)) entity.Barrnombbarrtran = dr.GetString(iBARRNOMBRE);

                    int iValoTranCodEntRet = dr.GetOrdinal(this.helper.ValoTranCodEntRet);
                    if (!dr.IsDBNull(iValoTranCodEntRet)) entity.ValoTranCodEntRet = dr.GetString(iValoTranCodEntRet);


                    int iVALORIZACION = dr.GetOrdinal(this.helper.VALORIZACION);
                    if (!dr.IsDBNull(iVALORIZACION)) entity.VTTotalDia = dr.GetDecimal(iVALORIZACION);

                    int iENERGIA = dr.GetOrdinal(this.helper.ENERGIA);
                    if (!dr.IsDBNull(iENERGIA)) entity.VTTotalEnergia = dr.GetDecimal(iENERGIA);

                    int iVTTipoinformacion = dr.GetOrdinal(this.helper.VTTipoinformacion);
                    if (!dr.IsDBNull(iVTTipoinformacion)) entity.VTTipoinformacion = dr.GetString(iVTTipoinformacion);

                    
                    entitys.Add(entity);

                }
            }

            return entitys;
        }


       



        public List<ValorTransferenciaDTO> GetTotalByTipoFlag(int pericodi, int version)
        {
            List<ValorTransferenciaDTO> entitys = new List<ValorTransferenciaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetTotalByTipoFlag);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.ValoTranVersion, DbType.Int32, version);
                    


            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
               while(dr.Read())
                {
                    ValorTransferenciaDTO entity = new ValorTransferenciaDTO();

                  
                    int iPeriCodi = dr.GetOrdinal(this.helper.PeriCodi);
                    if (!dr.IsDBNull(iPeriCodi)) entity.PeriCodi = dr.GetInt32(iPeriCodi);

                    int iValoTranVersion = dr.GetOrdinal(this.helper.ValoTranVersion);
                    if (!dr.IsDBNull(iValoTranVersion)) entity.ValoTranVersion = dr.GetInt32(iValoTranVersion);


                    int iValoTranFlag = dr.GetOrdinal(this.helper.ValoTranFlag);
                    if (!dr.IsDBNull(iValoTranFlag)) entity.ValoTranFlag = dr.GetString(iValoTranFlag);

                    int iVTTotalDia = dr.GetOrdinal(this.helper.VTTotalDia);
                    if (!dr.IsDBNull(iVTTotalDia)) entity.VTTotalDia = dr.GetDecimal(iVTTotalDia);

                    entitys.Add(entity);
                    
                }
            }

            return entitys;
        }




        public List<ValorTransferenciaDTO> GetValorEmpresa(int pericodi, int version)
        {
            List<ValorTransferenciaDTO> entitys = new List<ValorTransferenciaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetValorEmpresaByPeriVer);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.ValoTranVersion, DbType.Int32, version);
                    


            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
               while(dr.Read())
                {
                    ValorTransferenciaDTO entity = new ValorTransferenciaDTO();

                    int iEmpCodi = dr.GetOrdinal(this.helper.EmpCodi);
                    if (!dr.IsDBNull(iEmpCodi)) entity.EmpCodi = dr.GetInt32(iEmpCodi);

                    int iSALEMPSALDO = dr.GetOrdinal(this.helper.SALEMPSALDO);
                    if (!dr.IsDBNull(iSALEMPSALDO)) entity.Salempsaldo = dr.GetDecimal(iSALEMPSALDO);

                    int iCOMPENSACION = dr.GetOrdinal(this.helper.COMPENSACION);
                    if (!dr.IsDBNull(iCOMPENSACION)) entity.Compensacion = dr.GetDecimal(iCOMPENSACION);

                    int iVALORIZACION = dr.GetOrdinal(this.helper.VALORIZACION);
                    if (!dr.IsDBNull(iVALORIZACION)) entity.Valorizacion = dr.GetDecimal(iVALORIZACION);


                    int iSALRSCSALDO = dr.GetOrdinal(this.helper.SALRSCSALDO);
                    if (!dr.IsDBNull(iSALRSCSALDO)) entity.Salrscsaldo = dr.GetDecimal(iSALRSCSALDO); 
                  
                   


                    int iPeriCodi = dr.GetOrdinal(this.helper.PeriCodi);
                    if (!dr.IsDBNull(iPeriCodi)) entity.PeriCodi = dr.GetInt32(iPeriCodi);

                  
                    int iValoTranVersion = dr.GetOrdinal(this.helper.ValoTranVersion);
                    if (!dr.IsDBNull(iValoTranVersion)) entity.ValoTranVersion = dr.GetInt32(iValoTranVersion);


                    entitys.Add(entity);
                    
                }
            }

            return entitys;
        }

        public List<ValorTransferenciaDTO> GetBalance(int pericodi)
        {



            List<ValorTransferenciaDTO> entitys = new List<ValorTransferenciaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetBalance);


            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
            //dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    ValorTransferenciaDTO entity = new ValorTransferenciaDTO();

                    int iNombEmpresa = dr.GetOrdinal(this.helper.NombEmpresa);
                    if (!dr.IsDBNull(iNombEmpresa)) entity.nombEmpresa = dr.GetString(iNombEmpresa);

                    int iEmpCodi = dr.GetOrdinal(this.helper.EmpCodi);
                    if (!dr.IsDBNull(iEmpCodi)) entity.EmpCodi = dr.GetInt32(iEmpCodi);

                    int iPeriCodi = dr.GetOrdinal(this.helper.PeriCodi);
                    if (!dr.IsDBNull(iPeriCodi)) entity.PeriCodi = dr.GetInt32(iPeriCodi);

                    int iEntregas = dr.GetOrdinal(this.helper.Entregas);
                    if (!dr.IsDBNull(iEntregas)) entity.entregas = dr.GetDecimal(iEntregas);

                    int iRetiros = dr.GetOrdinal(this.helper.Retiros);
                    if (!dr.IsDBNull(iRetiros)) entity.retiros = dr.GetDecimal(iRetiros);

                    int iNeto = dr.GetOrdinal(this.helper.Neto);
                    if (!dr.IsDBNull(iNeto)) entity.neto = dr.GetDecimal(iNeto);

                    entitys.Add(entity);

                }
            }

            return entitys;
        }

    }
}
