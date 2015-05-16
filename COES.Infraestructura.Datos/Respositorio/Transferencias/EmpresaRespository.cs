using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using COES.Dominio.DTO.Transferencias;
using COES.Dominio.Interfaces.Transferencias;
using COES.Base.Core;
using COES.Infraestructura.Datos.Helper.Transferencias;

namespace COES.Infraestructura.Datos.Respositorio.Transferencias
{

    public class EmpresaRepository: RepositoryBase, IEmpresaRepository
    {
        public EmpresaRepository(string strConn): base(strConn)
        {
        }

        EmpresaHelper helper = new EmpresaHelper();

        public EmpresaDTO GetById(System.Int32 id)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.EmprCodi, DbType.Int32, id);
            EmpresaDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public EmpresaDTO GetByCodigo(string nombre)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCodigo);

            dbProvider.AddInParameter(command, helper.EmprCodi, DbType.String, nombre);
            EmpresaDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EmpresaDTO> List()
        {
            List<EmpresaDTO> entitys = new List<EmpresaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<EmpresaDTO> GetByCriteria(string nombre)
        {
            List<EmpresaDTO> entitys = new List<EmpresaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.EmprNombre, DbType.String, nombre);

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
