
namespace RPM_7_library
{
    public interface IFigure 
    {
        double GetVolume();
        string GetInfo();
        static int Count { get; set; }
    }

    public class Parallelepiped : IFigure, IComparable, ICloneable
    {
        private int id;
        public int Length { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        static public int Count { get; set; }
        public int ID { get => id; set { } }

        public Parallelepiped()
        {
            id = Count + 1;
            Length = 2;
            Width = 2;
            Height = 2;
        }

        public Parallelepiped(int Length, int Width, int Height)
        {
            id = Count + 1;
            this.Length = Length;
            this.Width = Width;
            this.Height = Height;
        }

        public double GetVolume()
        {
            int volume = Length * Width * Height;
            return volume;
        }

        public string GetInfo()
        {
            string info = $"Параллелепипед: длина = {Length}, ширина = {Width}, высота = {Height}, объём = {GetVolume()}";
            return info;
        }

        public override string ToString()
        {
            return $"Параллелепипед{id}";
        }

        public int CompareTo(object obj)
        {
            IFigure temp = (IFigure)obj;
            if (this.GetVolume() > temp.GetVolume()) return 1;
            else if (this.GetVolume() < temp.GetVolume()) return -1;
            else return 0;
        }

        public object Clone()
        {
            Parallelepiped p = new Parallelepiped();
            p.Length = Length;
            p.Width = Width;
            p.Height = Height;
            return p;
        }

        public Parallelepiped ShallowClone()
        {
            return (Parallelepiped)this.MemberwiseClone();
        }
    }

    public class Ball : IFigure, IComparable, ICloneable
    {
        private int id;
        public int Radius { get; private set; }
        static public int Count { get; set; }
        public int ID { get => id; set { } }

        public Ball()
        {
            id = Count+1;
            Radius = 2;
        }

        public Ball(int Radius)
        {
            id = Count+1;
            this.Radius = Radius;
        }

        public void SetParams(int Radius)
        {
            this.Radius = Radius;
        }

        public double GetVolume()
        {
            double volume = Math.Round(4 * Math.PI * Math.Pow(Radius, 3) / 3, 3);
            return volume;
        }

        public string GetInfo()
        {
            string info = $"Шар: радиус = {Radius}, объём = {GetVolume()}";
            return info;
        }

        public override string ToString()
        {
            return $"Шар{id}";
        }

        public int CompareTo(object obj)
        {
            IFigure temp = (IFigure)obj;
            if (this.GetVolume() > temp.GetVolume()) return 1;
            else if (this.GetVolume() < temp.GetVolume()) return -1;
            else return 0;
        }

        public object Clone()
        {
            Ball b = new Ball();
            b.Radius = Radius;
            return b;
        }

        public Ball ShallowClone()
        {
            return (Ball)this.MemberwiseClone();
        }
    }
}
