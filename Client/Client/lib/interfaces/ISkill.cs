using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;

using Client.lib.classes;

namespace Client.lib.interfaces
{
    public interface ISkill
    {
        StringCollection Commands
        {
            get;
            set;
        }

        void Action(Player Player, System.Windows.Forms.Keys k);

        void Action(Player Player, string[] cmd);
    }
}
