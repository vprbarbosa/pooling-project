namespace Pooling.Application.Dtos
{
    public class CreateQuestionnaireDto
    {
        public string Title { get; set; }
        public List<CreateQuestionDto> Questions { get; set; } = new();
    }

    public class CreateQuestionDto
    {
        public string Text { get; set; } = string.Empty;
        public List<CreateOptionDto> Options { get; set; } = new();
    }

    public class CreateOptionDto
    {
        public string Label { get; set; } = string.Empty;
    }

    public class QuestionnaireCreatedDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
