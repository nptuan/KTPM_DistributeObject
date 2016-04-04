using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributeObject
{
    public class SPTBacNhat : ServerObject
    {
        private float a { get; set; }
        private float b { get; set; }
        public override object GetAttributeValue(string attributeName)
        {
            attributeName = nomanlizeString(attributeName);
            switch (attributeName)
            {
                case "a":
                    return a;
                case "b":
                    return b;
            }
            return null;
        }

        public override string GetClassName()
        {
            return "PTBacNhat";
        }
        
        public override bool SetAttributeValue(string attributeName, object newValue)
        {
            attributeName = nomanlizeString(attributeName);
            switch (attributeName)
            {
                case "a":
                    this.a = (float)newValue;
                    return true;
                case "b":
                    this.b = (float)newValue;
                    return true;
            }
            return false;
        }
        public override string[] Solve()
        {
            string[] result = new string[2];
            if (this.a == 0)
            {
                if (this.b == 0)
                {
                    result[0] = "Vo So Nghiem";
                    result[1] = "";
                }
                else
                {
                    result[0] = "Vo Nghiem";
                    result[1] = "";
                }
            }
            else
            {
                if (this.b == 0)
                {
                    result[0] = "Vo So Nghiem";
                    result[1] = "";
                }
                else
                {
                    result[0] = "Mot Nghiem";
                    result[1] = (-b / a).ToString();
                }
            }
            return result;
        }
    }
}