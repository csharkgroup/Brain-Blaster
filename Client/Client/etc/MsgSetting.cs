namespace Client.etc
{
    //To jest do wywalenia
    //mam inna lepsza wizje komunikacji
    //Ta i teraz juz nie mam pojêcia jaka on by³a :/
    public abstract class Msg
    {
        public const string Prefix = "###__";

        public const string Move = Prefix + "MOVE";
        public const string Disconnect = Prefix + "DISCONNECT";
        public const string SetBomb = Prefix + "SETBOMB";
    }

    public class MsgS : Msg
    {
        public const string SetID = Prefix + "SETID";
        public const string GetNick = Prefix + "GETNICK";
        public const string Join = Prefix + "JOIN";
        public const string MapSetting = Prefix + "MAPSIZE";
        public const string Bomb = Prefix + "BOMB";
    }

    public class MsgC : Msg
    {
        public const string GetID = Prefix + "GETID";
        public const string SetNick = Prefix + "SETNICK";
    }
}