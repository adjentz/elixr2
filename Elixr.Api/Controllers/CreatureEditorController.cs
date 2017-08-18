using Elixr2.Api.Models;
using Elixr2.Api.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using Elixr2.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Elixr2.Api.Extensions;

namespace Elixr2.Api.Controllers
{
    public class CreatureEditorController
    {
        private readonly CreaturesService creaturesService;
        private readonly CampaignSettingsService settingsService;
        public CreatureEditorController(CreaturesService creaturesService, CampaignSettingsService settingsService)
        {
            this.creaturesService = creaturesService;
            this.settingsService = settingsService;
        }

        [HttpGet("~/creature-editor/view-model")]
        public async Task<CreatureEditorViewModel> GetViewModel()
        {
            var setting = await settingsService.GetCampaignSettingByCode(CampaignSetting.StandardCampaignSettingCode);
            var creature = new Creature
            {
                Age = string.Empty,
                CampaignSettingId = setting.Id,
                Description = string.Empty,
                Eyes = string.Empty,
                Gender = string.Empty,
                Hair = string.Empty,
                Height = string.Empty,
                Name = string.Empty,
                Skin = string.Empty,
                Weight = string.Empty
            };

            return new CreatureEditorViewModel
            {
                Creature = creature.ToViewModel(),
                Setting = setting.ToViewModel()
            };

        }
        [HttpGet("~/creature-editor/view-model/{creatureId}")]
        public async Task<CreatureEditorViewModel> GetViewModel(int creatureId)
        {
            var creature = await creaturesService.GetCreatureById(creatureId);
            var setting = await settingsService.GetCampaignSettingById(creature.CampaignSettingId);

            return new CreatureEditorViewModel
            {
                Creature = creature.ToViewModel(),
                Setting = setting.ToViewModel()
            };

        }

        public class CreatureEditorViewModel
        {
            public CreatureViewModel Creature { get; set; }
            public CampaignSettingViewModel Setting { get; set; }
        }
    }
}