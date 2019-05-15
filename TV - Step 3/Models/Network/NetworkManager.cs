using System;
using TV___Step_3.Interfaces.Network;

namespace TV___Step_3.Models.Network
{
    public class NetworkManager : INetworkManager
    {
        private readonly INetwork _network;

        public NetworkManager(INetwork network)
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
