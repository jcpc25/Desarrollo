﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
  public  interface ITipoTramiteRepository:IRepositoryBase
    {
        List<TipoTramiteDTO> List();
        TipoTramiteDTO GetById(System.Int32? id);
    }
}
