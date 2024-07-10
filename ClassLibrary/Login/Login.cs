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
    public class Login : ILogin//, IUserDataChecker
    {


        //public bool Authorisation(string username, string password)
        //{
        //    //throw new NotImplementedException();

        //    //string fileName = "C:\\My Projects\\BankManagement\\BankManagementApp\\Data\\CustomerAccountData.json";
        //    //string jsonString = File.ReadAllText(fileName);
        //    var data = DataAccess.GetCustomerDataFromJson();
        //    var user = data.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();

        //    if (user != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //    //MessagesToUser.WrongUsernameOrPassword();
        //    //string usernameFromJson = data["Username"].Value<string>();
        //}
        //public bool LogInUser(ClassLibrary.User.User.User customer)
        //{
        //    //do validation here
        //    var customers = DataAccess.GetCustomerDataFromJson();
        //    var user = customers.Where(x => x.Username.Equals(customer.Username) && x.Password.Equals(customer.Password)).FirstOrDefault();

        //    if (user != null)
        //    {
        //        customer.Id = user.Id;
        //        customer.FirstName = user.FirstName;
        //        customer.LastName = user.LastName;
        //        //isAuthorised = true;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool CheckData(Dictionary<string, string> user)
        //{
        //    var customers = DataAccess.GetCustomerDataFromJson();
        //    Customer selectedUser = customers.Where(x => x.Username.Equals(user["Username"])).FirstOrDefault();

        //    if (user.ContainsKey("Password"))
        //    {
        //        selectedUser = customers.Where(x => x.Username.Equals(user["Username"]) && x.Password.Equals(user["Password"])).FirstOrDefault();

        //    }


        //    if (selectedUser == null)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

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

                //ClassLibrary.User.User.User admin = Factory.CreateAdmin();

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
