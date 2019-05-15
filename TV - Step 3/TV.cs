using System;
using System.Collections.Generic;
using System.Linq;
using TV___Step_3.Builders;
using TV___Step_3.Handlers;
using TV___Step_3.Interfaces;
using TV___Step_3.Interfaces.Network;
using TV___Step_3.Models;
using TV___Step_3.Models.Channel;
using TV___Step_3.Models.Data;
using TV___Step_3.Models.Language;
using TV___Step_3.Models.Network;
using TV___Step_3.Models.Subtitles;
using TV___Step_3.Resources;
using Version = TV___Step_3.Models.Data.Version;

namespace TV___Step_3
{
    public class TV
    {
        public IChannelSwitcher ChannelSwitcher { get; set; } = new Switcher(new UserInteraction());

        public ITimeManager TimeManager { get; set; } = new TimeManager();

        public Size Size = new Size(140, 90);

        public string SoftwareName = "Live555";

        public Version SoftwareVersion { get; set; } = new Version(2, 4);

        public DataSource Source = new DataSource("HDMI");

        public DisplayMode WatchMode { get; set; } = new DisplayMode("Sports");

        public bool AllowedRemoteControl { get; set; } = true;

        public bool AllowedAudioVideoShare { get; set; } = true;

        public SoundEqualizer Equalizer { get; set; } = new SoundEqualizer("Rock");

        public bool DynamicBassOn { get; set; } = true;

        public int ZoomLevel { get; set; } = 200;

        public INetworkManager NetworkManager { get; set; } = new NetworkManager(new Wireless("Nul Tien Public", "qwerty"));
        public UiLanguage SelectedLanguage { get; set; } = new UiLanguage("de");
        private Volume _lastKnownVolume { get; set; } = new Volume(15);

        public Volume Volume { get; set; } = new Volume(15);

        public Percentage Brightness { get; set; } = new Percentage(50);

        public Percentage Sharpness { get; set; } = new Percentage(50);

        public Percentage Contrast { get; set; } = new Percentage(50);

        public ISubtitleSettings SubtitleSettings { get; set; } = new SubtitleSettingsBuilder().WithEnabled(true)
                                                                                               .WithSize(24)
                                                                                               .WithColor(new Color("red"))
                                                                                               .WithLanguage(new SubtitleLanguage("fr"))
                                                                                               .Build();
        public TV()
        {
            ChannelSwitcher.TrySwitching(0);
            if (!(ChannelSwitcher is IParentalControl parentalControl))
            {
                throw new ApplicationException("Parental control is expected to be integrated within Channel Switcher!");
            }

            parentalControl.Add(new List<Channel> { new Channel(41), new Channel(69), new Channel(111)});
            const string lastPassword = "KeepAwayFromChildren";
            parentalControl.Set(lastPassword);
        }

        public void SetSelectedLanguage(string language)
        {
            SelectedLanguage = new UiLanguage(language);
        }

        public void ChangeBrightness(int newBrightness)
        {
            Brightness = new Percentage(Convert.ToByte(newBrightness));
        }

        public void IncreaseVolume()
        {
            Volume = Volume.Increase();
        }

        public void DisplayMessageToUser(string message)
        {
            // TODO:
        }

        public void DecreaseVolume()
        {
            Volume = Volume.Decrease();
        }

        public void SwitchWatchingMode(string newMode)
        {
            if (newMode == "Movies")
            {
                if (Brightness > 50)
                {
                    Brightness = new Percentage(30);
                }

                if (Sharpness > 70)
                {
                    Sharpness = new Percentage(70);
                }
            }

            else if (newMode == "Nature")
            {
                if (Sharpness < 20)
                {
                    Sharpness = new Percentage(20);
                }

                if (Brightness < 40)
                {
                    Brightness = new Percentage(50);
                }
            }

            WatchMode = new DisplayMode(newMode);
        }

        public void ResetToFactorySettings()
        {
            ChannelSwitcher = new Switcher(new UserInteraction());
            ChannelSwitcher.TrySwitching(0);
            TimeManager = new TimeManager();
            SoftwareVersion = new Version(2, 1);
            Source = new DataSource("VGA");
            AllowedRemoteControl = false;
            AllowedAudioVideoShare = false;
            Equalizer = new SoundEqualizer("Movie");
            DynamicBassOn = false;
            ZoomLevel = 100;
            NetworkManager = new NetworkManager(new None());
            SelectedLanguage = new UiLanguage("en");
            _lastKnownVolume = new Volume(15);
            Volume = new Volume(15);
            Brightness = new Percentage(60);
            Sharpness = new Percentage(70);
            Contrast = new Percentage(40);
            SubtitleSettings = new SubtitleSettingsBuilder().Build();
            WatchMode = new DisplayMode("Nature");
        }

        public void UpgradeSoftware()
        {
            if (SoftwareVersion == "V.2.4.0")
            {
                DisplayMessageToUser(Labels.SoftwareUpToDate);
            }

            InitiateSoftwareUpgrade();
        }

        public void InitiateSoftwareUpgrade()
        {
            SoftwareVersion = new Version(2, 4);
        }

        public void Mute()
        {
            _lastKnownVolume = Volume.Clone();
            Volume = new Volume(0);
        }

        public void Unmute()
        {
            Volume = _lastKnownVolume.Clone();
        }
    }
}
