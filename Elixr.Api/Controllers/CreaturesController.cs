using Elixr2.Api.ViewModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elixr2.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Elixr2.Api.Extensions;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using Elixr2.Api.Models;

namespace Elixr2.Api.Controllers
{
    public class CreaturesController : Controller
    {
        private readonly CreaturesService creaturesService;
        private readonly ObjectStorageService storageService;
        public CreaturesController(CreaturesService creaturesService, ObjectStorageService storageService)
        {
            this.creaturesService = creaturesService;
            this.storageService = storageService;
        }
        [HttpGet("~/creatures/{creatureId}")]
        public async Task<CreatureViewModel> GetCreature(int creatureId)
        {
            var creature = await this.creaturesService.GetCreatureById(creatureId);
            return creature.ToViewModel();
        }
        [HttpPost("~/creatures/save-portrait")]
        public async Task<string> SaveCreaturePortrait()
        {
            var file = Request.Form.Files.First();
            using (var stream = file.OpenReadStream())
            {
                await storageService.SaveStream(stream, file.FileName);
            }

            return "{}";
        }

        private CreatureListingViewModel ToListingViewModel(Creature creature)
        {
            return new CreatureListingViewModel
            {
                Description = creature.Description,
                Name = creature.Name,
                Power = creature.Power,
                CreatureId = creature.Id
            };
        }
        [HttpPost("~/creatures/search")]
        public async Task<List<CreatureListingViewModel>> GetCreatures([FromBody]SearchCreaturesInput input)
        {
            var creatures = await creaturesService.GetCreatures();
            return creatures.Select(c => ToListingViewModel(c)).ToList();
        }

        [HttpPost("~/creatures/save")]
        public async Task<CreatureViewModel> SaveCreature([FromBody]UpdateCreatureInput input)
        {
            Creature creature = null;
            if (input.CreatureId > 0)
            {
                creature = await creaturesService.GetCreatureById(input.CreatureId);
            }
            else
            {
                creature = new Creature();
                creature.CampaignSettingId = input.CampaignSettingId;
            }
            creature.Name = input.NameChangedTo;
            creature.Age = input.AgeChangedTo;
            creature.Gender = input.GenderChangedTo;
            creature.Weight = input.WeightChangedTo;
            creature.Height = input.HeightChangedTo;
            creature.Hair = input.HairChangedTo;
            creature.Eyes = input.EyesChangedTo;
            creature.Skin = input.SkinChangedTo;
            creature.Description = input.DescriptionChangedTo;
            creature.Level = input.LevelSetTo;

            creature.Mods.RemoveAll(asm => input.DeletedAppliedStatModIds.Contains(asm.Id));
            creature.SelectedArmor.RemoveAll(sa => input.DeletedSelectedArmorIds.Contains(sa.Id));
            creature.SelectedCharacteristics.RemoveAll(sc => input.DeletedSelectedCharacteristicIds.Contains(sc.Id));
            creature.SelectedItems.RemoveAll(si => input.DeletedSelectedItemIds.Contains(si.Id));
            creature.SelectedSpells.RemoveAll(ss => input.DeletedSelectedSpellIds.Contains(ss.Id));
            creature.SelectedTemplates.RemoveAll(st => input.DeletedSelectedTemplateIds.Contains(st.Id));
            creature.SelectedWeapons.RemoveAll(sw => input.DeletedSelectedWeaponIds.Contains(sw.Id));

            input.NewAppliedStatMods.ForEach(sm => ApplyStatMod(sm, creature));
            input.NewSelectedArmor.ForEach(sa => AddSelectedArmor(sa, creature));
            input.NewSelectedCharacteristics.ForEach(sc => AddSelectedCharacteristic(sc, creature));
            input.NewSelectedItems.ForEach(si => AddSelectedItem(si, creature));
            input.NewSelectedSpells.ForEach(ss => AddSelectedSpell(ss, creature));
            input.NewSelectedTemplates.ForEach(st => AddSelectedTemplate(st, creature));
            input.NewSelectedWeapons.ForEach(sw => AddSelectedWeapon(sw, creature));
            input.NewWealthAdjustments.ForEach(wa => AddWealthAdjustment(wa, creature));

            var task = input.CreatureId > 0 ? creaturesService.UpdateCreature(creature) : creaturesService.CreateCreature(creature);
            await task;
            creature = await creaturesService.GetCreatureById(creature.Id); //Maybe overkill, but it makes sure that we're in sync with the DB.
            return creature.ToViewModel();
        }
        private void AddSelectedArmor(SelectedArmorViewModel selectedArmor, Creature creature)
        {
            creature.SelectedArmor.Add(new SelectedArmor
            {
                ArmorId = selectedArmor.Armor.ArmorId,
                Notes = selectedArmor.Notes,
                SelectedAtMS = selectedArmor.SelectedAtMS
            });
        }

