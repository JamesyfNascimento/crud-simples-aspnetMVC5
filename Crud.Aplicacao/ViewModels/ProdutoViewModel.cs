using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crud.Aplicacao.ViewModels
{
    public class ProdutoViewModel
    {

        public ProdutoViewModel()
        {
            ProdutoId = Guid.NewGuid();
        }

        [Key]
        public Guid ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo quantidade estoque")]
        [DisplayName("Qtd. em estoque")]
        public double QtdEstoque { get; set; }

        [Display(Name = "Data Validade")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataValidade { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Produto Ativo")]
        [DisplayName("Produto Ativo?")]
        public bool Ativo { get; set; }
    }
}
