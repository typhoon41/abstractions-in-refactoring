using System;

namespace TV___Step_5.Models
{
    public class DataSource
    {
        public string Name { get; }

        public DataSource(string name)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentException(nameof(name)) : name;
        }

        public DataSource Clone()
        {
            return new DataSource(Name);
        }
    }
}
