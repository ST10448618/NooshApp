using Microsoft.EntityFrameworkCore;
using NooshApp.Api.Data;
using NooshApp.Api.Models;
using NooshApp.Api.Repositories.Interfaces;

namespace NooshApp.Api.Repositories
{
    public class RewardRuleRepository : IRewardRuleRepository
    {
        private readonly ApplicationDbContext _context;
        public RewardRuleRepository(ApplicationDbContext context) { _context = context; }

        public async Task<List<RewardRule>> GetActiveAsync() =>
            await _context.RewardRules.Where(r => r.IsActive).OrderBy(r => r.DisplayOrder).ToListAsync();

        public async Task<List<RewardRule>> GetAllAsync() =>
            await _context.RewardRules.OrderBy(r => r.DisplayOrder).ToListAsync();

        public async Task<RewardRule?> GetByIdAsync(int id) => await _context.RewardRules.FindAsync(id);

        public async Task<RewardRule> CreateAsync(RewardRule rule)
        {
            await _context.RewardRules.AddAsync(rule);
            await _context.SaveChangesAsync();
            return rule;
        }

        public async Task UpdateAsync(RewardRule rule)
        {
            rule.UpdatedAt = DateTime.UtcNow;
            _context.RewardRules.Update(rule);
            await _context.SaveChangesAsync();
        }
    }
}