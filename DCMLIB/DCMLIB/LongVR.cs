using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DCMLIB
{
    public abstract class LongVR : VR
    {
        public LongVR(TransferSyntax syntax) : base(syntax) { }
        public override uint GetLength(byte[] data, ref uint idx)
        {
            if (syntax.isExplicit == true)
            {
                idx += 2;
                return GetUInt(data, ref idx);
            }
            else
                return GetUInt(data, ref idx);
        }
    }

    public class OB : LongVR
    {
        public OB(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = "";
            for(int i = 0;i<data.Length;i++)
            {
                if(i == data.Length -1)
                    value += "0x" + data[i].ToString("X2") ;
                else
                    value += "0x" + data[i].ToString("X2") + ",";
            }
            return value;
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class OF : LongVR
    {
        public OF(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = "";
            Single single;
            uint i = 0;
            if (data.Length % 4 == 1)
                return "数组长度出错！";
            while (i < data.Length)
            {
                single = GetSingle(data, ref i);
                if(i == data.Length -4)
                    value += single.ToString();
                else
                    value += single.ToString() + ",";
            }
            return value;
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class OW : LongVR
    {
        public OW(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            //string value = "";
            //ushort Ushort;
            //uint i = 0;
            //if (data.Length % 2 == 1)
            //    return "数组长度出错！";
            //while (i < data.Length)
            //{
            //    Ushort = GetUShort(data, ref i);
            //    if (i == data.Length - 2)
            //        value += Ushort.ToString();
            //    else
            //        value += Ushort.ToString() + ",";
            //}
            //return value;
            return "太多，程序运行太慢，先注释掉！";
        }

        public override T[] ReadValue<T>(byte[] data)
        {
            if (typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
            {
                ushort[] val = new ushort[data.Length / 2];
                uint idx = 0;
                for (int i = 0; i < val.Length; i++)
                {
                    val[i] = GetUShort(data, ref idx);

                }
                return val as T[];
            }
            throw new NotSupportedException();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            if (typeof(T) == typeof(ushort))
            {
                ushort[] vals = val as ushort[];
                byte[] data = new byte[val.Length * 2];
                for (int i = 0; i < val.Length; i++)
                {
                    byte[] ss = BitConverter.GetBytes(vals[i]);
                    if (syntax.isBE) Array.Reverse(ss);
                    data[i * 2] = ss[0];
                    data[i * 2 + 1] = ss[1];
                }
                return data;
            }
            throw new NotSupportedException();
        }

    }

    public class SQ : LongVR
    {
        public SQ(TransferSyntax syntax) : base(syntax) { }
        public override byte[] GetValue(byte[] data, ref uint idx, uint length)
        {
            uint offset = idx;
            uint i = 0;
            DCMDataSequence sq = new DCMDataSequence(syntax);
            while (idx - offset < length)
            {
                DCMAbstractType item = syntax.Decode(data, ref idx);
                if (length == 0xffffffff && item.gtag == 0xfffe && item.etag == 0xe0dd)
                    break;
                else
                    sq[i++] = ((DCMDataItem)item);
            }
            GCHandle handle = GCHandle.Alloc(sq);
            IntPtr ptr = GCHandle.ToIntPtr(handle);
            return BitConverter.GetBytes(ptr.ToInt64());
        }
        public override string GetString(byte[] data, string head)
        {
            IntPtr ptr = new IntPtr(BitConverter.ToInt64(data, 0));
            GCHandle handle = GCHandle.FromIntPtr(ptr);
            DCMDataSequence sq = (DCMDataSequence)handle.Target;
            return sq.ToString(head + ">");
        }

        public override T[] ReadValue<T>(byte[] data)
        {
            if (typeof(T) == typeof(DCMDataSequence))
            {
                IntPtr ptr = new IntPtr(BitConverter.ToInt64(data, 0));
                GCHandle handle = GCHandle.FromIntPtr(ptr);
                DCMDataSequence[] sq = new DCMDataSequence[1];
                sq[0] = (DCMDataSequence)handle.Target;
                return sq as T[];
            }
            else
                throw new NotSupportedException();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            if (typeof(T) == typeof(DCMDataSequence))
            {
                DCMDataSequence[] sq = val as DCMDataSequence[];
                GCHandle handle = GCHandle.Alloc(sq[0]);
                IntPtr ptr = GCHandle.ToIntPtr(handle);
                return BitConverter.GetBytes(ptr.ToInt64());
            }
            else
                throw new NotSupportedException();
        }

    }

    public class UT : LongVR
    {
        public UT(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            return Getstring(data);
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class UN : LongVR
    {
        public UN(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            return Getstring(data);
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }
}
