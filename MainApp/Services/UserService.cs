using MainApp.Factories;
using MainApp.Models;

namespace MainApp.Services;

public class UserService
{
    public void Create(UserRegistrationForm form)
    {
       UserEntity userEntity = UserFactory.Create(form);
    }

    public void Update()
    {
        
    }

    public void Delete()
    {
        
    }
}