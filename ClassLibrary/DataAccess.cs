using ClassLibrary.User;
using ClassLibrary.User.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary
{
    public static class DataAccess
    {
        public static void SaveCustomerDataToJson(Customer customer)
        {
            string fileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("bin", "Data") + "\\CustomerAccountData.json";//"C:\\My Projects\\BankManagementCopy\\BankManagement\\BankManagementApp\\Data\\CustomerAccountData.json";
            string jsonString = File.ReadAllText(fileName);
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(jsonString);

            customers.Add(customer);
            //look at using the using keyword here
            jsonString = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public static List<Customer> GetCustomerDataFromJson()
        {
            string fileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("bin", "Data") + "\\CustomerAccountData.json";////Application.start, +  @"\Data\CustomerAccountData.json");//"C:\\My Projects\\BankManagementCopy\\BankManagement\\BankManagementApp\\Data\\CustomerAccountData.json";
            string jsonString = File.ReadAllText(fileName);
            List<Customer> data = JsonConvert.DeserializeObject<List<Customer>>(jsonString);

            return data;

        }

        public static void UpdateCustomerJsonData(List<Customer> customers)
        {
            string fileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("bin", "Data") + "\\CustomerAccountData.json";
            string jsonString = File.ReadAllText(fileName);
            jsonString = JsonConvert.SerializeObject(customers, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public static List<Admin> GetAdminDataFromJson()
        {
            string fileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("bin", "Data") + "\\AdminAccountData.json";
            string jsonString = File.ReadAllText(fileName);
            List<Admin> data = JsonConvert.DeserializeObject<List<Admin>>(jsonString);

            return data;

        }
    }
}
