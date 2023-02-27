using MediatR;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {

        public String UsuarioSolicitante { get;  set; }
        public string NomeFornecedor { get;  set; }
        public IList<ItemCompraCommand> Itens { get; set; }
    }



    public class ItemCompraCommand {

        public Guid  ProdutoId { get; set; }
        public int Qtde { get; set; }
    
    }

}
