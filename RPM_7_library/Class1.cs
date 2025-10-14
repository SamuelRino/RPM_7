
namespace RPM_7_library
{
    public interface IFigure 
    {
        double GetVolume();
        string GetInfo();
    }

    public class Parallelepiped : IFigure, IComparable, ICloneable
    {
        public int Length { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Parallelepiped()
        {
            Length = 2;
            Width = 2;
            Height = 2;
        }

        public Parallelepiped(int Length, int Width, int Height)
        {
            this.Length = Length;
            this.Width = Width;
            this.Height = Height;
        }

        public void SetParams(int Length, int Width, int Height)
        {
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
            string info = $"��������������: ����� = {Length}, ������ = {Width}, ������ = {Height}, ����� = {GetVolume()}";
            return info;
        }

        public override string ToString()
        {
            return GetInfo();
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
        public int Radius { get; private set; }

        public Ball()
        {
            Radius = 2;
        }

        public Ball(int Radius)
        {
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
            string info = $"���: ������ = {Radius}, ����� = {GetVolume()}";
            return info;
        }

        public override string ToString()
        {
            return GetInfo();
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
            b.Radius = Radius;
            return b;
        }

        public Ball ShallowClone()
        {
            return (Ball)this.MemberwiseClone();
        }
    }
}
