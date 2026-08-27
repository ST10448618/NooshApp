namespace NooshApp.Api.Dtos
{
    /// <summary>
    /// The shape returned to any client (NooshApp.Web, or later, a mobile
    /// app). Deliberately separate from the MenuItem entity so the API's
    /// public contract doesn't change every time the database schema does.
    /// </summary>
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public bool IsPopular { get; set; }
        public bool IsVegetarian { get; set; }
        public int SpiceLevel { get; set; }
        public bool ContainsEggs { get; set; }
        public bool ContainsWheat { get; set; }
        public bool ContainsDairy { get; set; }
        public bool ContainsSesame { get; set; }
    }
}