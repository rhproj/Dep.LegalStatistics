namespace LegalStatistics.ReportRepository.Models.BaseModels.DTO
{
    public class UpsertEntryDto : DtoBase
    {
        public int Id { get; set; }
        //public int Value { get; set; }
        //public DateTime FillDate { get; set; }
        public string? Comments { get; set; }
    }
}
