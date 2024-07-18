using ClassLibrary.Login.Login;
using ClassLibrary.Menu;
using ClassLibrary.Register.Register;
using ClassLibrary.User;
using ClassLibrary.User.User;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementApp
{
    public static class Factory
    {
        public static IRegister CreateRegistration()
        {
            return new Register();
        }

        public static User CreateCustomer()
        {
            return new Customer();
        }

        public static User CreateAdmin()
        {
            return new Admin();
        }

        public static ILogin CreateLogin()
        {
            return new Login();
        }

        public static IUserDataChecker CreateDataChecker()
        {
            return new UserDataChecker();
        }

        public static IText CreateText(ILogger<Text> logger)
        {
            return new Text(logger);
        }

        public static IDisplayText CreateDisplayText(IText text) 
        {
            return new DisplayText(text);
        }

        public static IUserInputGetter CreateUserInputGetter()
        {
            return new UserInputGetter();
        }

        public static IUserInputValidator CreateUserInputValidator()
        {
            return new UserInputValidator();
        }

        public static IProcessUserInput CreateUserInputProcessor(IUserInputGetter userInputGetter, IUserInputValidator userInputValidator, IDisplayText displayText)
        {
            return new ProcessUserInput(userInputGetter, userInputValidator, displayText);
        }
    }
}
