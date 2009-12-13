using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;

using Client.etc;
using Client.lib.interfaces;

namespace Client.lib.classes.skills
{
    class KeyPress : ISkill
    {
        #region ISkill Members

        public StringCollection Commands
        {
            get;
            set;
        }

        public void Action(Player Player, System.Windows.Forms.Keys k)
        {
            ISkill o;

            switch (k)
            {
                case System.Windows.Forms.Keys.Left:
                case System.Windows.Forms.Keys.Right:
                case System.Windows.Forms.Keys.Up:
                case System.Windows.Forms.Keys.Down:
                    o = (ISkill)Skill.List[MsgS.Move];
                    o.Action(Player, k);
                    break;
                case System.Windows.Forms.Keys.Space:
                    o = (ISkill)Skill.List[MsgS.SetBomb];
                    o.Action(Player, k);
                    break;
            }
            
        }

        public void Action(Player Player, string[] cmd)
        {
            throw new NotImplementedException();
        }

        #endregion

        public KeyPress()
        {
            Commands = new StringCollection();
            Commands.Add("KeyPress");
        }
    }
}
