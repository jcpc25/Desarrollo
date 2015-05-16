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
    public class TransferenciaRetiroDetalleRepository : RepositoryBase, ITransferenciaRetiroDetalleRepository
    {

        public TransferenciaRetiroDetalleRepository(string strConn)
            : base(strConn)
        {

        }


        TransferenciaRetiroDetalleHelper helper = new TransferenciaRetiroDetalleHelper();

        public int Save(TransferenciaRetiroDetalleDTO entity)
        {


            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.TRANRETICODI, DbType.Int32, entity.Tranreticodi);
            dbProvider.AddInParameter(command, helper.TRANRETIDETACODI, DbType.Int32, GetCodigoGenerado());
            dbProvider.AddInParameter(command, helper.TRANRETIDETAVERSION, DbType.Int32, entity.Tranretidetaversion);
            dbProvider.AddInParameter(command, helper.TRANRETIDETADIA, DbType.Int32, entity.Tranretidetadia);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAPROMDIA, DbType.Decimal, entity.Tranretidetapromdia);
            dbProvider.AddInParameter(command, helper.TRANRETIDETASUMADIA, DbType.Decimal, entity.Tranretidetasumadia);
            
            
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH1, DbType.Double, entity.Tranretidetah1);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH2, DbType.Double, entity.Tranretidetah2);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH3, DbType.Double, entity.Tranretidetah3);           
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH4, DbType.Double, entity.Tranretidetah4);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH5, DbType.Double, entity.Tranretidetah5);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH6, DbType.Double,entity.Tranretidetah6);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH7, DbType.Double,entity.Tranretidetah7);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH8, DbType.Double,entity.Tranretidetah8);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH9, DbType.Double, entity.Tranretidetah9);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH10, DbType.Double, entity.Tranretidetah10);

            dbProvider.AddInParameter(command, helper.TRANRETIDETAH11, DbType.Double, entity.Tranretidetah11);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH12, DbType.Double, entity.Tranretidetah12);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH13, DbType.Double, entity.Tranretidetah13);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH14, DbType.Double, entity.Tranretidetah14);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH15, DbType.Double, entity.Tranretidetah15);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH16, DbType.Double, entity.Tranretidetah16);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH17, DbType.Double, entity.Tranretidetah17);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH18, DbType.Double, entity.Tranretidetah18);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH19, DbType.Double, entity.Tranretidetah19);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH20, DbType.Double, entity.Tranretidetah20);

            dbProvider.AddInParameter(command, helper.TRANRETIDETAH21, DbType.Double, entity.Tranretidetah21);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH22, DbType.Double, entity.Tranretidetah22);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH23, DbType.Double, entity.Tranretidetah23);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH24, DbType.Double, entity.Tranretidetah24);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH25, DbType.Double, entity.Tranretidetah25);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH26, DbType.Double, entity.Tranretidetah26);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH27, DbType.Double, entity.Tranretidetah27);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH28, DbType.Double, entity.Tranretidetah28);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH29, DbType.Double, entity.Tranretidetah29);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH30, DbType.Double, entity.Tranretidetah30);

            dbProvider.AddInParameter(command, helper.TRANRETIDETAH31, DbType.Double, entity.Tranretidetah31);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH32, DbType.Double, entity.Tranretidetah32);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH33, DbType.Double, entity.Tranretidetah33);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH34, DbType.Double, entity.Tranretidetah34);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH35, DbType.Double, entity.Tranretidetah35);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH36, DbType.Double, entity.Tranretidetah36);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH37, DbType.Double, entity.Tranretidetah37);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH38, DbType.Double, entity.Tranretidetah38);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH39, DbType.Double, entity.Tranretidetah39);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH40, DbType.Double, entity.Tranretidetah40);

            dbProvider.AddInParameter(command, helper.TRANRETIDETAH41, DbType.Double, entity.Tranretidetah41);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH42, DbType.Double, entity.Tranretidetah42);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH43, DbType.Double, entity.Tranretidetah43);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH44, DbType.Double, entity.Tranretidetah44);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH45, DbType.Double, entity.Tranretidetah45);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH46, DbType.Double, entity.Tranretidetah46);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH47, DbType.Double, entity.Tranretidetah47);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH48, DbType.Double, entity.Tranretidetah48);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH49, DbType.Double, entity.Tranretidetah49);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH50, DbType.Double, entity.Tranretidetah50);


            dbProvider.AddInParameter(command, helper.TRANRETIDETAH51, DbType.Double, entity.Tranretidetah51);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH52, DbType.Double, entity.Tranretidetah52);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH53, DbType.Double, entity.Tranretidetah53);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH54, DbType.Double, entity.Tranretidetah54);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH55, DbType.Double, entity.Tranretidetah55);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH56, DbType.Double, entity.Tranretidetah56);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH57, DbType.Double, entity.Tranretidetah57);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH58, DbType.Double, entity.Tranretidetah58);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH59, DbType.Double, entity.Tranretidetah59);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH60, DbType.Double, entity.Tranretidetah60);

            dbProvider.AddInParameter(command, helper.TRANRETIDETAH61, DbType.Double, entity.Tranretidetah61);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH62, DbType.Double, entity.Tranretidetah62);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH63, DbType.Double, entity.Tranretidetah63);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH64, DbType.Double, entity.Tranretidetah64);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH65, DbType.Double, entity.Tranretidetah65);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH66, DbType.Double, entity.Tranretidetah66);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH67, DbType.Double, entity.Tranretidetah67);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH68, DbType.Double, entity.Tranretidetah68);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH69, DbType.Double, entity.Tranretidetah69);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH70, DbType.Double, entity.Tranretidetah70);

            dbProvider.AddInParameter(command, helper.TRANRETIDETAH71, DbType.Double, entity.Tranretidetah71);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH72, DbType.Double, entity.Tranretidetah72);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH73, DbType.Double, entity.Tranretidetah73);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH74, DbType.Double, entity.Tranretidetah74);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH75, DbType.Double, entity.Tranretidetah75);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH76, DbType.Double, entity.Tranretidetah76);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH77, DbType.Double, entity.Tranretidetah77);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH78, DbType.Double, entity.Tranretidetah78);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH79, DbType.Double, entity.Tranretidetah79);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH80, DbType.Double, entity.Tranretidetah80);

            dbProvider.AddInParameter(command, helper.TRANRETIDETAH81, DbType.Double, entity.Tranretidetah81);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH82, DbType.Double, entity.Tranretidetah82);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH83, DbType.Double, entity.Tranretidetah83);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH84, DbType.Double, entity.Tranretidetah84);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH85, DbType.Double, entity.Tranretidetah85);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH86, DbType.Double, entity.Tranretidetah86);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH87, DbType.Double, entity.Tranretidetah87);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH88, DbType.Double, entity.Tranretidetah88);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH89, DbType.Double, entity.Tranretidetah89);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH90, DbType.Double, entity.Tranretidetah90);

            dbProvider.AddInParameter(command, helper.TRANRETIDETAH91, DbType.Double, entity.Tranretidetah91);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH92, DbType.Double, entity.Tranretidetah92);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH93, DbType.Double, entity.Tranretidetah93);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH94, DbType.Double, entity.Tranretidetah94);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH95, DbType.Double, entity.Tranretidetah95);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAH96, DbType.Double, entity.Tranretidetah96);



            dbProvider.AddInParameter(command, helper.TRETDEUSERNAME, DbType.String, entity.Tretdeusername);
            dbProvider.AddInParameter(command, helper.TRANRETIDETAFECINS, DbType.DateTime,DateTime.Now);

 

   


            return dbProvider.ExecuteNonQuery(command);
        }

        public void Update(TransferenciaRetiroDetalleDTO entity)
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
            dbProvider.AddInParameter(command, helper.TRANRETIVERSION, DbType.Int32, version);
      
            dbProvider.ExecuteNonQuery(command);
        }

        public TransferenciaRetiroDetalleDTO GetById(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.TRANRETICODI, DbType.Int32, id);
            TransferenciaRetiroDetalleDTO entity = null;

            //using (IDataReader dr = dbProvider.ExecuteReader(command))
            //{
            //    if (dr.Read())
            //    {
            //        entity = helper.Create(dr);
            //    }
            //}

            return entity;
        }

        public List<TransferenciaRetiroDetalleDTO> List(int emprcodi, int pericodi)
        {
            List<TransferenciaRetiroDetalleDTO> entitys = new List<TransferenciaRetiroDetalleDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);

            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);


            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    TransferenciaRetiroDetalleDTO entity = new TransferenciaRetiroDetalleDTO();

                    int iSOLICODIRETICODIGO = dr.GetOrdinal(helper.SOLICODIRETICODIGO);
                    if (!dr.IsDBNull(iSOLICODIRETICODIGO)) entity.Solicodireticodigo = dr.GetString(iSOLICODIRETICODIGO);

                    entitys.Add(entity);

                    
                }
            }

            return entitys;
        }

        public List<TransferenciaRetiroDetalleDTO> GetByCriteria(int emprcodi, int pericodi, string solicodireticodigo,int version)
        {
            List<TransferenciaRetiroDetalleDTO> entitys = new List<TransferenciaRetiroDetalleDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.SOLICODIRETICODIGO, DbType.String, solicodireticodigo);
            dbProvider.AddInParameter(command, helper.SOLICODIRETICODIGO, DbType.String, solicodireticodigo);
            dbProvider.AddInParameter(command, helper.TRANRETIVERSION, DbType.Int32, version);
            dbProvider.AddInParameter(command, helper.TRANRETIVERSION, DbType.Int32, version);
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

       public  List<TransferenciaRetiroDetalleDTO> GetByPeriodoVersion(int pericodi, int version)
        {
            List<TransferenciaRetiroDetalleDTO> entitys = new List<TransferenciaRetiroDetalleDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListByPeriodoVersion);

            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.TRANRETIVERSION, DbType.Int32, version);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    TransferenciaRetiroDetalleDTO entity = new TransferenciaRetiroDetalleDTO();

                    /////////////////
                    int iEMPRCODI = dr.GetOrdinal(this.helper.EMPRCODI);
                    if (!dr.IsDBNull(iEMPRCODI)) entity.Emprcodi = dr.GetInt32(iEMPRCODI);

                    int iBARRCODI = dr.GetOrdinal(this.helper.BARRCODI);
                    if (!dr.IsDBNull(iBARRCODI)) entity.Barrcodi = dr.GetInt32(iBARRCODI);

                    int iSOLICODIRETICODIGO = dr.GetOrdinal(this.helper.SOLICODIRETICODIGO);
                    if (!dr.IsDBNull(iSOLICODIRETICODIGO)) entity.Solicodireticodigo = dr.GetString(iSOLICODIRETICODIGO);

                    int iCLICODI = dr.GetOrdinal(this.helper.CLICODI);
                    if (!dr.IsDBNull(iCLICODI)) entity.Clicodi = dr.GetInt32(iCLICODI);


                    int iPERICODI = dr.GetOrdinal(this.helper.PERICODI);
                    if (!dr.IsDBNull(iPERICODI)) entity.Pericodi = dr.GetInt32(iPERICODI);

                    int iTRANRETIVERSION = dr.GetOrdinal(this.helper.TRANRETIVERSION);
                    if (!dr.IsDBNull(iTRANRETIVERSION)) entity.Tretversion = dr.GetInt32(iTRANRETIVERSION);

                    int iTRANRETITIPOINFORMACION = dr.GetOrdinal(this.helper.TRANRETITIPOINFORMACION);
                    if (!dr.IsDBNull(iTRANRETITIPOINFORMACION)) entity.Tranretitipoinformacion = dr.GetString(iTRANRETITIPOINFORMACION);

                    int iTRETTABLA = dr.GetOrdinal(this.helper.TRETTABLA);
                    if (!dr.IsDBNull(iTRETTABLA)) entity.TretTabla = dr.GetString(iTRETTABLA);

           
                    entitys.Add(entity);

                }
            }

            return entitys;
        }
    

    }
}
