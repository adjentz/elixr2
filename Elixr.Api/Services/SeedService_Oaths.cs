using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elixr2.Api.Models;
using System.Linq;
using Elixr2.Api.Services.Seeding.Builders;

namespace Elixr2.Api.Services.Seeding
{
    public partial class SeedService
    {

        private void AddOaths()
        {
            CharacteristicBuilder builder = new CharacteristicBuilder(standardCampaignSetting);
            var oath = builder.OfType(CharacteristicType.Oath)
                    .HasName("Chastity")
                    .HasDescriptionFile("Content\\Oaths\\chastity.md")
                    //.HasSpecificPowerAdjustment(-1)
                    .Build();
            dbContext.Characteristics.Add(oath);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            oath = builder.OfType(CharacteristicType.Oath)
                    .HasName("Eschew Magic")
                    .HasDescriptionFile("Content\\Oaths\\eschew-magic.md")
                    //.HasSpecificPowerAdjustment(-8)
                    .Build();
            dbContext.Characteristics.Add(oath);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            oath = builder.OfType(CharacteristicType.Oath)
                    .HasName("Eschew Spells")
                    .HasDescriptionFile("Content\\Oaths\\eschew-spells.md")
                    //.HasSpecificPowerAdjustment(-4)
                    .Build();
            dbContext.Characteristics.Add(oath);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            oath = builder.OfType(CharacteristicType.Oath)
                    .HasName("Fealty")
                    .HasDescriptionFile("Content\\Oaths\\fealty.md")
                    //.HasSpecificPowerAdjustment(-2)
                    .Build();
            dbContext.Characteristics.Add(oath);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            oath = builder.OfType(CharacteristicType.Oath)
                    .HasName("Justice")
                    .HasDescriptionFile("Content\\Oaths\\justice.md")
                    .WithMod("Diplomacy Misc.", 2)
                    .Build();
            dbContext.Characteristics.Add(oath);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            oath = builder.OfType(CharacteristicType.Oath)
                    .HasName("Poverty")
                    .HasDescriptionFile("Content\\Oaths\\poverty.md")
                    //.HasSpecificPowerAdjustment(-1)
                    .Build();
            dbContext.Characteristics.Add(oath);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            oath = builder.OfType(CharacteristicType.Oath)
                    .HasName("Protect Nature")
                    .HasDescriptionFile("Content\\Oaths\\protect-nature.md")
                    .WithMod("Survival Misc.", 3)
                    .Build();
            dbContext.Characteristics.Add(oath);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            oath = builder.OfType(CharacteristicType.Oath)
                    .HasName("Vengeance")
                    .HasDescriptionFile("Content\\Oaths\\vengeance.md")
                    .WithMod("Concentration Misc.", 3)
                    .Build();
            dbContext.Characteristics.Add(oath);

        }
    }
}