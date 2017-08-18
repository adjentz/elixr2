using System.Collections.Generic;
using Elixr2.Api.Models;

namespace Elixr2.Api.ViewModels
{
    public class SelectedCharacteristicViewModel
    {
        public int SelectedCharacteristicId { get; set; }
        public long TakenAtMS { get; set; }
        public int TakenAtLevel { get; set; }
        public CharacteristicViewModel Characteristic { get; set; }
        public bool IsTemplateCharacteristic { get; set; }
        public string Notes { get; set; }
    }
}