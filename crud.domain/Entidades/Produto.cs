using crud.domain.Validacao.Produtos;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Entidades
{
    public class Produto
    {
        public Produto()
        {
            ProdutoID = Guid.NewGuid();
        }
        public Guid ProdutoID { get; set; }
        public string Descricao { get; set; }
        public double QtdEstoque { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ProdutoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
