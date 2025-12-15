using Pooling.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Polling.Api.Models.Requests
{
    public class SubmitResponseRequest
    {
        [Required]
        public Guid QuestionnaireId { get; set; }

        [Required]
        [MinLength(5)]
        public string Fingerprint { get; set; }

        [Required]
        [MinLength(1)]
        public List<AnswerRequest> Answers { get; set; } = new List<AnswerRequest>();

        public SubmitResponseDto ToDto()
        {
            return new SubmitResponseDto
            {
                QuestionnaireId = QuestionnaireId,
                Fingerprint = Fingerprint,
                Answers = Answers.Select(a => a.ToDto()).ToList()
            };
        }
    }

    public class AnswerRequest
    {
        [Required]
        public Guid QuestionId { get; set; }

        [Required]
        [MinLength(1)]
        public string Value { get; set; }

        public AnswerDto ToDto()
        {
            return new AnswerDto
            {
                QuestionId = QuestionId,
                Value = Value
            };
        }
    }
}
