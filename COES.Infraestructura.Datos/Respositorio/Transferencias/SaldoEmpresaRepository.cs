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
    public class SaldoEmpresaRepository : RepositoryBase, ISaldoEmpresaRepository
    {

        public SaldoEmpresaRepository(string strConn)
            : base(strConn)
        {


        }


        SaldoEmpresaHelper helper = new SaldoEmpresaHelper();

        public int Save(SaldoEmpresaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);



            dbProvider.AddInParameter(command, helper.SALEMPCODI, DbType.Int32, GetCodigoGenerado());
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, entity.PERICODI);
            dbProvider.AddInParameter(command, helper.EMPCODI, DbType.Int32, entity.EMPCODI);
            dbProvider.AddInParameter(command, helper.SALEMPVERSION, DbType.Int32, entity.SALEMPVERSION);
            dbProvider.AddInParameter(command, helper.SALEMPSALDO, DbType.Decimal, entity.SALEMPSALDO);   
            dbProvider.AddInParameter(command, helper.SALEMPFECINS, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.SALEMPUSERNAME, DbType.String, entity.SALEMPUSERNAME);



            return dbProvider.ExecuteNonQuery(command);
        }

        public void Update(SaldoEmpresaDTO entity)
        {
            //DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            //dbProvider.AddInParameter(command, helper.Barrnombre, DbType.String, entity.Barrnombre);
            //dbProvider.AddInParameter(command, helper.Barrtension, DbType.String, entity.Barrtension);
            //dbProvider.AddInParameter(command, helper.Barrpuntosumirer, DbType.String, entity.Barrpuntosumirer);
            //dbProvider.AddInParameter(command, helper.Barrbarrabgr, DbType.String, entity.Barrbarrabgr);
            //dbProvider.AddInParameter(command, helper.Barrflagbarrtran, DbType.String, entity.Barrflagbarrtran);
            //dbProvider.AddInParameter(command, helper.Barrnombbarrtran, DbType.String, entity.Barrnombbarrtran);
            //dbProvider.AddInParameter(command, helper.Barrestado, DbType.String, entity.Barrestado);
            //dbProvider.AddInParameter(command, helper.Barrfecact, DbType.DateTime, DateTime.Now);
            //dbProvider.AddInParameter(command, helper.Barrcodi, DbType.Int32, entity.Barrcodi);

            //dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int pericodi,int version)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            //dbProvider.AddInParameter(command, helper.Barrfecact, DbType.DateTime, DateTime.Now);
            dbProvider.AddInParameter(command, helper.PERICODI, DbType.Int32, pericodi);
              dbProvider.AddInParameter(command, helper.SALEMPVERSION, DbType.Int32, version);

            dbProvider.ExecuteNonQuery(command);

    
        }

        //public SaldoTotalTransmisionEmpresaDTO GetById(System.Int32 id)
        //{
        //    SaldoTotalTransmisionEmpresaDTO entity = null;

        //    //DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

        //    //dbProvider.AddInParameter(command, helper.Barrcodi, DbType.Int32, id);

        //    //using (IDataReader dr = dbProvider.ExecuteReader(command))
        //    //{
        //    //    if (dr.Read())
        //    //    {
        //    //        entity = helper.Create(dr);
        //    //    }
        //    //}

        //    return entity;
        //}

        //public List<SaldoTotalTransmisionEmpresaDTO> List()
        //{
        //    List<SaldoTotalTransmisionEmpresaDTO> entitys = new List<SaldoTotalTransmisionEmpresaDTO>();
        //    //DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);

        //    //using (IDataReader dr = dbProvider.ExecuteReader(command))
        //    //{
        //    //    while (dr.Read())
        //    //    {
        //    //        entitys.Add(helper.Create(dr));
        //    //    }
        //    //}

        //    return entitys;
        //}

        //public List<SaldoTotalTransmisionEmpresaDTO> GetByCriteria(string nombre)
        //{
        //    List<SaldoTotalTransmisionEmpresaDTO> entitys = new List<SaldoTotalTransmisionEmpresaDTO>();
        //    //DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
        //    //dbProvider.AddInParameter(command, helper.Barrnombre, DbType.String, nombre);

        //    //using (IDataReader dr = dbProvider.ExecuteReader(command))
        //    //{
        //    //    while (dr.Read())
        //    //    {
        //    //        entitys.Add(helper.Create(dr));
        //    //    }
        //    //}

        //    return entitys;
        //}

        public int GetCodigoGenerado()
        {
            int newId = 0;
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCodigoGenerado);
            newId = Int32.Parse(dbProvider.ExecuteScalar(command).ToString());

            return newId;
        }
    }
}
