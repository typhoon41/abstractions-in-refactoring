using System;
using TV___Step_5.Interfaces.Network;

namespace TV___Step_5.Models.Network
{
    public class Manager : INetworkManager
    {
        private readonly INetwork _network;

        public Manager(INetwork network)
        {
            _network = network ?? throw new ArgumentNullException(nameof(network));
        }

        public void TryConnect()
        {
            if (_network.Test())
            {
                _network.Connect();
            }
        }
    }
}
