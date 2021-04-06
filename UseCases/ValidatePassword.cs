using System;
using Domain.interfaces;
using Domain.ValueObjects;

namespace UseCases
{
    public class ValidatePassword: IValidatePassword 
    {
        public bool IsValid(string password)
        {
            try
            {
                var pwd = new Password(password);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}