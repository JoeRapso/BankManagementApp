using ClassLibrary.User;
using ClassLibrary.User.User;

namespace ClassLibrary.Register.Register
{
    public interface IRegister
    {
        void RegisterCustomer(IDictionary<string,string> registrationDetails);
    }
}