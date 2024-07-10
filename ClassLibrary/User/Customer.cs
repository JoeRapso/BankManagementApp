using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.User.User
{
    public class Customer : User, ICustomerActions  //, IAuthorisation
    {
        //[JsonProperty]
        public string? AccountNumber;

        [JsonProperty]
        private int Balance = 0;

        //private bool isAuthorised = false;

        //public bool isAuthorised = false;
        public void Deposit(int amount)
        {
            //Make a json data read/access class to decouple the data saving json way.
            //balance -= amount;
            //string fileName = "C:\\My Projects\\BankManagement\\BankManagementApp\\Data\\CustomerAccountData.json";
            //string jsonString = File.ReadAllText(fileName);
            var customers = DataAccess.GetCustomerDataFromJson();
            var user = customers.Where(x => x.Id.Equals(this.Id)).FirstOrDefault();
            user.Balance += amount;
            Balance += amount;
            DataAccess.UpdateCustomerJsonData(customers);

            //List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(jsonString);

            //customers.Add(customer);
            ////look at using the using keyword here



        }

        public void Withdraw(int amount)
        {
            //balance += amount;
            //string fileName = "C:\\My Projects\\BankManagement\\BankManagementApp\\Data\\CustomerAccountData.json";
            //string jsonString = File.ReadAllText(fileName);
            var customers = DataAccess.GetCustomerDataFromJson();

            var user = customers.Where(x => x.Id.Equals(this.Id)).FirstOrDefault();
            user.Balance -= amount;
            Balance -= amount;
            //if(user.Balance == 0)
            //{
            //    Balance = 0;
            //}

            DataAccess.UpdateCustomerJsonData(customers);

        }

        public int DisplayBalance()
        {

            var customers = DataAccess.GetCustomerDataFromJson();
            var user = customers.Where(x => x.Id.Equals(this.Id)).FirstOrDefault();
            Balance = user.Balance;
            return Balance;
        }

        //public bool Login()
        //{

        //    var customers = DataAccess.GetCustomerDataFromJson();
        //    var user = customers.Where(x => x.Username.Equals(this.Username) && x.Password.Equals(this.Password)).FirstOrDefault();

        //    if (user != null)
        //    {
        //        this.Id = user.Id;
        //        this.FirstName = user.FirstName;
        //        this.LastName = user.LastName;
        //        isAuthorised = true;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public void Authorisation(string username, string password)
        //{
        //    if (username == "user" && password == "test")
        //    {
        //        isAuthorised = true;
        //    }


        //}
    }
}
