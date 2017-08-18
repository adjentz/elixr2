using Microsoft.EntityFrameworkCore;
using Elixr2.Api.Models;

namespace Elixr2.Api.Services
{
    public class ElixrDbContext : DbContext
    {
        public ElixrDbContext(DbContextOptions<ElixrDbContext> options)
        : base(options)
        { }
        public DbSet<CampaignSetting> CampaignSettings { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }

        public DbSet<Template> Templates { get; set; }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Spell> Spells { get; set; }

        public DbSet<Creature> Creatures { get; set; }
        public DbSet<WeaponCharacteristic> WeaponCharacteristics { get; set; }
        public DbSet<SpellCharacteristic> SpellCharacteristics { get; set; }

    }
}