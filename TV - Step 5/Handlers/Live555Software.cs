using System;
using TV___Step_5.Interfaces;
using TV___Step_5.Resources;
using Version = TV___Step_5.Models.Data.Version;

namespace TV___Step_5.Handlers
{
    public class Live555Software : ISoftware
    {
        private readonly IUserInteraction _userInteraction;

        public Live555Software(IUserInteraction userInteraction)
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

        public void Downgrade()
        {
            // TODO: do real downgrade
            // TODO: save downgraded version to state
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
