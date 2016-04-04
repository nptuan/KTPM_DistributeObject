using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributeObject
{
    public class ServerObjectManager
    {
        static private Dictionary<int, ServerObject> obj = new Dictionary<int, ServerObject>();

        internal static bool CanAttachHandle(string className, int handle)
        {
            ServerObject o = FindByHandle(handle);
            if (o == null)
                return false;
            if (o.GetClassName() != className)
                return false;
            return true;
        }

        internal static void DetachHandle(int handle)
        {

        }

        internal static int CreateObject(string className)
        {
            ServerObject newObj = null;
            if (className == "PTBacHai")
            {
                newObj = new SPTBacHai();
            }
            else if (className == "PTBacNhat")
            {
                newObj = new SPTBacNhat();
            }
            if (newObj != null)
                return newObj.Handle;
            return 0;
        }

        private static int _NextHandle = 1;

        public static int GetNextAvailableHandle()
        {
            return _NextHandle++;
        }

        public static void RegisterMe(ServerObject serverObjbect)
        {
            obj.Add(serverObjbect.Handle, serverObjbect);
        }

        public static ServerObject FindByHandle(int handle)
        {
            return obj[handle];
        }

        public static object GetAttributeValue(int handle, string attributeName)
        {
            ServerObject o = FindByHandle(handle);
            if (o == null)
                return null;
            return o.GetAttributeValue(attributeName);
        }

        public static bool SetAttributeValue(int handle, string attributeName,
            object newValue)
        {
            ServerObject o = FindByHandle(handle);
            if (o == null)
                return false;
            return o.SetAttributeValue(attributeName, newValue);
        }

        public static object ExecuteFunction(int handle, string functionName,
            object parameters)
        {
            ServerObject o = FindByHandle(handle);
            if (o == null)
                return false;
            return o.ExecuteFunction(functionName, parameters);
        }
    }
}