using System;
using TV___Step_4.Interfaces.Network;

namespace TV___Step_4.Models.Network
{
    public class Lan : INetwork
    {
        public string Ip { get; }
        public string Group { get; }
        private readonly string _password;

        public Lan(string ip, string group, string password)
        {
            Ip = string.IsNullOrEmpty(ip) ? throw new ArgumentException(nameof(ip)) : ip;
            Group = string.IsNullOrEmpty(group) ? throw new ArgumentException(nameof(group)) : group;
            _password = string.IsNullOrEmpty(password) ? throw new ArgumentException(nameof(password)) : password;
        }

        public void Connect()
        {
            // TODO: 
        }

        public bool Test()
        {
            // TODO:
            return true;
        }
    }
}
