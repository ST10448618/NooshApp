using NooshApp.Web.Dtos;

namespace NooshApp.Web.Services
{
    public interface IAdminApiClient
    {
        Task<List<AdminRewardRuleDto>> GetAllRewardRulesAsync(string adminKey);
        Task<bool> CreateRewardRuleAsync(string adminKey, string name, int pointsRequired, string description);
        Task<bool> UpdateRewardRuleAsync(string adminKey, int id, string name, int pointsRequired, string description, bool isActive, int displayOrder);
        Task<AppSettingsDto> GetSettingsAsync(string adminKey);
        Task<bool> UpdateSettingsAsync(string adminKey, decimal pointsPerRand);
    }
}