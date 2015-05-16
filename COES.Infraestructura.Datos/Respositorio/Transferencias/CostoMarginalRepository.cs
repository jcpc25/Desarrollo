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
    public class CostoMarginalRepository : RepositoryBase, ICostoMarginalRepository
    {
        public CostoMarginalRepository(string strConn)
            : base(strConn)
        {
        }

        CostoMarginalHelper helper = new CostoMarginalHelper();

        public int Save(CostoMarginalDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);
            int IdCosMarCodi = GetCodigoGenerado();
            dbProvider.AddInParameter(command, helper.CosMarCodi, DbType.Int32, IdCosMarCodi);
            dbProvider.AddInParameter(command, helper.BarrCodi, DbType.Int32, entity.BarrCodi);
            dbProvider.AddInParameter(command, helper.CosMarBarraTransferencia, DbType.String, entity.CosMarBarraTransferencia);
            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, entity.PeriCodi);
            dbProvider.AddInParameter(command, helper.FacPerCodi, DbType.Int32, entity.FacPerCodi);
            dbProvider.AddInParameter(command, helper.CosMarVersion, DbType.Int32, entity.CosMarVersion);
            dbProvider.AddInParameter(command, helper.CosMarDia, DbType.Int32, entity.CosMarDia);
            dbProvider.AddInParameter(command, helper.CosMar1, DbType.Double, entity.CosMar1);
            dbProvider.AddInParameter(command, helper.CosMar2, DbType.Double, entity.CosMar2);
            dbProvider.AddInParameter(command, helper.CosMar3, DbType.Double, entity.CosMar3);
            dbProvider.AddInParameter(command, helper.CosMar4, DbType.Double, entity.CosMar4);
            dbProvider.AddInParameter(command, helper.CosMar5, DbType.Double, entity.CosMar5);
            dbProvider.AddInParameter(command, helper.CosMar6, DbType.Double, entity.CosMar6);
            dbProvider.AddInParameter(command, helper.CosMar7, DbType.Double, entity.CosMar7);
            dbProvider.AddInParameter(command, helper.CosMar8, DbType.Double, entity.CosMar8);
            dbProvider.AddInParameter(command, helper.CosMar9, DbType.Double, entity.CosMar9);
            dbProvider.AddInParameter(command, helper.CosMar10, DbType.Double, entity.CosMar10);
            dbProvider.AddInParameter(command, helper.CosMar11, DbType.Double, entity.CosMar11);
            dbProvider.AddInParameter(command, helper.CosMar12, DbType.Double, entity.CosMar12);
            dbProvider.AddInParameter(command, helper.CosMar13, DbType.Double, entity.CosMar13);
            dbProvider.AddInParameter(command, helper.CosMar14, DbType.Double, entity.CosMar14);
            dbProvider.AddInParameter(command, helper.CosMar15, DbType.Double, entity.CosMar15);
            dbProvider.AddInParameter(command, helper.CosMar16, DbType.Double, entity.CosMar16);
            dbProvider.AddInParameter(command, helper.CosMar17, DbType.Double, entity.CosMar17);
            dbProvider.AddInParameter(command, helper.CosMar18, DbType.Double, entity.CosMar18);
            dbProvider.AddInParameter(command, helper.CosMar19, DbType.Double, entity.CosMar19);
            dbProvider.AddInParameter(command, helper.CosMar20, DbType.Double, entity.CosMar20);
            dbProvider.AddInParameter(command, helper.CosMar21, DbType.Double, entity.CosMar21);
            dbProvider.AddInParameter(command, helper.CosMar22, DbType.Double, entity.CosMar22);
            dbProvider.AddInParameter(command, helper.CosMar23, DbType.Double, entity.CosMar23);
            dbProvider.AddInParameter(command, helper.CosMar24, DbType.Double, entity.CosMar24);
            dbProvider.AddInParameter(command, helper.CosMar25, DbType.Double, entity.CosMar25);
            dbProvider.AddInParameter(command, helper.CosMar26, DbType.Double, entity.CosMar26);
            dbProvider.AddInParameter(command, helper.CosMar27, DbType.Double, entity.CosMar27);
            dbProvider.AddInParameter(command, helper.CosMar28, DbType.Double, entity.CosMar28);
            dbProvider.AddInParameter(command, helper.CosMar29, DbType.Double, entity.CosMar29);
            dbProvider.AddInParameter(command, helper.CosMar30, DbType.Double, entity.CosMar30);
            dbProvider.AddInParameter(command, helper.CosMar31, DbType.Double, entity.CosMar31);
            dbProvider.AddInParameter(command, helper.CosMar32, DbType.Double, entity.CosMar32);
            dbProvider.AddInParameter(command, helper.CosMar33, DbType.Double, entity.CosMar33);
            dbProvider.AddInParameter(command, helper.CosMar34, DbType.Double, entity.CosMar34);
            dbProvider.AddInParameter(command, helper.CosMar35, DbType.Double, entity.CosMar35);
            dbProvider.AddInParameter(command, helper.CosMar36, DbType.Double, entity.CosMar36);
            dbProvider.AddInParameter(command, helper.CosMar37, DbType.Double, entity.CosMar37);
            dbProvider.AddInParameter(command, helper.CosMar38, DbType.Double, entity.CosMar38);
            dbProvider.AddInParameter(command, helper.CosMar39, DbType.Double, entity.CosMar39);
            dbProvider.AddInParameter(command, helper.CosMar40, DbType.Double, entity.CosMar40);
            dbProvider.AddInParameter(command, helper.CosMar41, DbType.Double, entity.CosMar41);
            dbProvider.AddInParameter(command, helper.CosMar42, DbType.Double, entity.CosMar42);
            dbProvider.AddInParameter(command, helper.CosMar43, DbType.Double, entity.CosMar43);
            dbProvider.AddInParameter(command, helper.CosMar44, DbType.Double, entity.CosMar44);
            dbProvider.AddInParameter(command, helper.CosMar45, DbType.Double, entity.CosMar45);
            dbProvider.AddInParameter(command, helper.CosMar46, DbType.Double, entity.CosMar46);
            dbProvider.AddInParameter(command, helper.CosMar47, DbType.Double, entity.CosMar47);
            dbProvider.AddInParameter(command, helper.CosMar48, DbType.Double, entity.CosMar48);
            dbProvider.AddInParameter(command, helper.CosMar49, DbType.Double, entity.CosMar49);
            dbProvider.AddInParameter(command, helper.CosMar50, DbType.Double, entity.CosMar50);
            dbProvider.AddInParameter(command, helper.CosMar51, DbType.Double, entity.CosMar51);
            dbProvider.AddInParameter(command, helper.CosMar52, DbType.Double, entity.CosMar52);
            dbProvider.AddInParameter(command, helper.CosMar53, DbType.Double, entity.CosMar53);
            dbProvider.AddInParameter(command, helper.CosMar54, DbType.Double, entity.CosMar54);
            dbProvider.AddInParameter(command, helper.CosMar55, DbType.Double, entity.CosMar55);
            dbProvider.AddInParameter(command, helper.CosMar56, DbType.Double, entity.CosMar56);
            dbProvider.AddInParameter(command, helper.CosMar57, DbType.Double, entity.CosMar57);
            dbProvider.AddInParameter(command, helper.CosMar58, DbType.Double, entity.CosMar58);
            dbProvider.AddInParameter(command, helper.CosMar59, DbType.Double, entity.CosMar59);
            dbProvider.AddInParameter(command, helper.CosMar60, DbType.Double, entity.CosMar60);
            dbProvider.AddInParameter(command, helper.CosMar61, DbType.Double, entity.CosMar61);
            dbProvider.AddInParameter(command, helper.CosMar62, DbType.Double, entity.CosMar62);
            dbProvider.AddInParameter(command, helper.CosMar63, DbType.Double, entity.CosMar63);
            dbProvider.AddInParameter(command, helper.CosMar64, DbType.Double, entity.CosMar64);
            dbProvider.AddInParameter(command, helper.CosMar65, DbType.Double, entity.CosMar65);
            dbProvider.AddInParameter(command, helper.CosMar66, DbType.Double, entity.CosMar66);
            dbProvider.AddInParameter(command, helper.CosMar67, DbType.Double, entity.CosMar67);
            dbProvider.AddInParameter(command, helper.CosMar68, DbType.Double, entity.CosMar68);
            dbProvider.AddInParameter(command, helper.CosMar69, DbType.Double, entity.CosMar69);
            dbProvider.AddInParameter(command, helper.CosMar70, DbType.Double, entity.CosMar70);
            dbProvider.AddInParameter(command, helper.CosMar71, DbType.Double, entity.CosMar71);
            dbProvider.AddInParameter(command, helper.CosMar72, DbType.Double, entity.CosMar72);
            dbProvider.AddInParameter(command, helper.CosMar73, DbType.Double, entity.CosMar73);
            dbProvider.AddInParameter(command, helper.CosMar74, DbType.Double, entity.CosMar74);
            dbProvider.AddInParameter(command, helper.CosMar75, DbType.Double, entity.CosMar75);
            dbProvider.AddInParameter(command, helper.CosMar76, DbType.Double, entity.CosMar76);
            dbProvider.AddInParameter(command, helper.CosMar77, DbType.Double, entity.CosMar77);
            dbProvider.AddInParameter(command, helper.CosMar78, DbType.Double, entity.CosMar78);
            dbProvider.AddInParameter(command, helper.CosMar79, DbType.Double, entity.CosMar79);
            dbProvider.AddInParameter(command, helper.CosMar80, DbType.Double, entity.CosMar80);
            dbProvider.AddInParameter(command, helper.CosMar81, DbType.Double, entity.CosMar81);
            dbProvider.AddInParameter(command, helper.CosMar82, DbType.Double, entity.CosMar82);
            dbProvider.AddInParameter(command, helper.CosMar83, DbType.Double, entity.CosMar83);
            dbProvider.AddInParameter(command, helper.CosMar84, DbType.Double, entity.CosMar84);
            dbProvider.AddInParameter(command, helper.CosMar85, DbType.Double, entity.CosMar85);
            dbProvider.AddInParameter(command, helper.CosMar86, DbType.Double, entity.CosMar86);
            dbProvider.AddInParameter(command, helper.CosMar87, DbType.Double, entity.CosMar87);
            dbProvider.AddInParameter(command, helper.CosMar88, DbType.Double, entity.CosMar88);
            dbProvider.AddInParameter(command, helper.CosMar89, DbType.Double, entity.CosMar89);
            dbProvider.AddInParameter(command, helper.CosMar90, DbType.Double, entity.CosMar90);
            dbProvider.AddInParameter(command, helper.CosMar91, DbType.Double, entity.CosMar91);
            dbProvider.AddInParameter(command, helper.CosMar92, DbType.Double, entity.CosMar92);
            dbProvider.AddInParameter(command, helper.CosMar93, DbType.Double, entity.CosMar93);
            dbProvider.AddInParameter(command, helper.CosMar94, DbType.Double, entity.CosMar94);
            dbProvider.AddInParameter(command, helper.CosMar95, DbType.Double, entity.CosMar95);
            dbProvider.AddInParameter(command, helper.CosMar96, DbType.Double, entity.CosMar96);
            dbProvider.AddInParameter(command, helper.CosMarPromedioDia, DbType.Double, entity.CosMarPromedioDia);
            dbProvider.AddInParameter(command, helper.CosMarUserName, DbType.String, entity.CosMarUserName);
            dbProvider.AddInParameter(command, helper.CosMarFecIns, DbType.DateTime, DateTime.Now);

            dbProvider.ExecuteNonQuery(command);
            return IdCosMarCodi;
        }

        public void Delete(System.Int32 PeriCod, System.Int32 CosMarVersion)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, PeriCod);
            dbProvider.AddInParameter(command, helper.CosMarVersion, DbType.Int32, CosMarVersion);

            dbProvider.ExecuteNonQuery(command);
        }

        public int GetCodigoGenerado()
        {
            int newId = 0;
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCodigoGenerado);
            newId = Int32.Parse(dbProvider.ExecuteScalar(command).ToString());

            return newId;
        }

        public List<CostoMarginalDTO> List(int pericodi)
        {
            List<CostoMarginalDTO> entitys = new List<CostoMarginalDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
            
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    CostoMarginalDTO entity = new CostoMarginalDTO();

                    int iBARRCODI = dr.GetOrdinal(this.helper.BarrCodi);
                    if (!dr.IsDBNull(iBARRCODI)) entity.BarrCodi = dr.GetInt32(iBARRCODI);

                    int iCosMarBarraTransferencia = dr.GetOrdinal(this.helper.CosMarBarraTransferencia);
                    if (!dr.IsDBNull(iCosMarBarraTransferencia)) entity.CosMarBarraTransferencia = dr.GetString(iCosMarBarraTransferencia);
                   
                    entitys.Add(entity);

                }
            }

            return entitys;

        }

        public List<CostoMarginalDTO> GetByCriteria(int pericodi, string barrcodi)
        {
            List<CostoMarginalDTO> entitys = new List<CostoMarginalDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.BarrCodi, DbType.Int32, barrcodi);
            dbProvider.AddInParameter(command, helper.BarrCodi, DbType.Int32, barrcodi);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));

                }
            }

            return entitys;
        }

        public List<CostoMarginalDTO> ListByBarrPeriodoVersion(int barrcodi, int pericodi, int costmargversion)
        {
            List<CostoMarginalDTO> entitys = new List<CostoMarginalDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListByBarraPeriodoVers);

            dbProvider.AddInParameter(command, helper.BarrCodi, DbType.Int32, barrcodi);
            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.CosMarVersion, DbType.Int32, costmargversion);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));

                }
            }
            return entitys;
        }

        public List<CostoMarginalDTO> GetByCodigo(int? pericodi)
        {
            List<CostoMarginalDTO> entitys = new List<CostoMarginalDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCodigo);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {

                    entitys.Add(helper.Create(dr));


                }
            }
            return entitys;
        }

        public List<CostoMarginalDTO> GetByBarraTransferencia(int pericodi, int cosmarversion)
        {
            List<CostoMarginalDTO> entitys = new List<CostoMarginalDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByBarraTransferencia);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.CosMarVersion, DbType.Int32, cosmarversion);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    CostoMarginalDTO entity = new CostoMarginalDTO();

                    int iBarrCodi = dr.GetOrdinal(helper.BarrCodi);
                    if (!dr.IsDBNull(iBarrCodi)) entity.BarrCodi = dr.GetInt32(iBarrCodi);

                    int iCosMarBarraTransferencia = dr.GetOrdinal(helper.CosMarBarraTransferencia);
                    if (!dr.IsDBNull(iCosMarBarraTransferencia)) entity.CosMarBarraTransferencia = dr.GetString(iCosMarBarraTransferencia);

                    entitys.Add(entity);

                }
            }

            return entitys;
        }

    }
}
