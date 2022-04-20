using AutoMapper;
using LobsterInk.Adventure.Shared.Models;

namespace LobsterInk.Adventure.Business.Mapper
{
    public class ParentAssociationNodeProfile : Profile
    {
        public ParentAssociationNodeProfile()
        {
            CreateMap<Node, Data.Entities.ParentAssociation.ParentAssociationNodeEntity>()
                .ForMember(d => d.Id, opts => opts.MapFrom(s => s.Id))
                .ForMember(d => d.Details, opts => opts.MapFrom(s => s.Details))
                .ForMember(d => d.Message, opts => opts.MapFrom(s => s.Message))
                .ForMember(d => d.ParentId, opts => opts.MapFrom(s => s.ParentId))
                .ReverseMap();
        }
    }
}
