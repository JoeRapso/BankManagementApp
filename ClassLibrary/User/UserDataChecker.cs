using ClassLibrary.User.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.User
{
    public class UserDataChecker : IUserDataChecker
    {
        public bool CheckBalance(string id, int amount)
        {
            var customers = DataAccess.GetCustomerDataFromJson();
            Customer selectedUser = customers.Where(x => x.Id.Equals(id)).FirstOrDefault();

            if (selectedUser.DisplayBalance() == 0 || selectedUser.DisplayBalance() - amount < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckIfCustomerExists(string username, string id, string accountNumber)
        {
            var customers = DataAccess.GetCustomerDataFromJson();
            Customer selectedUser;//;= customers.Where(x => x.Username.Equals(customer["Username"])).FirstOrDefault();

            if (username != null)
            {
                selectedUser = customers.Where(x => x.Username.Equals(username)).FirstOrDefault();

                if (selectedUser == null)
                {
                    return false;
                }

            }
            else if (id != null)
            {
                selectedUser = customers.Where(x => x.Id.Equals(id)).FirstOrDefault();

                if (selectedUser == null)
                {
                    return false;
                }
            }
            else if (accountNumber != null)
            {
                selectedUser = customers.Where(x => x.AccountNumber.Equals(accountNumber)).FirstOrDefault();

                if (selectedUser == null)
                {
                    return false;
                }
            }
            //var user = customers.Where(x => x.Username.Equals(customer["Username"]) || x.Id.Equals(customer["Id"]) || x.AccountNumber.Equals(customer["accountNumber"])).FirstOrDefault();
            //string? customerId = customers.Where(x => x.Id.Equals(input)).FirstOrDefault();


            //if (selectedUser == null) 
            //{
            //    return false;
            //}

            return true;
        }

        public bool CheckUsernamePassword(Dictionary<string, string> user)
        {
            var customers = DataAccess.GetCustomerDataFromJson();
            var admins = DataAccess.GetAdminDataFromJson();
            Admin selectedAdmin = admins.Where(x => x.Username.Equals(user["Username"])).FirstOrDefault();
            Customer selectedCustomer = customers.Where(x => x.Username.Equals(user["Username"])).FirstOrDefault();

            if (user.ContainsKey("Password"))
            {
                selectedCustomer = customers.Where(x => x.Username.Equals(user["Username"]) && x.Password.Equals(user["Password"])).FirstOrDefault();
                selectedAdmin = admins.Where(x => x.Username.Equals(user["Username"]) && x.Password.Equals(user["Password"])).FirstOrDefault();

            }


            if (selectedCustomer == null && selectedAdmin == null)
            {
                return false;
            }

            return true;
        }

        public bool IsAdmin(string username, string password)
        {
            var admins = DataAccess.GetAdminDataFromJson();
            Admin selectedAdmin = admins.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();

            if(selectedAdmin == null)
            {
                return false;
            }
            return true;
        }
    }
}
