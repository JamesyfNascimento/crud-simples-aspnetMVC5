using Crud.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Crud.Infra.Data.EntidadesConfig
{
    public class ProdutoConfiguracao : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguracao()
        {
            HasKey(c => c.ProdutoID);
            Property(c => c.Descricao).IsRequired().HasMaxLength(250);
            Property(c => c.QtdEstoque).IsRequired();
            Property(c => c.DataValidade).IsRequired();
            Property(c => c.Ativo).IsRequired();
            ToTable("Produtos");
        }
        

    }
}
