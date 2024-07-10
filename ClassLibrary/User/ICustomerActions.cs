using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.User.User
{
    public interface ICustomerActions
    {
        void Deposit(int amount);

        void Withdraw(int amount);

        int DisplayBalance();
    }
}
