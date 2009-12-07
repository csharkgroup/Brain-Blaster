namespace Settings
{
    class InetSetting
    {
        public const string Host = "127.0.0.1";
        public const int Port = 2610;
    }

    class PosSetting
    {
        public int[,] Pos { get; set; }
        private int _maxX, _maxY;

        public PosSetting(int maxX, int maxY)
        {
            this._maxX = maxX;
            this._maxY = maxY;

            Pos = new int[4, 2] { { 0, 0 }, { _maxX, 0 }, { 0, _maxY }, { _maxX, _maxY } };
        }
    }
}
