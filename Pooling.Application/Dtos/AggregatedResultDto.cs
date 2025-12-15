namespace Pooling.Application.Dtos
{
    public class AggregatedResultDto
    {
        public Guid QuestionId { get; set; }
        public string Option { get; set; }
        public int Count { get; set; }
    }
}
