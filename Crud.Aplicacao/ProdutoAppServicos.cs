using Crud.Aplicacao.Interfaces;
using System;
using System.Collections.Generic;
using Crud.Aplicacao.ViewModels;
using Crud.Domain.Interfaces.Servicos;
using AutoMapper;
using Crud.Domain.Entidades;

namespace Crud.Aplicacao
{
    public class ProdutoAppServicos : AppService, IProdutoAppServicos
    {

        private readonly IProdutoServicos _produtoServicos;

        public ProdutoAppServicos(IProdutoServicos produtoServicos)
        {
            _produtoServicos = produtoServicos;
        }
        public ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);

            BeginTransaction();
            var produtoReturn = _produtoServicos.Adicionar(produto);
            if (produtoReturn != null)
            {
                Commit();
                return produtoViewModel;
            }
            return null;
        }

        public void Atualizar(ProdutoViewModel produto)
        {
            BeginTransaction();
            Produto prod = Mapper.Map<ProdutoViewModel, Produto>(produto);

            _produtoServicos.Atualizar(prod);

            Commit();

        }
        

        public ProdutoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Produto, ProdutoViewModel>(_produtoServicos.ObterPorId(id));
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoServicos.ObterTodos());
        }

        public void Remover(Guid id)
        {
            BeginTransaction();

            _produtoServicos.Remover(id);

            Commit();
        }

        public void Dispose()
        {
            _produtoServicos.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
