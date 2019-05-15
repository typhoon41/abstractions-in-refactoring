using System;
using System.Collections.Generic;

namespace TV
{
    public class TV
    {
        private List<int> _channelsLockedByParents = new List<int>() { 41, 69, 111 };

        private string ParentalPassword = "KeepAwayFromChildren!";

        public int Width { get; set; } = 140;

        public string SoftwareName = "Live555";

        public string SoftwareVersion = "V.2.4.0.0";

        public string Source = "HDMI";

        public string WatchMode = "Sports";

        public bool AllowedRemoteControl { get; set; } = true;

        public bool AllowedAudioVideoShare { get; set; } = true;

        public string Equalizer { get; set; } = "Rock";

        public bool DynamicBassOn { get; set; } = true;

        public int Height { get; set; } = 90;

        public DateTime DateTime { get; set; }

        private DateTime _realDateTime = DateTime.Now;

        public int ZoomLevel { get; set; } = 200;

        public string NetworkConnectionType { get; set; } = "wireless";

        public string NetworkName = "Nul Tien Public";
        public string NetworkPassword = "qwerty";

        public string SelectedLanguage { get; set; } = "de";
        private int _lastKnownVolume { get; set; } = 15;

        public int Volume { get; set; } = 15;

        public int Brightness { get; set; } = 50;

        public int Sharpness { get; set; } = 50;

        public int Contrast { get; set; } = 50;

        public int SelectedChannel { get; set; } = 0;

        public bool SubtitlesEnabled { get; set; } = true;

        public int SubtitlesSize { get; set; } = 24;

        public string SubtitlesColor { get; set; } = "red";

        public string SubtitlesLanguage { get; set; } = "fr";

        public void SetSelectedLanguage(string language)
        {
            SelectedLanguage = language;
        }

        public void ChangeChannel(int newChannel)
        {
            CheckIfChannelIsAllowedByParentalControl(newChannel);

            if (newChannel > 500 || newChannel < 0)
            {
                return;
            }

            SelectedChannel = newChannel;
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

        private void CheckIfChannelIsAllowedByParentalControl(int selectedChannel)
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
                string message;

                switch (SelectedLanguage)
                {
                    case "de":
                        message = "Passwort ist ungültig!";
                        break;
                    case "fr":
                        message = "Le mot de passe est invalide!";
                        break;
                    case "es":
                        message = "La contraseña no es valida";
                        break;
                    case "zh":
                        message = "密碼無效";
                        break;

                    default:
                        message = "Password is invalid!";
                        break;
                }

                throw new Exception(message);
            }
        }

        private string GetPasswordFromUser()
        {
            return "12345";
        }

        public void ChangeBrightness(int newBrightness)
        {
            if (newBrightness <= 100 && newBrightness >= 0)
            {
                Brightness = newBrightness;
            }
        }

        public void IncreaseChannel()
        {
            if (SelectedChannel == 500)
            {
                SelectedChannel = 0;
                return;
            }

            SelectedChannel++;
        }

        public void DecreaseChannel()
        {
            if (SelectedChannel == 0)
            {
                SelectedChannel = 500;
                return;
            }

            SelectedChannel--;
        }

        public void IncreaseVolume()
        {
            if (Volume < 100)
            {
                Volume++;
            }
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
            if (Volume > 0)
            {
                Volume--;
            }
        }

        public void SwitchWatchingMode(string newMode)
        {
            if (newMode == "Movies")
            {
                if (Brightness > 50)
                {
                    Brightness = 30;
                }

                if (Sharpness > 70)
                {
                    Sharpness = 70;
                }
            }

            else if (newMode == "Nature")
            {
                if (Sharpness < 20)
                {
                    Sharpness = 20;
                }

                if (Brightness < 40)
                {
                    Brightness = 50;
                }
            }

            WatchMode = newMode;
        }

        public void ResetToFactorySettings()
        {
            _channelsLockedByParents = new List<int>();
            ParentalPassword = string.Empty;
            SoftwareVersion = "V.2.1.0.0";
            Source = "VGA";
            AllowedRemoteControl = false;
            AllowedAudioVideoShare = false;
            Equalizer = "Movie";
            DynamicBassOn = false;
            DateTime = DateTime.Now;
            ZoomLevel = 100;
            NetworkConnectionType = "none";
            NetworkName = string.Empty;
            NetworkPassword = string.Empty;
            SelectedLanguage = "en";
            _lastKnownVolume = 15;
            Volume = 15;
            Brightness = 60;
            Sharpness = 70;
            Contrast = 40;
            SelectedChannel = 0;
            SubtitlesEnabled = false;
            SubtitlesSize = 36;
            SubtitlesColor = "white";
            SubtitlesLanguage = "en";
            WatchMode = "Nature";
        }

        public void UpgradeSoftware()
        {
            if (SoftwareVersion == "V.2.4.0.0")
            {
                string message;

                switch (SelectedLanguage)
                {
                    case "de":
                        message = "Die Software ist auf dem neuesten Stand!";
                        break;
                    case "fr":
                        message = "Le logiciel est à jour!";
                        break;
                    case "es":
                        message = "El software esta actualizado!";
                        break;
                    case "zh":
                        message = "軟件是最新的";
                        break;

                    default:
                        message = "Software is up to date!";
                        break;
                }

                DisplayMessageToUser(message);
            }

            InitiateSoftwareUpgrade();
        }

        public void InitiateSoftwareUpgrade()
        {
            SoftwareVersion = "V.2.4.0.0";
        }

        public void Mute()
        {
            _lastKnownVolume = Volume;
            Volume = 0;
        }

        public void Unmute()
        {
            Volume = _lastKnownVolume;
        }
    }
}
