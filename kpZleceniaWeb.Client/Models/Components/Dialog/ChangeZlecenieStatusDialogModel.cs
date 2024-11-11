using kpZleceniaWeb.Shared.Common;

namespace kpZleceniaWeb.Client.Models.Components.Dialog
{
    public class ChangeZlecenieStatusDialogModel
    {
        public ChangeZlecenieStatusDialogModel()
        {
            ItemList = new();
        }

        public List<pAppComboDto> ItemList {  get; set; }
        public int CurrentZlecenieStausId { get; set; }
    }
}
