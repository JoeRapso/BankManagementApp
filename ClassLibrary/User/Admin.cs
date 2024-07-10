using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.User
{
    public class Admin : ClassLibrary.User.User.User, IAdminActions
    {
        public void DeleteCustomerAccount()
        {
            //throw new NotImplementedException();
        }

        public void ViewCustomerAccounts()
        {
            //throw new NotImplementedException();
        }
    }
}
