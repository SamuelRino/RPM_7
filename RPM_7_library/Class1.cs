
namespace RPM_7_library
{
    interface IFigure 
    {
        double GetVolume();
        string GetInfo();
    }

    class Parallelepiped : IFigure, IComparable, ICloneable
    {
        int length;
        int width;
        int height;

        public Parallelepiped()
        {
            length = 2;
            width = 2;
            height = 2;
        }

        public Parallelepiped(int length, int width, int height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public void SetParams(int length, int width, int height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public double GetVolume()
        {
            int volume = length * width * height;
            return volume;
        }

        public string GetInfo()
        {
            string info = $"Параллелепипед: длина = {length}, ширина = {width}, высота = {height}, объём = {GetVolume()}";
            return info;
        }

        public int CompareTo(object obj)
        {
            Parallelepiped temp = (Parallelepiped)obj;
            if (this.GetVolume() > temp.GetVolume()) return 1;
            else if (this.GetVolume() < temp.GetVolume()) return -1;
            else return 0;
        }

        public object Clone()
        {
            Parallelepiped p = new Parallelepiped();
            p.length = length;
            p.width = width;
            p.height = height;
            return p;
        }

        public Parallelepiped ShallowClone()
        {
            return (Parallelepiped)this.MemberwiseClone();
        }
    }

    class Ball : IFigure, IComparable, ICloneable
    {
        int radius;

        public Ball()
        {
            radius = 2;
        }

        public Ball(int radius)
        {
            this.radius = radius;
        }

        public void SetParams(int radius)
        {
            this.radius = radius;
        }

        public double GetVolume()
        {
            double volume = Math.Round(4 * Math.PI * Math.Pow(radius, 3) / 3, 3);
            return volume;
        }

        public string GetInfo()
        {
            string info = $"Шар: радиус = {radius}, объём = {GetVolume()}";
            return info;
        }

        public int CompareTo(object obj)
        {
            Ball temp = (Ball)obj;
            if (this.GetVolume() > temp.GetVolume()) return 1;
            else if (this.GetVolume() < temp.GetVolume()) return -1;
            else return 0;
        }

        public object Clone()
        {
            Ball b = new Ball();
            b.radius = radius;
            return b;
        }

        public Ball ShallowClone()
        {
            return (Ball)this.MemberwiseClone();
        }
    }
}
