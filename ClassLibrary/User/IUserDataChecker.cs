using ClassLibrary.User.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.User
{
    public interface IUserDataChecker
    {
        bool CheckBalance(string id, int amount);
        bool CheckUsernamePassword(Dictionary<string,string> usernamePassword);
        bool IsAdmin(string username, string password);
        bool CheckIfCustomerExists(string? username = null, string? id = null, string? accountNumber = null);

    }
}
