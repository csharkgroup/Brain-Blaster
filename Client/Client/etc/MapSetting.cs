namespace Client.etc.Settings
{
    public class Map
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public int MaxPlayers { get; set; }

        public double Rate { get; set; }

        public Map(int MaxX, int MaxY, double Rate)
        {
            this.MaxX = MaxX;
            this.MaxY = MaxY;
            this.Rate = Rate;

            this.MaxPlayers = 4;
        }
    }
}
