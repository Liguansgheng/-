using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DCMLIB
{
    public abstract class DCMAbstractType
    {
        /// <summary>
        /// 组号
        /// </summary>
        public ushort gtag;
        /// <summary>
        /// 元素号
        /// </summary>
        public ushort etag;
        /// <summary>
        /// 数据元素名
        /// </summary>
        public string name;
        /// <summary>
        /// 值表示法
        /// </summary>
        public string vr;
        /// <summary>
        /// 多值
        /// </summary>
        public string vm;
        /// <summary>
        /// 值长度
        /// </summary>
        public uint length;
        /// <summary>
        /// 值
        /// </summary>
        public byte[] value;

        public VR vrparser;

        public abstract string ToString(string head);

        public virtual void WriteValue<T>(T[] val)
        {
            value = vrparser.WriteValue<T>(val);
            length = (uint)value.Length;
        }

        public virtual T[] ReadValue<T>()
        {
            return vrparser.ReadValue<T>(value);
        }

    }

    class DCMDataElement : DCMAbstractType
    {
        public override string ToString(string head)
        {
            string str = head;
            str += gtag.ToString("X4") + "," + etag.ToString("X4") + "\t";
            str += vr + "\t";
            str += name + "\t";
            if (length == 0xffffffff)
                str += "未定义";
            else
                str += length.ToString();
            str += "\t";
            str += vrparser.GetString(value, head);
            return str;
        }
    }

    public class DCMDataSet : DCMAbstractType
    {
        protected List<DCMAbstractType> items;
        protected TransferSyntax syntax;
        public DCMDataSet(TransferSyntax syntax)   //传输语法由构造函数传入
        {
            this.syntax = syntax;
            items = new List<DCMAbstractType>();
        }

        public virtual DCMAbstractType this[uint idx]
        {
            get
            {
                DCMAbstractType item = items.Find(elem => (uint)(elem.gtag << 16) + (elem.etag) == idx); //拉姆达表达式(匿名函数)比较tag与索引idx是否相等，返回索引结果
                return item;
            }
            set
            {
                DCMAbstractType val = (DCMAbstractType)value;
                DCMAbstractType item = items.Find(elem => (uint)(elem.gtag << 16 + (elem.etag)) == idx);
                if (item == null)  //not exists
                    items.Add(val);
                else
                {
                    item.length = val.length;
                    item.value = val.value;
                }
            }
        }

        public override string ToString(string head)
        {
            string str = "";
            foreach (DCMAbstractType item in items)
            {
                if (item != null)
                {
                    if (str != "") str += "\n";  //两个数据元素之间用换行符分割
                    str += item.ToString(head);
                }
            }
            return str;
        }

        public virtual List<DCMAbstractType> Decode(byte[] data, ref uint idx)
        {
            while (idx < data.Length)
            {
                DCMAbstractType item = null;
                item = syntax.Decode(data, ref idx);  //2
                items.Add(item);
            }
            return items;
        }
    }

    public class DCMDataItem : DCMDataSet   //条目
    {
        public DCMDataItem(TransferSyntax syntax) : base(syntax) { }
    }

    public class DCMDataSequence : DCMDataSet  //SQ
    {
        public DCMDataSequence(TransferSyntax syntax) : base(syntax) { }
        public override string ToString(string head)
        {
            string str = "";
            int i = 1;
            foreach (DCMAbstractType item in items)
            {
                str += "\n" + head + "ITEM" + i.ToString() + "\n";
                str += item.ToString(head);
                i++;
            }
            return str;
        }
    }

    public class DCMFileMeta : DCMDataSet
    {
        public DCMFileMeta(TransferSyntax syntax) : base(syntax) { }

        public override List<DCMAbstractType> Decode(byte[] data, ref uint idx)
        {
            while (idx < data.Length)
            {
                DCMAbstractType item = null;
                uint copyidx = idx;
                item = syntax.Decode(data, ref idx);  //2
                if(item.gtag ==0x0002)
                    items.Add(item);
                else
                {
                    idx = copyidx;
                    break;
                }
            }
            return items;
        }
    }

    public class DCMFile : DCMDataSet
    {
        protected string filename;
        protected DCMFileMeta filemeta;
        protected TransferSyntaxes tsFactory;
        public DCMFile(string filename) : base(new ImplicitVRLittleEndian())
        {
            this.filename = filename;
            tsFactory = new TransferSyntaxes();
        }

        public override List<DCMAbstractType> Decode(byte[] data, ref uint idx)
        {
            //读二进制文件
            byte[] Data;
            idx = 0;
            FileStream fs = new FileStream(filename, FileMode.Open,FileAccess.Read);
            BinaryReader binReader = new BinaryReader(fs); 

            Data = new byte[fs.Length];
            binReader.Read(Data, 0, (int)fs.Length);

            binReader.Close();
            fs.Close();

            idx += 128;   //跳过前导符
            string DICM = Encoding.Default.GetString(Data, (int)idx, 4);   //读取4字节“DICM”
            idx += 4;

            filemeta = new DCMFileMeta(new ExplicitVRLittleEndian());  //实例化filemeta对象
            filemeta.Decode(Data, ref idx);

            DCMDataElement HeadElement = (DCMDataElement)filemeta[DicomTags.TransferSyntaxUid];  //查出头元素
            string tranfersyntaxname = HeadElement.vrparser.GetString(HeadElement.value, "").Trim('\0');   //查出uid，即传输方式
            for (int i = 0; i < tsFactory.TSs.Length; i++)      //匹配对应传输语法类
                if (tranfersyntaxname == tsFactory.TSs[i].uid)
                {
                    syntax = tsFactory.TSs[i];
                    break;
                }
            //syntax = tsFactory.TSs[0];
            base.Decode(Data,ref idx);   //调用base.Decode方法解码数据集

            return items;
        }

        public override string ToString(string head)
        {
            //return base.ToString("");
            return filemeta.ToString("") + "\n" + base.ToString("");
        }
    }
}
