using Crud.Domain.Entidades;
using System;

namespace Crud.Domain.Interfaces.Repositorio
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        Produto ObterPorDataValidade(string dataValidade);
        bool Adicionar(Produto obj);


    }
}
