using ClassLibrary.Models;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.Menu
{
    public interface IText
    {
        internal void ShowText(string text);
        internal MenuText ShowMenuText(string menuType, ClassLibrary.User.User.User? user = null);


        //internal MenuText LookUpMenuText(string menuType);

        //internal MenuText LookUpMenuText(string menuType);
    }
}