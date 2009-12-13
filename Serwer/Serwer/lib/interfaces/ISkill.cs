using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;

using Serwer.lib.classes;

namespace Serwer.lib.interfaces
{
    public interface ISkill
    {
        StringCollection Commands
        {
            get;
            set;
        }

        void Action(Player Player, string[] cmd);
    }
}
