namespace EAP.Xamarin.Core.Models
{
    public enum MenuItemType
    {
        Home,
        About
    }

    public class MainPageMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
