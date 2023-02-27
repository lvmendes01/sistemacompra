using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.SolicitacaoCompraRepositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Infra.Data.SolicitacaoCompraRepositorio
{
    public class SolicitacaoCompraRepositorio : ISolicitacaoCompraRepositorio
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepositorio(SistemaCompraContext context)
        {
            this.context = context;
        }
        public void RegistrarSolicitacaoCompra(SolicitacaoCompra solicitacao)
        {
            context.SolicitacaoCompras.Add(solicitacao);
        }
    }
}
