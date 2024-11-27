using MainApp.Interfaces;
using MainApp.Models;

namespace MainApp.Services;

public class MenuDialogs : IMenuDialogs
{
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
                    CreatOption();
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

        private void CreatOption()
        {
            var userRegistrationForm = new UserRegistrationForm();
            Console.Clear();
            
            Console.WriteLine("Enter your first name: )");
            userRegistrationForm.FirstName = Console.ReadLine();
            
            Console.WriteLine("Enter your last name: )");
            userRegistrationForm.LastName = Console.ReadLine();

            Console.WriteLine("Enter your email: )");
            userRegistrationForm.Email = Console.ReadLine();
            
            Console.WriteLine("Enter your password: )");
            userRegistrationForm.Password = Console.ReadLine();

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
}