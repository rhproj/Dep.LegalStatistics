namespace LegalStatistics.ReportRepository.Models.BaseModels.DTO
{
    public class ValueDto
    {
        public int ContentOrdinal { get; set; }
        public int ActionOrdinal { get; set; }
        public int Value { get; set; }
        public int ReportingYear { get; set; }
        public byte ReportingPeriod { get; set; }
        public DateTime FillDate { get; set; }
        public string? Comments { get; set; }
    }
}
