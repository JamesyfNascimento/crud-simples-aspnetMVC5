using Crud.Domain.Entidades;
using Crud.Domain.Interfaces.Repositorio;
using Crud.Infra.Data.Contexto;
using Crud.Infra.Data.Interfaces;
using Dapper;
using System;
using System.Data.Entity;
using System.Linq;

namespace Crud.Infra.Data.Repositorios
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public Produto ObterPorDataValidade(string dataValidade)
        {
            throw new NotImplementedException("--------------------- Sem implementação");
        }


        public override Produto ObterPorIdReadOnly(Guid Id)
        {
            var sql = @"SELECT * FROM dbo.Produtos p WHERE p.ProdutoID=" + "'{" + Id + "}'";


            using (var cn = Db.Database.Connection)
            {
                cn.Open();

                var produto = cn.Query<Produto>(sql);

                cn.Close();
                return produto.FirstOrDefault();


            }
        }

        public override bool Adicionar(Produto obj)
        {

            if (Buscar(o => o.Descricao == obj.Descricao).Count() < 1)
            {
                DbSet.Add(obj);
                return true;
            }
            return false;
        }

        //public override void Remover(Guid id)
        //{
        //    try
        //    {
        //        Produto x = (Produto)ObterPorIdReadOnly(id);


        //        Db.Set<Produto>().Remove(x);



        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("ERRRRRROOOOOOOOOOOOOOR: '{0}'", e);
        //    }

        //}
    }
}
