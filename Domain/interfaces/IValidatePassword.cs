namespace Domain.interfaces
{
    public interface IValidatePassword
    {
        bool IsValid(string password);
    }
}