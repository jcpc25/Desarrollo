/*****************************************************************************************
* Fecha de Creación: 29-05-2014
* Creado por: COES SINAC
* Descripción: Clase que implementa la interface de acceso a datos
* haciendo uso del Data Access Application Block
*****************************************************************************************/

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Diagnostics;

namespace COES.Base.DataHelper
{
    public class DbProvider:IDataBase
    {        
        /// <summary>
        /// 
        /// </summary>
        private readonly Database dataBase;



        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="dbName"></param>
        public DbProvider(string dbName)
        {            
            dataBase = DatabaseFactory.CreateDatabase(dbName);
        }

        /// <summary>
        /// Devuelve un objeto DbCommand encargado de ejecutar el store procedure
        /// especificado
        /// </summary>
        /// <param name="storedProcedureName">Nombre del Store Procedure</param>
        /// <returns></returns>
        public DbCommand GetStoredProcCommand(string storedProcedureName)
        {            
            return dataBase.GetStoredProcCommand(storedProcedureName);            
        }

        /// <summary>
        /// Devuelve un objeto DbCommand encargado de ejecutar el query especificado
        /// </summary>
        /// <param name="query">Query a ejecutar</param>
        /// <returns></returns>
        public DbCommand GetSqlStringCommand(string query)
        {
            return dataBase.GetSqlStringCommand(query);
        }

        /// <summary>
        /// Agrega parámetros de entrada que son necesarios para ejecutar un comando
        /// </summary>
        /// <param name="command">Objeto DbCommnand que requiere el parámetro</param>
        /// <param name="name">Nombre del parámetro</param>
        /// <param name="dbType">Tipo de dato del parámetro</param>
        /// <param name="value">Valor del parámetro</param>
        public void AddInParameter(DbCommand command, string name, DbType dbType, object value)
        {
            dataBase.AddInParameter(command, name, dbType, value);            
        }

        /// <summary>
        /// Agrega parámetros de salida al comando especificado
        /// </summary>
        /// <param name="command">Objeto DbCommand que contiene el parámetro</param>
        /// <param name="name">Nombre del parámetro</param>
        /// <param name="dbType">Tipo de dato del parámetro</param>
        /// <param name="size">Longitud del parámetro</param>
        public void AddOutParameter(DbCommand command, string name, DbType dbType, int size)
        {
            dataBase.AddOutParameter(command, name, dbType, size);            
        }

        /// <summary>
        /// Ejecuta el comando y devuelve un objeto IDataReader para la lectura de datos
        /// </summary>
        /// <param name="command">Comando a ejecutar</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(DbCommand command)
        {            
            return dataBase.ExecuteReader(command);
        }

        /// <summary>
        /// Obtiene el valor de un parametro despues de haber ejecutado del comando
        /// </summary>
        /// <param name="command">Objeto DbCommand a ejecutar</param>
        /// <param name="name">Nombre del parámetro</param>
        /// <returns></returns>
        public object GetParameterValue(DbCommand command, string name)
        {
            return dataBase.GetParameterValue(command, name);
        }

        /// <summary>
        /// Obtiene el valor de la primera celda en la primera fila del resultado
        /// tras haber ejecutado el comando
        /// </summary>
        /// <param name="command">Objeto DbCommand a ejecutar</param>
        /// <returns></returns>
        public object ExecuteScalar(DbCommand command)
        {
            return dataBase.ExecuteScalar(command);
        }

        /// <summary>
        /// Retorna el número de filas afectadas despues de haber ejecutado un comando
        /// </summary>
        /// <param name="command">Objeto DbCommand a ajecutar</param>
        public int ExecuteNonQuery(DbCommand command)
        {
            return dataBase.ExecuteNonQuery(command);            
        }


        /// <summary>
        /// Carga los datos obtenidos tras ejecutar un comando a un dataset
        /// </summary>
        /// <param name="command">Objeto DbCommand a ejecutar</param>
        /// <param name="dataSet">DataSet donde se carga el resultado</param>
        /// <param name="tableName">Nombre de la tabla cargada</param>
        public void LoadDataSet(DbCommand command, DataSet dataSet, string tableName)
        {
            dataBase.LoadDataSet(command, dataSet, tableName); 
        }
        
        

    }
}
