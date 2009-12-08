using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Client.lib.interfaces;

namespace Client.lib.classes
{
    class Skill
    {
        public static Hashtable List;

        static Skill instance = null;
        static readonly object padlock = new object();

        //To cudo tutaj ładuje nam wszystkie skille z namespacesa w finalnej wersji to serwer
        //ma wysylac jakie skille maja byc zaladowane
        static Skill()
        {
            
            List<Type> skillList = new List<Type>();
            List = new Hashtable();
            Assembly asm = Assembly.GetExecutingAssembly();

            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == "Client.lib.classes.skills")
                {
                    skillList.Add(type);
                }
                
            }
            
            foreach (Type className in skillList)
            {
                ISkill obj = (ISkill)Activator.CreateInstance(className);
                StringCollection cmdList = obj.Commands;

                foreach (string s in cmdList)
                {
                    List.Add(s, obj);
                }
                
            }

        }

        //Nie wiem czy to potrzebne
        Skill()
        {

        }

        public static Skill Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Skill();
                    }
                    return instance;
                }
            }
        }
    }
}
