using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;

namespace SistemaCompra.Service
{
    public interface ISolicitacaoCompraService
    {
        ReturnApi RegistrarSolicitacaoCompra(SolicitacaoCompra solicitacao);
        Produto ObterProduto(Guid IdProduto);

    }
}
