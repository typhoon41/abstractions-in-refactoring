using System;
using System.Collections.Generic;
using System.Linq;
using TV___Step_2.Builders;
using TV___Step_2.Interfaces;
using TV___Step_2.Models;
using TV___Step_2.Models.Data;
using TV___Step_2.Models.Language;
using TV___Step_2.Models.Subtitles;
using TV___Step_2.Resources;
using Version = TV___Step_2.Models.Data.Version;

namespace TV___Step_2
{
    public class TV
    {
        private IEnumerable<Channel> _channelsLockedByParents = new List<Channel> { new Channel(41), new Channel(69), new Channel(111) };

        private string ParentalPassword = "KeepAwayFromChildren!";

        public Size Size = new Size(140, 90);

        public string SoftwareName = "Live555";

        public Version SoftwareVersion { get; set; } = new Version(2, 4);

        public DataSource Source = new DataSource("HDMI");

        public DisplayMode WatchMode { get; set; } = new DisplayMode("Sports");

        public bool AllowedRemoteControl { get; set; } = true;

        public bool AllowedAudioVideoShare { get; set; } = true;

        public SoundEqualizer Equalizer { get; set; } = new SoundEqualizer("Rock");

        public bool DynamicBassOn { get; set; } = true;

        public DateTime DateTime { get; set; }

        private DateTime _realDateTime = DateTime.Now;

        public int ZoomLevel { get; set; } = 200;

        public string NetworkConnectionType { get; set; } = "wireless";

        public string NetworkName = "Nul Tien Public";
        public string NetworkPassword = "qwerty";

        public UiLanguage SelectedLanguage { get; set; } = new UiLanguage("de");
        private Volume _lastKnownVolume { get; set; } = new Volume(15);

        public Volume Volume { get; set; } = new Volume(15);

        public Percentage Brightness { get; set; } = new Percentage(50);

        public Percentage Sharpness { get; set; } = new Percentage(50);

        public Percentage Contrast { get; set; } = new Percentage(50);

        public Channel SelectedChannel { get; set; } = new Channel(0);

        public ISubtitleSettings SubtitleSettings { get; set; } = new SubtitleSettingsBuilder().WithEnabled(true)
                                                                                               .WithSize(24)
                                                                                               .WithColor(new Color("red"))
                                                                                               .WithLanguage(new SubtitleLanguage("fr"))
                                                                                               .Build();
        public void SetSelectedLanguage(string language)
        {
            SelectedLanguage = new UiLanguage(language);
        }

        public void ChangeChannel(int newChannel)
        {
            CheckIfChannelIsAllowedByParentalControl(new Channel(newChannel));

            if (newChannel > 500 || newChannel < 0)
            {
                return;
            }

            SelectedChannel = new Channel(newChannel);
        }

        public void SetDateTime(DateTime dateTime)
        {
            _realDateTime = DateTime.Now;
            DateTime = dateTime;
        }

        public DateTime GetDateTime()
        {
            var now = DateTime.Now;
            var difference = now - _realDateTime;

            return DateTime.Add(difference);
        }

        private void CheckIfChannelIsAllowedByParentalControl(Channel selectedChannel)
        {
            if (_channelsLockedByParents.Contains(selectedChannel))
            {
                PromptUserForParentalPassword();
            }
        }

        private void PromptUserForParentalPassword()
        {
            var passwordFromUser = GetPasswordFromUser();

            if (passwordFromUser != ParentalPassword)
            {
                throw new Exception(Labels.InvalidPassword);
            }
        }

        private string GetPasswordFromUser()
        {
            // TODO: 
            return "12345";
        }

        public void ChangeBrightness(int newBrightness)
        {
            Brightness = new Percentage(Convert.ToByte(newBrightness));
        }

        public void IncreaseChannel()
        {
            SelectedChannel = SelectedChannel.Next();
        }

        public void DecreaseChannel()
        {
            SelectedChannel = SelectedChannel.Previous();
        }

        public void IncreaseVolume()
        {
            Volume = Volume.Increase();
        }

        public void SwitchToSomeOtherWirelessNetwork(string network, string password)
        {
            if (TestNetworkConnection(network, password))
            {
                NetworkName = network;
                NetworkPassword = password;
                ConnectToNetwork();
            }
        }

        private bool TestNetworkConnection(string network, string password)
        {
            return true;
        }

        private void ConnectToNetwork()
        {
            if (NetworkConnectionType == "wireless")
            {
                ConnectToWireless();
            }

            else if (NetworkConnectionType == "LAN")
            {
                ConnectToLAN();
            }
        }

        private void ConnectToWireless()
        {

        }

        private void ConnectToLAN()
        {

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
            _channelsLockedByParents = new List<Channel>();
            ParentalPassword = string.Empty;
            SoftwareVersion = new Version(2, 1);
            Source = new DataSource("VGA");
            AllowedRemoteControl = false;
            AllowedAudioVideoShare = false;
            Equalizer = new SoundEqualizer("Movie");
            DynamicBassOn = false;
            DateTime = DateTime.Now;
            ZoomLevel = 100;
            NetworkConnectionType = "none";
            NetworkName = string.Empty;
            NetworkPassword = string.Empty;
            SelectedLanguage = new UiLanguage("en");
            _lastKnownVolume = new Volume(15);
            Volume = new Volume(15);
            Brightness = new Percentage(60);
            Sharpness = new Percentage(70);
            Contrast = new Percentage(40);
            SelectedChannel = new Channel(0);
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
