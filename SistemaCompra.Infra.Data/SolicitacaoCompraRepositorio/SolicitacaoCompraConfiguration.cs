using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");
            //builder.OwnsOne(c => c.TotalGeral, b => b.Property("Value").HasColumnName("TotalGeral")); 
        }
    }
}
