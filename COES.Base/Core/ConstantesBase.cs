/*****************************************************************************************
* Fecha de Creación: 29-05-2014
* Creado por: COES SINAC
* Descripción: Clase que contiene las constantes de capa de persitencia
*****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace COES.Base.Core
{
    public class ConstantesBase
    {

        #region Constantes DAOHelperBase

        public const string Aplicacion = "RutaSqlAplicacion";     
        public const string ExtensionSqlXml = "Sql.xml";

        public const string Insertar = "USP_SAVE_";
        public const string Actualizar = "USP_UPDATE_";
        public const string Eliminar = "USP_DELETE_";
        public const string Listar = "USP_LIST_";
        public const string ObtenerPorId = "USP_GETBYID_";
        public const string ObtenerPorCriterio = "USP_GETBYCRITERIA_";


        public const string KeyInsertar = "Save";
        public const string KeyActualizar = "Update";
        public const string KeyEliminar = "Delete";
        public const string KeyListar = "List";
        public const string KeyObtenerPorId = "GetById";
        public const string KeyObtenerPorCriterio = "GetByCriteria";
        public const string KeyTotalRecords = "TotalRecords";
        public const string KeyGetMaxId = "GetMaxId";

        public const string MainNodeSql = "Sqls";
        public const string SubNodeSql = "Sql";
        public const string KeyNode = "key";
        public const string QueryNode = "query";


        public const string SI = "S";
        public const string NO = "N";

        public const string FormatoFecha = "yyyy-MM-dd";
        public const string FormatoFechaExtendido = "yyyy-MM-dd HH:mm:ss";
        public const string FormatoFechaHora = "yyyy-MM-dd HH:mm";

        #endregion

        #region Medidores

        public const string KeyTodos = "_TODOS";
        public const int TODOS = 0;
        public const int COES = -1;
        public const int NOCOES = 10;

        public const short FueraPuntaFin = 71;
        public const short PuntaFin = 92;
        //// Constante entidad ENVIO
        public const byte ENVIO_ENVIADO = 1;
        public const byte ENVIO_PROCESADO = 2;
        public const byte ENVIO_APROBADO = 3;
        public const byte ENVIO_RECHAZADO = 4;
        public const byte ENVIO_FUERAPLAZO = 5;
        public const decimal DELTACAMBIO = 0.0003M;

        //Destino Potencia
        public const int GeneracionPeru = 0;
        public const int ExportacionEcuador = 1;
        public const int ImportacionEcuador = 2;

        #endregion

        #region Estado
        public const int ENVIADO = 1;
        public const int PROCESADO = 2;
        public const int APROBADO = 3;
        public const int RECHAZADO = 4;
        public const int FUERA_DE_PLAZO = 5;
        public const int OBSERVADO = 6;
        public const int CORREGIDO = 7;
        #endregion
        #region Combustible
        public const int LIQUIDO = 1;
        public const int CARBON = 2;
        public const int GAS = 3;
        #endregion
    }

    public class CombustibleBase 
    {
        
    }
}
