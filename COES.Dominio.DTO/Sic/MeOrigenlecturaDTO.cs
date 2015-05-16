using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla ME_ORIGENLECTURA
    /// </summary>
    public class MeOrigenlecturaDTO : EntityBase
    {
        public string Origlectnombre { get; set; } 
        public int Origlectcodi { get; set; } 

    }
}
