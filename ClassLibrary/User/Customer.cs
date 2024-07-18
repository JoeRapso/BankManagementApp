using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.User.User
{
    public class Customer : User, ICustomerActions
    {
        public string? AccountNumber;

        [JsonProperty]
        private int Balance = 0;
        public void Deposit(int amount)
        {
            var customers = DataAccess.GetCustomerDataFromJson();
            var user = customers.Where(x => x.Id.Equals(this.Id)).FirstOrDefault();
            user.Balance += amount;
            Balance += amount;

            DataAccess.UpdateCustomerJsonData(customers);
        }

        public void Withdraw(int amount)
        {
            var customers = DataAccess.GetCustomerDataFromJson();

            var user = customers.Where(x => x.Id.Equals(this.Id)).FirstOrDefault();
            user.Balance -= amount;
            Balance -= amount;

            DataAccess.UpdateCustomerJsonData(customers);

        }

        public int DisplayBalance()
        {
            var customers = DataAccess.GetCustomerDataFromJson();
            var user = customers.Where(x => x.Id.Equals(this.Id)).FirstOrDefault();
            Balance = user.Balance;
            return Balance;
        }
    }
}
