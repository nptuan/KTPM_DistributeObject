using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributeObject
{
    public abstract class ServerObject
    {
        private int handle;
        public ServerObject()
        {
            handle = ServerObjectManager.GetNextAvailableHandle();
            ServerObjectManager.RegisterMe(this);
        }

        public int Handle
        {
            get
            {
                return handle;
            }

            set
            {
                handle = value;
            }
        }

        public abstract string GetClassName();
        public virtual object GetAttributeValue(string attributeName)
        {
            return null;
        }

        public virtual bool SetAttributeValue(string attributeName, object newValue)
        {
            return false;
        }

        public abstract string[] Solve();
        public object ExecuteFunction(string functionName, object parameters)
        {
            functionName = nomanlizeString(functionName);
            switch (functionName)
            {
                case "Solve":
                    return Solve();
            }
            return null;
        }
        public string nomanlizeString(string str)
        {
            switch (str)
            {
                case "a":
                case "A":
                    return "a";
                case "b":
                case "B":
                    return "b";
                case "c":
                case "C":
                    return "c";
                case "solve":
                case "Solve":
                case "Giai":
                case "ket qua":
                    return "Solve";
            }
            return null;
        }
    }
}