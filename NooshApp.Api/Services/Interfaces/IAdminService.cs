using NooshApp.Api.Models;

namespace NooshApp.Api.Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<RewardRule>> GetAllRewardRulesAsync();
        Task<RewardRule> CreateRewardRuleAsync(string name, int pointsRequired, string description);
        Task<RewardRule?> UpdateRewardRuleAsync(int id, string name, int pointsRequired, string description, bool isActive, int displayOrder);
        Task<AppSettings> GetSettingsAsync();
        Task UpdatePointsPerRandAsync(decimal pointsPerRand);
    }
}