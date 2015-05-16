/*****************************************************************************************
* Fecha de Creación: 29-05-2014
* Creado por: COES SINAC
* Descripción: Clase que contiene metodos para acceder a los querys o sp
*****************************************************************************************/

using System;
using System.Xml;
using System.Configuration;

namespace COES.Base.Core
{
    public class HelperBase
    {
        private string className;
        private string xmlFile;

        #region Constructores

        public HelperBase(string file)
        {            
            this.xmlFile = file;
        }

        public HelperBase()
        {
        }

        #endregion


        /// <summary>
        /// Retorna los nombres de los stores procedures
        /// </summary>
        #region Stores Procedures

        public string SpGetById
        {
            get { return ConstantesBase.ObtenerPorId + className.ToUpper(); }
        }

        public string SpList
        {
            get { return ConstantesBase.Listar + className.ToUpper(); }
        }

        public string SpGetByCriteria
        {
            get { return ConstantesBase.ObtenerPorCriterio + className.ToUpper(); }
        }

        public string SpSave
        {
            get { return ConstantesBase.Insertar + className.ToUpper(); }
        }

        public string SpUpdate
        {
            get { return ConstantesBase.Actualizar + className.ToUpper(); }
        }

        public string SpDelete
        {
            get { return ConstantesBase.Eliminar + className.ToUpper(); }
        }
        

        #endregion


        /// <summary>
        /// Retorna las sentencias SQL
        /// </summary>
        #region Sentencias SQL

        public string SqlGetById
        {
            get { return GetSqlXml(ConstantesBase.KeyObtenerPorId); }
        }

        public string SqlList
        {
            get { return GetSqlXml(ConstantesBase.KeyListar); }
        }

        public string SqlGetByCriteria
        {
            get { return GetSqlXml(ConstantesBase.KeyObtenerPorCriterio); }
        }

        public string SqlSave
        {
            get { return GetSqlXml(ConstantesBase.KeyInsertar); }
        }

        public string SqlUpdate
        {
            get { return GetSqlXml(ConstantesBase.KeyActualizar); }
        }

        public string SqlDelete
        {
            get { return GetSqlXml(ConstantesBase.KeyEliminar); }
        }

        public string SqlTotalRecords
        {
            get { return GetSqlXml(ConstantesBase.KeyTotalRecords); }
        }

        public string SqlGetMaxId
        {
            get { return GetSqlXml(ConstantesBase.KeyGetMaxId); }
        }


        #endregion

        /// <summary>
        /// Obtiene la sentencia SQL del archivo xml
        /// </summary>
        /// <param name="idMessage"></param>
        /// <returns></returns>
        public string GetSqlXml(string idSql)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xmlFile);

                XmlNodeList nSqls = xDoc.GetElementsByTagName(ConstantesBase.MainNodeSql);
                XmlNodeList nSql = ((XmlElement)nSqls[0]).GetElementsByTagName(ConstantesBase.SubNodeSql);

                foreach (XmlElement nodo in nSql)
                {
                    XmlNodeList nKey = nodo.GetElementsByTagName(ConstantesBase.KeyNode);

                    if (nKey[0].InnerText == idSql)
                    {
                        XmlNodeList nQuery = nodo.GetElementsByTagName(ConstantesBase.QueryNode);
                        return nQuery[0].InnerText;
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        #region Campos para paginado

        public string PageSize = "PageSize";
        public string PageNumber = "PageNumber";
        public string TotalRecord = "TotalRecord";
        public string Campo = "campo";
        public string Valor = "valor";
        public string Ok = "OK";
        public string CaracterGuion = "-";
        public char Cero = '0';     

        #endregion
   
    }
}
