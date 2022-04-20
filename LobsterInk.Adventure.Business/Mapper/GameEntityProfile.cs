using AutoMapper;

namespace LobsterInk.Adventure.Business.Mapper
{
    public class GameEntityProfile : Profile
    {
        public GameEntityProfile()
        {
            CreateMap<Shared.Models.Game, Data.Entities.GameEntity>()
                .ForMember(d => d.Id, opts => opts.MapFrom(s => s.Id))
                .ForMember(d => d.AdventureId, opts => opts.MapFrom(s => s.AdventureId))
                .ForMember(d => d.Adventure, opts => opts.MapFrom(s => s.Adventure))
                .ForMember(d => d.Steps, opts => opts.MapFrom(s => s.Steps))
                .ForMember(d => d.SessionId, opts => opts.MapFrom(s => s.SessionId))
                .ReverseMap();
        }
    }
}
