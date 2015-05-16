using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Sic;
using COES.Base.Core;
using COES.Infraestructura.Datos.Helper.Sic;

namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    /// <summary>
    /// Clase de acceso a datos de la tabla EQ_EQUIPO
    /// </summary>
    public class EqEquipoRepository: RepositoryBase, IEqEquipoRepository
    {
        public EqEquipoRepository(string strConn): base(strConn)
        {
        }

        EqEquipoHelper helper = new EqEquipoHelper();

        public int Save(EqEquipoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, entity.Grupocodi);
            dbProvider.AddInParameter(command, helper.Elecodi, DbType.Int32, entity.Elecodi);
            dbProvider.AddInParameter(command, helper.Areacodi, DbType.Int32, entity.Areacodi);
            dbProvider.AddInParameter(command, helper.Famcodi, DbType.Int32, entity.Famcodi);
            dbProvider.AddInParameter(command, helper.Equiabrev, DbType.String, entity.Equiabrev);
            dbProvider.AddInParameter(command, helper.Equinomb, DbType.String, entity.Equinomb);
            dbProvider.AddInParameter(command, helper.Equiabrev2, DbType.String, entity.Equiabrev2);
            dbProvider.AddInParameter(command, helper.Equitension, DbType.Decimal, entity.Equitension);
            dbProvider.AddInParameter(command, helper.Equipadre, DbType.Int32, entity.Equipadre);
            dbProvider.AddInParameter(command, helper.Equipot, DbType.Decimal, entity.Equipot);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Ecodigo, DbType.String, entity.Ecodigo);
            dbProvider.AddInParameter(command, helper.Equiestado, DbType.String, entity.Equiestado);
            dbProvider.AddInParameter(command, helper.Osigrupocodi, DbType.String, entity.Osigrupocodi);
            dbProvider.AddInParameter(command, helper.Lastcodi, DbType.Int32, entity.Lastcodi);
            dbProvider.AddInParameter(command, helper.Equifechiniopcom, DbType.DateTime, entity.Equifechiniopcom);
            dbProvider.AddInParameter(command, helper.Equifechfinopcom, DbType.DateTime, entity.Equifechfinopcom);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(EqEquipoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, entity.Equicodi);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, entity.Grupocodi);
            dbProvider.AddInParameter(command, helper.Elecodi, DbType.Int32, entity.Elecodi);
            dbProvider.AddInParameter(command, helper.Areacodi, DbType.Int32, entity.Areacodi);
            dbProvider.AddInParameter(command, helper.Famcodi, DbType.Int32, entity.Famcodi);
            dbProvider.AddInParameter(command, helper.Equiabrev, DbType.String, entity.Equiabrev);
            dbProvider.AddInParameter(command, helper.Equinomb, DbType.String, entity.Equinomb);
            dbProvider.AddInParameter(command, helper.Equiabrev2, DbType.String, entity.Equiabrev2);
            dbProvider.AddInParameter(command, helper.Equitension, DbType.Decimal, entity.Equitension);
            dbProvider.AddInParameter(command, helper.Equipadre, DbType.Int32, entity.Equipadre);
            dbProvider.AddInParameter(command, helper.Equipot, DbType.Decimal, entity.Equipot);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Ecodigo, DbType.String, entity.Ecodigo);
            dbProvider.AddInParameter(command, helper.Equiestado, DbType.String, entity.Equiestado);
            dbProvider.AddInParameter(command, helper.Osigrupocodi, DbType.String, entity.Osigrupocodi);
            dbProvider.AddInParameter(command, helper.Lastcodi, DbType.Int32, entity.Lastcodi);
            dbProvider.AddInParameter(command, helper.Equifechiniopcom, DbType.DateTime, entity.Equifechiniopcom);
            dbProvider.AddInParameter(command, helper.Equifechfinopcom, DbType.DateTime, entity.Equifechfinopcom);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int equicodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, equicodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public EqEquipoDTO GetById(int equicodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, equicodi);
            EqEquipoDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EqEquipoDTO> List()
        {
            List<EqEquipoDTO> entitys = new List<EqEquipoDTO>();
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

        public List<EqEquipoDTO> GetByCriteria()
        {
            List<EqEquipoDTO> entitys = new List<EqEquipoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<EqEquipoDTO> GetByEmprFam(int emprcodi, int famcodi)
        {
            List<EqEquipoDTO> entitys = new List<EqEquipoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.Famcodi, DbType.Int32, famcodi);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }


        public List<EqEquipoDTO> ListadoCentralesOsinergmin()
        {
            var entitys = new List<EqEquipoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListadoCentralesOsinergmin);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    var oEquipo = new EqEquipoDTO();
                    oEquipo.Emprcodi = dr.IsDBNull(dr.GetOrdinal("EMPRCODI"))?-1: dr.GetInt32(dr.GetOrdinal("EMPRCODI"));
                    oEquipo.Equifechfinopcom = dr.IsDBNull(dr.GetOrdinal("EQUIFECHFINOPCOM")) ? (DateTime?)null : dr.GetDateTime(dr.GetOrdinal("EQUIFECHFINOPCOM"));
                    oEquipo.Equifechiniopcom = dr.IsDBNull(dr.GetOrdinal("EQUIFECHINIOPCOM")) ? (DateTime?)null : dr.GetDateTime(dr.GetOrdinal("EQUIFECHINIOPCOM"));
                    oEquipo.Equinomb = dr.GetString(dr.GetOrdinal("EQUINOMB"));
                    oEquipo.Famcodi = dr.IsDBNull(dr.GetOrdinal("FAMCODI")) ? -1 : dr.GetInt32(dr.GetOrdinal("FAMCODI"));
                    oEquipo.Grupocodi = dr.IsDBNull(dr.GetOrdinal("GRUPOCODI")) ? -1 : dr.GetInt32(dr.GetOrdinal("GRUPOCODI"));
                    entitys.Add(oEquipo);
                }
            }
            return entitys;
        }


        /// <summary>
        /// Listado de Equipos por filtro de Empresa, Familia, Tipo Empresa y Estado Equipo
        /// </summary>
        /// <param name="idEmpresa">Código Empresa</param>
        /// <param name="sEstado">Estado de Equipo</param>
        /// <param name="idTipoEquipo">Código Familia</param>
        /// <param name="idTipoEmpresa">Código Tipo Empresa</param>
        /// <param name="sNombreEquipo">Nombre de Equipo</param>
        /// <param name="idPadre">Código Padre Equipo * Usar -99 para evitar este filtro*</param>
        /// <returns></returns>
        public List<EqEquipoDTO> ListarEquiposxFiltro(int idEmpresa, string sEstado, int idTipoEquipo, int idTipoEmpresa, string sNombreEquipo, int idPadre)
        {
            var entitys = new List<EqEquipoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SQLListarEquiposxFiltro);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, idEmpresa);
            dbProvider.AddInParameter(command, helper.Famcodi, DbType.Int32, idTipoEquipo);
            dbProvider.AddInParameter(command, "TIPOEMPRCODI", DbType.Int32, idTipoEmpresa);
            dbProvider.AddInParameter(command, helper.Equinomb, DbType.String, sNombreEquipo);
            dbProvider.AddInParameter(command, helper.Equipadre, DbType.Int32, idPadre);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    var oEquipo = new EqEquipoDTO();
                    oEquipo = helper.Create(dr);
                    oEquipo.EMPRNOMB = dr.GetString(dr.GetOrdinal("EMPRNOMB"));
                    oEquipo.AREANOMB = dr.GetString(dr.GetOrdinal("AREANOMB"));
                    oEquipo.Famnomb = dr.GetString(dr.GetOrdinal("Famnomb"));

                    entitys.Add(oEquipo);
                }
            }
            entitys = sEstado == "AF" ? entitys.Where(eq => eq.Equiestado == "A" || eq.Equiestado == "F").ToList() : entitys.Where(eq => eq.Equiestado == sEstado).ToList();
            return entitys;
        }

        /// <summary>
        /// Listado de Equipos filtrado por nombre.
        /// Datos solo de tabla Equipo
        /// </summary>
        /// <param name="coincidencia">Nombre del Equipo</param>
        /// <param name="nroPagina">N° de página</param>
        /// <param name="nroFilas">N° de Filas</param>
        /// <returns></returns>
        public List<EqEquipoDTO> BuscarEquipoxNombre(string coincidencia, int nroPagina, int nroFilas)
        {
            var entitys = new List<EqEquipoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlBuscarEquipoPorNombrePaginado);
            dbProvider.AddInParameter(command, helper.Equinomb, DbType.String, coincidencia);
            dbProvider.AddInParameter(command, "nropaginas", DbType.Int32, nroPagina);
            dbProvider.AddInParameter(command, "nroFilas", DbType.Int32, nroFilas);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    var oEquipo = new EqEquipoDTO();
                    oEquipo = helper.Create(dr);
                    entitys.Add(oEquipo);
                }
            }
            return entitys;
        }

        /// <summary>
        /// Listado de Equipos filtrado por varias familias.
        /// Datos de Equipo, Familia, Empresa y Area
        /// </summary>
        /// <param name="iCodFamilias">Código de Familias</param>
        /// <returns></returns>
        public List<EqEquipoDTO> ListarEquipoxFamilias(params int[] iCodFamilias)
        {
            var entitys = new List<EqEquipoDTO>();
            if (iCodFamilias.Length > 0)
            {
                string sCodFamilias = string.Empty;
                foreach (var ifamcodi in iCodFamilias)
                {
                    sCodFamilias = sCodFamilias + "," + ifamcodi;
                }
                sCodFamilias=sCodFamilias.Substring(1);

                DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlEquiposxFamilias);
                dbProvider.AddInParameter(command, helper.Famcodi, DbType.String, sCodFamilias);
                using (IDataReader dr = dbProvider.ExecuteReader(command))
                {
                    while (dr.Read())
                    {
                        var oEquipo = new EqEquipoDTO();
                        oEquipo = helper.Create(dr);
                        oEquipo.EMPRNOMB = dr.GetString(dr.GetOrdinal("EMPRNOMB"));
                        oEquipo.AREANOMB = dr.GetString(dr.GetOrdinal("AREANOMB"));
                        oEquipo.Famnomb = dr.GetString(dr.GetOrdinal("Famnomb"));

                        entitys.Add(oEquipo);
                    }
                }

            }
            return entitys;
        }

        public List<EqEquipoDTO> ListarEquipoxFamilias2(string sCodFamilias,string sCodEmpresas)
        {
            var entitys = new List<EqEquipoDTO>();
            string sQuery = string.Format(helper.SqlEquiposxFamilias2, sCodFamilias,sCodEmpresas);
            DbCommand command = dbProvider.GetSqlStringCommand(sQuery);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    var oEquipo = new EqEquipoDTO();
                    oEquipo = helper.Create(dr);
                    oEquipo.EMPRNOMB = dr.GetString(dr.GetOrdinal("EMPRNOMB"));
                    oEquipo.AREANOMB = dr.GetString(dr.GetOrdinal("AREANOMB"));
                    oEquipo.Famnomb = dr.GetString(dr.GetOrdinal("Famnomb"));
                    entitys.Add(oEquipo);
                }
            }
            return entitys;
        }

        public List<EqEquipoDTO> ListarCentralesXCombustible(int emprcodi, int tipocombustible)
        {
            List<EqEquipoDTO> entitys = new List<EqEquipoDTO>();
            string query = string.Format(helper.SqlCentralesXCombustible, tipocombustible, emprcodi);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<EqEquipoDTO> ListarCentralesXEmpresaGEN(string emprcodi)
        {
            List<EqEquipoDTO> entitys = new List<EqEquipoDTO>();
            string query = string.Format(helper.SqlCentralesXEmpresaGEN, emprcodi);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }
        public List<EqEquipoDTO> ListarEquiposEnsayo(string equicodi)
        {
            List<EqEquipoDTO> entitys = new List<EqEquipoDTO>();
            string query = string.Format(helper.SqlListaEquiposEnsayo, equicodi);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<EqEquipoDTO> ListaRecursosxCuenca(int idEquipo)
        {
            List<EqEquipoDTO> entitys = new List<EqEquipoDTO>();
            string query = string.Format(helper.SqlListaRecursosxCuenca, idEquipo);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    var oEquipo = new EqEquipoDTO();
                    oEquipo = helper.Create(dr);                  
                    oEquipo.Famnomb = dr.GetString(dr.GetOrdinal("Famnomb"));
                    entitys.Add(oEquipo);                                     
                }
            }

            return entitys;

        }
    }
}
