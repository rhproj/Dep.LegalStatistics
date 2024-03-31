using AutoMapper;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;

namespace LegalStatistics.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ArbitrationProceeding_Statistics, ValueDto>()
                .ForMember(s=>s.ActionOrdinal, s=>s.MapFrom(a=>a.LegalAction.Ordinal))
                .ForMember(s=>s.ContentOrdinal, s=>s.MapFrom(a=>a.LawsuitContent.Ordinal))
                .ReverseMap();

            CreateMap<TableAxesBase, AxisUptDto>().ReverseMap();
            CreateMap<ArbitrationProceeding_LawsuitContent, AxisUptDto>().ReverseMap();
            CreateMap<ArbitrationProceeding_LegalAction, AxisUptDto>().ReverseMap();
        }
    }
}
