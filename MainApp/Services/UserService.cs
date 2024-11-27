using MainApp.Factories;
using MainApp.Helpers;
using MainApp.Models;

namespace MainApp.Services;

public class UserService
{
    public void Create(UserRegistrationForm form)
    {
       UserEntity userEntity = UserFactory.Create(form);
       userEntity.Id = UniqueIdentifierGenerator.GenerateUniqueId();
       userEntity.Password = SecurePasswordGenerator.Generate(form.Password);
    }
}