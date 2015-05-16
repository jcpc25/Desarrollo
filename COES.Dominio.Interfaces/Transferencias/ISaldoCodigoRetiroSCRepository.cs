﻿using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface ISaldoCodigoRetiroSCRepository
    {

        int Save(SaldoCodigoRetiroscDTO entity);
        void Update(SaldoCodigoRetiroscDTO entity);
        void Delete(int pericodi, int version);
    }
}