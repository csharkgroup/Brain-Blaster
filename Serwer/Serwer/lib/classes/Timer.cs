using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

using Serwer.etc;
using Serwer.lib.interfaces;

namespace Serwer.lib.classes
{
    public class TimeObject
    {
        public int Time { get; set; }
        public string[] Cmd { get; set; }
        public Player Player;

        public TimeObject(Player Player, string[] Cmd, int Time)
        {
            this.Cmd = Cmd;
            this.Time = Time;
            this.Player = Player;
        }

    }

    public sealed class Timer
    {
        public static Queue<TimeObject> Queue { get; set; }

        private static Thread _t;
        static Timer instance = null;
        static readonly object padlock = new object();

        static Timer()
        {
            Queue = new Queue<TimeObject>();
            _t = new Thread(new ThreadStart(action));
        }

        Timer()
        {
        }

        public static void Start()
        {
            _t.Start();
        }

        public static Timer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Timer();
                    }
                    return instance;
                }
            }
        }

        private static void action()
        {
            while (true)
            {
                Thread.Sleep(200);
                while (Queue.Count > 0)
                {
                    Thread.Sleep(200);
                    TimeObject t = Queue.Dequeue();
                    if (t.Time-- == 0)
                    {
                        ISkill o = (ISkill)Skill.List[t.Cmd[0]];
                        o.Action(t.Player, t.Cmd);
                    }
                    else
                    {
                        Queue.Enqueue(t);
                    }
                }
            }
        }
    }
}
