using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.User.User
{
    public abstract class User//: IAuthorisation
    {
        public string? Id { get; set; }

        public bool IsAdmin { get; set; } = false;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //[EmailAddress(ErrorMessage = "The email address is not valid")]
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }


        //public bool Login()
        //{
        //    return false;
        //}



        //public virtual void Authorisation(string username, string password)
        //{
        //}
    }
}
