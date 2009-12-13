namespace Serwer.etc.Settings
{
    public class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Field(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }
    }
}
