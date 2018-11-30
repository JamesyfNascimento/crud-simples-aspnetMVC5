using Crud.Infra.Data.Contexto;
using Crud.Infra.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;

namespace Crud.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CrudSimplesContexto _dbContexto;
        private readonly IContextoGerente _contextoGerente;
        private bool _disposed;

        public UnitOfWork()
        {
            _contextoGerente = ServiceLocator.Current.GetInstance<IContextoGerente>();
            _dbContexto = _contextoGerente.GetContext();
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContexto.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContexto.Dispose();
                }

            }
            _disposed = true;
        }

    }
}
