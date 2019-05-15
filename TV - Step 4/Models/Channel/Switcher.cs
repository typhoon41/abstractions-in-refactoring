using System;
using System.Collections.Generic;
using TV___Step_4.Interfaces;
using TV___Step_4.Resources;

namespace TV___Step_4.Models.Channel
{
    public class Switcher : IChannelSwitcher, IParentalControl
    {
        public string Password { get; private set; } = string.Empty; //= "KeepAwayFromChildren!";

        public Channel Current { get; private set; }

        private readonly IList<Channel> _lockedChannels = new List<Channel>();
        private readonly IUserInteraction _userInteraction;

        public Switcher(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction ?? throw new ArgumentNullException(nameof(userInteraction));
        }

        public void TrySwitching(ushort channelNumber)
        {
            var newChannel = Channel.FromInput(channelNumber);

            if (newChannel == null)
            {
                return;
            }

            if (_lockedChannels.Contains(newChannel) && _userInteraction.PasswordPrompt() != Password)
            {
                _userInteraction.Notify(Labels.InvalidPassword);
                return;
            }

            Current = newChannel;
        }

        public void Next()
        {
            Current = Current.Next();
        }

        public void Previous()
        {
            Current = Current.Previous();
        }

        public void Set(string password)
        {
            Password = password;
        }

        public void Add(IEnumerable<Channel> channels)
        {
            foreach (var channel in channels)
            {
                _lockedChannels.Add(channel);
            }
        }

        public void Remove(Channel channel)
        {
            _lockedChannels.Remove(channel);
        }
    }
}
