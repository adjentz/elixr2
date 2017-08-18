using System.Collections.Generic;
using Elixr2.Api.ViewModels;

namespace Elixr2.Api.InputModels
{
    public class UpdateCreatureInput
    {
        public List<int> DeletedAppliedStatMods { get; set; }
        public List<AppliedStatModViewModel> AppliedStatMods { get; set; }
        
    }
}