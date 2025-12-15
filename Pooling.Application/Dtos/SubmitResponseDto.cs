namespace Pooling.Application.Dtos
{
    public class SubmitResponseDto
    {
        public Guid QuestionnaireId { get; set; }
        public string Fingerprint { get; set; }
        public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    }

    public class AnswerDto
    {
        public Guid QuestionId { get; set; }
        public string Value { get; set; }
    }
}
