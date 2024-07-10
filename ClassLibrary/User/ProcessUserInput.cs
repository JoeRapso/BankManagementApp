﻿using BankManagementApp;
using ClassLibrary.Menu;
using ClassLibrary.Models;
using ClassLibrary.Register.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.User
{
    public class ProcessUserInput : IProcessUserInput
    {
        private readonly IUserInputValidator _userInputValidator;
        private readonly IUserInputGetter _inputGetter;
        private readonly IDisplayText _displayText;

        private string _userInput;
        private bool _isUserInputValid = false;

        public int SelectedMenuOption { get; set; }

        public int Amount { get; set; }

        public IDictionary<string, string> RegistrationDetails { get; set; } = new Dictionary<string, string>();

        //public int MenuOptions { get; set; }


        public ProcessUserInput(IUserInputGetter userInputGetter, IUserInputValidator userInputValidator, IDisplayText displayText)
        {
            _inputGetter = userInputGetter;
            _userInputValidator = userInputValidator;
            _displayText = displayText;
        }

        public void getUserInput()
        {
            _userInput = _inputGetter.GetUserInput();
        }

        public void ValidateUserMenuInputChoice(MenuText  menuText)
        {
            _isUserInputValid = _userInputValidator.ValidateUserMenuChoice(_userInput,  menuText.MenuOptions.Count);

            while (_isUserInputValid == false)
            {
                //MessagesToUser.WrongChoice();
                _displayText.ShowText("You have entered an invalid choice");
                _userInput = _inputGetter.GetUserInput();
                _isUserInputValid = _userInputValidator.ValidateUserMenuChoice(_userInput, menuText.MenuOptions.Count);

            }
            SelectedMenuOption = int.Parse(_userInput);
        }

        public void GetRegistrationDetails(IUserDataChecker dataChecker)
        {
            Console.WriteLine("First name:"); //Have this be done by other class?
            _userInput = _inputGetter.GetUserInput();
            _isUserInputValid = _userInputValidator.ValidateRegistrationOrLoginDetails(_userInput);
            //string firstName = Console.ReadLine();
            while (_isUserInputValid == false)
            {
                //MessagesToUser.InvalidRegistrationOrLoginDetails();
                _displayText.ShowText("You have entered something invalid, please try again. Do not enter something blank or too long that exceeds 50 characters."); // create the value differently?
                if (_isUserInputValid == false)
                {
                    Console.WriteLine("First name:");
                }
                _userInput = _inputGetter.GetUserInput();
                _isUserInputValid = _userInputValidator.ValidateRegistrationOrLoginDetails(_userInput);
            }
            RegistrationDetails.Add("FirstName", _userInput);

            Console.WriteLine("Last name:"); //Have this be done by other class?
            _userInput = _inputGetter.GetUserInput();
            _isUserInputValid = _userInputValidator.ValidateRegistrationOrLoginDetails(_userInput);
            //string firstName = Console.ReadLine();
            while (_isUserInputValid == false)
            {
                _displayText.ShowText("You have entered something invalid, please try again. Do not enter something blank or too long that exceeds 50 characters."); // create the value differently?
                if (_isUserInputValid == false)
                {
                    Console.WriteLine("Last name:");
                }
                _userInput = _inputGetter.GetUserInput();
                _isUserInputValid = _userInputValidator.ValidateRegistrationOrLoginDetails(_userInput);
            }
            RegistrationDetails.Add("LastName", _userInput);

            Console.WriteLine("Email"); // add extra email validation.
            _userInput = _inputGetter.GetUserInput();

            _isUserInputValid = _userInputValidator.ValidateRegistrationOrLoginDetails(_userInput);
            bool isEmailFormatValid = _userInputValidator.ValidateEmailFormat(_userInput);


            while (_isUserInputValid == false || isEmailFormatValid == false)
            {

                if (_isUserInputValid == false)
                {
                    _displayText.ShowText("You have entered something invalid, please try again. Do not enter something blank or too long that exceeds 50 characters."); // create the value differently?
                    Console.WriteLine("Email:");
                }
                else if (isEmailFormatValid == false)
                {
                    //MessagesToUser.InvalidEmailFormat();
                    _displayText.ShowText("Invalid email format, try again.");
                    Console.WriteLine("Email");
                }
                _userInput = _inputGetter.GetUserInput();
                _isUserInputValid = _userInputValidator.ValidateRegistrationOrLoginDetails(_userInput);
                isEmailFormatValid = _userInputValidator.ValidateEmailFormat(_userInput);
            }
            RegistrationDetails.Add("Email", _userInput);

            Console.WriteLine("Username:");
            string userName = _inputGetter.GetUserInput();
            bool isUserNameValid = _userInputValidator.ValidateRegistrationOrLoginDetails(userName);
            bool doesUsernameExist = dataChecker.CheckIfCustomerExists(userName);

            while (isUserNameValid == false || doesUsernameExist == true)
            {

                if (isUserNameValid == false)
                {
                    _displayText.ShowText("You have entered something invalid, please try again. Do not enter something blank or too long that exceeds 50 characters."); // create the value differently?
                    Console.WriteLine("Username:");
                }
                else if (doesUsernameExist == true)
                {
                    //MessagesToUser.UsernameExists();
                    _displayText.ShowText("Username already exists. Please try another.");
                    Console.WriteLine("Username:");
                }
                userName = _inputGetter.GetUserInput();
                isUserNameValid = _userInputValidator.ValidateRegistrationOrLoginDetails(userName);
                //valuePairs["Username"] = userName;
                doesUsernameExist = dataChecker.CheckIfCustomerExists(userName);
            }

            RegistrationDetails.Add("Username", userName);

            Console.WriteLine("Password:");
            string password = _inputGetter.GetUserInput();

            bool isPasswordValid = _userInputValidator.ValidateRegistrationOrLoginDetails(password);

            while (isPasswordValid == false)
            {
                _displayText.ShowText("You have entered something invalid, please try again. Do not enter something blank or too long that exceeds 50 characters."); // create the value differently?
                if (isPasswordValid == false)
                {
                    Console.WriteLine("Password:");
                }
                password = _inputGetter.GetUserInput();
                isPasswordValid = _userInputValidator.ValidateRegistrationOrLoginDetails(password);
            }
            RegistrationDetails.Add("Password", password);

            //register.RegisterCustomer(RegistrationDetails);

        }
        public void GetAmount()
        {
            _userInput = _inputGetter.GetUserInput();

            _isUserInputValid = _userInputValidator.ValidateInputAmount(_userInput);

            if( _isUserInputValid == true )
            {
                Amount = int.Parse(_userInput);
            }
            else 
            {

            }
        }

        public Dictionary<string, string> GetLoginDetails(IUserDataChecker dataChecker)
        {
            Dictionary<string, string> loginDetails = new Dictionary<string, string>();
            //IUserDataChecker dataChecker = Factory.CreateDataChecker();

            Console.WriteLine("Username:");
            string userName = _inputGetter.GetUserInput();

            //Dictionary<string, string> valuePairs = new Dictionary<string, string>();

            bool isUserNameValid = _userInputValidator.ValidateRegistrationOrLoginDetails(userName);
            //valuePairs.Add("Username", userName);
            loginDetails.Add("Username", userName);
            bool doesUsernameExist = dataChecker.CheckUsernamePassword(loginDetails);

            while (isUserNameValid == false || doesUsernameExist == false)
            {

                if (isUserNameValid == false)
                {
                    _displayText.ShowText("You have entered something invalid, please try again. Do not enter something blank or too long that exceeds 50 characters.");
                    Console.WriteLine("Username:");
                }
                else if (doesUsernameExist == false)
                {
                    _displayText.ShowText("Account not found. You have entered an invalid username. Please try again or register an account.");
                    Console.WriteLine("Username:");
                }
                userName = _inputGetter.GetUserInput();
                isUserNameValid = _userInputValidator.ValidateRegistrationOrLoginDetails(userName);
                //valuePairs["Username"] = userName;
                loginDetails["Username"] = userName;
                doesUsernameExist = dataChecker.CheckUsernamePassword(loginDetails);
            }

            //loginDetails.Add(userName);
            //loginDetails.Add("Username", userName);

            Console.WriteLine("Password:");
            string password = _inputGetter.GetUserInput();

            bool isPasswordValid = _userInputValidator.ValidateRegistrationOrLoginDetails(password);
            //valuePairs["Password"] = password;
            loginDetails.Add("Password", password);

            bool doesPasswordExist = dataChecker.CheckUsernamePassword(loginDetails);

            while (isPasswordValid == false || doesPasswordExist == false)
            {

                if (isUserNameValid == false)
                {
                    _displayText.ShowText("You have entered something invalid, please try again. Do not enter something blank or too long that exceeds 50 characters.");
                    Console.WriteLine("Password:");
                }
                else if (doesPasswordExist == false)
                {
                    _displayText.ShowText("Wrong password. Please try again.");
                    Console.WriteLine("Password:");
                }
                password = _inputGetter.GetUserInput();
                isUserNameValid = _userInputValidator.ValidateRegistrationOrLoginDetails(password);
                //valuePairs["Password"] = password;
                loginDetails["Password"] = password;
                doesPasswordExist = dataChecker.CheckUsernamePassword(loginDetails);
            }
            //loginDetails.Add("Password", password);
            bool isUserAdmin = dataChecker.IsAdmin(loginDetails["Username"], loginDetails["Password"]);

            if (isUserAdmin == false)
            {
                loginDetails.Add("Admin", "no");
            }
            else
            {
                loginDetails.Add("Admin", "yes");

            }

            return loginDetails;
        }

    }
}