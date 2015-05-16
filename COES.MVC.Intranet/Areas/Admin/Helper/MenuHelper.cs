using COES.MVC.Intranet.SeguridadServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace COES.MVC.Intranet.Areas.Admin.Helper
{
    public class MenuHelper
    {
        /// <summary>
        /// Permite obtener el tree de opciones
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string ObtenerTreeOpciones(List<OptionDTO> list, string nodos)
        {
            int idPadre = 1;

            StringBuilder strHtml = new StringBuilder();
            strHtml.Append("[\n");

            List<OptionDTO> listItem = list.Where(x => x.PadreCodi == idPadre).ToList();
            int contador = 0;
            foreach (OptionDTO item in listItem)
            {
                List<OptionDTO> listHijos = list.Where(x => x.PadreCodi == item.OptionCode).ToList();
                if (listHijos.Count > 0)
                {
                    strHtml.Append("   {'key': '" + item.OptionCode + "', 'title': '" + item.OptionName +
                        "' , 'expanded' : 'true', selected : " + this.ObtieneSeleccionNodo(item.OptionCode, item.Selected, nodos) + ", 'children':[\n");
                    strHtml.Append(ObtenerSubMenu(listHijos, list, "   ", nodos));
                    if (contador < listItem.Count - 1) strHtml.Append("   ]},\n");
                    else strHtml.Append("   ]}\n");
                }
                else
                {
                    if (contador < listItem.Count - 1)
                        strHtml.Append("   {'key': '" + item.OptionCode + "', 'title': '" +
                            item.OptionName + "' , selected : " + this.ObtieneSeleccionNodo(item.OptionCode, item.Selected, nodos) + "},\n");
                    else
                        strHtml.Append("   {'key': '" + item.OptionCode + "', 'title': '" +
                            item.OptionName + "',  selected : " + this.ObtieneSeleccionNodo(item.OptionCode, item.Selected, nodos) + "}\n");
                }
                contador++;
            }

            strHtml.Append("]");
            return strHtml.ToString();
        }

        /// <summary>
        /// Funcion recursiva para obtener el menu
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string ObtenerSubMenu(List<OptionDTO> list, List<OptionDTO> listGeneral, string pad, string nodos)
        {
            StringBuilder strHtml = new StringBuilder();

            int contador = 0;
            foreach (OptionDTO item in list)
            {
                List<OptionDTO> listHijos = listGeneral.Where(x => x.PadreCodi == item.OptionCode).ToList();

                if (listHijos.Count > 0)
                {
                    strHtml.Append(pad + "    {'key': '" + item.OptionCode + "' , selected :" + this.ObtieneSeleccionNodo(item.OptionCode, item.Selected, nodos) + ", 'title': '" +
                        item.OptionName + "', 'children':[\n");
                    strHtml.Append(this.ObtenerSubMenu(listHijos, listGeneral, pad + "  ", nodos));
                    if (contador < list.Count - 1) strHtml.Append(pad + "    ]},\n");
                    else strHtml.Append(pad + "    ]}\n");
                }
                else
                {
                    if (contador < list.Count - 1)
                        strHtml.Append("   {'key': '" + item.OptionCode + "', 'title': '" +
                           item.OptionName + "' , selected : " + this.ObtieneSeleccionNodo(item.OptionCode, item.Selected, nodos) + "},\n");
                    else
                        strHtml.Append("   {'key': '" + item.OptionCode + "', 'title': '" +
                            item.OptionName + "',  selected : " + this.ObtieneSeleccionNodo(item.OptionCode, item.Selected, nodos) + "}\n");
                }
                contador++;
            }

            return strHtml.ToString();
        }

        /// <summary>
        /// Permite verificar la selección de un nodo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="selected"></param>
        /// <param name="nodos"></param>
        /// <returns></returns>
        private string ObtieneSeleccionNodo(int id, int selected, string nodos)
        {
            string[] nodes = nodos.Split(',');

            if (nodes.Contains(id.ToString()) || selected > 0)
            {
                return "true";
            }
            return "false";
        }
    }
}