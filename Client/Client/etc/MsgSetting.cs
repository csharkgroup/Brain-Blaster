namespace Client.etc
{
    //To jest do wywalenia
    //mam inna lepsza wizje komunikacji
    //Ta i teraz juz nie mam poj�cia jaka on by�a :/
    public abstract class Msg
    {
        public const string Prefix = "###__";

        public const string Move = Prefix + "MOVE";
        public const string Disconnect = Prefix + "DISCONNECT";
    }

    public class MsgS : Msg
    {
        public const string SetID = Prefix + "SETID";
        public const string GetNick = Prefix + "GETNICK";
        public const string Join = Prefix + "JOIN";
    }

    public class MsgC : Msg
    {
        public const string GetID = Prefix + "GETID";
        public const string SetNick = Prefix + "SETNICK";
    }
}