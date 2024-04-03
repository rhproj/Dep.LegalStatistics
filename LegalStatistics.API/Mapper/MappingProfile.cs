using AutoMapper;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Models.LawImplementation.CivilRights;

namespace LegalStatistics.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region ArbitrationProceeding_Statistics
            CreateMap<ArbitrationProceeding_Statistics, ValueDto>()
                .ForMember(s => s.ActionOrdinal, s => s.MapFrom(a => a.LegalAction.Ordinal))
                .ForMember(s => s.ContentOrdinal, s => s.MapFrom(a => a.LawsuitContent.Ordinal))
                .ReverseMap();

            CreateMap<ArbitrationProceeding_LawsuitContent, AxisUpDto>().ReverseMap();
            CreateMap<ArbitrationProceeding_LawsuitContent, AxisDto>();
            CreateMap<ArbitrationProceeding_LegalAction, AxisUpDto>().ReverseMap();
            CreateMap<ArbitrationProceeding_LegalAction, AxisDto>();
            #endregion

            #region CivilRights_Statistics
            CreateMap<CivilRights_Statistics, ValueDto>()
                .ForMember(s => s.ActionOrdinal, s => s.MapFrom(a => a.LegalAction.Ordinal))
                .ForMember(s => s.ContentOrdinal, s => s.MapFrom(a => a.LawsuitContent.Ordinal))
                .ReverseMap();

            CreateMap<CivilRights_LawsuitContent, AxisUpDto>().ReverseMap();
            CreateMap<CivilRights_LawsuitContent, AxisDto>();
            CreateMap<CivilRights_LegalAction, AxisUpDto>().ReverseMap();
            CreateMap<CivilRights_LegalAction, AxisDto>(); 
            #endregion
        }
    }
}
