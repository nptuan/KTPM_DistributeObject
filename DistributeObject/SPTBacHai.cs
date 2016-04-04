using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributeObject
{
    public class SPTBacHai : ServerObject
    {
        private float a { get; set; }
        private float b { get; set; }
        private float c { get; set; }


        public float C
        {
            get
            {
                return c;
            }

            set
            {
                c = value;
            }
        }
        public override object GetAttributeValue(string attributeName)
        {
            attributeName = nomanlizeString(attributeName);
            switch (attributeName)
            {
                case "a":
                    return a;
                case "b":
                    return b;
                case "c":
                    return c;
            }
            return null;
        }

        public override string GetClassName()
        {
            return "PTBacHai";
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
                case "c":
                    this.c = (float)newValue;
                    return true;
            }
            return false;
        }
        public override string[] Solve()
        {
            string[] result = new string[2];
            float delta = b * b - 4 * a * c;
            if (a == 0)
            {
                if (b == 0 && c != 0)
                {
                    result[0] = "Vo Nghiem";
                    result[1] = "";
                }
                else
                {
                    result[0] = "Nghiem Kep";
                    result[1] = (-c / b).ToString();
                }
            }
            else
            {
                if (delta < 0)
                {
                    result[0] = "Vo Nghiem";
                    result[1] = "";
                }
                else if (delta == 0)
                {
                    result[0] = "Nghiem Kep";
                    result[1] = (-b / (2 * a)).ToString();
                }
                else
                {
                    result[0] = ((-b - (float)Math.Sqrt(delta)) / (2 * a)).ToString();
                    result[1] = ((-b + (float)Math.Sqrt(delta)) / (2 * a)).ToString();
                }
            }            
            return result;
        }
        
    }
}