using NooshApp.Api.Models;

namespace NooshApp.Api.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            // ---------------------------------------------------------
            // MENU ITEMS
            // Only seed menu items if none exist.
            // ---------------------------------------------------------
            if (!context.MenuItems.Any())
            {
                var items = new List<MenuItem>
                {
                    // ---------- Shawarma Wraps ----------
                    new MenuItem
                    {
                        Name = "Chicken Shawarma ",
                        Description = "Grilled chicken, onions, tomatoes, pickles, fried brinjal, cabbage, lettuce, cheese and fries.",
                        Price = 80.00m,
                        Category = "Shawarma Wraps",
                        ImageUrl = "/images/menu/chicken-wrap.webp",
                        IsPopular = true,
                        IsVegetarian = false,
                        SpiceLevel = SpiceLevel.Mild
                    },

                    new MenuItem
                    {
                        Name = "Beef Shawarma ",
                        Description = "Slow-cooked beef, onions, tomatoes, pickles, fried brinjal, cabbage, lettuce, cheese and fries.",
                        Price = 90.00m,
                        Category = "Shawarma Wraps",
                        ImageUrl = "/images/menu/beef-wrap.webp",
                        IsPopular = true,
                        IsVegetarian = false,
                        SpiceLevel = SpiceLevel.Mild
                    },

                    new MenuItem
                    {
                        Name = "Falafel Shawarma ",
                        Description = "Crispy falafel, onions, tomatoes, pickles, fried brinjal, cabbage, lettuce, cheese and fries.",
                        Price = 80.00m,
                        Category = "Shawarma Wraps",
                        ImageUrl = "/images/menu/falafel-wrap.webp",
                        IsPopular = true,
                        IsVegetarian = true,
                        SpiceLevel = SpiceLevel.Medium
                    },

                    // ---------- Shawarma Bowls ----------
                    new MenuItem
                    {
                        Name = "Chicken Bowl",
                        Description = "Grilled chicken on your choice of rice, fries, or half & half, loaded with all the fixings.",
                        Price = 110.00m,
                        Category = "Shawarma Bowls",
                        ImageUrl = "/images/menu/chicken-bowl.webp",
                        IsPopular = true,
                        IsVegetarian = false,
                        SpiceLevel = SpiceLevel.Mild
                    },

                    new MenuItem
                    {
                        Name = "Beef Bowl",
                        Description = "Slow-cooked beef on your choice of rice, fries, or half & half, loaded with all the fixings.",
                        Price = 120.00m,
                        Category = "Shawarma Bowls",
                        ImageUrl = "/images/menu/beef-bowl.webp",
                        IsPopular = false,
                        IsVegetarian = false,
                        SpiceLevel = SpiceLevel.Mild
                    },

                    new MenuItem
                    {
                        Name = "Falafel Bowl",
                        Description = "Crispy falafel on your choice of rice, fries, or half & half, loaded with all the fixings.",
                        Price = 110.00m,
                        Category = "Shawarma Bowls",
                        ImageUrl = "/images/menu/falafel-bowl.webp",
                        IsPopular = false,
                        IsVegetarian = true,
                        SpiceLevel = SpiceLevel.Medium
                    },

                    // ---------- Loaded Cheesy Fries ----------
                    new MenuItem
                    {
                        Name = "Chilli Cheese Fries",
                        Description = "Loaded fries topped with melted cheese, guacamole, sour cream and crushed nachos.",
                        Price = 60.00m,
                        Category = "Loaded Cheesy Fries",
                        ImageUrl = "/images/menu/chilli-cheese-fries.webp",
                        IsPopular = true,
                        IsVegetarian = true,
                        SpiceLevel = SpiceLevel.Medium
                    },

                    new MenuItem
                    {
                        Name = "Chilli Cheese Fries — Chicken",
                        Description = "Loaded fries topped with grilled chicken, melted cheese, guacamole, sour cream and crushed nachos.",
                        Price = 80.00m,
                        Category = "Loaded Cheesy Fries",
                        ImageUrl = "/images/menu/chilli-cheese-fries-chicken.webp",
                        IsPopular = false,
                        IsVegetarian = false,
                        SpiceLevel = SpiceLevel.Medium
                    },

                    new MenuItem
                    {
                        Name = "Chilli Cheese Fries — Beef",
                        Description = "Loaded fries topped with slow-cooked beef, melted cheese, guacamole, sour cream and crushed nachos.",
                        Price = 100.00m,
                        Category = "Loaded Cheesy Fries",
                        ImageUrl = "/images/menu/chilli-cheese-fries-beef.webp",
                        IsPopular = false,
                        IsVegetarian = false,
                        SpiceLevel = SpiceLevel.Medium
                    },

                    // ---------- Fries ----------
                    new MenuItem
                    {
                        Name = "Medium Fries",
                        Description = "Crispy golden fries.",
                        Price = 25.00m,
                        Category = "Fries",
                        ImageUrl = "/images/menu/fries-medium.webp",
                        IsVegetarian = true,
                        SpiceLevel = SpiceLevel.None
                    },

                    new MenuItem
                    {
                        Name = "Medium Saucy Fries",
                        Description = "Crispy fries drizzled with garlic sauce and peri peri.",
                        Price = 30.00m,
                        Category = "Fries",
                        ImageUrl = "/images/menu/fries-medium-saucy.webp",
                        IsVegetarian = true,
                        SpiceLevel = SpiceLevel.Mild
                    },

                    new MenuItem
                    {
                        Name = "Large Fries",
                        Description = "Crispy golden fries.",
                        Price = 45.00m,
                        Category = "Fries",
                        ImageUrl = "/images/menu/fries-large.webp",
                        IsVegetarian = true,
                        SpiceLevel = SpiceLevel.None
                    },

                    new MenuItem
                    {
                        Name = "Large Saucy Fries",
                        Description = "Crispy fries drizzled with garlic sauce and peri peri.",
                        Price = 55.00m,
                        Category = "Fries",
                        ImageUrl = "/images/menu/fries-large-saucy.webp",
                        IsVegetarian = true,
                        SpiceLevel = SpiceLevel.Mild
                    },

                    // ---------- Sauce Tubs ----------
                    new MenuItem
                    {
                        Name = "Noosh Chilli Paste",
                        Description = "Our signature house-made chilli paste.",
                        Price = 10.00m,
                        Category = "Sauce Tubs",
                        ImageUrl = "/images/menu/sauce-chilli-paste.webp",
                        IsVegetarian = true,
                        SpiceLevel = SpiceLevel.ExtraHot
                    },

                    new MenuItem
                    {
                        Name = "Noosh Garlic Sauce",
                        Description = "Creamy house garlic sauce.",
                        Price = 10.00m,
                        Category = "Sauce Tubs",
                        ImageUrl = "/images/menu/sauce-garlic.webp",
                        IsVegetarian = true,
                        SpiceLevel = SpiceLevel.None
                    },

                    new MenuItem
                    {
                        Name = "Noosh Peri Peri",
                        Description = "Fiery house peri peri sauce.",
                        Price = 10.00m,
                        Category = "Sauce Tubs",
                        ImageUrl = "/images/menu/sauce-peri-peri.webp",
                        IsVegetarian = true,
                        SpiceLevel = SpiceLevel.Hot
                    },

                    // ---------- Kids Meal ----------
                    new MenuItem
                    {
                        Name = "Noosh Kids Meal",
                        Description = "2 x Chicken Nooshie Wraps, crispy fries, a sauce tub, juice and a fun activity.",
                        Price = 75.00m,
                        Category = "Kids Meal",
                        ImageUrl = "/images/menu/kids-meal.webp",
                        IsPopular = true,
                        IsVegetarian = false,
                        SpiceLevel = SpiceLevel.None
                    }
                };

                context.MenuItems.AddRange(items);
            }

            // ---------------------------------------------------------
            // REWARD RULES
            // Seed independently from MenuItems.
            // ---------------------------------------------------------
            if (!context.RewardRules.Any())
            {
                context.RewardRules.AddRange(
                    new RewardRule
                    {
                        Name = "Free Fries",
                        PointsRequired = 150,
                        RewardDescription = "1 Free Fries",
                        DisplayOrder = 1
                    },

                    new RewardRule
                    {
                        Name = "Free Shawarma",
                        PointsRequired = 400,
                        RewardDescription = "1 Free Shawarma",
                        DisplayOrder = 2
                    }
                );
            }

            // ---------------------------------------------------------
            // APP SETTINGS
            // Seed independently from MenuItems.
            // ---------------------------------------------------------
            if (!context.AppSettings.Any())
            {
                context.AppSettings.Add(
                    new AppSettings
                    {
                        Id = 1,
                        PointsPerRand = 0.1m
                    }
                );
            }

            // Save everything
            context.SaveChanges();
        }
    }
}