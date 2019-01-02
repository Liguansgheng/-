using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7LIB
{
    public abstract class abstractType  //抽象节点
    {
        protected string name;  //类名
        protected string value; //值

        public abstractType(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Version
        {
            get
            {
                return common.version;
            }
        }

        public string Value
        {
            get
            {
                return ToString();
            }

            set
            {
                Parse(value);
            }
        }

        public abstract bool Parse(string text);

        public abstract override string ToString();
    }

    public class primitiveType : abstractType  //叶子节点
    {
        public primitiveType(string name):base(name){}

        public override bool  Parse(string text)
        {
            value = text;
            return true;
        }

        public override string ToString()
        {
            return value;
        }
    }

    public class compositeType:abstractType  //容器节点
    {
        protected abstractType[] data;
        public string delimiter;

        public compositeType(compositeType parent, string name):base(name)
        {
            //根据上层节点的分隔符选择当前节点的分隔符
            if (parent == null)
                delimiter = common.segmentDelimiter;
            else if (parent.delimiter == common.segmentDelimiter)
                delimiter = common.fieldDelimiter;
            else if (parent.delimiter == common.fieldDelimiter)
                delimiter = common.componentDelimiter;
            else if (parent.delimiter == common.componentDelimiter)
                delimiter = common.subComponentDelimiter;
        }

        public override bool Parse(string text)
        {
            string[] subs = text.Split(delimiter[0]);
            for (int i = 0; i < subs.Length; i++)
            {
                if (subs[i] == null || subs[i].Length == 0) continue;
                data[i].Parse(subs[i]); //这里有个问题，消息里的某些段是非必须的，如果给的总串里没有某段，但由于定义时全部定义满了。这样会导致段的值移位
            }
            value = text;
            return true;
        }

        public override string ToString()
        {
            string str = "";
            bool isEmpty = true;
            for (int i = data.Length - 1; i >= 0; i--)
            {
                if (data[i] == null) continue;
                if (isEmpty)
                {
                    str = data[i].ToString();
                    if (str != null && str.Length > 0)
                        isEmpty = false;
                }
                else
                    str = data[i].ToString() + delimiter + str;
            }
            value = str;
            return str;
        }
    }
}
