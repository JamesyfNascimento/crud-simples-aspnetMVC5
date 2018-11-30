using Crud.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace Crud.Domain.Interfaces.Servicos
{
    public interface IProdutoServicos : IDisposable
    {
        Produto Adicionar(Produto obj);
        Produto ObterPorId(Guid Id);
        IEnumerable<Produto> ObterTodos();
        void Atualizar(Produto obj);

        void Remover(Guid id);
    }
}
