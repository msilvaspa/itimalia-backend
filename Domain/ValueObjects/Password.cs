using System;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Password
    {
        private readonly string _password;

        public Password(string password)
        {
            if (!IsValid(password)) throw new Exception("invalid password");
        }
        
        private static bool IsValid(string password)
        {
            if (!Rule1(password)) return false;
            if (!Rule2(password)) return false;
            if (!Rule3(password)) return false;
            if (!Rule4(password)) return false;
            if (!Rule5(password)) return false;
            if (!Rule6(password)) return false;
            return true;
        }

        private static bool Rule1(string pwd) => new Regex(@".{9,}").IsMatch(pwd);
        private static bool Rule2(string pwd) => new Regex(@"\d").IsMatch(pwd);
        private static bool Rule3(string pwd) => new Regex(@"[a-z]").IsMatch(pwd);
        private static bool Rule4(string pwd) => new Regex(@"[A-Z]").IsMatch(pwd);
        private static bool Rule5(string pwd) => new Regex(@"[!@#$%^&*()-+]").IsMatch(pwd);
        private static bool Rule6(string pwd) => new Regex(@"(.)(.+)?\1").IsMatch(pwd);
    }
}