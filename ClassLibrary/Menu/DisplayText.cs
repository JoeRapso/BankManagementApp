using ClassLibrary.Models;
using ClassLibrary.User.User;
using Microsoft.Extensions.Logging;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibrary.Menu
{
    public class DisplayText : IDisplayText
    {
        private readonly IText _text;
        //private readonly ILogger _log;

        //public List<string> Texts { get; set; }

        public DisplayText(IText text)
        {
            //_log = log;
            _text = text;
        }

        public void ShowText(string text)
        {
            _text.ShowText(text);
        }

        public MenuText ShowMenuText(string menuType, ClassLibrary.User.User.User? user = null)
        {
            //MenuText menuText = LookUpMenuText(menuType);
            MenuText menuText = _text.ShowMenuText(menuType, user);

            return menuText;
        }


    }
}
