using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7LIB
{
    public class compositeSegment : compositeType
    {
        public compositeSegment(compositeType parent, string name) : base(parent, name) { }
        public override string ToString()
        {
            string str = base.ToString();
            if (name == "MSH") //MSH段需单独处理                
                str = name + str.Substring(1);
            else
                str = name + delimiter + str;
            return str;
        }
        public override bool Parse(string text)
        {
            string seg = text.Substring(0, 3); //取段名             
            value = text;
            text = text.Substring(4);//去段名
            string[] subs;
            if (seg == "MSH")
            {  //MSH段需单独处理                 
                text = delimiter + text;
                subs = text.Split(delimiter[0]);
                subs[0] = delimiter;
            }
            else
                subs = text.Split(delimiter[0]);
            for (int i = 0; i < subs.Length; i++)
            {
                if (subs[i] == null || subs[i].Length == 0)
                    continue;
                data[i].Parse(subs[i]);
            }
            return true;
        }
    }

    public class compositeMessage : compositeType
    {
        public compositeMessage(compositeType parent, string name) : base(parent, name) { }
    }

    public class compositeField : compositeType
    {
        public compositeField(compositeType parent, string name) : base(parent, name) { }
    }
}
