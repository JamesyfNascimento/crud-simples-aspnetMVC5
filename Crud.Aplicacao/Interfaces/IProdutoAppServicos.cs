using Crud.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Aplicacao.Interfaces
{
    public interface IProdutoAppServicos : IDisposable
    {
        ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel);
        ProdutoViewModel ObterPorId(Guid id);
        IEnumerable<ProdutoViewModel> ObterTodos();
        void Atualizar(ProdutoViewModel clienteViewModel);

        void Remover(Guid id);
    }
}
