using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using COES.Dominio.Interfaces.Transferencias;
using COES.Infraestructura.Datos.Helper.Transferencias;
using System.Data;
using System.Data.Common;

namespace COES.Infraestructura.Datos.Respositorio.Transferencias
{
   public class RatioCumplimientoRepository: RepositoryBase, IRatioCumplimientoRepository
    {
             public RatioCumplimientoRepository(string strConn)
            : base(strConn)
        {
        }

        RatioCumplimientoHelper helper = new RatioCumplimientoHelper();

        public List<RatioCumplimientoDTO> GetByCodigo(int? tipoemprcodi, int? pericodi)
        {


            List<RatioCumplimientoDTO> entitys = new List<RatioCumplimientoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCodigo);

            dbProvider.AddInParameter(command, helper.Tipoemprcodi, DbType.Int32, tipoemprcodi);
            dbProvider.AddInParameter(command, helper.Tipoemprcodi, DbType.Int32, tipoemprcodi);

            dbProvider.AddInParameter(command, helper.Pericodi, DbType.Int32, pericodi);
            dbProvider.AddInParameter(command, helper.Pericodi, DbType.Int32, pericodi);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {

                    entitys.Add(helper.Create(dr));


                }
            }

            return entitys;
        }

        public List<RatioCumplimientoDTO> GetByCriteria(string nombre)
        {
            List<RatioCumplimientoDTO> entitys = new List<RatioCumplimientoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.Emprnomb, DbType.String, nombre);

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
