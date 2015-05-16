using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla CB_ENVIO
    /// </summary>
    public class CbEnvioDTO : EntityBase
    {
         public int Enviocodi { get; set; }
         public DateTime? Enviofecha { get; set; }
         public string Usercodi { get; set; }
         public int? Grupocodi { get; set; }
         public int? Estenvcodi { get; set; }
         public int? Tipocombcodi { get; set; }
         public int? Emprcodi { get; set; }
         public string  Envioobservacion { get; set; }
         public string Emprnomb { get; set; }
         public string Gruponomb { get; set; }
         public string Estenvnomb { get; set; }
         public string Envioestado { get; set; }
         public string Envioplazo { get; set; }
         public DateTime Lastdate { get; set; }
         public string Lastuser { get; set; }
    }
}
