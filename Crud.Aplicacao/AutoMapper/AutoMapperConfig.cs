using AutoMapper;
using Crud.Aplicacao.ViewModels;
using Crud.Domain.Entidades;

namespace Crud.Aplicacao.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoViewModel>()
                .ForMember(vm => vm.Descricao, o => o.MapFrom(e => e.Descricao))
                .ForMember(vm => vm.QtdEstoque, o => o.MapFrom(e => e.QtdEstoque))
                .ForMember(vm => vm.DataValidade, o => o.MapFrom(e => e.DataValidade));

                cfg.CreateMap<ProdutoViewModel, Produto>()
                .ForMember(e => e.Descricao, o => o.MapFrom(vm => vm.Descricao))
                .ForMember(e => e.QtdEstoque, o => o.MapFrom(vm => vm.QtdEstoque))
                .ForMember(e => e.DataValidade, o => o.MapFrom(vm => vm.DataValidade));

            });
        }
    }
}
