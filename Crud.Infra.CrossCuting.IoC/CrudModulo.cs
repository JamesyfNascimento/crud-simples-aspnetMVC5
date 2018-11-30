using crud.domain.Servicos;
using Crud.Aplicacao;
using Crud.Aplicacao.Interfaces;
using Crud.Domain.Interfaces.Repositorio;
using Crud.Domain.Interfaces.Servicos;
using Crud.Infra.Data.Contexto;
using Crud.Infra.Data.Interfaces;
using Crud.Infra.Data.Repositorios;
using Crud.Infra.Data.UoW;
using Ninject.Modules;

namespace Crud.Infra.CrossCuting.IoC
{
    public class CrudModulo : NinjectModule
    {
        public override void Load()
        {
            Bind<IProdutoAppServicos>().To<ProdutoAppServicos>();

            // Domain
            Bind<IProdutoServicos>().To<ProdutoServicos>();

            // Data
            Bind<IProdutoRepositorio>().To<ProdutoRepositorio>();
            Bind<IContextoGerente>().To<ContextoGerente>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
