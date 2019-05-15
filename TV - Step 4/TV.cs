using System;
using System.Collections.Generic;
using TV___Step_4.Builders;
using TV___Step_4.Handlers;
using TV___Step_4.Interfaces;
using TV___Step_4.Interfaces.Network;
using TV___Step_4.Models;
using TV___Step_4.Models.Channel;
using TV___Step_4.Models.Data;
using TV___Step_4.Models.Language;
using TV___Step_4.Models.Network;
using TV___Step_4.Models.Picture;
using TV___Step_4.Models.Picture.Modes;
using TV___Step_4.Models.Subtitles;
using TV___Step_4.Models.Volume;

namespace TV___Step_4
{
    public class TV
    {
        public IChannelSwitcher ChannelSwitcher { get; set; } = new Switcher(new UserInteraction());

        public ITimeManager TimeManager { get; set; } = new TimeManager();

        public IPictureSettings PictureSettings { get; set; } = new PictureSettings();

        public IVolumeControl Volume { get; set; } = new VolumeControl(new Volume(15));

        public ISoftware Software { get; set; } = new Software(new UserInteraction());

        public Size Size = new Size(140, 90);

        public string SoftwareName = "Live555";

        public DataSource Source = new DataSource("HDMI");

        public bool AllowedRemoteControl { get; set; } = true;

        public bool AllowedAudioVideoShare { get; set; } = true;

        public SoundEqualizer Equalizer { get; set; } = new SoundEqualizer("Rock");

        public bool DynamicBassOn { get; set; } = true;

        public int ZoomLevel { get; set; } = 200;

        public INetworkManager NetworkManager { get; set; } = new NetworkManager(new Wireless("Nul Tien Public", "qwerty"));
        public UiLanguage SelectedLanguage { get; set; } = new UiLanguage("de");

        public ISubtitleSettings SubtitleSettings { get; set; } = new SubtitleSettingsBuilder().WithEnabled(true)
                                                                                               .WithSize(24)
                                                                                               .WithColor(new Color("red"))
                                                                                               .WithLanguage(new SubtitleLanguage("fr"))
                                                                                               .Build();
        public TV()
        {
            PictureSettings.Switch(new Sports());
            PictureSettings.SetBrightness(50);
            PictureSettings.SetSharpness(50);
            PictureSettings.SetContrast(50);

            ChannelSwitcher.TrySwitching(0);
            if (!(ChannelSwitcher is IParentalControl parentalControl))
            {
                throw new ApplicationException("Parental control is expected to be integrated within Channel Switcher!");
            }

            parentalControl.Add(new List<Channel> { new Channel(41), new Channel(69), new Channel(111) });
            const string lastPassword = "KeepAwayFromChildren";
            parentalControl.Set(lastPassword);
        }

        public void ResetToFactorySettings()
        {
            Volume = new VolumeControl(new Volume(15));
            ChannelSwitcher = new Switcher(new UserInteraction());
            ChannelSwitcher.TrySwitching(0);
            TimeManager = new TimeManager();
            Software = new Software(new UserInteraction());
            Source = new DataSource("VGA");
            AllowedRemoteControl = false;
            AllowedAudioVideoShare = false;
            Equalizer = new SoundEqualizer("Movie");
            DynamicBassOn = false;
            ZoomLevel = 100;
            NetworkManager = new NetworkManager(new None());
            SelectedLanguage = new UiLanguage("en");
            SubtitleSettings = new SubtitleSettingsBuilder().Build();
            PictureSettings = new PictureSettings();
        }
    }
}
