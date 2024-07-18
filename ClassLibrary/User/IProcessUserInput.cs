using ClassLibrary.Models;
using ClassLibrary.Register.Register;

namespace ClassLibrary.User
{
    public interface IProcessUserInput
    {
        void getUserInput();
        void ValidateUserMenuInputChoice(MenuText  menuText);
        void GetRegistrationDetails(IUserDataChecker dataChecker);
        void GetAmount();
        Dictionary<string, string> GetLoginDetails(IUserDataChecker dataChecker);
    }
}