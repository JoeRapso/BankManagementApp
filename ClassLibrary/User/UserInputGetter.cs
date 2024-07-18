using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.User
{
    public class UserInputGetter : IUserInputGetter
    {
        private string?  _input;
        string IUserInputGetter.GetUserInput()
        {
            _input = Console.ReadLine();
            return _input;
        }
    }
}
