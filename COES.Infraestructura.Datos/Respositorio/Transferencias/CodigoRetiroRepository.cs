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
    public class CodigoRetiroRepository : RepositoryBase, ICodigoRetiroRepository
    {
        public CodigoRetiroRepository(string strConn)
            : base(strConn)
        {
        }

        CodigoRetiroHelper helper = new CodigoRetiroHelper();


        public int Save(CodigoRetiroDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);    
            dbProvider.AddInParameter(command, helper.SOLICODIRETICODI, DbType.Int32, GetCodigoGenerado());
            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.BARRCODI, DbType.Int32, entity.Barrcodi);
            dbProvider.AddInParameter(command, helper.USUACODI, DbType.String, entity.Usuacodi);
            dbProvider.AddInParameter(command, helper.TIPOCONTCODI, DbType.Int32, entity.Tipocontcodi);
            dbProvider.AddInParameter(command, helper.TIPOUSUACODI, DbType.Int32, entity.Tipousuacodi);
            dbProvider.AddInParameter(command, helper.CLICODI, DbType.Int32, entity.Clicodi);
            dbProvider.AddInParameter(command, helper.SOLICODIRETICODIGO, DbType.String, entity.Solicodireticodigo);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHAREGISTRO, DbType.DateTime, entity.Solicodiretifecharegistro);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIDESCRIPCION, DbType.String, entity.Solicodiretidescripcion);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIDETALLEAMPLIO, DbType.String, entity.Solicodiretidetalleamplio);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHAINICIO, DbType.DateTime, entity.Solicodiretifechainicio);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHAFIN, DbType.DateTime, entity.Solicodiretifechafin);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIOBSERVACION, DbType.String, entity.Solicodiretiobservacion);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIESTADO, DbType.String, entity.Solicodiretiestado);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIFECINS, DbType.DateTime, DateTime.Now.Date);
          
            return dbProvider.ExecuteNonQuery(command);
        }

        public void Update(CodigoRetiroDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);


           
            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.BARRCODI, DbType.Int32, entity.Barrcodi);
            dbProvider.AddInParameter(command, helper.COESUSERNAME, DbType.String, entity.Coesusername);
            dbProvider.AddInParameter(command, helper.TIPOCONTCODI, DbType.Int32, entity.Tipocontcodi);
            dbProvider.AddInParameter(command, helper.TIPOUSUACODI, DbType.Int32, entity.Tipousuacodi);
            dbProvider.AddInParameter(command, helper.CLICODI, DbType.Int32, entity.Clicodi);
            dbProvider.AddInParameter(command, helper.SOLICODIRETICODIGO, DbType.String, entity.Solicodireticodigo);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHAREGISTRO, DbType.DateTime, entity.Solicodiretifecharegistro);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIDESCRIPCION, DbType.String, entity.Solicodiretidescripcion);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIDETALLEAMPLIO, DbType.String, entity.Solicodiretidetalleamplio);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHAINICIO, DbType.DateTime, entity.Solicodiretifechainicio);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHAFIN, DbType.DateTime, entity.Solicodiretifechafin);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIOBSERVACION, DbType.String, entity.Solicodiretiobservacion);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIESTADO, DbType.String, entity.Solicodiretiestado);          
            dbProvider.AddInParameter(command, helper.SOLICODIRETIFECACT, DbType.DateTime, DateTime.Now.Date);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHASOLBAJA, DbType.DateTime, entity.Solicodiretifechasolbaja);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHADEBAJA, DbType.DateTime,  entity.Solicodiretifechadebaja);
         
            dbProvider.AddInParameter(command, helper.SOLICODIRETICODI, DbType.Int32, entity.Solicodireticodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);


            dbProvider.AddInParameter(command, helper.SOLICODIRETIFECACT, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.SOLICODIRETICODI, DbType.Int32, id);

            dbProvider.ExecuteNonQuery(command);
        }

        public CodigoRetiroDTO GetById(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.SOLICODIRETICODI, DbType.Int32, id);
            CodigoRetiroDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<CodigoRetiroDTO> List(string estado)
        {
            List<CodigoRetiroDTO> entitys = new List<CodigoRetiroDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);
            dbProvider.AddInParameter(command, helper.SOLICODIRETIESTADO, DbType.String, estado);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<CodigoRetiroDTO> GetByCriteria(string nombreEmp, string tipousu, string tipocont, string bartran, string clinomb, DateTime? fechaIni, DateTime? fechaFin, string Solicodiretiobservacion, string estado)
        {
            //BUSCA LISTA SEGUN CODIGO DE CODIGODE ENTREGA
                    List<CodigoRetiroDTO> entitys = new List<CodigoRetiroDTO>();
                    DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);  

                    dbProvider.AddInParameter(command, helper.EMPRNOMB, DbType.String, nombreEmp);
                    dbProvider.AddInParameter(command, helper.EMPRNOMB, DbType.String, nombreEmp);

                    dbProvider.AddInParameter(command, helper.TIPOUSUANOMBRE, DbType.String,  tipousu);
                    dbProvider.AddInParameter(command, helper.TIPOUSUANOMBRE, DbType.String, tipousu);

                    dbProvider.AddInParameter(command, helper.TIPOCONTNOMBRE, DbType.String, tipocont);
                    dbProvider.AddInParameter(command, helper.TIPOCONTNOMBRE, DbType.String, tipocont);

                    dbProvider.AddInParameter(command, helper.BARRNOMBBARRTRAN, DbType.String, bartran);
                    dbProvider.AddInParameter(command, helper.BARRNOMBBARRTRAN, DbType.String, bartran);

                    dbProvider.AddInParameter(command, helper.CLINOMBRE, DbType.String, clinomb);
                    dbProvider.AddInParameter(command, helper.CLINOMBRE, DbType.String, clinomb);

                    dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHAINICIO, DbType.DateTime, fechaIni);
                    dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHAINICIO, DbType.DateTime, fechaIni);


                    dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHAFIN, DbType.DateTime, fechaFin);
                    dbProvider.AddInParameter(command, helper.SOLICODIRETIFECHAFIN, DbType.DateTime, fechaFin);

                    dbProvider.AddInParameter(command, helper.SOLICODIRETIOBSERVACION, DbType.String, Solicodiretiobservacion);
                    dbProvider.AddInParameter(command, helper.SOLICODIRETIOBSERVACION, DbType.String, Solicodiretiobservacion);

                    dbProvider.AddInParameter(command, helper.SOLICODIRETIESTADO, DbType.String, estado);
                    dbProvider.AddInParameter(command, helper.SOLICODIRETIESTADO, DbType.String, estado);

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

        public CodigoRetiroDTO GetByCodigoRetiCodigo(System.String CodiReticodigo)
            {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlObtenerPorCodigoRetiroCodigo);

            dbProvider.AddInParameter(command, helper.TRETCODIGO, DbType.String, CodiReticodigo);

            CodigoRetiroDTO entity = new CodigoRetiroDTO();

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {


                    int iTRETTABLA = dr.GetOrdinal(this.helper.TRETTABLA);
                    if (!dr.IsDBNull(iTRETTABLA)) entity.Trettabla = dr.GetString(iTRETTABLA);

                    int iTRETCORESOCORESCCODI = dr.GetOrdinal(this.helper.TRETCORESOCORESCCODI);
                    if (!dr.IsDBNull(iTRETCORESOCORESCCODI)) entity.Solicodireticodi = dr.GetInt32(iTRETCORESOCORESCCODI);

                    int iTRETCODIGO = dr.GetOrdinal(this.helper.TRETCODIGO);
                    if (!dr.IsDBNull(iTRETCODIGO)) entity.Solicodireticodigo = dr.GetString(iTRETCODIGO);

                    int iBARRCODI = dr.GetOrdinal(this.helper.BARRCODI);
                    if (!dr.IsDBNull(iBARRCODI)) entity.Barrcodi = dr.GetInt32(iBARRCODI);

                    int iEMPRCODI = dr.GetOrdinal(this.helper.EMPRCODI);
                    if (!dr.IsDBNull(iEMPRCODI)) entity.Emprcodi = dr.GetInt32(iEMPRCODI);

                    int iCLICODI = dr.GetOrdinal(this.helper.CLICODI);
                    if (!dr.IsDBNull(iCLICODI)) entity.Clicodi = dr.GetInt32(iCLICODI);




                }
            }

            return entity;
        }

       
        
    }
}
