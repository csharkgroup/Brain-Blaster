namespace Client.etc.Settings
{
    public class Map
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public int MaxPlayers { get; set; }

        public Map(int MaxX, int MaxY)
        {
            this.MaxX = MaxX;
            this.MaxY = MaxY;

            this.MaxPlayers = 4;
        }
    }
}
