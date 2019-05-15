using System;
using TV___Step_4.Interfaces;
using TV___Step_4.Resources;
using Version = TV___Step_4.Models.Data.Version;

namespace TV___Step_4.Handlers
{
    public class Software : ISoftware
    {
        private readonly IUserInteraction _userInteraction;

        public Software(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction ?? throw new ArgumentNullException(nameof(userInteraction));
            Version = CurrentVersion();
        }

        public Version Version { get; private set; }

        public void Upgrade()
        {
            if (Version == LatestVersion())
            {
                _userInteraction.Notify(Labels.SoftwareUpToDate);
                return;
            }

            InitiateUpgrade();
        }

        private Version CurrentVersion()
        {
            // TODO: read it from somewhere
            return new Version(2, 1);
        }

        private Version LatestVersion()
        {
            // TODO: get it from some server
            return new Version(2, 4);
        }

        private void InitiateUpgrade()
        {
            // TODO: do real upgrade
            Version = LatestVersion();
        }
    }
}
