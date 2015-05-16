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
    public class TransferenciaEntregaDetalleRepository : RepositoryBase, ITransferenciaEntregaDetalleRepository
    {

        public TransferenciaEntregaDetalleRepository(string strConn)
            : base(strConn)
        {
        }

        TransferenciaEntregaDetalleHelper helper = new TransferenciaEntregaDetalleHelper();


        public int Save(TransferenciaEntregaDetalleDTO entity)
        {

  
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

         
            dbProvider.AddInParameter(command, helper.TRANENTRCODI, DbType.Int32, entity.Tranentrcodi);
            dbProvider.AddInParameter(command, helper.TRANENTRDETACODI, DbType.Int32, GetCodigoGenerado());
            dbProvider.AddInParameter(command, helper.TRANENTRDETAVERSION, DbType.Int32, entity.Tranentrdetaversion);
            dbProvider.AddInParameter(command, helper.TRANENTRDETADIA, DbType.Int32, entity.Tranentrdetadia);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAPROMDIA, DbType.Decimal, entity.Tranentrdetapromdia);
            dbProvider.AddInParameter(command, helper.TRANENTRDETASUMADIA, DbType.Decimal, entity.Tranentrdetasumadia);
            
      
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH1, DbType.Double, entity.Tranentrdetah1);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH2, DbType.Double, entity.Tranentrdetah2);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH3, DbType.Double, entity.Tranentrdetah3);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH4, DbType.Double, entity.Tranentrdetah4);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH5, DbType.Double, entity.Tranentrdetah5);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH6, DbType.Double, entity.Tranentrdetah6);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH7, DbType.Double, entity.Tranentrdetah7);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH8, DbType.Double, entity.Tranentrdetah8);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH9, DbType.Double, entity.Tranentrdetah9);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH10, DbType.Double, entity.Tranentrdetah10);

            dbProvider.AddInParameter(command, helper.TRANENTRDETAH11, DbType.Double, entity.Tranentrdetah11);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH12, DbType.Double, entity.Tranentrdetah12);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH13, DbType.Double, entity.Tranentrdetah13);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH14, DbType.Double, entity.Tranentrdetah14);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH15, DbType.Double, entity.Tranentrdetah15);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH16, DbType.Double, entity.Tranentrdetah16);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH17, DbType.Double, entity.Tranentrdetah17);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH18, DbType.Double, entity.Tranentrdetah18);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH19, DbType.Double, entity.Tranentrdetah19);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH20, DbType.Double, entity.Tranentrdetah20);

            dbProvider.AddInParameter(command, helper.TRANENTRDETAH21, DbType.Double, entity.Tranentrdetah21);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH22, DbType.Double, entity.Tranentrdetah22);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH23, DbType.Double, entity.Tranentrdetah23);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH24, DbType.Double, entity.Tranentrdetah24);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH25, DbType.Double, entity.Tranentrdetah25);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH26, DbType.Double, entity.Tranentrdetah26);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH27, DbType.Double, entity.Tranentrdetah27);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH28, DbType.Double, entity.Tranentrdetah28);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH29, DbType.Double, entity.Tranentrdetah29);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH30, DbType.Double, entity.Tranentrdetah30);

            dbProvider.AddInParameter(command, helper.TRANENTRDETAH31, DbType.Double, entity.Tranentrdetah31);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH32, DbType.Double, entity.Tranentrdetah32);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH33, DbType.Double, entity.Tranentrdetah33);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH34, DbType.Double, entity.Tranentrdetah34);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH35, DbType.Double, entity.Tranentrdetah35);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH36, DbType.Double, entity.Tranentrdetah36);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH37, DbType.Double, entity.Tranentrdetah37);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH38, DbType.Double, entity.Tranentrdetah38);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH39, DbType.Double, entity.Tranentrdetah39);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH40, DbType.Double, entity.Tranentrdetah40);

            dbProvider.AddInParameter(command, helper.TRANENTRDETAH41, DbType.Double, entity.Tranentrdetah41);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH42, DbType.Double, entity.Tranentrdetah42);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH43, DbType.Double, entity.Tranentrdetah43);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH44, DbType.Double, entity.Tranentrdetah44);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH45, DbType.Double, entity.Tranentrdetah45);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH46, DbType.Double, entity.Tranentrdetah46);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH47, DbType.Double, entity.Tranentrdetah47);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH48, DbType.Double, entity.Tranentrdetah48);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH49, DbType.Double, entity.Tranentrdetah49);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH50, DbType.Double, entity.Tranentrdetah50);


            dbProvider.AddInParameter(command, helper.TRANENTRDETAH51, DbType.Double, entity.Tranentrdetah51);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH52, DbType.Double, entity.Tranentrdetah52);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH53, DbType.Double, entity.Tranentrdetah53);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH54, DbType.Double, entity.Tranentrdetah54);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH55, DbType.Double, entity.Tranentrdetah55);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH56, DbType.Double, entity.Tranentrdetah56);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH57, DbType.Double, entity.Tranentrdetah57);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH58, DbType.Double, entity.Tranentrdetah58);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH59, DbType.Double, entity.Tranentrdetah59);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH60, DbType.Double, entity.Tranentrdetah60);

            dbProvider.AddInParameter(command, helper.TRANENTRDETAH61, DbType.Double, entity.Tranentrdetah61);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH62, DbType.Double, entity.Tranentrdetah62);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH63, DbType.Double, entity.Tranentrdetah63);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH64, DbType.Double, entity.Tranentrdetah64);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH65, DbType.Double, entity.Tranentrdetah65);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH66, DbType.Double, entity.Tranentrdetah66);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH67, DbType.Double, entity.Tranentrdetah67);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH68, DbType.Double, entity.Tranentrdetah68);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH69, DbType.Double, entity.Tranentrdetah69);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH70, DbType.Double, entity.Tranentrdetah70);

            dbProvider.AddInParameter(command, helper.TRANENTRDETAH71, DbType.Double, entity.Tranentrdetah71);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH72, DbType.Double, entity.Tranentrdetah72);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH73, DbType.Double, entity.Tranentrdetah73);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH74, DbType.Double, entity.Tranentrdetah74);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH75, DbType.Double, entity.Tranentrdetah75);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH76, DbType.Double, entity.Tranentrdetah76);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH77, DbType.Double, entity.Tranentrdetah77);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH78, DbType.Double, entity.Tranentrdetah78);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH79, DbType.Double, entity.Tranentrdetah79);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH80, DbType.Double, entity.Tranentrdetah80);

            dbProvider.AddInParameter(command, helper.TRANENTRDETAH81, DbType.Double, entity.Tranentrdetah81);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH82, DbType.Double, entity.Tranentrdetah82);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH83, DbType.Double, entity.Tranentrdetah83);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH84, DbType.Double, entity.Tranentrdetah84);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH85, DbType.Double, entity.Tranentrdetah85);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH86, DbType.Double, entity.Tranentrdetah86);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH87, DbType.Double, entity.Tranentrdetah87);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH88, DbType.Double, entity.Tranentrdetah88);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH89, DbType.Double, entity.Tranentrdetah89);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH90, DbType.Double, entity.Tranentrdetah90);

            dbProvider.AddInParameter(command, helper.TRANENTRDETAH91, DbType.Double, entity.Tranentrdetah91);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH92, DbType.Double, entity.Tranentrdetah92);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH93, DbType.Double, entity.Tranentrdetah93);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH94, DbType.Double, entity.Tranentrdetah94);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH95, DbType.Double, entity.Tranentrdetah95);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAH96, DbType.Double, entity.Tranentrdetah96);

        
     
            dbProvider.AddInParameter(command, helper.TENTDEUSERNAME, DbType.String, entity.Tentdeusername);
            dbProvider.AddInParameter(command, helper.TRANENTRDETAFECINS, DbType.DateTime, DateTime.Now);
        

       

            return dbProvider.ExecuteNonQuery(command);
        }

        public void Update(TransferenciaEntregaDetalleDTO entity)
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
            dbProvider.AddInParameter(command, helper.TRANENTRDETAVERSION, DbType.Int32, version);
        
          dbProvider.ExecuteNonQuery(command);
        }

        public TransferenciaEntregaDetalleDTO GetById(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.TRANENTRDETACODI, DbType.Int32, id);
            TransferenciaEntregaDetalleDTO entity = null;

            //using (IDataReader dr = dbProvider.ExecuteReader(command))
            //{
            //    if (dr.Read())
            //    {
            //        entity = helper.Create(dr);
            //    }
            //}

            return entity;
        }

        public List<TransferenciaEntregaDetalleDTO> List(int emprcodi, int pericodi)
        {
            List<TransferenciaEntregaDetalleDTO> entitys = new List<TransferenciaEntregaDetalleDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);

            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    TransferenciaEntregaDetalleDTO entity = new TransferenciaEntregaDetalleDTO();

                    int iTENTCODIGO = dr.GetOrdinal(helper.TENTCODIGO);
                    if (!dr.IsDBNull(iTENTCODIGO)) entity.Tentcodigo = dr.GetString(iTENTCODIGO);

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<TransferenciaEntregaDetalleDTO> GetByCriteria(int emprcodi,int pericodi,string codientrcodi,int version)
        {
 

 
            List<TransferenciaEntregaDetalleDTO> entitys = new List<TransferenciaEntregaDetalleDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.CODIENTRCODIGO, DbType.String, codientrcodi);
            dbProvider.AddInParameter(command, helper.CODIENTRCODIGO, DbType.String, codientrcodi);
            dbProvider.AddInParameter(command, helper.TRANENTRVERSION, DbType.Int32, version);
            dbProvider.AddInParameter(command, helper.TRANENTRVERSION, DbType.Int32, version);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));

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


        public List<TransferenciaEntregaDetalleDTO> GetByPeriodoVersion(int pericodi, int version)
        {
            List<TransferenciaEntregaDetalleDTO> entitys = new List<TransferenciaEntregaDetalleDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListByPeriodoVersion);

            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.TRANENTRVERSION, DbType.Int32, version);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                   

                    TransferenciaEntregaDetalleDTO entity = new TransferenciaEntregaDetalleDTO();

                    int iEMPRCODI = dr.GetOrdinal(this.helper.EMPRCODI);
                    if (!dr.IsDBNull(iEMPRCODI)) entity.Emprcodi = dr.GetInt32(iEMPRCODI);

                    int iBARRCODI = dr.GetOrdinal(this.helper.BARRCODI);
                    if (!dr.IsDBNull(iBARRCODI)) entity.Barrcodi = dr.GetInt32(iBARRCODI);

                    int iCODIENTRCODIGO = dr.GetOrdinal(this.helper.CODIENTRCODIGO);
                    if (!dr.IsDBNull(iCODIENTRCODIGO)) entity.Codientrcodigo = dr.GetString(iCODIENTRCODIGO);

                    int iCENTGENECODI = dr.GetOrdinal(this.helper.CENTGENECODI);
                    if (!dr.IsDBNull(iCENTGENECODI)) entity.Centgenecodi = dr.GetInt32(iCENTGENECODI);

                    int iPERICODI = dr.GetOrdinal(this.helper.PERICODI);
                    if (!dr.IsDBNull(iPERICODI)) entity.Pericodi = dr.GetInt32(iPERICODI);

                    int iTRANENTRVERSION = dr.GetOrdinal(this.helper.TRANENTRVERSION);
                    if (!dr.IsDBNull(iTRANENTRVERSION)) entity.Tranentrversion = dr.GetInt32(iTRANENTRVERSION);

                    int iTIPOINFORMACION = dr.GetOrdinal(this.helper.TRANENTRTIPOINFORMACION);
                    if (!dr.IsDBNull(iTIPOINFORMACION)) entity.Tranentrtipoinformacion = dr.GetString(iTIPOINFORMACION);


                    entitys.Add(entity);

                }
            }

            return entitys;
        }


        public List<TransferenciaEntregaDetalleDTO> BalanceEnergiaActiva(int pericodi)
        {
            List<TransferenciaEntregaDetalleDTO> entitys = new List<TransferenciaEntregaDetalleDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlBalanceEnergiaActiva);

            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);


            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {


                    TransferenciaEntregaDetalleDTO entity = new TransferenciaEntregaDetalleDTO();

                    int iPERICODI = dr.GetOrdinal(this.helper.PERICODI);
                    if (!dr.IsDBNull(iPERICODI)) entity.Pericodi = dr.GetInt32(iPERICODI);

                    int iBARRCODI = dr.GetOrdinal(this.helper.BARRCODI);
                    if (!dr.IsDBNull(iBARRCODI)) entity.Barrcodi = dr.GetInt32(iBARRCODI);

                    int iNOMBBARRA = dr.GetOrdinal(this.helper.NOMBBARRA);
                    if (!dr.IsDBNull(iNOMBBARRA)) entity.Nombbarra = dr.GetString(iNOMBBARRA);

                    int iTENTCODIGO = dr.GetOrdinal(this.helper.TENTCODIGO);
                    if (!dr.IsDBNull(iTENTCODIGO)) entity.Tentcodigo = dr.GetString(iTENTCODIGO);

                    int iENERGIA = dr.GetOrdinal(this.helper.ENERGIA);
                    if (!dr.IsDBNull(iENERGIA)) entity.Energia = dr.GetDecimal(iENERGIA);




                    entitys.Add(entity);

                }
            }

            return entitys;
        }
    
      
    }
}
