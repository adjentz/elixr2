using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elixr2.Api.Models;
using System.Linq;
using Elixr2.Api.Services.Seeding.Builders;
using System.Collections.Generic;

namespace Elixr2.Api.Services.Seeding
{
    public partial class SeedService
    {

        private void AddEquipment()
        {
            AddWeapons();
            AddArmor();
            AddItems();

            // Best place for this?
            AddWeaponCharacteristics();
        }

        private void AddWeapons()
        {
            WeaponBuilder builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Dagger")
                                       .HasDescription("A sharp knife designed as a weapon.")
                                       .MarkPiercing()
                                       .MarkSlashing()
                                       .HasWeight(1)
                                       .HasCost(2, 0, 0)
                                       .HasDamage("1d4")
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Dagger, throwing")
                                       .HasDescription("A sharp knife designed to be thrown as a weapon.")
                                       .HasWeight(1)
                                       .MarkPiercing()
                                       .HasRange(10)
                                       .HasCost(2, 0, 0)
                                       .HasDamage("1d4")
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Mace, light")
                                       .HasDescription("A wooden rod with a heavy metal head on one end to deliver powerful blows.")
                                       .MarkBludgeoning()
                                       .HasWeight(4)
                                       .HasCost(5, 0, 0)
                                       .HasDamage("1d6")
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Club")
                                       .HasDescription("A short, but thick, wooden stick.")
                                       .HasWeight(3)
                                       .HasCost(0, 0, 1)
                                       .HasDamage("1d6")
                                       .MarkBludgeoning()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Mace, heavy")
                                       .HasDescription("A wooden rod with a heavy metal head on one end to deliver powerful blows.")
                                       .HasWeight(8)
                                       .HasCost(12, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkBludgeoning()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Morningstar")
                                       .HasDescription("A wooden rod with a heavy metal head fielded with spikes on one end to deliver powerful blows.")
                                       .HasWeight(6)
                                       .HasCost(8, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkBludgeoning()
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Spear, throwing")
                                       .HasDescription("A wooden pole with a pointed metal head at the end.")
                                       .HasWeight(3)
                                       .HasRange(20)
                                       .HasCost(1, 0, 0)
                                       .HasDamage("1d6")
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Longspear")
                                       .HasDescription("A wooden pole with a pointed metal head at the end.")
                                       .HasWeight(9)
                                       .HasReach()
                                       .HasCost(5, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkTwoHanded()
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Quarterstaff")
                                       .HasDescription("A shaft of hardwood. Each side counts as seperate weapon. See the rules for two-weapon fighting in the Combat section of Playing Elixr.")
                                       .HasWeight(4)
                                       .HasRange(0)
                                       .HasCost(5, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkTwoHanded(true)
                                       .MarkBludgeoning()
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Spear, melee")
                                       .HasDescription("A wooden pole with a pointed metal head at the end.")
                                       .HasWeight(6)
                                       .HasRange(0)
                                       .HasCost(2, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkTwoHanded(true)
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Crossbow, heavy")
                                       .HasDescription(@"A horizontal bow mounted on a wooden stock.
                                       \n\n
                                       Reloading a Heavy Crossbow costs 50ft of movement Speed.
                                       \n\n
                                       Ammunition costs 1 Gold Piece for 10 bolts.")
                                       .HasWeight(8)
                                       .HasRange(120)
                                       .HasCost(50, 0, 0)
                                       .HasDamage("1d10")
                                       .MarkTwoHanded(true)
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Agility)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Crossbow, light")
                                       .HasDescription(@"A horizontal bow mounted on a wooden stock.
                                       \n\n
                                       Reloading a Heavy Crossbow costs 20ft of movement Speed.
                                       \n\n
                                       Ammunition costs 1 Gold Piece for 10 bolts.")
                                       .HasWeight(4)
                                       .HasRange(80)
                                       .HasCost(35, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkTwoHanded(true)
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Agility)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Javelin")
                                       .HasDescription("A light spear meant to be thrown. Attempting to use in melee combat incurs Disadvantage for all attacks.")
                                       .HasWeight(2)
                                       .HasRange(30)
                                       .HasCost(1, 0, 0)
                                       .HasDamage("1d6")
                                       .MarkTwoHanded(false)
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Axe, throwing")
                                       .HasDescription("An axe meant to be thrown overhand.")
                                       .HasWeight(2)
                                       .HasRange(10)
                                       .HasCost(8, 0, 0)
                                       .HasDamage("1d6")
                                       .MarkTwoHanded(false)
                                       .MarkSlashing()
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Hammer, light")
                                       .HasDescription("A small rod with a blunt, mallet-like head.")
                                       .HasWeight(2)
                                       .HasRange(0)
                                       .HasCost(1, 0, 0)
                                       .HasDamage("1d6")
                                       .MarkTwoHanded(false)
                                       .MarkBludgeoning()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Axe, hand")
                                       .HasDescription("A wooden rod with a sharpened steel blade attached at a right angle at the end.")
                                       .HasWeight(3)
                                       .HasRange(0)
                                       .HasCost(6, 0, 0)
                                       .HasDamage("1d6")
                                       .MarkTwoHanded(false)
                                       .MarkSlashing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Sword, short")
                                       .HasDescription("A metal blade held from a hilt with a handguard, used for thrusting.")
                                       .HasWeight(2)
                                       .HasRange(0)
                                       .HasCost(10, 0, 0)
                                       .HasDamage("1d6")
                                       .MarkTwoHanded(false)
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Axe, battle")
                                       .HasDescription("A wooden rod with two sharpened steel blade attached at right angles at the end.")
                                       .HasWeight(6)
                                       .HasRange(0)
                                       .HasCost(10, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkTwoHanded(false)
                                       .MarkSlashing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Flail")
                                       .HasDescription("A spiked metal ball attached to a wooden rod by a chain. Held by the rod to swing the ball in a circular motion overhead.")
                                       .HasWeight(5)
                                       .HasRange(0)
                                       .HasCost(8, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkTwoHanded(false)
                                       .MarkBludgeoning()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Sword, long")
                                       .HasDescription("A long metal blade held from a hilt with a handguard.")
                                       .HasWeight(4)
                                       .HasRange(0)
                                       .HasCost(15, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkTwoHanded(false)
                                       .MarkSlashing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Rapier")
                                       .HasDescription("A swift, thin blade, used for incisive thrusts.")
                                       .HasWeight(2)
                                       .HasRange(0)
                                       .HasCost(20, 0, 0)
                                       .HasDamage("1d6")
                                       .MarkTwoHanded(false)
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Scimitar")
                                       .HasDescription("A curved metal blade that broadens towards the point.")
                                       .HasWeight(4)
                                       .HasRange(0)
                                       .HasCost(15, 0, 0)
                                       .HasDamage("1d6")
                                       .MarkTwoHanded(false)
                                       .MarkSlashing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Hammer, war")
                                       .HasDescription("A large wooden handle with a large mallet-like head on one end.")
                                       .HasWeight(5)
                                       .HasRange(0)
                                       .HasCost(12, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkTwoHanded(false)
                                       .MarkBludgeoning()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Falchion")
                                       .HasDescription("A single-edged short sword with a wide blade.")
                                       .HasWeight(8)
                                       .HasRange(0)
                                       .HasCost(75, 0, 0)
                                       .HasDamage("2d4")
                                       .MarkTwoHanded(true)
                                       .MarkSlashing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Axe, great")
                                       .HasDescription("A long wooden rod with a large steel blade attached at a right angle to the rod.")
                                       .HasWeight(12)
                                       .HasRange(0)
                                       .HasCost(20, 0, 0)
                                       .HasDamage("1d10")
                                       .MarkTwoHanded(true)
                                       .MarkSlashing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Club, great")
                                       .HasDescription("A long, thick, wooden stick.")
                                       .HasWeight(8)
                                       .HasRange(0)
                                       .HasCost(5, 0, 0)
                                       .HasDamage("1d10")
                                       .MarkTwoHanded(true)
                                       .MarkBludgeoning()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Flail, heavy")
                                       .HasDescription("A spiked metal ball attached to a long wooden rod by a chain. Held by the rod to swing the ball in a circular motion overhead.")
                                       .HasWeight(10)
                                       .HasRange(0)
                                       .HasCost(15, 0, 0)
                                       .HasDamage("1d10")
                                       .MarkTwoHanded(true)
                                       .MarkBludgeoning()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Sword, great")
                                       .HasDescription("A long sword, requiring two hands.")
                                       .HasWeight(8)
                                       .HasRange(0)
                                       .HasCost(50, 0, 0)
                                       .HasDamage("2d6")
                                       .MarkTwoHanded(true)
                                       .MarkSlashing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Halberd")
                                       .HasDescription("A long metal pole with pointed tip and axe-like protrusion at the top.")
                                       .HasWeight(12)
                                       .HasRange(0)
                                       .HasCost(10, 0, 0)
                                       .HasDamage("1d10")
                                       .MarkTwoHanded(true)
                                       .MarkPiercing()
                                       .MarkSlashing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Lance")
                                       .HasDescription(@"A wooden shaft with a pointed steel head meant for thrusting. 
                                       \n\n
                                       Attacks made while mounted deal double damage.")
                                       .HasWeight(10)
                                       .HasReach()
                                       .HasCost(10, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkTwoHanded(true)
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Scythe")
                                       .HasDescription("An agricultural tool consisted of a wooden staff with a crescent blade at the top; retrofitted for attack.")
                                       .HasWeight(10)
                                       .HasRange(0)
                                       .HasCost(18, 0, 0)
                                       .HasDamage("2d4")
                                       .MarkTwoHanded(true)
                                       .MarkPiercing()
                                       .MarkSlashing()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Bow, long")
                                       .HasDescription("A large, curved piece of wood with a taut string joining the ends. Used to fire arrows. Ammunition costs 1 Gold Piece for 20 arrows.")
                                       .HasWeight(3)
                                       .HasRange(100)
                                       .HasCost(75, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkTwoHanded(true)
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Agility)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Bow, long (composite)")
                                       .HasDescription("A large, curved piece of wood with a taut string joining the ends. Manufactured to withstand more pressure. Used to fire arrows. Ammunition costs 1 Gold Piece for 20 arrows.")
                                       .HasWeight(3)
                                       .HasRange(110)
                                       .HasCost(100, 0, 0)
                                       .HasDamage("1d8")
                                       .MarkTwoHanded(true)
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Bow, short")
                                       .HasDescription("A curved piece of wood with a taut string joining the ends. Used to fire arrows. Ammunition costs 1 Gold Piece for 20 arrows.")
                                       .HasWeight(2)
                                       .HasRange(60)
                                       .HasCost(30, 0, 0)
                                       .HasDamage("1d6")
                                       .MarkTwoHanded(true)
                                       .MarkPiercing()
                                       .UseAttackAbility(WeaponUseAbility.Agility)
                                       .UseDamageAbility(WeaponUseAbility.Agility)
                                       .Build());

            builder = new WeaponBuilder(standardCampaignSetting);
            dbContext.Weapons.Add(builder.HasName("Glaive")
                                       .HasDescription("A single-edged blade on the end of a pole.")
                                       .HasWeight(10)
                                       .HasRange(0)
                                       .HasCost(8, 0, 0)
                                       .HasDamage("1d10")
                                       .MarkTwoHanded(true)
                                       .HasReach()
                                       .UseAttackAbility(WeaponUseAbility.Strength)
                                       .UseDamageAbility(WeaponUseAbility.Strength)
                                       .Build());
        }
        private void AddArmor()
        {

            ArmorBuilder builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Quilted")
                                       .HasDescription("A padded jacket to dampen blows")
                                       .HasWeight(10)
                                       .HasCost(5, 0, 0)
                                       .HasDefenseBonus(1)
                                       .HasSpeedPenalty(0)
                                       .HasAgilityPenalty(0)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Leather")
                                       .HasDescription("Strips of leather boiled in oil formed into a shirt and leggings.")
                                       .HasWeight(15)
                                       .HasCost(10, 0, 0)
                                       .HasDefenseBonus(2)
                                       .HasSpeedPenalty(0)
                                       .HasAgilityPenalty(0)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Studded Leather")
                                       .HasDescription("Strips of leather boiled in oil formed into a shirt and leggings decorated with metal studs.")
                                       .HasWeight(20)
                                       .HasCost(10, 0, 0)
                                       .HasDefenseBonus(2)
                                       .HasSpeedPenalty(0)
                                       .HasAgilityPenalty(1)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Chain Shirt")
                                       .HasDescription("A shirt of metal rings linked together to form a protective mesh.")
                                       .HasWeight(25)
                                       .HasCost(100, 0, 0)
                                       .HasDefenseBonus(4)
                                       .HasSpeedPenalty(0)
                                       .HasAgilityPenalty(2)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Hide")
                                       .HasDescription("Clothing made of the layered, thick pelts of animals.")
                                       .HasWeight(25)
                                       .HasCost(15, 0, 0)
                                       .HasDefenseBonus(3)
                                       .HasSpeedPenalty(10)
                                       .HasAgilityPenalty(3)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Scale Mail")
                                       .HasDescription("Shirt made of overlapping metal plates sewn to cloth.")
                                       .HasWeight(30)
                                       .HasCost(50, 0, 0)
                                       .HasDefenseBonus(4)
                                       .HasSpeedPenalty(10)
                                       .HasAgilityPenalty(4)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Chainmail")
                                       .HasDescription("A sleeved shirt made of mail that reaches down to the mid-thigh.")
                                       .HasWeight(30)
                                       .HasCost(150, 0, 0)
                                       .HasDefenseBonus(5)
                                       .HasSpeedPenalty(10)
                                       .HasAgilityPenalty(5)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Breastplate")
                                       .HasDescription("A single piece of metal that covers the torso and attaches to a back piece.")
                                       .HasWeight(40)
                                       .HasCost(200, 0, 0)
                                       .HasDefenseBonus(5)
                                       .HasSpeedPenalty(10)
                                       .HasAgilityPenalty(4)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Splint Mail")
                                       .HasDescription("Leather with steel plates riveted to it.")
                                       .HasWeight(45)
                                       .HasCost(200, 0, 0)
                                       .HasDefenseBonus(6)
                                       .HasSpeedPenalty(20)
                                       .HasAgilityPenalty(7)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Banded Mail")
                                       .HasDescription("Leather armor with metal strips fastened to it.")
                                       .HasWeight(35)
                                       .HasCost(250, 0, 0)
                                       .HasDefenseBonus(6)
                                       .HasSpeedPenalty(20)
                                       .HasAgilityPenalty(6)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Half Plate")
                                       .HasDescription("Plate armor covering the torso. Includes helmet.")
                                       .HasWeight(50)
                                       .HasCost(600, 0, 0)
                                       .HasDefenseBonus(7)
                                       .HasSpeedPenalty(20)
                                       .HasAgilityPenalty(7)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Full Plate")
                                       .HasDescription("A full suit of armor (including helmet and gauntlets) made of metal plates.")
                                       .HasWeight(50)
                                       .HasCost(1500, 0, 0)
                                       .HasDefenseBonus(8)
                                       .HasSpeedPenalty(20)
                                       .HasAgilityPenalty(6)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Buckler")
                                       .HasDescription("A small round shield held from a central handle. Dropping a buckler has 0 movement speed cost.")
                                       .HasWeight(5)
                                       .HasCost(15, 0, 0)
                                       .HasDefenseBonus(1)
                                       .HasSpeedPenalty(0)
                                       .HasAgilityPenalty(1)
                                       .Build());

            builder = new ArmorBuilder(standardCampaignSetting);
            dbContext.Armor.Add(builder.HasName("Shield")
                                       .HasDescription("A large wooden shield held with an arm strap. Dropping a shield has movement speed cost 5ft.")
                                       .HasWeight(10)
                                       .HasCost(7, 0, 0)
                                       .HasDefenseBonus(2)
                                       .HasSpeedPenalty(0)
                                       .HasAgilityPenalty(2)
                                       .Build());
        }
        private void AddItems()
        {
            var builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Backpack")
                                       .HasDescription("One cubic ft. bag that can be slung over the shoulders.")
                                       .HasWeight(2)
                                       .HasCost(2, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Bedroll")
                                       .HasDescription("A collection of bedding material constructed to be easy to roll up and transport.")
                                       .HasWeight(5)
                                       .HasCost(0, 1, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Candle")
                                       .HasDescription("An ignitable wick embedded in wax.")
                                       .HasWeight(0)
                                       .HasCost(0, 0, 1)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Chain (10 ft.)")
                                       .HasDescription("A metal chain meant for binding a person. Bursting requires an Strength check (Difficutly 25)")
                                       .HasWeight(2)
                                       .HasCost(30, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Crowbar")
                                       .HasDescription("Grants +2 to Strength checks meant for the intention of prying something open. Can be used as a Club (see Weapons)")
                                       .HasWeight(5)
                                       .HasCost(2, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Firewood")
                                       .HasDescription("Chopped wood for making a fire.")
                                       .HasWeight(20)
                                       .HasCost(0, 0, 1)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Fishhook")
                                       .HasDescription("Curved piece of metal meant for catching fish.")
                                       .HasWeight(0)
                                       .HasCost(0, 1, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Flask (empty")
                                       .HasDescription("A narrow-necked glass container for holding liquid.")
                                       .HasWeight(1.5f)
                                       .HasCost(0, 0, 3)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Flint and steel")
                                       .HasDescription("Grants Advantage to Survival checks when used for creating fire.")
                                       .HasWeight(0)
                                       .HasCost(1, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Grappling hook")
                                       .HasDescription("Throwing a grappling hook requires an Agility Attack, where the effective Defense is 10 + 2 per 10ft of distance thrown.")
                                       .HasWeight(4)
                                       .HasCost(1, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Ink (1 oz. vial)")
                                       .HasDescription("Black ink for writing.")
                                       .HasWeight(1 / 16f)
                                       .HasCost(0, 1, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Quill")
                                       .HasDescription("A feather meant for dipping in ink and writing with.")
                                       .HasWeight(0)
                                       .HasCost(0, 1, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Ladder, 10 ft")
                                       .HasDescription("A wooden runged ladder")
                                       .HasWeight(20)
                                       .HasCost(0, 0, 5)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Lantern")
                                       .HasDescription("A lantern which clearly illuminates a 30 ft radius and provides shadowy illumination in a 60 ft radius. \n\n It burns for 6 hours on a pint of oil and can be carried in one hand.")
                                       .HasWeight(5)
                                       .HasCost(7, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Lock, simple")
                                       .HasDescription("Opening a simple lock requires an Engineer check with a Difficulty of 20.")
                                       .HasWeight(1)
                                       .HasCost(20, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Lock, average")
                                       .HasDescription("Opening an average lock requires an Engineer check with a Difficulty of 25.")
                                       .HasWeight(1)
                                       .HasCost(40, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Lock, good")
                                       .HasDescription("Opening a good lock requires an Engineer check with a Difficulty of 30.")
                                       .HasWeight(1)
                                       .HasCost(80, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Lock, superior")
                                       .HasDescription("Opening a good lock requires an Engineer check with a Difficulty of 30.")
                                       .HasWeight(1)
                                       .HasCost(150, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Manacles")
                                       .HasDescription("Manacles for binding a Medium creature. An Escape Artist (Difficulty 30) to slip out can be made. Small creatures get Advantage on this check, Large creatures get Disadvantage.\n\nA Strength check (Difficulty 26) can be used to break out.")
                                       .HasWeight(2)
                                       .HasCost(15, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Manacles, masterwork")
                                       .HasDescription("Manacles for binding a Medium creature. An Escape Artist (Difficulty 35) to slip out can be made. Small creatures get Advantage on this check, Large creatures get Disadvantage.\n\nA Strength check (Difficulty 28) can be used to break out.")
                                       .HasWeight(2)
                                       .HasCost(50, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Mirror, small steel")
                                       .HasDescription("A reflective steel surface.")
                                       .HasWeight(0.5f)
                                       .HasCost(10, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Parchment (sheet)")
                                       .HasDescription("Writing material made from untanned skins of animals.")
                                       .HasWeight(1)
                                       .HasCost(0, 2, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Mess kit")
                                       .HasDescription("A lightweight pot, pan, mug, and spatula.")
                                       .HasWeight(10)
                                       .HasCost(2, 6, 2)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Pouch, belt (empty)")
                                       .HasDescription("Small sack that can be attached to the belt.")
                                       .HasWeight(0.5f)
                                       .HasCost(1, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Rope, hemp (50 ft)")
                                       .HasDescription("Tying knots requires a Survival check to determine adequacy of the knot.\n\nCan be burst with Strength check (Difficulty 23)")
                                       .HasWeight(10)
                                       .HasCost(1, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Rope, silk (50 ft)")
                                       .HasDescription("Tying knots requires a Survival check made with Advantage to determine adequacy of the knot.\n\nCan be burst with Strength check (Difficulty 24)")
                                       .HasWeight(5)
                                       .HasCost(10, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Shovel")
                                       .HasDescription("A tool meant for digging. Has a pointed (spade) tip.")
                                       .HasWeight(8)
                                       .HasCost(2, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Spyglass")
                                       .HasDescription("A telescope that grants Advantage on Perception checks made to discern far away objects.")
                                       .HasWeight(1)
                                       .HasCost(1000, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Tent")
                                       .HasDescription("Two-person shelter made of canvas held up by wooden poles.")
                                       .HasWeight(20)
                                       .HasCost(10, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Torch")
                                       .HasDescription("A wooden rod with one end wrapped in a cloth soaked with a flammable substance.\n\nBurns for 1 hour, clearly illuminating within 20 ft. and providing shadowy illumination out to a 40 ft radius.")
                                       .HasWeight(1)
                                       .HasCost(0, 0, 1)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Vial")
                                      .HasDescription("Glass tube with a stopper. Holds one ounce of liqud. Approximately 1 inch wide and 3 inches high.")
                                       .HasWeight(1 / 10f)
                                       .HasCost(1, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Waterskin")
                                       .HasDescription("Cured sheepskin formed to retain water for drinking.")
                                       .HasWeight(4)
                                       .HasCost(1, 0, 0)
                                       .Build());

            builder = new ItemBuilder(standardCampaignSetting);
            dbContext.Items.Add(builder.HasName("Whetstone")
                                       .HasDescription("A tool for sharpening metal.")
                                       .HasWeight(1)
                                       .HasCost(0, 0, 2)
                                       .Build());
        }

        private void AddWeaponCharacteristics()
        {
            var builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Rake")
                                                       .HasSpecificPower(14)
                                                       .HasDescriptionFile(@"Content\Characteristics\Weapons\rake.md")
                                                       .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Tripping")
                                                        .HasSpecificPower(5)
                                                        .HasDescriptionFile(@"Content\Characteristics\Weapons\tripping.md")
                                                        .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Cooldown, 1d4")
                                                        .HasSpecificPower(-4)
                                                        .HasDescriptionFile(@"Content\Characteristics\Weapons\cooldown.md", "1d4")
                                                        .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Conic, 15ft")
                                                        .HasSpecificPower(11)
                                                        .HasDescriptionFile(@"Content\Characteristics\Weapons\conic.md", "15ft")
                                                        .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Conic, 20ft")
                                                        .HasSpecificPower(14)
                                                        .HasDescriptionFile(@"Content\Characteristics\Weapons\conic.md", "20ft")
                                                        .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Conic, 30ft")
                                                        .HasSpecificPower(20)
                                                        .HasDescriptionFile(@"Content\Characteristics\Weapons\conic.md", "30ft")
                                                        .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Conic, 80ft")
                                                        .HasSpecificPower(56)
                                                        .HasDescriptionFile(@"Content\Characteristics\Weapons\conic.md", "20ft")
                                                        .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Non-Lethal")
                                                        .HasSpecificPower(-1)
                                                        .HasDescriptionFile(@"Content\Characteristics\Weapons\non-lethal.md", "15ft")
                                                        .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Leech, 1d8")
                                                        .HasSpecificPower(12)
                                                        .HasDescriptionFile(@"Content\Characteristics\Weapons\leech.md", "1d8")
                                                        .Build());




            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Splashing")
                                                        .HasSpecificPower(5)
                                                        .HasDescriptionFile(@"Content\Characteristics\Weapons\splashing.md")
                                                        .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Targets Acrobatics Defense")
                                                        .HasSpecificPower(1)
                                                        .HasDescriptionFile(@"Content\Characteristics\Weapons\targets-acrobatics-defense.md")
                                                        .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Causes Level Loss")
                                                        .HasSpecificPower(12)
                                                        .HasDescriptionFile(@"Content\Characteristics\Weapons\causes-level-loss.md")
                                                        .Build());

            string[] energyTypes = new string[] { "Acid", "Electric", "Fire", "Cold", "Light", "Shadow" };
            string[] dieTypes = new string[] { "d4", "d6", "d8", "d12" };

            foreach (var energyType in energyTypes)
            {
                foreach (var die in dieTypes)
                {
                    for (int sides = 1; sides <= 3; sides++)
                    {
                        string damage = sides + die;
                        builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
                        dbContext.WeaponCharacteristics.Add(builder.HasName($"{energyType}, {damage}")
                                                                   .HasExtraDamage(damage)
                                                                   .HasDescriptionFile(@"Content\Characteristics\Weapons\energy-attack.md", damage, "Electric")
                                                                   .Build());
                    }
                }
            }

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Latch") // e.g. "Improved Grab"
                                                       .HasSpecificPower(5)
                                                       .HasDescriptionFile(@"Content\Characteristics\Weapons\latch.md")
                                                       .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Poison, 1d6 Str")
                                                       .HasSpecificPower(6)
                                                       .HasDescriptionFile(@"Content\Characteristics\Weapons\poison.md", "1d6", "Strength Score")
                                                       .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Poison, 1d4 Agility")
                                                       .HasSpecificPower(4)
                                                       .HasDescriptionFile(@"Content\Characteristics\Weapons\poison.md", "1d4", "Agility Score")
                                                       .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Poison, 2d6 Str")
                                                       .HasSpecificPower(12)
                                                       .HasDescriptionFile(@"Content\Characteristics\Weapons\poison.md", "2d6", "Strength Score")
                                                       .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Poison, 2d6 Agility")
                                                       .HasSpecificPower(12)
                                                       .HasDescriptionFile(@"Content\Characteristics\Weapons\poison.md", "2d6", "Agility Score")
                                                       .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Poison, 1d6 Energy")
                                                       .HasSpecificPower(6)
                                                       .HasDescriptionFile(@"Content\Characteristics\Weapons\poison.md", "1d6", "Current Energy")
                                                       .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Ignores Armor")
                                                       .HasSpecificPower(10) // should maybe scale with Base Defense, or Defense.PowerRating?
                                                       .HasDescriptionFile(@"Content\Characteristics\Weapons\ignores-armor.md", standardCampaignSetting.BaseDefense.ToString())
                                                       .Build());

            builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
            dbContext.WeaponCharacteristics.Add(builder.HasName("Constrict")
                                                       .HasSpecificPower(8) // should maybe scale with Base Defense, or Defense.PowerRating?
                                                       .HasDescriptionFile(@"Content\Characteristics\Weapons\constrict.md", standardCampaignSetting.BaseDefense.ToString())
                                                       .Build());

            for (int i = 1; i <= 15; i++)
            {
                builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
                dbContext.WeaponCharacteristics.Add(builder.HasName($"Weapon Training, {i}")
                                                           .HasSpecificPower(i * 2)
                                                           .HasAttackBonusMod(i)
                                                           .HasDescriptionFile(@"Content\Characteristics\Weapons\weapon-training.md", i.ToString())
                                                           .Build());

                builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
                dbContext.WeaponCharacteristics.Add(builder.HasName($"Weapon Specialization, {i}")
                                                           .HasSpecificPower(i)
                                                           .HasDamageBonusMod(i)
                                                           .HasDescriptionFile(@"Content\Characteristics\Weapons\weapon-specialization.md", i.ToString())
                                                           .Build());

                builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
                dbContext.WeaponCharacteristics.Add(builder.HasName($"Clumsy Weapon, {i}")
                                                           .HasSpecificPower(-i * 2)
                                                           .HasAttackBonusMod(-i)
                                                           .HasDescriptionFile(@"Content\Characteristics\Weapons\clumsy-weapon.md", i.ToString())
                                                           .Build());

                builder = new WeaponCharacteristicBuilder(standardCampaignSetting);
                dbContext.WeaponCharacteristics.Add(builder.HasName($"Weak Weapon, {i}")
                                                           .HasSpecificPower(-i)
                                                           .HasDamageBonusMod(-i)
                                                           .HasDescriptionFile(@"Content\Characteristics\Weapons\weak-weapon.md", i.ToString())
                                                           .Build());
            }
        }
    }
}