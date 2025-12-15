namespace Polling.Api.Models.Responses
{
    public class AggregatedResultResponse
    {
        public Guid QuestionId { get; set; }
        public string Option { get; set; }
        public int Count { get; set; }
    }
}
