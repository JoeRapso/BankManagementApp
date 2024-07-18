using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.User.User;
using ClassLibrary.User;
using BankManagementApp;

namespace ClassLibrary.Login.Login
{
    public class Login : ILogin
    {
        public User.User.User LogInUser(IProcessUserInput userInputProcessor, IUserDataChecker dataChecker)
        {
            Dictionary<string,string> loginDetails = userInputProcessor.GetLoginDetails(dataChecker);
            if (loginDetails["Admin"] == "no")
            {
                var customers = DataAccess.GetCustomerDataFromJson();
                var user = customers.Where(x => x.Username.Equals(loginDetails["Username"]) && x.Password.Equals(loginDetails["Password"])).FirstOrDefault();
                
                ClassLibrary.User.User.User customer = Factory.CreateCustomer();
                
                if (user != null)
                {
                    customer = user;
                    return customer;
                }
                
            }
            else
            {
                ClassLibrary.User.User.User admin = Factory.CreateAdmin();

                var admins = DataAccess.GetAdminDataFromJson();
                var user = admins.Where(x => x.Username.Equals(loginDetails["Username"]) && x.Password.Equals(loginDetails["Password"])).FirstOrDefault();

                if (user != null)
                {
                    admin = user;
                    return admin;
                }
                return admin;
            }
            return null;
        }
    }
}
