using System;
using System.Collections.Generic;
using TV___Step_5.Handlers;
using TV___Step_5.Interfaces;
using TV___Step_5.Models.Channel;
using TV___Step_5.Models.Data;
using TV___Step_5.Models.Volume;
using Settings = TV___Step_5.Models.Settings;

namespace TV___Step_5
{
    public class Philips55Pus670312 : TV
    {
        public override IChannelSwitcher ChannelSwitcher { get; } = new Switcher(new UserInteraction());
        public override Size Size => new Size(140, 90);
        public override IVolumeControl Volume { get; } = new VolumeControl(new Volume(15));
        public Settings Settings { get; private set; } = new Settings();
        public ISoftware Software { get; set; } = new Live555Software(new UserInteraction());

        public void RestoreState()
        {
            // TODO: Read last state from memory. State is a subset of all settings, so values are hard-coded just for demo.
            Volume.Restore(new Volume(15));
            ChannelSwitcher.TrySwitchingTo(0);

            if (!(ChannelSwitcher is IParentalControl parentalControl))
            {
                throw new ApplicationException("Parental control is expected to be integrated within Channel Switcher!");
            }

            parentalControl.Add(new List<Channel> { new Channel(41), new Channel(69), new Channel(111) });
            const string lastPassword = "KeepAwayFromChildren";
            parentalControl.Set(lastPassword);

            // TODO: It will already have changed state like (Brightness == 50, Subtitle of FR language etc.)
            var savedSettings = new Settings();
            Settings = savedSettings;
        }

        public override void ToFactorySettings()
        {
            Software.Downgrade();
            Settings.Reset();
            base.ToFactorySettings();
        }
    }
}
