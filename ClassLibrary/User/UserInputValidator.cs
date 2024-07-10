using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.User
{
    public class UserInputValidator : IUserInputValidator
    {
        bool IUserInputValidator.ValidateRegistrationOrLoginDetails(string input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    return false;
                }
                else if (input.Length > 50)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        bool IUserInputValidator.ValidateUserMenuChoice(string input, int numberOfMenuOptions)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    return false;
                }
                else if (int.Parse(input) < 1)
                {
                    return false;
                }
                else if (int.Parse(input) > numberOfMenuOptions)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }



            return true;
        }

        bool IUserInputValidator.ValidateEmailFormat(string input)
        {
            bool validFormat = false;
            int stringSplitCount = input.Split('@').Length;

            if (stringSplitCount > 1 && stringSplitCount <= 2)
            {
                stringSplitCount = input.Split('.').Length;

                if (stringSplitCount > 1)
                    validFormat = true;
            }

            return validFormat;
        }

        bool IUserInputValidator.ValidateInputAmount(string amount)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(amount))
                {
                    return false;
                }
                else if (int.Parse(amount) > 100000 || int.Parse(amount) <= 0)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

    }
}
