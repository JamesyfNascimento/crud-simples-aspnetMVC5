using crud.domain.Especificacao.Produtos;
using Crud.Domain.Entidades;
using DomainValidation.Validation;

namespace crud.domain.Validacao.Produtos
{
    public class ProdutoEstaConsistenteValidation : Validator<Produto>
    {

        public ProdutoEstaConsistenteValidation()
        {

            var produtoDescricao = new ProdutoDeveTerDescricaoValidoSpecification();
            base.Add("produtoDescricao", new Rule<Produto>(produtoDescricao, "Informou uma descrição inválida, deve conter no mínimo 4 caracteres"));
        }

    }
}
