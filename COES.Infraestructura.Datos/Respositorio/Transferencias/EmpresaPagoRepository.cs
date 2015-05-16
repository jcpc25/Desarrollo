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
    public class EmpresaPagoRepository : RepositoryBase, IEmpresaPagoRepository
    {
        public EmpresaPagoRepository(string strConn)
            : base(strConn)
        {
        }

        EmpresaPagoHelper helper = new EmpresaPagoHelper();    

      


        public int Save(EmpresaPagoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.EMPPAGOCODI, DbType.Int32, GetCodigoGenerado());
            dbProvider.AddInParameter(command, helper.VALTOTAEMPCODI, DbType.Int32, entity.VALTOTAEMPCODI);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, entity.PERICODI);
            dbProvider.AddInParameter(command, helper.EMPCODI, DbType.Int32, entity.EMPCODI);
            dbProvider.AddInParameter(command, helper.VALTOTAEMPVERSION, DbType.Int32, entity.VALTOTAEMPVERSION);           
            dbProvider.AddInParameter(command, helper.EMPPAGOCODEMPPAGO, DbType.Int32, entity.EMPPAGOCODEMPPAGO);
            dbProvider.AddInParameter(command, helper.EMPPAGOMONTO, DbType.Decimal, entity.EMPPAGOMONTO);
            dbProvider.AddInParameter(command, helper.EMPPAGUSERNAME, DbType.String, entity.EMPPAGUSERNAME);
            dbProvider.AddInParameter(command, helper.EMPPAGOFECINS, DbType.DateTime, DateTime.Now);


            return dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int PeriCodi, int Version)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);


            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, PeriCodi);
            dbProvider.AddInParameter(command, helper.VALTOTAEMPVERSION, DbType.Int32, Version);

            dbProvider.ExecuteNonQuery(command);
        }

        public List<EmpresaPagoDTO> GetByCriteria(int pericodi, int version)
        {
            List<EmpresaPagoDTO> entitys = new List<EmpresaPagoDTO>();
            //DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            //dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            //dbProvider.AddInParameter(command, helper.VALTOTAEMPVERSION, DbType.Int32, version);

            //using (IDataReader dr = dbProvider.ExecuteReader(command))
            //{
            //    while (dr.Read())
            //    {
            //        entitys.Add(helper.Create(dr));
            //    }
            //}

            return entitys;
        }

      

        public int GetCodigoGenerado()
        {
            int newId = 0;
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCodigoGenerado);
            newId = Int32.Parse(dbProvider.ExecuteScalar(command).ToString());

            return newId;
        }


        public List<EmpresaPagoDTO> GetEmpresaPositivaByCriteria(int pericodi, int version)
        {
           List<EmpresaPagoDTO> entitys = new List<EmpresaPagoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetEmpresaPositiva);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.VALTOTAEMPVERSION, DbType.Int32, version);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<EmpresaPagoDTO> GetEmpresaNegativaByCriteria(int pericodi, int version)
        {
            List<EmpresaPagoDTO> entitys = new List<EmpresaPagoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetEmpresaNegativa);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.VALTOTAEMPVERSION, DbType.Int32, version);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }
    }
}
