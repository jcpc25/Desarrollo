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
  public  class IngresoCompensacionRepository: RepositoryBase, IIngresoCompensacionRepository
    {

      public IngresoCompensacionRepository(string strConn): base(strConn)
        {
        }

      IngresoCompensacionHelper helper = new IngresoCompensacionHelper();

      public int Save(IngresoCompensacionDTO entity)
      {
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

          dbProvider.AddInParameter(command, helper.IngrCompCodi, DbType.Int32, GetCodigoGenerado());
          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, entity.PeriCodi);
          dbProvider.AddInParameter(command, helper.EmprCodi, DbType.Int32, entity.EmprCodi);
          dbProvider.AddInParameter(command, helper.CompCodi, DbType.Int32, entity.CompCodi);
          dbProvider.AddInParameter(command, helper.IngrCompVers, DbType.Int32, entity.IngrCompVersion);
          dbProvider.AddInParameter(command, helper.IngrCompImporte, DbType.Double, entity.IngrCompImporte);
          dbProvider.AddInParameter(command, helper.IngrCompusername, DbType.String, entity.IngrCompusername);
          dbProvider.AddInParameter(command, helper.IngrCompfecins, DbType.DateTime, DateTime.Now);

          return dbProvider.ExecuteNonQuery(command);
      }

      public void Delete(System.Int32 PeriCod, System.Int32 IngrCompVersion)
      {
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, PeriCod);
          dbProvider.AddInParameter(command, helper.IngrCompVers, DbType.Int32, IngrCompVersion);

          dbProvider.ExecuteNonQuery(command);
      }

      public int GetCodigoGenerado()
      {
          int newId = 0;
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCodigoGenerado);
          newId = Int32.Parse(dbProvider.ExecuteScalar(command).ToString());

          return newId;
      }

      public List<IngresoCompensacionDTO> GetByCodigo(int? pericodi)
      {


          List<IngresoCompensacionDTO> entitys = new List<IngresoCompensacionDTO>();
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCodigo);



          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);

          using (IDataReader dr = dbProvider.ExecuteReader(command))
          {
              while (dr.Read())
              {

                  //entitys.Add(helper.Create(dr));

                  IngresoCompensacionDTO entity = new IngresoCompensacionDTO();

                  int iPerinombre = dr.GetOrdinal(helper.PeriNombre);
                  if (!dr.IsDBNull(iPerinombre)) entity.PeriNombre = dr.GetString(iPerinombre);

                  int iEmprnombre = dr.GetOrdinal(helper.EmprNombre);
                  if (!dr.IsDBNull(iEmprnombre)) entity.EmprNombre = dr.GetString(iEmprnombre);

                  int iCompnombre = dr.GetOrdinal(helper.CabeCompNombre);
                  if (!dr.IsDBNull(iCompnombre)) entity.CabeCompNombre = dr.GetString(iCompnombre);

                  int iIngrCompVers = dr.GetOrdinal(helper.IngrCompVers);
                  if (!dr.IsDBNull(iIngrCompVers)) entity.IngrCompVersion = dr.GetInt32(iIngrCompVers);

                  int iIngrCompImporte = dr.GetOrdinal(helper.IngrCompImporte);
                  if (!dr.IsDBNull(iIngrCompImporte)) entity.IngrCompImporte = dr.GetDecimal(iIngrCompImporte);

                  int iIngrCompusername = dr.GetOrdinal(helper.IngrCompusername);
                  if (!dr.IsDBNull(iIngrCompusername)) entity.IngrCompusername = dr.GetString(iIngrCompusername);

                  entitys.Add(entity);
              }
          }

          return entitys;
      }


    }
}
