using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                ValidateSide(value, nameof(Length));
                this.length = value;

            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                ValidateSide(value, nameof(Width));
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                ValidateSide(value, nameof(Height));
                this.height = value;
            }
        }
        public double CalculateSurfaceArea() => 2 * Length * Width +
            2 * Length * Height + 2 * Width * Height;
        public double CalculateLateralSurfaceArea() =>
            2 * Length * Height + 2 * Width * Height;
        public double CalculateVolume() => Length * Width * Height;

        private static void ValidateSide(double side, string paramName)
        {
            if (side <= 0)
            {
                throw new ArgumentException($"{paramName} cannot be zero or negative.");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Surface Area - {CalculateSurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {CalculateLateralSurfaceArea():F2}")
                .AppendLine($"Volume - {CalculateVolume():F2}");
            return sb.ToString().TrimEnd();

        }
    }
}
