using System.Diagnostics;
using MainApp.Factories;
using MainApp.Helpers;
using MainApp.Models;

namespace MainApp.Services;

public class UserService
{
    private readonly List<UserEntity> _users = [];
    public bool Create(UserRegistrationForm form)
    {
        try
        {
            UserEntity userEntity = UserFactory.Create(form);

            _users.Add(userEntity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public void ClearList()
    {
        _users.Clear();
    }

    public IEnumerable<User> GetAll()
    {
       /*
            var list = new List<User>();
            foreach (var userEntity in _users)
            list.Add(UserFactory.Create(userEntity));
            return list;
        */
       
       return _users.Select(UserFactory.Create);
    }
}