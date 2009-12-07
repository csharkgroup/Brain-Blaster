namespace Client.etc.Settings
{
    public class Net
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public Net(string Host, int Port)
        {
            this.Host = Host;
            this.Port = Port;
        }
    }
}
