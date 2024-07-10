using ClassLibrary.Models;

namespace ClassLibrary.Menu
{
    public interface IDisplayText
    {
        MenuText ShowMenuText(string menuType, User.User.User? user = null);
        void ShowText(string text);
    }
}