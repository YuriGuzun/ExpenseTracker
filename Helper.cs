using ExpenseTrackerApi.Models.Database;

internal static class Helper
{
    internal static void FillWithData(DatabaseContext context)
    {
        if (context.Users.Any())
        {
            return;
        }

        context.Users.Add(new User { Name = "Homer Simpson", Email = "homer@simpsons.com" });
        context.SaveChanges();

        context.Categories.AddRange(new []
        {
            new Category { Name = "Food", UserId = 1 },
            new Category { Name = "Alcohol", UserId = 1 },
            new Category { Name = "Smoking", UserId = 1 },
            new Category { Name = "Entertaiment", UserId = 1 },
            new Category { Name = "Bills", UserId = 1 }
        });
        context.SaveChanges();

        context.Transactions.AddRange(new []
        {
            new Transaction { UserId = 1, Amount = 30, Date = DateTime.Now.AddDays(-1), CategoryId = 1, Description = "Pizza"         },
            new Transaction { UserId = 1, Amount = 30, Date = DateTime.Now.AddDays(-2), CategoryId = 1, Description = "Pizza"         },
            new Transaction { UserId = 1, Amount = 30, Date = DateTime.Now.AddDays(-3), CategoryId = 1, Description = "Pizza"         },
            new Transaction { UserId = 1, Amount = 5,  Date = DateTime.Now.AddDays(-3), CategoryId = 2, Description = "Duff beer"     },
            new Transaction { UserId = 1, Amount = 5,  Date = DateTime.Now.AddDays(-3), CategoryId = 2, Description = "Duff beer"     },
            new Transaction { UserId = 1, Amount = 15, Date = DateTime.Now.AddDays(-5), CategoryId = 2, Description = "Duff beer"     },
            new Transaction { UserId = 1, Amount = 5,  Date = DateTime.Now.AddDays(-3), CategoryId = 2, Description = "Duff beer"     },
            new Transaction { UserId = 1, Amount = 25, Date = DateTime.Now.AddDays(-3), CategoryId = 3, Description = "Marlboro"      },
            new Transaction { UserId = 1, Amount = 25, Date = DateTime.Now.AddDays(-1), CategoryId = 3, Description = "Marlboro"      },
            new Transaction { UserId = 1, Amount = 40, Date = DateTime.Now.AddDays(-1), CategoryId = 4, Description = "Movie tickets" },
            new Transaction { UserId = 1, Amount = 90, Date = DateTime.Now.AddDays(-1), CategoryId = 4, Description = "October bills" },
        });
        context.SaveChanges();
    }
}