using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace TV___Step_5.Models.Language
{
    public class UiLanguage
    {
        public string Name { get; }

        public UiLanguage(string name)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentException(nameof(name)) : name;
            SetCulture();
        }

        private void SetCulture()
        {
            var cultureInfo = CultureInfo.GetCultures(CultureTypes.AllCultures)
                                         .FirstOrDefault(info => info.Name.Equals(Name, StringComparison.OrdinalIgnoreCase));
            Thread.CurrentThread.CurrentUICulture = cultureInfo ?? throw new ApplicationException("Language not supported!");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        }
    }
}
