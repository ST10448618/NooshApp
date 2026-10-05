using NooshApp.Api.Dtos;
using NooshApp.Api.Models;
using NooshApp.Api.Repositories.Interfaces;
using NooshApp.Api.Services.Interfaces;

namespace NooshApp.Api.Services
{
    public class CateringService : ICateringService
    {
        private readonly ICateringRepository _cateringRepository;
        private readonly IEmailService _emailService;

        public async Task<CateringRequestDto> SubmitRequestAsync(CateringRequestCreateDto request)
        {
            var entity = new CateringRequest
            {
                FullName = request.FullName, PhoneNumber = request.PhoneNumber, Email = request.Email,
                EventDate = request.EventDate, GuestCount = request.GuestCount,
                EventLocation = request.EventLocation, AdditionalNotes = request.AdditionalNotes,
                Status = CateringStatus.New, SubmittedAt = DateTime.UtcNow
            };

            await _cateringRepository.AddAsync(entity);

            _ = Task.Run(async () =>
            {
                try { await _emailService.SendCateringNotificationAsync(entity); }
                catch { /* logged internally */ }
            });

            return ToDto(entity);
        }

        public async Task<CateringRequestDto?> GetByIdAsync(int id)
        {
            var entity = await _cateringRepository.GetByIdAsync(id);
            return entity == null ? null : ToDto(entity);
        }

        private static CateringRequestDto ToDto(CateringRequest entity) => new CateringRequestDto
        {
            Id = entity.Id,
            FullName = entity.FullName,
            EventDate = entity.EventDate,
            GuestCount = entity.GuestCount,
            EventLocation = entity.EventLocation,
            AdditionalNotes = entity.AdditionalNotes,
            Status = entity.Status.ToString(),
            SubmittedAt = entity.SubmittedAt
        };
    }
}