using MainApp.Factories;
using MainApp.Interfaces;
using MainApp.Models;

namespace MainApp.Services;

public class MenuService : IMenuDialogs
{   
    // I have to use dependency injection instead
    private readonly UserService _userService = new UserService();
    
    
    public void Show()
    {
        while (true)
        {
            MainMenu();
        }
    }

    private void MainMenu()
        { 
            Console.Clear();
            Console.WriteLine($"{"1.", -5} Create User");   
            Console.WriteLine($"{"2.", -5} View Users");
            Console.WriteLine($"{"Q.", -5} Quit Application");

            Console.WriteLine("--------------------------");
            Console.WriteLine("Choose your option; ");
            var option = Console.ReadLine()!;
           
            switch (option.ToLower())
            {
                case "q":
                    QuitOption();
                    break;
                case "1":
                    CreateOption();
                    break;
                case "2":
                    ViewOption();
                    break;
                default:
                    InvalidOption();
                    break;
            }
        }
    

        private void QuitOption()
        {
            Console.Clear();
            Console.WriteLine("Do you want to exit? (Y/N)");
            var option = Console.ReadLine()!;
            
            if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
            {
                Environment.Exit(0);
            }
        }

        private void CreateOption()
        {
            UserRegistrationForm userRegistrationForm = UserFactory.Create();
            Console.Clear();
            
            Console.Write("Enter your first name: )");
            userRegistrationForm.FirstName = Console.ReadLine()!;
            
            Console.Write("Enter your last name: )");
            userRegistrationForm.LastName = Console.ReadLine()!;

            Console.Write("Enter your email: )");
            userRegistrationForm.Email = Console.ReadLine()!;
            
            Console.Write("Enter your password: )");
            userRegistrationForm.Password = Console.ReadLine()!;
    
            bool result = _userService.Create(userRegistrationForm);

            OutputDialog(result ? "User was successfully created." : "User creation failed.");

            Console.ReadKey();
        }

        private void ViewOption()
        {
            Console.Clear();
            Console.ReadKey();
        }
        private void InvalidOption()
        {
            Console.Clear();
            Console.WriteLine("You must enter a valid option.");
            Console.ReadKey();
        }
        public void OutputDialog(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }
}