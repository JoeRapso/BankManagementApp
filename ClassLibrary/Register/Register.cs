using BankManagementApp;
using ClassLibrary.User;
using ClassLibrary.User.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary.Register.Register
{
    public class Register : IRegister//, IUserDataChecker
    {
        public void RegisterCustomer(IDictionary<string,string> registrationDetails)
        {

            Customer customer = (Customer)Factory.CreateCustomer(); // di

            customer.Id = generateId();
            customer.AccountNumber = generateAccountNumber();
            customer.FirstName = registrationDetails["FirstName"];
            customer.LastName = registrationDetails["LastName"];
            customer.Email = registrationDetails["Email"];
            customer.Username = registrationDetails["Username"];
            customer.Password = registrationDetails["Password"];

            DataAccess.SaveCustomerDataToJson(customer);


        }

        public bool CheckData(Dictionary<string, string> customer)
        {
            //customer = (Customer)customer;
            var customers = DataAccess.GetCustomerDataFromJson();
            Customer selectedUser;//;= customers.Where(x => x.Username.Equals(customer["Username"])).FirstOrDefault();

            if (customer.ContainsKey("Username"))
            {
                selectedUser = customers.Where(x => x.Username.Equals(customer["Username"])).FirstOrDefault();

                if (selectedUser == null)
                {
                    return false;
                }

            }
            else if (customer.ContainsKey("Id"))
            {
                selectedUser = customers.Where(x => x.Id.Equals(customer["Id"])).FirstOrDefault();

                if (selectedUser == null)
                {
                    return false;
                }
            }
            else if (customer.ContainsKey("AccountNumber"))
            {
                selectedUser = customers.Where(x => x.AccountNumber.Equals(customer["AccountNumber"])).FirstOrDefault();

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

        private string generateId()
        {
            Random res = new Random();

            string str = "abcdefghijklmnopqrstuvwxyz0123456789";
            int size = 8;

            string randomstring = "";
            Dictionary<string, string> valuePairs = new Dictionary<string, string>(); // change name
            valuePairs.Add("Id", randomstring);

            bool doesIdExist;
            do
            {
                for (int i = 0; i < size; i++)
                {

                    int randomIndex = res.Next(str.Length);


                    randomstring = randomstring + str[randomIndex];
                }
                valuePairs["randomstring"] = randomstring;

                //var CheckDatasObj = new  { Id = randomstring}; //

                doesIdExist = CheckData(valuePairs);
                if (doesIdExist)
                {
                    randomstring = string.Empty;
                }
            } while (doesIdExist == true);
            return randomstring;
        }

        private string generateAccountNumber()
        {
            Random res = new Random();

            string str = "0123456789";
            int size = 8;

            string randomstring = "";
            Dictionary<string, string> valuePairs = new Dictionary<string, string>(); // change name
            valuePairs.Add("AcountNumber", randomstring);
            bool doesAccountExist;
            do
            {
                for (int i = 0; i < size; i++)
                {

                    int randomIndex = res.Next(str.Length);
                    randomstring = randomstring + str[randomIndex];
                }
                //valuePairs.Add("AcountNumber", randomstring);\
                valuePairs["AccountNumber"] = randomstring;
                doesAccountExist = CheckData(valuePairs);
                if (doesAccountExist)
                {
                    randomstring = string.Empty;
                }
            } while (doesAccountExist == true);

            return randomstring;
        }

        //public void saveData(Customer customer)
        //{
        //string fileName = "C:\\My Projects\\BankManagement\\BankManagementApp\\Data\\CustomerAccountData.json";
        //string jsonString = File.ReadAllText(fileName);
        //List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(jsonString);

        //customers.Add(customer);
        ////look at using the using keyword here
        //jsonString = JsonConvert.SerializeObject(customers, Formatting.Indented);
        //File.WriteAllText(fileName, jsonString);

        //string jsonString = JsonSerializer.Serialize(customer);

        //string fileName = "C:\\My Projects\\BankManagement\\BankManagementApp\\Data\\CustomerAccountData.json";
        //string jsonString = JsonConvert.SerializeObject(customer);
        //File.WriteAllText(fileName, jsonString);



        //}
    }
}