        private void AddSelectedCharacteristic(SelectedCharacteristicViewModel selectedCharacteristic, Creature creature)
        {
            creature.SelectedCharacteristics.Add(new SelectedCharacteristic
            {
                TakenAtMS = selectedCharacteristic.TakenAtMS,
                TakenAtLevel = selectedCharacteristic.TakenAtLevel,
                CharacteristicId = selectedCharacteristic.Characteristic.CharacteristicId,
                IsTemplateCharacteristic = selectedCharacteristic.IsTemplateCharacteristic,
                Notes = selectedCharacteristic.Notes
            });
        }

        private void AddSelectedItem(SelectedItemViewModel selectedItem, Creature creature)
        {
            creature.SelectedItems.Add(new SelectedItem
            {
                ItemId = selectedItem.Item.ItemId,
                SelectedAtMS = selectedItem.SelectedAtMS,
                Notes = selectedItem.Notes
            });
        }

        private void AddSelectedSpell(SelectedSpellViewModel selectedSpell, Creature creature)
        {
            creature.SelectedSpells.Add(new SelectedSpell
            {
                SpellId = selectedSpell.Spell.SpellId,
                SelectedAtMS = selectedSpell.SelectedAtMS,
                Notes = selectedSpell.Notes
            });
        }

        private void AddSelectedTemplate(SelectedTemplateViewModel selectedTemplate, Creature creature)
        {
            creature.SelectedTemplates.Add(new SelectedTemplate
            {
                TemplateId = selectedTemplate.Template.TemplateId,
                SelectedAtMS = selectedTemplate.SelectedAtMS,
                Notes = selectedTemplate.Notes
            });
        }

        private void AddSelectedWeapon(SelectedWeaponViewModel selectedWeapon, Creature creature)
        {
            SelectedWeapon weapon = new SelectedWeapon
            {
                WeaponId = selectedWeapon.Weapon.WeaponId,
                SelectedAtMS = selectedWeapon.SelectedAtMS,
                Notes = selectedWeapon.Notes,
            };
            creature.SelectedWeapons.Add(weapon);
        }

        private void AddWealthAdjustment(WealthAdjustmentViewModel wealthAdjustment, Creature creature)
        {
            creature.WealthAdjustments.Add(new WealthAdjustment
            {
                Amount = wealthAdjustment.Amount,
                Reason = wealthAdjustment.Reason,
                AdjustedAtMS = wealthAdjustment.AdjustedAtMS
            });
        }

        private void ApplyStatMod(AppliedStatModViewModel appliedStatMod, Creature creature)
        {
            StatMod statMod = new StatMod
            {
                Modifier = appliedStatMod.StatMod.Modifier,
                Reason = appliedStatMod.StatMod.Reason,
                StatId = appliedStatMod.StatMod.StatId
            };

            creature.Mods.Add(new AppliedStatMod
            {
                StatMod = statMod,
                AppliedAtLevel = appliedStatMod.AppliedAtLevel,
                AppliedAtUnixMS = appliedStatMod.AppliedAtUnixMS
            });
        }
        public class UpdateCreatureInput
        {
            public int CampaignSettingId { get; set; }
            public int CreatureId { get; set; }
            public string NameChangedTo { get; set; }
            public string AgeChangedTo { get; set; }
            public string GenderChangedTo { get; set; }
            public string WeightChangedTo { get; set; }
            public string HeightChangedTo { get; set; }
            public string HairChangedTo { get; set; }
            public string EyesChangedTo { get; set; }
            public string SkinChangedTo { get; set; }
            public string DescriptionChangedTo { get; set; }
            public int LevelSetTo { get; set; }

            public List<int> DeletedAppliedStatModIds { get; set; }
            public List<int> DeletedSelectedArmorIds { get; set; }
            public List<int> DeletedSelectedWeaponIds { get; set; }
            public List<int> DeletedSelectedItemIds { get; set; }
            public List<int> DeletedSelectedSpellIds { get; set; }
            public List<int> DeletedSelectedTemplateIds { get; set; }
            public List<int> DeletedSelectedCharacteristicIds { get; set; }


            public List<AppliedStatModViewModel> NewAppliedStatMods { get; set; }
            public List<SelectedArmorViewModel> NewSelectedArmor { get; set; }
            public List<SelectedWeaponViewModel> NewSelectedWeapons { get; set; }
            public List<SelectedItemViewModel> NewSelectedItems { get; set; }
            public List<SelectedSpellViewModel> NewSelectedSpells { get; set; }
            public List<SelectedTemplateViewModel> NewSelectedTemplates { get; set; }
            public List<SelectedCharacteristicViewModel> NewSelectedCharacteristics { get; set; }
            public List<WealthAdjustmentViewModel> NewWealthAdjustments { get; set; }
        }

        public class SearchCreaturesInput
        {
            //
        }
    }
}