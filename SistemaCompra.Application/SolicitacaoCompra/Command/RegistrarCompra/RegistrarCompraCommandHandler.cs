using MediatR;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SistemaCompra.Service;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using System.Linq;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraService service;
        public RegistrarCompraCommandHandler(ISolicitacaoCompraService _service, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.service = _service;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var compra = new SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);


            foreach (var item in request.Itens)
            {
                var produto = service.ObterProduto(item.ProdutoId); 
                compra.Itens.Add(new Item(produto, item.Qtde));
            }
            compra.TotalGeral = compra.Itens.Sum(s => s.Produto.Preco * s.Qtde).Value;



            service.RegistrarSolicitacaoCompra(compra);


            Commit();
            PublishEvents(compra.Events);

            return Task.FromResult(true);
        }
    }
}
