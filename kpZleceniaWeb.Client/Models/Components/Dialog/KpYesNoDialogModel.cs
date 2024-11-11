namespace kpZleceniaWeb.Client.Models.Components.Dialog
{
    public class KPYesNoDialogModel
    {
        public KPYesNoDialogModel()
        {
            
        }

        public KPYesNoDialogModel(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}
