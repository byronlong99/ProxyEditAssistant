namespace WpfApp1
{
    public class Resolution
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public override string ToString()
        {
            return $"{Height}_{Width}";
        }
    }
}