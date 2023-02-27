using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Infra.Data.SolicitacaoCompraRepositorio.Interfaces
{
    public interface ISolicitacaoCompraRepositorio
    {
        void RegistrarSolicitacaoCompra(SolicitacaoCompra solicitacao);
    }
}
