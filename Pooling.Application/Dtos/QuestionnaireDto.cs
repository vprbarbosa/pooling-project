using Polling.Domain.Aggregates;

namespace Pooling.Application.Dtos
{
    public class QuestionnaireDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<QuestionDto> Questions { get; set; } = new();

        public static QuestionnaireDto FromDomain(Questionnaire questionnaire)
        {
            return new QuestionnaireDto
            {
                Id = questionnaire.Id,
                Title = questionnaire.Title,
                Questions = questionnaire.Questions.Select(q => new QuestionDto
                {
                    Id = q.Id,
                    Text = q.Text,
                    Options = q.Options.Select(o => new OptionDto
                    {
                        Id = o.Id,
                        Label = o.Label
                    }).ToList()
                }).ToList()
            };
        }
    }

    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<OptionDto> Options { get; set; } = new();
    }

    public class OptionDto
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
    }
}
