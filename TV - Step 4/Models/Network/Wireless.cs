using System;
using TV___Step_4.Interfaces.Network;

namespace TV___Step_4.Models.Network
{
    public class Wireless : INetwork
    {
        public string Name { get; }
        private readonly string _password;

        public Wireless(string name, string password)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentException(nameof(name)) : name;
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
