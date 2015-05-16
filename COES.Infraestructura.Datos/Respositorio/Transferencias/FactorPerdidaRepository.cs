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
   public class FactorPerdidaRepository: RepositoryBase, IFactorPerdidaRepository
    {
        public FactorPerdidaRepository(string strConn): base(strConn)
        {
        }

        FactorPerdidaHelper helper = new FactorPerdidaHelper();

        public int Save(FactorPerdidaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);
            int IdFactorPerdida = GetCodigoGenerado();
            dbProvider.AddInParameter(command, helper.FacPerCodi, DbType.Int32, IdFactorPerdida);
            dbProvider.AddInParameter(command, helper.BarrCodi, DbType.Int32, entity.BarrCodi);
            dbProvider.AddInParameter(command, helper.FacPerBarrNombre, DbType.String, entity.FacPerBarrNombre);
            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, entity.PeriCodi);
            dbProvider.AddInParameter(command, helper.FacPerBase, DbType.String, entity.FacPerBase);
            dbProvider.AddInParameter(command, helper.FacPerVersion, DbType.Int32, entity.FacPerVersion);
            dbProvider.AddInParameter(command, helper.FacPerDia, DbType.Int32, entity.FacPerDia);
            dbProvider.AddInParameter(command, helper.FacPer1, DbType.Double, entity.FacPer1);
            dbProvider.AddInParameter(command, helper.FacPer2, DbType.Double, entity.FacPer2);
            dbProvider.AddInParameter(command, helper.FacPer3, DbType.Double, entity.FacPer3);
            dbProvider.AddInParameter(command, helper.FacPer4, DbType.Double, entity.FacPer4);
            dbProvider.AddInParameter(command, helper.FacPer5, DbType.Double, entity.FacPer5);
            dbProvider.AddInParameter(command, helper.FacPer6, DbType.Double, entity.FacPer6);
            dbProvider.AddInParameter(command, helper.FacPer7, DbType.Double, entity.FacPer7);
            dbProvider.AddInParameter(command, helper.FacPer8, DbType.Double, entity.FacPer8);
            dbProvider.AddInParameter(command, helper.FacPer9, DbType.Double, entity.FacPer9);
            dbProvider.AddInParameter(command, helper.FacPer10, DbType.Double, entity.FacPer10);
            dbProvider.AddInParameter(command, helper.FacPer11, DbType.Double, entity.FacPer11);
            dbProvider.AddInParameter(command, helper.FacPer12, DbType.Double, entity.FacPer12);
            dbProvider.AddInParameter(command, helper.FacPer13, DbType.Double, entity.FacPer13);
            dbProvider.AddInParameter(command, helper.FacPer14, DbType.Double, entity.FacPer14);
            dbProvider.AddInParameter(command, helper.FacPer15, DbType.Double, entity.FacPer15);
            dbProvider.AddInParameter(command, helper.FacPer16, DbType.Double, entity.FacPer16);
            dbProvider.AddInParameter(command, helper.FacPer17, DbType.Double, entity.FacPer17);
            dbProvider.AddInParameter(command, helper.FacPer18, DbType.Double, entity.FacPer18);
            dbProvider.AddInParameter(command, helper.FacPer19, DbType.Double, entity.FacPer19);
            dbProvider.AddInParameter(command, helper.FacPer20, DbType.Double, entity.FacPer20);
            dbProvider.AddInParameter(command, helper.FacPer21, DbType.Double, entity.FacPer21);
            dbProvider.AddInParameter(command, helper.FacPer22, DbType.Double, entity.FacPer22);
            dbProvider.AddInParameter(command, helper.FacPer23, DbType.Double, entity.FacPer23);
            dbProvider.AddInParameter(command, helper.FacPer24, DbType.Double, entity.FacPer24);
            dbProvider.AddInParameter(command, helper.FacPer25, DbType.Double, entity.FacPer25);
            dbProvider.AddInParameter(command, helper.FacPer26, DbType.Double, entity.FacPer26);
            dbProvider.AddInParameter(command, helper.FacPer27, DbType.Double, entity.FacPer27);
            dbProvider.AddInParameter(command, helper.FacPer28, DbType.Double, entity.FacPer28);
            dbProvider.AddInParameter(command, helper.FacPer29, DbType.Double, entity.FacPer29);
            dbProvider.AddInParameter(command, helper.FacPer30, DbType.Double, entity.FacPer30);
            dbProvider.AddInParameter(command, helper.FacPer31, DbType.Double, entity.FacPer31);
            dbProvider.AddInParameter(command, helper.FacPer32, DbType.Double, entity.FacPer32);
            dbProvider.AddInParameter(command, helper.FacPer33, DbType.Double, entity.FacPer33);
            dbProvider.AddInParameter(command, helper.FacPer34, DbType.Double, entity.FacPer34);
            dbProvider.AddInParameter(command, helper.FacPer35, DbType.Double, entity.FacPer35);
            dbProvider.AddInParameter(command, helper.FacPer36, DbType.Double, entity.FacPer36);
            dbProvider.AddInParameter(command, helper.FacPer37, DbType.Double, entity.FacPer37);
            dbProvider.AddInParameter(command, helper.FacPer38, DbType.Double, entity.FacPer38);
            dbProvider.AddInParameter(command, helper.FacPer39, DbType.Double, entity.FacPer39);
            dbProvider.AddInParameter(command, helper.FacPer40, DbType.Double, entity.FacPer40);
            dbProvider.AddInParameter(command, helper.FacPer41, DbType.Double, entity.FacPer41);
            dbProvider.AddInParameter(command, helper.FacPer42, DbType.Double, entity.FacPer42);
            dbProvider.AddInParameter(command, helper.FacPer43, DbType.Double, entity.FacPer43);
            dbProvider.AddInParameter(command, helper.FacPer44, DbType.Double, entity.FacPer44);
            dbProvider.AddInParameter(command, helper.FacPer45, DbType.Double, entity.FacPer45);
            dbProvider.AddInParameter(command, helper.FacPer46, DbType.Double, entity.FacPer46);
            dbProvider.AddInParameter(command, helper.FacPer47, DbType.Double, entity.FacPer47);
            dbProvider.AddInParameter(command, helper.FacPer48, DbType.Double, entity.FacPer48);
            dbProvider.AddInParameter(command, helper.FacPerUserName, DbType.String, entity.FacPerUserName);
            dbProvider.AddInParameter(command, helper.FacPerFecIns, DbType.DateTime, DateTime.Now);

            dbProvider.ExecuteNonQuery(command);
            return IdFactorPerdida;
        }

        public void Delete(System.Int32 PeriCod, System.Int32 FacPerVersion)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, PeriCod);
            dbProvider.AddInParameter(command, helper.FacPerVersion, DbType.Int32, FacPerVersion);

            dbProvider.ExecuteNonQuery(command);
        }

        public List<FactorPerdidaDTO> ListByPeriodoVersion(int IPeriCodi, int IFacPerVersion)
        {
            List<FactorPerdidaDTO> entitys = new List<FactorPerdidaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListByPeriodoVersion);

            dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, IPeriCodi);
            dbProvider.AddInParameter(command, helper.FacPerVersion, DbType.Int32, IFacPerVersion);
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


    }
}
