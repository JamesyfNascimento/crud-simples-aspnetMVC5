using Crud.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Crud.Infra.Data.Contexto;
using System.Data.Entity;
using Crud.Infra.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Crud.Infra.Data.Repositorios
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        protected CrudSimplesContexto Db;
        protected DbSet<TEntity> DbSet;

        public Repositorio()
        {
            var contextoGerente = ServiceLocator.Current.GetInstance<IContextoGerente>();
            Db = contextoGerente.GetContext();
            DbSet = Db.Set<TEntity>();
        }
        public virtual bool Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
            return true;
        }

        public void Atualizar(TEntity obj)
        {
            try
            {
                var entidade = Db.Entry(obj);
                DbSet.Attach(obj);
                entidade.State = EntityState.Modified;
               
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> expressao)
        {
            return DbSet.Where(expressao);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity ObterPorId(Guid Id)
        {
            return DbSet.Find(Id);
        }

        public virtual TEntity ObterPorIdReadOnly(Guid Id)
        {
            throw new NotImplementedException("--------------------- Sem implementação");
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public virtual void Remover(Guid Id)
        {
            DbSet.Remove(ObterPorId(Id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
