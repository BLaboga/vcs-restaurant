using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistance
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.DailyDishes.Any()) return;
            
            var dailyDishes = new List<DailyDish>
            {
                new DailyDish
                {
                    Title = "Sushi",
                    Description = "nigiri kikiri",
                    Price = 99.99
                },

                new DailyDish
                {
                    Title = "mushi",
                    Description = "nigiri kikiri",
                    Price = 99.99
                },

               new DailyDish
                {
                    Title = "kishi",
                    Description = "nigiri kikiri",
                    Price = 99.99
                },
                new DailyDish
                {
                    Title = "dishi",
                    Description = "nigiri kikiri",
                    Price = 99.99
                }
            };

            await context.DailyDishes.AddRangeAsync(dailyDishes);
            await context.SaveChangesAsync();
        }
    
    }
}