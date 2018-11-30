using crud.domain.Validacao.Produtos;
using Crud.Domain.Entidades;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.domain.Especificacao.Produtos
{
    class ProdutoDeveTerDescricaoValidoSpecification : ISpecification<Produto>
    {
        public bool IsSatisfiedBy(Produto produto)
        {
            return ValidaDescricaoProduto.Validate(produto.Descricao);
        }
    }
}
