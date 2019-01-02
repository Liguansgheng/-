using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCMLIB
{
    public abstract class TransferSyntax
    {
        public bool isBE;
        public bool isExplicit;
        public string uid;
        public string name;
        protected VR vrdecoder;
        private DicomDictionary dictionary;
        protected VRFactory vrfactory;

        public TransferSyntax()
        {
            //初始化数据字典类对象
            dictionary = new DicomDictionary("dicom.dic");
            vrfactory = new VRFactory(this);
            vrdecoder = new UL(this);
        }

        public virtual DCMAbstractType Decode(byte[] data, ref uint idx)
        {
            DCMDataElement element = new DCMDataElement();
            //读取TAG
            element.gtag = vrdecoder.GetUShort(data, ref idx);
            element.etag = vrdecoder.GetUShort(data, ref idx);
            //此处需添加对SQ的三个特殊标记的处理
            if (element.gtag == 0xfffe && element.etag == 0xe000) //条目开始标记
            {
                DCMDataItem sqitem = new DCMDataItem(this);
                uint length = vrdecoder.GetUInt(data, ref idx); //不能用GetLength
                uint offset = idx;
                while (idx - offset < length)
                {
                    DCMAbstractType sqelem = Decode(data, ref idx);  //递归
                    if (length == 0xffffffff && sqelem.gtag == 0xfffe && sqelem.etag == 0xe00d) //条目结束标记
                        break;
                    sqitem[0] = sqelem;
                }
                return sqitem;
            }
            else if (element.gtag == 0xfffe && element.etag == 0xe0dd)  //序列结束标记
            {
                element.vr = "UL";
                element.length = vrdecoder.GetUInt(data, ref idx);  //不能用GetLength
                return element;
            }
            //查数据字典得到VR,Name,VM
            element.vr = vrdecoder.GetVR(data, ref idx);
            DicomDictionaryEntry entry = dictionary.GetEntry(element.gtag, element.etag);
            if (entry != null)
            {
                if (element.vr == "")
                    element.vr = entry.VR;
                if (element.vr == "OB or OW")
                    element.vr = "OW";
                element.name = entry.Keyword;
                element.vm = entry.VM;
            }
            else if (element.vr == "" && element.etag == 0)
                element.vr = "US";
            if (entry.VR == null)   //私有元素，默认ST
            {
                element.name = "private elements";
                element.vr = "ST";
            }
            element.vrparser = vrfactory.GetVR(element.vr);
            //读取值长度
            element.length = element.vrparser.GetLength(data, ref idx);
            element.value = element.vrparser.GetValue(data, ref idx, element.length);
            return element;

        }
    }

    public class ImplicitVRLittleEndian : TransferSyntax  //隐式VR，LE（默认传输语法）
    {
        public ImplicitVRLittleEndian()
        {
            isExplicit = false;
            isBE = false;
            uid = "1.2.840.10008.1.2";
            name = "implicitVRLittleEndian";
        }
    }

     public class ExplicitVRLittleEndian : TransferSyntax   //显式VR，LE
    {
        public ExplicitVRLittleEndian()
        {
            isExplicit =true;
            isBE = false;
            uid = "1.2.840.10008.1.2.1";
            name = "ExplicitVRLittleEndian";
        }
    }

    public class ExplicitVRBigEndian : TransferSyntax   //显示VR，BE
    {
        public ExplicitVRBigEndian()
        {
            isExplicit = true;
            isBE = true;
            uid = "1.2.840.10008.1.2.2";
            name = "ExplicitVRBigEndian";
        }
    }

    public class TransferSyntaxes
    {
        public TransferSyntax[] TSs = new TransferSyntax[3];
        public TransferSyntaxes()
        {
            TSs[0] = new ImplicitVRLittleEndian();
            TSs[1] = new ExplicitVRLittleEndian();
            TSs[2] = new ExplicitVRBigEndian();
        }
    }

}