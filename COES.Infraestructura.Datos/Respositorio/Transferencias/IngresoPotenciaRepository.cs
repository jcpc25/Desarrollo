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
  public  class IngresoPotenciaRepository: RepositoryBase, IIngresoPotenciaRepository
    {
      public IngresoPotenciaRepository(string strConn): base(strConn)
        {
        }

      IngresoPotenciaHelper helper = new IngresoPotenciaHelper();

      public int Save(IngresoPotenciaDTO entity)
      {
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

          dbProvider.AddInParameter(command, helper.IngrPoteCodi, DbType.Int32, GetCodigoGenerado());
          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, entity.PeriCodi);
          dbProvider.AddInParameter(command, helper.EmprCodi, DbType.Int32, entity.EmprCodi);
          dbProvider.AddInParameter(command, helper.IngrPoteVers, DbType.Int32, entity.IngrPoteVersion);
          dbProvider.AddInParameter(command, helper.IngrPoteImporte, DbType.Double, entity.IngrPoteImporte);
          dbProvider.AddInParameter(command, helper.IngrPoteUsername, DbType.String, entity.IngrPoteUsername);
          dbProvider.AddInParameter(command, helper.IngrPoteFecins, DbType.DateTime, DateTime.Now);
          dbProvider.AddInParameter(command, helper.IngrPoteFecact, DbType.DateTime, DateTime.Now);
          return dbProvider.ExecuteNonQuery(command);
      }

      public void Delete(System.Int32 PeriCod, System.Int32 IngrPoteVersion)
      {
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, PeriCod);
          dbProvider.AddInParameter(command, helper.IngrPoteVers, DbType.Int32, IngrPoteVersion);

          dbProvider.ExecuteNonQuery(command);
      }

      public int GetCodigoGenerado()
      {
          int newId = 0;
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCodigoGenerado);
          newId = Int32.Parse(dbProvider.ExecuteScalar(command).ToString());

          return newId;
      }

      public List<IngresoPotenciaDTO> GetByCriteria(int pericodi, int version)
      {

          List<IngresoPotenciaDTO> entitys = new List<IngresoPotenciaDTO>();
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
          dbProvider.AddInParameter(command, helper.IngrPoteVers, DbType.Int32, version);
          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
          dbProvider.AddInParameter(command, helper.IngrPoteVers, DbType.Int32, version);

          using (IDataReader dr = dbProvider.ExecuteReader(command))
          {
              while (dr.Read())
              {
                  entitys.Add(helper.Create(dr));
              }
          }

          return entitys;
      }

      public List<IngresoPotenciaDTO> GetByCodigo( int? pericodi)
      {


          List<IngresoPotenciaDTO> entitys = new List<IngresoPotenciaDTO>();
          DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCodigo);

    

          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);
          dbProvider.AddInParameter(command, helper.PeriCodi, DbType.Int32, pericodi);

          using (IDataReader dr = dbProvider.ExecuteReader(command))
          {
              while (dr.Read())
              {

                  //entitys.Add(helper.Create(dr));

                  IngresoPotenciaDTO entity = new IngresoPotenciaDTO();

                  int iPerinombre = dr.GetOrdinal(helper.PeriNombre);
                  if (!dr.IsDBNull(iPerinombre)) entity.PeriNombre = dr.GetString(iPerinombre);

                  int iEmprnombre = dr.GetOrdinal(helper.EmprNombre);
                  if (!dr.IsDBNull(iEmprnombre)) entity.EmprNombre = dr.GetString(iEmprnombre);

                  int iIngrPoteVers = dr.GetOrdinal(helper.IngrPoteVers);
                  if (!dr.IsDBNull(iIngrPoteVers)) entity.IngrPoteVersion = dr.GetInt32(iIngrPoteVers);

                  int iIngrPoteImporte = dr.GetOrdinal(helper.IngrPoteImporte);
                  if (!dr.IsDBNull(iIngrPoteImporte)) entity.IngrPoteImporte = dr.GetDecimal(iIngrPoteImporte);

                  int iIngrPoteUsername = dr.GetOrdinal(helper.IngrPoteUsername);
                  if (!dr.IsDBNull(iIngrPoteUsername)) entity.IngrPoteUsername = dr.GetString(iIngrPoteUsername);

                  entitys.Add(entity);
              }
          }

          return entitys;
      }

    }
}
