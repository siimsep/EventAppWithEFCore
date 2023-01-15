using Microsoft.EntityFrameworkCore;
using EventAppEFCore.Data;

namespace EventAppEFCore.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new EventAppEFCoreContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<EventAppEFCoreContext>>()))
        {
            if (context == null || context.EventInfo == null)
            {
                throw new ArgumentNullException("Null EventInfoContext");
            }

            // Look for any movies.
            if (context.EventInfo.Any())
            {
                return;   // DB has been seeded
            }

            context.EventInfo.AddRange(
                new EventInfo
                {
                    EventName = "Kandideerimine",
                    EventDate = DateTime.Parse("2022-12-5"),
                    EventLocation = "CVKeskus",
                    EventMemo = "CV Teele"
                },
                new EventInfo
                {
                    EventName = "Proovitöö",
                    EventDate = DateTime.Parse("2022-12-14"),
                    EventLocation = "Kodus",
                    EventMemo = "Proovile panek"
                },
                new EventInfo
                {
                    EventName = "Jõulud",
                    EventDate = DateTime.Parse("2022-12-24"),
                    EventLocation = "Pereringis",
                    EventMemo = "Salmid pähe!"
                },
                new EventInfo
                {
                    EventName = "Puhkus",
                    EventDate = DateTime.Parse("2022-12-25"),
                    EventLocation = "Miami Beach, Florida",
                    EventMemo = "Ei tohi unustada päikesekreemi."
                },
                new EventInfo
                {
                    EventName = "Proovitöö tagasiside",
                    EventDate = DateTime.Parse("2023-1-9"),
                    EventLocation = "Internetis",
                    EventMemo = "Põrmustav"
                },
                new EventInfo
                {
                    EventName = "Paranduste tegemine",
                    EventDate = DateTime.Parse("2023-1-10"),
                    EventLocation = "Haapsalu",
                    EventMemo = "Uus väljakutse"
                }
            );
            context.SaveChanges();
        }
    }
}