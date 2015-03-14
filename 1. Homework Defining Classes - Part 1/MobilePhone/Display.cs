using System;

namespace MobilePhone
{
    public class Display
    {
        public int Size
        {
            get;
            private set;
        }
        public int NumberOfColors
        {
            get;
            private set;
        }

        public Display(int size = 5, int colors = short.MaxValue)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Negative or zero display size");
            }
            this.Size = size;

            if (colors <= 0)
            {
                throw new ArgumentException("Negative or zero number of colors");
            }
            this.NumberOfColors = colors;
        }
    }
}