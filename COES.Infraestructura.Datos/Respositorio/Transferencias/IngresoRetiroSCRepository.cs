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
  public  class IngresoRetiroSCRepository: RepositoryBase, IIngresoRetiroSCRepository
    {
       public IngresoRetiroSCRepository(string strConn): base(strConn)
        {
        }

      IngresoRetiroSCHelper helper = new IngresoRetiroSCHelper();

      public int Save(IngresoRetiroSCDTO entity)
      {
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

          dbProvider.AddInParameter(command, helper.Ingrsccodi, DbType.Int32, GetCodigoGenerado());
          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, entity.PeriCodi);
          dbProvider.AddInParameter(command, helper.EmprCodi, DbType.Int32, entity.EmprCodi);
          dbProvider.AddInParameter(command, helper.Ingrscversion, DbType.Int32, entity.Ingrscversion);
          dbProvider.AddInParameter(command, helper.Ingrscimporte, DbType.Double, entity.Ingrscimporte);
          dbProvider.AddInParameter(command, helper.Ingrscusername, DbType.String, entity.Ingrscusername);
          dbProvider.AddInParameter(command, helper.Ingrscfecins, DbType.DateTime, DateTime.Now);
          dbProvider.AddInParameter(command, helper.Ingrscfecact, DbType.DateTime, DateTime.Now);
          return dbProvider.ExecuteNonQuery(command);
      }

      public void Delete(System.Int32 PeriCod, System.Int32 IngrscVersion)
      {
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, PeriCod);
          dbProvider.AddInParameter(command, helper.Ingrscversion, DbType.Int32, IngrscVersion);

          dbProvider.ExecuteNonQuery(command);
      }

      public int GetCodigoGenerado()
      {
          int newId = 0;
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCodigoGenerado);
          newId = Int32.Parse(dbProvider.ExecuteScalar(command).ToString());

          return newId;
      }

      public List<IngresoRetiroSCDTO> GetByCriteria(int pericodi, int version)
      {

          List<IngresoRetiroSCDTO> entitys = new List<IngresoRetiroSCDTO>();
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
          dbProvider.AddInParameter(command, helper.Ingrscversion, DbType.Int32, version);
          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
          dbProvider.AddInParameter(command, helper.Ingrscversion, DbType.Int32, version);

          using (IDataReader dr = dbProvider.ExecuteReader(command))
          {
              while (dr.Read())
              {
                  entitys.Add(helper.Create(dr));
              }
          }

          return entitys;
      }

      public List<IngresoRetiroSCDTO> GetByCodigo( int? pericodi)
      {


          List<IngresoRetiroSCDTO> entitys = new List<IngresoRetiroSCDTO>();
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCodigo);

    

          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);

          using (IDataReader dr = dbProvider.ExecuteReader(command))
          {
              while (dr.Read())
              {

                  //entitys.Add(helper.Create(dr));

                  IngresoRetiroSCDTO entity = new IngresoRetiroSCDTO();

                  int iPerinombre = dr.GetOrdinal(helper.PeriNombre);
                  if (!dr.IsDBNull(iPerinombre)) entity.PeriNombre = dr.GetString(iPerinombre);

                  int iEmprnombre = dr.GetOrdinal(helper.EmprNombre);
                  if (!dr.IsDBNull(iEmprnombre)) entity.EmprNombre = dr.GetString(iEmprnombre);


                  int iIngrscVers = dr.GetOrdinal(helper.Ingrscversion);
                  if (!dr.IsDBNull(iIngrscVers)) entity.Ingrscversion = dr.GetInt32(iIngrscVers);

                  int iIngrscImporte = dr.GetOrdinal(helper.Ingrscimporte);
                  if (!dr.IsDBNull(iIngrscImporte)) entity.Ingrscimporte = dr.GetDecimal(iIngrscImporte);

                  int iIngrscUsername = dr.GetOrdinal(helper.Ingrscusername);
                  if (!dr.IsDBNull(iIngrscUsername)) entity.Ingrscusername = dr.GetString(iIngrscUsername);

                  entitys.Add(entity);
              }
          }

          return entitys;
      }
    }
}
