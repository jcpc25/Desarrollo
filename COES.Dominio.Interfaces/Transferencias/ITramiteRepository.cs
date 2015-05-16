﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface ITramiteRepository
    {
        int Save(TramiteDTO entity);
        void Update(TramiteDTO entity);
        TramiteDTO GetById(System.Int32 id);
        List<TramiteDTO> List();
        List<TramiteDTO> GetByCriteria(DateTime? fecha, string corrinf, int periodo);
    }
}