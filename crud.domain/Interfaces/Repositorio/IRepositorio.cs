using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Crud.Domain.Interfaces.Repositorio
{
    public interface IRepositorio<TEntity> : IDisposable where TEntity : class
    {
        bool Adicionar(TEntity obj);
        TEntity ObterPorId(Guid Id);
        TEntity ObterPorIdReadOnly(Guid Id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
