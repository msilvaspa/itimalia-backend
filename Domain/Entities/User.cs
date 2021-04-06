using Domain.ValueObjects;

namespace Domain.Entities
{
    public class User
    {
        private Password _password;
        public User(Password password)
        {
            _password = password;
        }
    }
}