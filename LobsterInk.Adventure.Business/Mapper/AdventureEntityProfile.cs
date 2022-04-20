using AutoMapper;

namespace LobsterInk.Adventure.Business.Mapper
{
    public class AdventureEntityProfile : Profile
    {
        public AdventureEntityProfile()
        {
            CreateMap<Shared.Models.Adventure, Data.Entities.AdventureEntity>()
                .ForMember(d => d.Id, opts => opts.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opts => opts.MapFrom(s => s.Name))
                .ForMember(d => d.StartingNodeId, opts => opts.MapFrom(s => s.StartingNodeId))
                .ReverseMap();
        }
    }
}
