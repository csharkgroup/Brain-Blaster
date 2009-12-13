namespace Serwer.etc.Settings
{
    public class Position
    {
        public int[,] Pos { get; set; }
        private int _maxX, _maxY;

        public Position(int maxX, int maxY)
        {
            this._maxX = maxX;
            this._maxY = maxY;

            Pos = new int[4, 2] { { 0, 0 }, { _maxX, 0 }, { 0, _maxY }, { _maxX, _maxY } };
        }
    }
}
