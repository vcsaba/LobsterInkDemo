using AutoMapper;

namespace LobsterInk.Adventure.Business.Mapper
{
    public class GameStepEntityProfile : Profile
    {
        public GameStepEntityProfile()
        {
            CreateMap<Shared.Models.GameStep, Data.Entities.GameStepEntity>()
                .ForMember(d => d.Id, opts => opts.MapFrom(s => s.Id))
                .ForMember(d => d.GameId, opts => opts.MapFrom(s => s.GameId))
                .ForMember(d => d.Game, opts => opts.MapFrom(s => s.Game))
                .ForMember(d => d.SelectedNodeId, opts => opts.MapFrom(s => s.SelectedNodeId))
                .ForMember(d => d.SelectedTime, opts => opts.MapFrom(s => s.SelectedTime))
                .ReverseMap();
        }
    }
}
