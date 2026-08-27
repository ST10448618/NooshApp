using NooshApp.Api.Dtos;

namespace NooshApp.Api.Services.Interfaces
{
    public interface ICateringService
    {
        Task<CateringRequestDto> SubmitRequestAsync(CateringRequestCreateDto request);
        Task<CateringRequestDto?> GetByIdAsync(int id);
    }
}