﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;
namespace COES.Dominio.Interfaces.Transferencias
{
    public interface IValorTransferenciaEmpresaRepository
    {
    

        int Save(ValorTransferenciaEmpresaDTO entity);
        void Update(ValorTransferenciaEmpresaDTO entity);
        void Delete(int pericodi, int version);
        ValorTransferenciaEmpresaDTO GetById(System.Int32 id);
        List<ValorTransferenciaEmpresaDTO> List();
        List<ValorTransferenciaEmpresaDTO> GetByCriteria(string nombre);
    }
}
