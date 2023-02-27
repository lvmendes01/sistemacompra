using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.SolicitacaoCompraRepositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Service.SolicitacaoCompraService
{
    public class SolicitacaoCompraService : ISolicitacaoCompraService
    {
        private ISolicitacaoCompraRepositorio repositorio;
        private IProdutoRepository produtoRepositorio;
        public SolicitacaoCompraService(IProdutoRepository _produtoRepositorio, ISolicitacaoCompraRepositorio _repositorio)
        {
            produtoRepositorio = _produtoRepositorio;
            repositorio = _repositorio;
        }

        public Produto ObterProduto(Guid IdProduto)
        {
            return produtoRepositorio.Obter(IdProduto);
        }

        public ReturnApi RegistrarSolicitacaoCompra(SolicitacaoCompra solicitacao)
        {
            ReturnApi retorno = new ReturnApi();

            if (ValidarTotalGeral(solicitacao.TotalGeral))
            {
                solicitacao.Data = DateTime.Now.AddDays(30);
            }

            if (ValidarTotalItens(solicitacao.Itens.Count))
            {
                retorno.Valid = true;
                repositorio.RegistrarSolicitacaoCompra(solicitacao);
                retorno.Message = "Regstrado";
            }
            else
            {
                retorno.Valid = false;
                retorno.Message = "Total de Itens deve ser maior que 0";
            }

            return retorno;
        }

        private bool ValidarTotalGeral(decimal valorTotal)
        {
            return valorTotal > 50000;
        }
        private bool ValidarTotalItens(int totalItens)
        {
            return totalItens > 0;
        }
    }
}
