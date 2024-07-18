using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.User
{
    public interface IUserInputValidator
    {
        internal bool ValidateUserMenuChoice(string input, int numberOfMenuOptions);
        internal bool ValidateRegistrationOrLoginDetails(string input);
        internal bool ValidateEmailFormat(string input);
        internal bool ValidateInputAmount(string input);
    }
}
