using BankManagementApp;
using ClassLibrary.Login.Login;
using ClassLibrary.Menu;
using ClassLibrary.Register.Register;
using ClassLibrary.User;
using ClassLibrary.User.User;
using Microsoft.Extensions.Logging;
using System.Formats.Tar;
using System.Runtime.CompilerServices;

namespace BankManagementApp
{
    public interface IApp
    {
        void Run();
    }

    public class App : IApp
    {
        public void Run()
        {
            IRegister register = Factory.CreateRegistration();
            IUserDataChecker dataChecker = Factory.CreateDataChecker();

            var loggerFactory = (ILoggerFactory)new LoggerFactory();
            var logger = loggerFactory.CreateLogger<Text>();


            var text = Factory.CreateText(logger);

            var displayText = Factory.CreateDisplayText(text);

            bool userExited = false;
            while (!userExited)
            {
                bool userGoesBack = false;
                while (!userGoesBack)
                {
                    
                    string menuType = "welcomeMenu";
                    var menuText = displayText.ShowMenuText(menuType);
                    var inputGetter = Factory.CreateUserInputGetter();
                    var userInputValidator = Factory.CreateUserInputValidator();
                    var userInputProcessor = (ProcessUserInput)Factory.CreateUserInputProcessor(inputGetter, userInputValidator, displayText); //maybe not use casting?

                    userInputProcessor.getUserInput();

                    userInputProcessor.ValidateUserMenuInputChoice(menuText);
                    if (userInputProcessor.SelectedMenuOption == 1)
                    {
                        string registerMessage = "Please enter your details";
                        displayText.ShowText(registerMessage);
                        
                        userInputProcessor.GetRegistrationDetails(dataChecker);
                        register.RegisterCustomer(userInputProcessor.RegistrationDetails);

                        string registerSuccess = "Registration Succesful.";

                        displayText.ShowText(registerSuccess);
                    }
                    else if (userInputProcessor.SelectedMenuOption == 2)
                    {
                        string loginMessage = "Please enter your details";

                        displayText.ShowText(loginMessage);

                        ILogin login = Factory.CreateLogin();
                        
                        User user = login.LogInUser(userInputProcessor, dataChecker);


                        if (user.IsAdmin == false)
                        {
                            Customer customer = new Customer();
                            customer = (Customer)user;
                            bool customerHasNotExitedOrLoggedOut = false;
                            while (!customerHasNotExitedOrLoggedOut)
                            {
                                string loginMenu = "loginMenu";
                                var logingMenuText = displayText.ShowMenuText(loginMenu, user);
                                userInputProcessor.getUserInput();

                                userInputProcessor.ValidateUserMenuInputChoice(logingMenuText);

                                if (userInputProcessor.SelectedMenuOption == 1)
                                {
                                    string depositMsg = "Enter an amount you want to deposit.";
                                    displayText.ShowText(depositMsg);

                                    userInputProcessor.GetAmount();

                                    customer.Deposit(userInputProcessor.Amount);

                                    string depositSuccess = "Your money has been succesfully deposited.";
                                    displayText.ShowText(depositSuccess);

                                }
                                else if (userInputProcessor.SelectedMenuOption == 2)
                                {

                                    string withdraw = "Enter an amount you wish to withdraw.";
                                    displayText.ShowText(withdraw);

                                    userInputProcessor.GetAmount();

                                    customer.Withdraw(userInputProcessor.Amount);



                                    if (userInputProcessor.Amount != 0)
                                    {
                                        customer.Withdraw(userInputProcessor.Amount);
                                        displayText.ShowText("Your money has been succesfully withdrawn.");
                                    }
                                }
                                else if (userInputProcessor.SelectedMenuOption == 3)
                                {
                                    int amount = customer.DisplayBalance();
                                    displayText.ShowText($"You have ${amount} in your bank account");
                                }
                                else if (userInputProcessor.SelectedMenuOption == 4)
                                {
                                    customerHasNotExitedOrLoggedOut = true;
                                    userGoesBack = true;
                                }
                                else if (userInputProcessor.SelectedMenuOption == 5)
                                {
                                    customerHasNotExitedOrLoggedOut = true;
                                    userExited = true;
                                    return;
                                }
                            }
                        }
                        else 
                        if (user.IsAdmin == true)
                        {
                            Admin admin = new Admin();
                            admin = (Admin)user;
                            bool adminHasNotExitedOrLoggedOut = false;
                            while (!adminHasNotExitedOrLoggedOut)
                            {
                                string adminMenu = "adminMenu";
                                var adminMenuText = displayText.ShowMenuText(adminMenu, user);
                                userInputProcessor.getUserInput();

                                userInputProcessor.ValidateUserMenuInputChoice(adminMenuText);
                                if (userInputProcessor.SelectedMenuOption == 1)
                                {

                                }
                                else if (userInputProcessor.SelectedMenuOption == 2)
                                {

                                }
                                else if (userInputProcessor.SelectedMenuOption == 3)
                                {
                                    adminHasNotExitedOrLoggedOut = true;
                                    userGoesBack = true;
                                }
                                else if (userInputProcessor.SelectedMenuOption == 4)
                                {
                                    adminHasNotExitedOrLoggedOut = true;
                                    userExited = true;
                                    return;
                                }
                            }

                        }
                    }
                    else if (userInputProcessor.SelectedMenuOption == 3)
                    {
                        userExited = true;
                        return;
                    }
                }
            }
        }
    }
}
