using Microsoft.EntityFrameworkCore;
using EventAppEFCore.Data;
using System.Reflection.Emit;
using System.Reflection;
using System.Xml.Linq;

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

            // Look for any.
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
            context.PrivateParticipant.AddRange(
                new PrivateParticipant
                {
                    FName = "Siim",
                    LName = "PNimi",
                    PersonalIdNumber = "31111111112",
                    PaymentType = "Sularaha",
                    AdditionalInfo = "Mi sol es tu sonrisa",
                    EventInfoId = 1
                },
                new PrivateParticipant
                {
                    FName = "Siim",
                    LName = "PNimi",
                    PersonalIdNumber = "31111111112",
                    PaymentType = "Sularaha",
                    AdditionalInfo = "Mi sol es tu sonrisa",
                    EventInfoId = 2

                },
                new PrivateParticipant
                {
                    FName = "Siim",
                    LName = "PNimi",
                    PersonalIdNumber = "31111111112",
                    PaymentType = "Sularaha",
                    AdditionalInfo = "Jõulude ajal olin haige.",
                    EventInfoId = 3
                },
                new PrivateParticipant
                {
                    FName = "Siim",
                    LName = "PNimi",
                    PersonalIdNumber = "31111111112",
                    PaymentType = "Sularaha",
                    AdditionalInfo = "Puhatud sai Miamis.",
                    EventInfoId = 4
                },
                new PrivateParticipant
                {
                    FName = "Keiu",
                    LName = "PNimi",
                    PersonalIdNumber = "41111111112",
                    PaymentType = "Sularaha",
                    AdditionalInfo = "Puhatud sai Miamis.",
                    EventInfoId = 4
                });
            context.CompanyParticipant.AddRange(
                new CompanyParticipant
                {
                    CoName = "RIK",
                    CoCode = "70000310",
                    CoParticipants = "232",
                    PaymentType = "Ülekanne",
                    AdditionalInfo = "CV kätte saadud.",
                    EventInfoId = 1
                },
                new CompanyParticipant
                {
                    CoName = "RIK",
                    CoCode = "70000310",
                    CoParticipants = "232",
                    PaymentType = "Ülekanne",
                    AdditionalInfo = "Saadeti proovitöö.",
                    EventInfoId = 2
                },
                new CompanyParticipant
                {
                    CoName = "RIK",
                    CoCode = "70000310",
                    CoParticipants = "232",
                    PaymentType = "Ülekanne",
                    AdditionalInfo = "Proovitööl on puudusi.",
                    EventInfoId = 5
                });
            context.SaveChanges();
        }
    }
}