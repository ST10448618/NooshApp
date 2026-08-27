using Microsoft.AspNetCore.Mvc;
using NooshApp.Web.Helpers;
using NooshApp.Web.Services;
using NooshApp.Web.ViewModels;

namespace NooshApp.Web.Controllers
{
    public class RewardsController : Controller
    {
        private readonly IRewardsApiClient _rewardsApiClient;
        public RewardsController(IRewardsApiClient rewardsApiClient) { _rewardsApiClient = rewardsApiClient; }

        public async Task<IActionResult> Index()
        {
            if (!HttpContext.Session.IsLoggedIn())
                return RedirectToAction("Login", "Account");

            var idToken = HttpContext.Session.GetIdToken()!;
            var balance = await _rewardsApiClient.GetBalanceAsync(idToken);
            var rewards = await _rewardsApiClient.GetActiveRewardsAsync();

            return View(new RewardsDashboardViewModel
            {
                Balance = balance.Balance,
                History = balance.History,
                AvailableRewards = rewards
            });
        }

        [HttpPost]
        public async Task<IActionResult> GenerateQr()
        {
            if (!HttpContext.Session.IsLoggedIn()) return Unauthorized();
            var idToken = HttpContext.Session.GetIdToken()!;
            var result = await _rewardsApiClient.GenerateQrAsync(idToken, null);
            return result == null ? BadRequest() : Json(result);
        }
    }
}