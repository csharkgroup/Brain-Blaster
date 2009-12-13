using Client.etc.Settings;

namespace Client.etc
{

    public sealed class Setting
    {

        public static Map Map { get; set; }
        public static Position Position { get; set; }
        public static Net Net { get; set; }
        public static Field Field { get; set; }

        static Setting instance = null;
        static readonly object padlock = new object();

        static Setting()
        {
            Map = new Map(33, 18);
            Position = new Position(Map.MaxX, Map.MaxY);
            Net = new Net("127.0.0.1", 2610);
            Field = new Field(20, 20);

        }

        Setting()
        {
        }

        public static Setting Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Setting();
                    }
                    return instance;
                }
            }
        }

        public static void Export(string FileDest)
        {
        }

        public static void Import(string FileSrc)
        {
        }
    }

}
