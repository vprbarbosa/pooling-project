namespace Polling.Api.Models.Responses
{
    public class QuestionnaireResponse
    {
        public Guid Id { get; set; }
        public List<QuestionResponse> Questions { get; set; } = new();
    }

    public class QuestionResponse
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<OptionResponse> Options { get; set; } = new();
    }

    public class OptionResponse
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
    }

    public class QuestionnaireCreatedResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
