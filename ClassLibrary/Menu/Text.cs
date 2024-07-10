using ClassLibrary.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibrary.Menu
{
    public class Text : IText
    {
        private readonly ILogger _log;

        public Text(ILogger<Text> log)
        {
            _log = log;
        }

        MenuText IText.ShowMenuText(string menuType, ClassLibrary.User.User.User user)
        {
            MenuText menuText = LookUpMenuText(menuType);
            if(user == null)
            {
                Console.WriteLine(menuText.MenuTexts["preMenuText"]);
            }
            else
            {
                Console.WriteLine(menuText.MenuTexts["preMenuText"].Insert(5, $" {user.FirstName}"));
            }
            foreach (var menuOption in menuText.MenuOptions)
            {
                Console.WriteLine(menuOption);
            }
            Console.WriteLine(menuText.MenuTexts["afterMenuOptionsText"]);

            return menuText;
        }

        void IText.ShowText(string text)
        {
            Console.WriteLine(text);
        }

        private MenuText LookUpMenuText(string menuType)
        {

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            try
            {
                //var file = Path.Combine(Directory.GetCurrentDirectory(), "MenuText.json");

                //look to get the file path without hardcoding.
                List<MenuText> menuTextsets = JsonSerializer.Deserialize<List<MenuText>>(
                    File.ReadAllText(path: "C:\\My Projects\\BankManagementCopy\\BankManagement\\BankManagementApp\\Data\\MenuText.json"), options
                );

                MenuText? menuText = menuTextsets.Where(x => x.MenuType.Equals(menuType)).FirstOrDefault();

                if (menuText is null)
                {
                    throw new NullReferenceException(message: "The specified menuText was not found in the json file");
                }

                return menuText;
            }
            catch (Exception ex)
            {
                _log.LogError(message: "Error looking up the MenuText.json file", ex);  // may not be needed
                throw;
            }
        }


    }
}
