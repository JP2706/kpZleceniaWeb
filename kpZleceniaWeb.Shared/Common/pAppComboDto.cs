namespace kpZleceniaWeb.Shared.Common
{
    public class pAppComboDto
    {
        public IDictionary<string, object> Property { get; set; }

        public pAppComboDto(IDictionary<string, object> property)
        {
            Property = property;
        }

        public pAppComboDto()
        {
        }
    }
}
