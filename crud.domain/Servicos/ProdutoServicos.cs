using System;
using System.Collections.Generic;
using Crud.Domain.Interfaces.Servicos;
using Crud.Domain.Entidades;
using Crud.Domain.Interfaces.Repositorio;

namespace crud.domain.Servicos
{
    public class ProdutoServicos : IProdutoServicos
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServicos(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public Produto Adicionar(Produto produto)
        {
            if (!produto.IsValid())
            {
                return null;
            }
            if (_produtoRepositorio.Adicionar(produto))
            {
                return produto;
            }
            
            return null;
        }

        public void Atualizar(Produto produto)
        {
            if (!produto.IsValid())
            {
                return;
            }
            _produtoRepositorio.Atualizar(produto);
        }
        

        public void Dispose()
        {
            _produtoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Produto ObterPorId(Guid Id)
        {
            return _produtoRepositorio.ObterPorIdReadOnly(Id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _produtoRepositorio.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _produtoRepositorio.Remover(id);
        }
    }
}
