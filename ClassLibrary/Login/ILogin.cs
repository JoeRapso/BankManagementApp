using ClassLibrary.User;
using ClassLibrary.User.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Login.Login
{
    public interface ILogin //: IUserDataChecker
    {
        ClassLibrary.User.User.User LogInUser(IProcessUserInput userInputProcessor, IUserDataChecker dataChecker);
    }
}
