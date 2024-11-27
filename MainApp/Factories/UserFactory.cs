using MainApp.Helpers;
using MainApp.Models;

namespace MainApp.Factories;

public class UserFactory
{
    public static UserRegistrationForm Create()
    {
        return new UserRegistrationForm();
    }

    public static UserEntity Create(UserRegistrationForm form)
    {
        return new UserEntity()
        {
            //develop another way to manage password and Id in UserService
            Id = UniqueIdentifierGenerator.GenerateUniqueId(),
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            Password = SecurePasswordGenerator.Generate(form.Password),
        };
    }
    
    public static User Create(UserEntity entity)
    {
        return new User()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
        };
    }
}