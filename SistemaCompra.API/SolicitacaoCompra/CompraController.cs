using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.Produto.Command.AtualizarPreco;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using System;

namespace SistemaCompra.API.SolicitacaoCompra
{
    public class CompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompraController(IMediator mediator)
        {
            this._mediator = mediator;
        }



        [HttpPost, Route("compra/cadastro")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CadastrarProduto([FromBody] RegistrarCompraCommand registrarCompraCommand)
       {

            _mediator.Send(registrarCompraCommand);
            return StatusCode(201);
        }

       
    }
}
