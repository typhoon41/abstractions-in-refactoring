﻿namespace TV___Step_3.Models.Data
{
    public class Size
    {
        public ushort Width { get; }
        public ushort Height { get; }

        public Size(ushort width, ushort height)
        {
            Width = width;
            Height = height;
        }
    }
}
