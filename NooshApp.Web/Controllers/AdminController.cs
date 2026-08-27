using Microsoft.AspNetCore.Mvc;
using NooshApp.Web.Helpers;
using NooshApp.Web.Services;

namespace NooshApp.Web.Controllers
{
    // Not linked in navigation — reachable only by direct URL, gated by
    // the admin key itself (same pattern as Staff).
    public class AdminController : Controller
    {
        private readonly IAdminApiClient _adminApiClient;
        public AdminController(IAdminApiClient adminApiClient) { _adminApiClient = adminApiClient; }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string key)
        {
            var rules = await _adminApiClient.GetAllRewardRulesAsync(key);
            // GetAllRewardRulesAsync returns an empty list on a 401 — a genuinely
            // empty (but authorized) list would be indistinguishable from a wrong
            // key on the very first use before any rules exist. Acceptable here
            // since we always seed default reward rules, so an empty result
            // reliably means "key was rejected," not "no rules configured."
            if (!rules.Any())
            {
                ModelState.AddModelError(string.Empty, "Incorrect admin key.");
                return View();
            }

            HttpContext.Session.SetAdminKey(key);
            return RedirectToAction("Rewards");
        }

        public async Task<IActionResult> Rewards()
        {
            if (!HttpContext.Session.IsAdminAuthenticated()) return RedirectToAction("Login");

            var adminKey = HttpContext.Session.GetAdminKey()!;
            ViewBag.Rules = await _adminApiClient.GetAllRewardRulesAsync(adminKey);
            ViewBag.Settings = await _adminApiClient.GetSettingsAsync(adminKey);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRule(string name, int pointsRequired, string description)
        {
            var adminKey = HttpContext.Session.GetAdminKey();
            if (string.IsNullOrEmpty(adminKey)) return Unauthorized();

            await _adminApiClient.CreateRewardRuleAsync(adminKey, name, pointsRequired, description);
            return RedirectToAction("Rewards");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRule(int id, string name, int pointsRequired, string description, bool isActive, int displayOrder)
        {
            var adminKey = HttpContext.Session.GetAdminKey();
            if (string.IsNullOrEmpty(adminKey)) return Unauthorized();

            await _adminApiClient.UpdateRewardRuleAsync(adminKey, id, name, pointsRequired, description, isActive, displayOrder);
            return RedirectToAction("Rewards");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSettings(decimal pointsPerRand)
        {
            var adminKey = HttpContext.Session.GetAdminKey();
            if (string.IsNullOrEmpty(adminKey)) return Unauthorized();

            await _adminApiClient.UpdateSettingsAsync(adminKey, pointsPerRand);
            return RedirectToAction("Rewards");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.ClearAdminKey();
            return RedirectToAction("Login");
        }
    }
}