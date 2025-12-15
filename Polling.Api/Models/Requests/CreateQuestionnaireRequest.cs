using Pooling.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Polling.Api.Models.Requests
{
    public class CreateQuestionnaireRequest
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public List<CreateQuestionRequest> Questions { get; set; } = new();

        public CreateQuestionnaireDto ToDto()
        {
            return new CreateQuestionnaireDto
            {
                Title = Title,
                Questions = Questions.Select(q => q.ToDto()).ToList()
            };
        }
    }

    public class CreateQuestionRequest
    {
        [Required]
        [MinLength(3)]
        public string Text { get; set; }

        [Required]
        [MinLength(2)]
        public List<string> Options { get; set; } = new();

        public CreateQuestionDto ToDto()
        {
            return new CreateQuestionDto
            {
                Text = Text,
                Options = Options
                    .Select(o => new CreateOptionDto { Label = o })
                    .ToList()
            };
        }
    }
}
