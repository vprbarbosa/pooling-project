using Pooling.Application.Dtos;

namespace Pooling.Application.Interfaces
{
    public interface IResponseService
    {
        Task Submit(SubmitResponseDto dto);
    }
}
